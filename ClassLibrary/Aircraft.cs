using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Aircraft
    {
        private int _firstClass;
        private int _secondClass;

        public int AircraftID { get; set; }
        public string InternalID { get { return MakeID(); } }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        public int FirstClass
        {
            get { return _firstClass; }
            set
            {
                if (value >= 0 && value <= (TotalSeats*0.5))
                {
                    _firstClass = value;
                }
                else
                {
                    throw new Exception("Total Capacity exceeded on Executive");
                }
            } 
        }
        public int SecondClass
        {
            get { return _secondClass; }
            set
            {
                if (value >= 0 && value <= TotalSeats - FirstClass)
                {
                    _secondClass = value;
                }
                else
                {
                    throw new Exception("Total Capacity exceeded on Economy");
                }
            } 
        }
        public List<string> ExecSeats { get { return GenerateSeatsExecutive(); }  }
        public List<string> EconSeats { get { return GenerateSeatsEconomy(); }  }
        

        private string MakeID()
        {
            return Manufacturer[0].ToString().ToUpper() + Manufacturer[1].ToString().ToUpper() + "0" + "0" + AircraftID;
        }
        public override string ToString()
        {
            return InternalID + "-" + Manufacturer + " " + Model;
        }
        private List<string> GenerateSeatsEconomy()
        {
            char[] letterSeat = { 'A', 'B', 'C', 'D', 'E', 'F' };
            int row = (SecondClass / letterSeat.Length) + 10;
            List<string> Seats = new List<string>();
            string seatN;
            foreach (char item in letterSeat)
            {
                for (int i = 10; i <= row; i++)
                {
                    seatN = $"{item}{i}";
                    Seats.Add(seatN);
                }
            }
            return Seats;
        }
        private List<string> GenerateSeatsExecutive()
        {
            char[] letterSeat = { 'A', 'B', 'E', 'F' };
            int row = FirstClass / letterSeat.Length;
            List<string> Seats = new List<string>();
            string seatN;
            foreach (char item in letterSeat)
            {
                for (int i = 1; i <= row; i++)
                {
                    seatN = $"{item}{i}";
                    Seats.Add(seatN);
                }
            }
            return Seats;
        }
    }
}
