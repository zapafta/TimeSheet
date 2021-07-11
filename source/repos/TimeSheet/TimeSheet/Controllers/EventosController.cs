using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Models;
using TimeSheet.Models;
using DataAccess.Repository;
using DataAccess.Enum;
using DataAccess.ExtraModels;
using Microsoft.AspNetCore.Authorization;

namespace TimeSheet.Controllers
{

    [Authorize]
    public class EventosController : Controller
    {
        public ClienteRepository ClientesRepository;
        public ColaboradorRepository ColaboradorRepository;
        public LocalizacaoRepository LocalizacaoRepository;
        public EventoRepository EventoRepository;
        public TipoServicoRepository TipoServicoRepository;


        public EventosController(ClienteRepository _ClienteRepository, ColaboradorRepository _ColaboradorRepository, LocalizacaoRepository _LocalizacaoRepository,
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


    }
}
