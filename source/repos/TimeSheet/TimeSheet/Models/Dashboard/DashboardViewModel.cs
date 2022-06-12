using System;

namespace TimeSheet.Models.Dashboard
{
    public class DashboardViewModel
    {
        public string MessageOfDay { get; set; }
        public DateTime NextAbsence { get; set; }
        public int DaysToEndOfYear { get; set; }

    }
}
