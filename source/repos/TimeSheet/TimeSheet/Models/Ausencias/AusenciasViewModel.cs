using DataAccess.ExtraModels;
using System.Collections.Generic;

namespace TimeSheet.Models.Ausencias
{
    public class AusenciasViewModel
    {

        public List<EventsScheduler> ListEvents { get; set; }
        public double TotalDias { get; set; }
        public double TotalDiasGozados { get; set; }
        public double TotalDiasPorGozar { get; set; }

    }
}
