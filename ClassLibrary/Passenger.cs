using System;

namespace ClassLibrary
{
    public class Passenger
    {
        private string _passport;

        public int IdClient { get; set; }
        public string PassengerName { get; set; }
        public string LastName { get; set; }
        public string Passport 
        { 
            get { return _passport; } 
            set 
            {
                if (value.Length < 12)
                {
                    
                }
                else
                {
                    _passport = value;
                }
            } 
        }
        public string TaxNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Seat { get; set; }
    }
}
