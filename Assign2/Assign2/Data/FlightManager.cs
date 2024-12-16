using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2.Data
{
    internal class FlightManager
    {
        public const string any = "Any";
        public const string Sunday = "Sunday";




        /**
        * The location of the flights text database file.
        */
        public const string FLIGHTS_TEXT = @"C:\Users\Virka\OneDrive\Desktop\New folder\Assignment 2\Assign2\Assign2\NewFolder\flights.csv";
        /**
         * The location of the airports text database file.
         */
        public const string AIRPORTS_TEXT = @"C:\Users\Virka\OneDrive\Desktop\New folder\Assignment 2\Assign2\Assign2\NewFolder\airports.csv";



        public static List<Flight> flights = new List<Flight>();
        public static List<string> airports = new List<string>();

        public FlightManager() 
        { 
            this.populateAirports();
            this.PopulateFlights();
        
        }
        /*
         * get all of the airports
         * @return the arraylist of airports
         */

        public List<string> getAirtports()
        { 
            return new List<string>(airports);
        }

		/*
         * get all of the flights
         * @return arraylist of flights
         */

		public List<Flight> GetFlights()
		{
			return new List<Flight>(flights);
		}

		/*
         * find airport with code
         * @param code airport code
         * @return airport object
         */
		public string FindAirport(string code)
		{
			return airports.Find(airport => airport.Equals(code, StringComparison.OrdinalIgnoreCase));
		}


		/*
         * find the flight with flight code
         * @param code Flight code
         * @return Flight object 
         */
		public Flight FindFlightByCode(string code)
		{
			return flights.Find(flight => flight.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
		}
		/*
         * find flight between the airports on specific day
         * @param from airport code
         * @param to airport code
         * @param Weekday of the week
         * @return flight found
         */
		public List<Flight> FindFlights(string from, string to, string weekday)
		{
			return flights.FindAll(f => f.From.Equals(from, StringComparison.OrdinalIgnoreCase) &&
										 f.To.Equals(to, StringComparison.OrdinalIgnoreCase) &&
										 f.Weekday.Equals(weekday, StringComparison.OrdinalIgnoreCase));
		}

		/*
         * populate the flight arraylist from csv file
         */
		private void PopulateFlights()
		{
			foreach (string line in File.ReadLines(FLIGHTS_TEXT))
			{
				string[] parts = line.Split(',');
				flights.Add(new Flight(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], int.Parse(parts[6]), double.Parse(parts[7])));
			}
		}

		/*
         * populate airports from csv file
         */
		private void PopulateAirports()
		{
			foreach (string line in File.ReadLines(AIRPORTS_TEXT))
			{
				string[] parts = line.Split(',');
				airports.Add(parts[0]);
			}
		}

		private void populateAirports()
        {
            try
            {
                foreach(string line in System.IO.File.ReadLines(AIRPORTS_TEXT))
                {
                    string[] parts = line.Split(',');
                    string code = parts[0];
                    string name = parts[1];
                    airports.Add(code);
                }

            }
            catch (Exception e)
            {

            }
            
        }



    }
}
