using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ExtraModels
{
   public class EventsScheduler
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string  Location { get; set; }
        public string Obs { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public bool isBlock { get; set; }
     

    }
}
