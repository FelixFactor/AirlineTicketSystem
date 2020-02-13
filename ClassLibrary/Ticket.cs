namespace ClassLibrary
{
    public class Ticket : Passenger
    {
        public string Seat { get; set; }
        public string SeatClass { get; set; }

        public Ticket(string id, string name, string identification, string email, string gender, string seat, string seatClass)
            :base(id, name, identification, email, gender)
        {
            Seat = seat;
            SeatClass = seatClass;
        }

        public Ticket()
        {
            //rever esta salganhada e alterar o nome de passenger para person e ticket para passenger
        }
    }
}
