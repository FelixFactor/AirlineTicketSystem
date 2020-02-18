using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Flight
    {
        private DateTime _estimatedTimeArrival;


        public int EntryNumber { get; set; }
        public string FlightNumber { get { return makeId(); } }
        public Airport Origin { get; set; }
        public Airport Destination { get; set; }
        public Aircraft Plane { get; set; }
        public DateTime Date { get; set; }
        public string DepartureHour 
        { 
            get {return Date.ToShortTimeString(); } 
        }
        public string DepartureDate { get { return Date.ToShortDateString(); } }
        public DateTime EstimatedTimeArrival 
        { 
            get { return _estimatedTimeArrival; } 
            set {_estimatedTimeArrival = Date.AddHours(FlightDuration()); } 
        }
        public List<string> TakenSeats { get; set; }
        public List<Passenger> Tickets { get; set; }


        private string makeId()
        {
            return $"Flight#{EntryNumber}";
        }
        private double FlightDuration()
        {
            return 4;//TODO check flight duration
        }
    }
}
