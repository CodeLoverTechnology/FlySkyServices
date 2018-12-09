using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlySkyServices.Models
{
    public class RunningFlightInfo
    {
        public int FlightTableID { get; set; }
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string FlightDate { get; set; }
        public System.TimeSpan FromTime { get; set; }
        public System.TimeSpan ToTime { get; set; }
        public System.TimeSpan ActualFromTime { get; set; }
        public System.TimeSpan ActualToTime { get; set; }
        public int Departure { get; set; }
        public string DepartureName { get; set; }
        public int Arrival { get; set; }
        public string ArrivalName { get; set; }
        public int FlightStatus { get; set; }
        public string FlightStatusName { get; set; }
        public int DelayStatus { get; set; }
        public string DelayStatusName { get; set; }
        public string DelayedReason { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }

    }
}