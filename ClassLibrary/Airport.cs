using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Airport
    {
        private string _city;
        private string _country;

        //public int IdAirport { get; set; }
        public string City { get { return Utils.UpperCase(_city); } set { _city = value; } }
        public string AirportName { get; set; }
        public string Country { get { return Utils.UpperCase(_country); } set { _country = value; } }
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
