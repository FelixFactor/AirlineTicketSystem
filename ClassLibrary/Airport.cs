namespace ClassLibrary
{
    public class Airport
    {
        public int InternId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AirportID { get; set; }
        public string Name { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
        public string TimezoneHour { get; set; }
        public string DST { get; set; }
        public string TimeZone { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public Airport(int id,string cityName, string countryName, string shortName, string name)
        {
            InternId = id;
            City = cityName;
            Country = countryName;
            IATA= shortName;
            Name = name;
        }
        public Airport()
        {

        }

        public override string ToString()
        {
            return "(" + IATA + ")" + City +", "+ Country;
        }
    }
}
