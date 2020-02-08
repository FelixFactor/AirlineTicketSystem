using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ClassLibrary
{
    public static class SaveLoad
    {
        public static string PathToData { get { return $@"{Directory.GetCurrentDirectory()}\Data"; } }
        public static void CheckForFiles(List<Airport> locations, List<Aircraft> fleet, List<Flight> flights)
        {
            if (!Directory.Exists(PathToData))
            {
                Directory.CreateDirectory(PathToData);
                SaveAirports(locations);
                SaveFleet(fleet);
                SaveFlights(flights);
            }
        }
        public static void SaveAirports(List<Airport> objects)
        {
            var file = Directory.CreateDirectory(PathToData);
            XmlSerializer serial = new XmlSerializer (typeof(List<Airport>));
            TextWriter stream = new StreamWriter($@"{file}\airports.xml");
            serial.Serialize(stream, objects);
            stream.Close();
        }
        public static List<Airport> LoadAirports()
        {
            var file = Directory.CreateDirectory(PathToData);
            XmlSerializer serial = new XmlSerializer(typeof(List<Airport>));
            StreamReader stream = new StreamReader($@"{file}\airports.xml");
            List<Airport> loaded = (List<Airport>)serial.Deserialize(stream);
            stream.Close();
            return loaded;
        }
        public static void SaveFleet(List<Aircraft> objects)
        {
            var file = Directory.CreateDirectory(PathToData);
            XmlSerializer serial = new XmlSerializer(typeof(List<Aircraft>));
            TextWriter stream = new StreamWriter($@"{file}\aircrafts.xml");
            serial.Serialize(stream, objects);
            stream.Close();
        }
        public static List<Aircraft> LoadFleet()
        {
            var file = Directory.CreateDirectory(PathToData);
            XmlSerializer serial = new XmlSerializer(typeof(List<Aircraft>));
            StreamReader stream = new StreamReader($@"{ file}\aircrafts.xml");
            List<Aircraft> loaded = (List<Aircraft>)(serial.Deserialize(stream));
            stream.Close();
            return loaded;
        }
        public static void SaveFlights(List<Flight> objects)
        {
            var file = Directory.CreateDirectory(PathToData);
            XmlSerializer serial = new XmlSerializer(typeof(List<Flight>));
            TextWriter stream = new StreamWriter($@"{file}\flights.xml");
            serial.Serialize(stream, objects);
            stream.Close();
        }
        public static List<Flight> LoadFlights()
        {
            var file = Directory.CreateDirectory(PathToData);
            XmlSerializer serial = new XmlSerializer(typeof(List<Flight>));
            StreamReader stream = new StreamReader($@"{ file}\flights.xml");
            List<Flight> loaded = (List<Flight>)(serial.Deserialize(stream));
            stream.Close();
            return loaded;
        }
    }
}
