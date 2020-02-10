using iText.Forms;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClassLibrary
{
    public static class Utils
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
            string[] splited = local.Trim().Split(' ');
            string city = "";
            for (int i = 0; i < splited.Length; i++)
            {
                splited[i] = TurnUpperCase(splited[i]);
                city += $" {splited[i]}";
            }
            return city.Trim();
            //try
            //{
            //    string loca = TurnUpperCase(splited[0]);
            //    string tion = TurnUpperCase(splited[1]);
            //    return loca + " " + tion;
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    return TurnUpperCase(local);
            //}
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

        public static void FillPDF(Ticket fields, Flight flight)
        {
            string pathTemplate = SaveLoad.PathToTemplates;
            //readying some strings we will need later
            string gatesClose = flight.Date.AddMinutes(-40).ToShortTimeString();
            string destination = flight.Destination.City + $"({flight.Destination.AirportName})";
            string origin = flight.Origin.City + $"({flight.Origin.AirportName})";

            //creates a new directory for the flight
            string pdfDir = SaveLoad.CreateDir(flight.FlightNumber);

            //gets the template from the main dir
            string template = pathTemplate + "\\boardingPass.pdf";

            //creates the file with a new passenger Boarding Pass
            string boardingPass = pdfDir + $"\\{fields.IdPassenger}.pdf";
            SaveLoad.CreateFile(boardingPass);
            
            //opens the template and readies it to be written creating a new PDFDocument
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(template), new PdfWriter(boardingPass));
            //gets the document and prepares the fields to be written
            PdfAcroForm writeFields = PdfAcroForm.GetAcroForm(pdfDoc, true);

            writeFields.GetField("pName").SetValue(fields.PassengerName);
            writeFields.GetField("origin").SetValue(origin);
            writeFields.GetField("destination").SetValue(destination);
            writeFields.GetField("departureTime").SetValue( flight.DepartureHour);
            writeFields.GetField("eta").SetValue( "Unknown");
            writeFields.GetField("flightNumber").SetValue( flight.EntryNumber.ToString());
            writeFields.GetField("date").SetValue( flight.Date.ToLongDateString());
            writeFields.GetField("depTime").SetValue( flight.DepartureHour);
            writeFields.GetField("gatesTime").SetValue( gatesClose);
            writeFields.GetField("seatClass").SetValue(fields.SeatClass);

            pdfDoc.Close();
        }

    }
}
