using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2.Data
{
    internal class Reservation
    {
        private string code;
        private string airline;
        private string name;
        private string citizenship;
        private double cost;
        private string reservationCode;
        private Flight flight;
        public bool IsActive { get; set; }

        /*
         * constructor for the reservation
         */
        public Reservation(string code, string airline, string name, string citizenship, double cost, Flight flight)
		{
			this.code = code;
			this.airline = airline;
			this.name = name;
			this.citizenship = citizenship;
			this.cost = cost;
			this.flight = flight;
			this.reservationCode = GenerateReservationCode();
            IsActive = true;
        }
		private string GenerateReservationCode()
		{
			Random random = new Random();
			return $"R{random.Next(1000, 9999)}";
		}

		/*
         * getter and setters
         */
		public string Code { get => code; set => code = value; }
		public string Airline { get => airline; set => airline = value; }
		public string Name { get => name; set => name = value; }
		public string Citizenship { get => citizenship; set => citizenship = value; }
		public double Cost { get => cost; set => cost = value; }
		public string ReservationCode { get => reservationCode; }
		public Flight Flight { get => flight; set => flight = value; }

		/*
         * Return a string representation of the reservation
         */
		public override string ToString()
		{
			return $"Reservation Code: {reservationCode}\nName: {name}\nCitizenship: {citizenship}\nFlight: {flight.Code} - {flight.Airline}\nCost: ${cost}\n";
		}

		/*
         * Check equality based on reservation code
         */
		public override bool Equals(object obj)
		{
			return obj is Reservation reservation && reservationCode == reservation.reservationCode;
		}

		public override int GetHashCode()
		{
			return reservationCode.GetHashCode();
		}

	}
}
