using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Airport
    {
        //public int IdAirport { get; set; }
        public string City { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public string ShortName { get; set; }
        /// <summary>
        /// overrides the returned string to display what I want properly in the form 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + ShortName + ")" + City +", "+ Country;
        }
    }
}
