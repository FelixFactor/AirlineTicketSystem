using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public Airport Origin { get; set; }
        public Airport Destination { get; set; }
        public Aircraft Plane { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get { return Date.ToShortTimeString(); } }
        public string AData { get { return Date.ToShortDateString(); } }
        public List<string> TakenSeats { get; set; }
    }
}
