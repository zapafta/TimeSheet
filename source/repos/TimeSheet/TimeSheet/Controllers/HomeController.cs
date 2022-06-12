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
using TimeSheet.Models.Dashboard;

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
            var FullName = this.User.Identity.Name.ToString().Split(' ');
            string FirstName = FullName[0];
            
            DashboardViewModel dashboard = new DashboardViewModel
            {



              MessageOfDay =ColaboradorRepository.GetFraseOfDay(),
              DaysToEndOfYear=500,
              NextAbsence=DateTime.Now.Date,

            };

            return View(dashboard);
        }


   


    }
}
