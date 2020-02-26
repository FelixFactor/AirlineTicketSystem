using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Usefull
    {
        public static List<Flight> Flights = new List<Flight>();
        public static List<Airport> Airports = new List<Airport>();
        public static List<Aircraft> Fleet = new List<Aircraft>();

        /// <summary>
        /// version 2.0 
        /// </summary>
        /// <param name="local"></param>
        /// <returns>upper casing the 1st letter of each string if user doesn't inputed right</returns>
        public static string UpperCase(string local)
        {
            string[] splited = local.Trim().ToLower().Split(' ');
            string city = "";
            for (int i = 0; i < splited.Length; i++)
            {
                splited[i] = TurnUpperCase(splited[i]);
                city += $" {splited[i]}";
            }
            return city.Trim();
        }
        static private string TurnUpperCase(string local)
        {
            char[] splat = local.ToCharArray();
            try
            {
                splat[0] = char.ToUpper(splat[0]);
            }
            catch (IndexOutOfRangeException)
            {
                string unknown = "Unknown";
                TurnUpperCase(unknown);
            }
            return new string(splat);
        }
    }
}
