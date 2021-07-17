using DataAccess.Enum;
using DataAccess.ExtraModels;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ClienteRepository ClientesRepository;
        public ColaboradorRepository ColaboradorRepository;
        public LocalizacaoRepository LocalizacaoRepository;
        public EventoRepository EventoRepository;
        public TipoServicoRepository TipoServicoRepository;

        public HomeController(ClienteRepository _ClienteRepository, ColaboradorRepository _ColaboradorRepository, LocalizacaoRepository _LocalizacaoRepository,
         EventoRepository _EventoRepository, TipoServicoRepository _TipoServicoRepository)
        {
            ClientesRepository = _ClienteRepository;
            ColaboradorRepository = _ColaboradorRepository;
            LocalizacaoRepository = _LocalizacaoRepository;
            EventoRepository = _EventoRepository;
            TipoServicoRepository = _TipoServicoRepository;
        }

        public ActionResult Index()
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


        public AnswerClientServer SaveEvent(Evento Evento)
        {

            try
            {
                TimeSpan StartTime = Evento.StartDate.TimeOfDay;
                TimeSpan EndTime = Evento.EndDate.TimeOfDay;
                DateTime date = DateTime.Parse(Evento.Date);

                Evento.StartDate = date.Date.Add(StartTime);
                Evento.EndDate = date.Date.Add(EndTime);
                
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
