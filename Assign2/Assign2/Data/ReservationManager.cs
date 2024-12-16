using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2.Data
{
    class ReservationManager
    {

        /*
         * location of reservation
         */
        //public const string reservation_binary = "res/reservation.txt";
         


        private List<Reservation> reservations;

		/*
         * Make a reservation
         * @param flight to book
         * @param name of the person
         * @param citizenship of person
         * return created reservation
         */
		public Reservation MakeReservation(Flight flight, string name, string citizenship)
		{
			if (flight.Seats <= 0)
			{
				throw new Exception("No seats available on this flight.");
			}

			flight.Seats--;
			var reservation = new Reservation(flight.Code, flight.Airline, name, citizenship, flight.CostPerSeat, flight);
			reservations.Add(reservation);
			return reservation;
		}

		/*
         * finds the reservation by airline or code
         * @param reservation code
         * @param airline
         * @param name of traveler
         * @return the reservation objects
         * 
         */

        public List<Reservation> FindReservations(string reservationCode = null, string name = null)
        {
            // Ensure the reservations list is not null
            if (reservations == null)
            {
                reservations = new List<Reservation>();
            }

            return reservations
                .Where(r => (string.IsNullOrEmpty(reservationCode) || r.ReservationCode.Equals(reservationCode, StringComparison.OrdinalIgnoreCase)) &&
                            (string.IsNullOrEmpty(name) || r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        /*
         * find the reservation by code
         * @param reservatiion code
         * reurn the reservation object
         */
        public Reservation FindReservationByCode(string reservationCode)
		{
			return reservations.FirstOrDefault(r => r.ReservationCode.Equals(reservationCode, StringComparison.OrdinalIgnoreCase));
		}
		public void SaveReservations(string filePath)
		{
			using (var stream = new FileStream(filePath, FileMode.Create))
			using (var writer = new BinaryWriter(stream))
			{
				foreach (var reservation in reservations)
				{
					writer.Write(reservation.ToString());
				}
			}
		}
		/*
         * Load reservations from a binary file
         * @param filePath File path to load the reservations
         */
		public void LoadReservations(string filePath)
		{
			if (!File.Exists(filePath)) return;

			using (var stream = new FileStream(filePath, FileMode.Open))
			using (var reader = new BinaryReader(stream))
			{
				while (stream.Position < stream.Length)
				{
					var data = reader.ReadString();
					// Parse the reservation string back to an object if required
				}
			}
		}
	}
}
