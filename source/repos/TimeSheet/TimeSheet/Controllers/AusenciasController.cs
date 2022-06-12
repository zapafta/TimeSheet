using DataAccess.Enum;
using DataAccess.ExtraModels;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

        public AnswerClientServer SaveEvent(Evento Evento)
        {

            try
            {
                TimeSpan StartTime = Evento.StartDate.TimeOfDay;
                TimeSpan EndTime = Evento.EndDate.TimeOfDay;
                DateTime date = DateTime.Parse(Evento.Date);

                Evento.StartDate = date.Date.Add(StartTime);
                Evento.EndDate = date.Date.Add(EndTime);
                Evento.IdCliente = Guid.Parse("21b713a5-ff72-4785-9421-96ac488c7c66");
                Evento.IdLocalizacao = Guid.Parse("e817b372-63a6-48ac-a856-cc0d3fef368d");
                Evento.IdTipoServico = Guid.Parse("4c1c5496-39b3-47af-919a-34a48b4d97f0");
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
