namespace ClassLibrary
{
    public class Passenger : Person
    {
        public string Seat { get; set; }
        public string SeatClass { get; set; }

        public Passenger(string id, string name, string identification, string email, string gender, string seat, string seatClass)
            :base(id, name, identification, email, gender)
        {
            Seat = seat;
            SeatClass = seatClass;
        }

        public Passenger()
        {
            
        }
    }
}
