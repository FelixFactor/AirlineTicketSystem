using System;

namespace ClassLibrary
{
    public abstract class Passenger
    {
        public  string IdPassenger { get; set; }
        public  string PassengerName { get; set; }
        public  string Identification { get; set; }
        public  string TaxNumber { get; set; }
        public  string Email { get; set; }
        public  string Address { get; set; }
        public  string Gender { get; set; }
        public  string PhoneNumber { get; set; }
        public  DateTime BirthDate { get; set; }

        public Passenger(string id, string name, string identification, string email, string gender)
        {
            IdPassenger = id;
            PassengerName = name;
            Identification = identification;
            Email = email;
            Gender = gender;
        }
        public Passenger()
        {

        }
    }
}
