namespace ClassLibrary
{
    public class Airport
    {
        public string City { get; set; }
        public string AirportName { get; set; }
        public string Country { get; set; }
        public string ShortName { get; set; }
        
        public override string ToString()
        {
            return "(" + ShortName + ")" + City +", "+ Country;
        }
    }
}
