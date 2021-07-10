using DataAccess.ExtraModels;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class EventoModelView
    {

        public List<SampleObject> Colaboradores { get; set; }

        public List<SampleObject> Clientes { get; set; }

        public List<SampleObject> Localizacoes { get; set; }

        public List<SampleObject> TiposDeServico { get; set; }

        public List<SampleObject> ListStatus { get; set; }
    }



}
