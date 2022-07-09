using DataAccess.Enum;
using DataAccess.ExtraModels;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.Models;

namespace TimeSheet.Controllers
{
    [Authorize]
    public class AusenciasController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ClienteRepository ClientesRepository;
        public ColaboradorRepository ColaboradorRepository;
        public LocalizacaoRepository LocalizacaoRepository;
        public EventoRepository EventoRepository;
        public TipoServicoRepository TipoServicoRepository;

        public AusenciasController(ClienteRepository _ClienteRepository, ColaboradorRepository _ColaboradorRepository, LocalizacaoRepository _LocalizacaoRepository,
        EventoRepository _EventoRepository, TipoServicoRepository _TipoServicoRepository)
        {
            ClientesRepository = _ClienteRepository;
            ColaboradorRepository = _ColaboradorRepository;
            LocalizacaoRepository = _LocalizacaoRepository;
            EventoRepository = _EventoRepository;
            TipoServicoRepository = _TipoServicoRepository;
        }
        public IActionResult Index()
        {

            EventoModelView eventoModelView = new EventoModelView
            {
                ListEvents = EventoRepository.GetAllEventsByUserLogad(Guid.Empty),
                Clientes = ClientesRepository.GetAllClienteSampleObject(),
                Colaboradores = ColaboradorRepository.GetAllColaboradoresSampleObject(),
                Localizacoes = LocalizacaoRepository.GetAllLocalizacao(),
                TiposDeServico = TipoServicoRepository.GetAllTipoServicoToObjectSample(),
                ListStatus = Enum.GetValues(typeof(EnumStatus)).Cast<EnumStatus>()
            .Select(r => new SampleObject { IdInt = (int)r, Description = r.ToString() })
            .ToList()
            };

            return View(eventoModelView);
        }


        public ActionResult LoadData()  // Here we get the Start and End Date and based on that can filter the data and return to Scheduler
        {
            var data = EventoRepository.GetAllEventsByUserLogad(Guid.Empty);

            return Json(data);
        }

        [HttpPost]
        public ActionResult UpdateData([FromBody] EditParams param)
        {
            if (param.action == "insert" || (param.action == "batch" && param.added != null)) // this block of code will execute while inserting the appointments
            {
                var value = (param.action == "insert") ? param.value : param.added[0];
                DateTime startTime = Convert.ToDateTime(value.StartTime);
                DateTime endTime = Convert.ToDateTime(value.EndTime);
                Evento appointment = new Evento()
                {
                    Id = Guid.NewGuid()
                };
                EventoRepository.SaveEvento(appointment);
            }
            if (param.action == "update" || (param.action == "batch" && param.changed != null)) // this block of code will execute while updating the appointment
            {
               
            }
            if (param.action == "remove" || (param.action == "batch" && param.deleted != null)) // this block of code will execute while removing the appointment
            {
              
            }
            var data = EventoRepository.GetAllEventsByUserLogad(Guid.Empty);
            return Json(data);
        }


        public class EditParams
        {
            public string key { get; set; }
            public string action { get; set; }
            public List<EventsScheduler> added { get; set; }
            public List<EventsScheduler> changed { get; set; }
            public List<EventsScheduler> deleted { get; set; }
            public EventsScheduler value { get; set; }
        }

        public AnswerClientServer SaveEvent(Evento Evento)
        {

            try
            {
                TimeSpan StartTime = Evento.StartDate.TimeOfDay;
                TimeSpan EndTime = Evento.EndDate.TimeOfDay;
                DateTime date = DateTime.Parse(Evento.Date);
                Evento.EventType = EnumEventType.Férias;
                Evento.StartDate = date.Date.Add(StartTime);
                Evento.EndDate = date.Date.Add(EndTime);
                Evento.IdLocalizacao = Guid.Parse("e817b372-63a6-48ac-a856-cc0d3fef368d");
                EventoRepository.SaveEvento(Evento);
                return AnswerClientServer.GetSuccessAnswerWithMessage("Sucesso");
            }
            catch (Exception ex)
            {
                return AnswerClientServer.GetErrorAnswer(ex.Message);

            }

        }
    }
}
