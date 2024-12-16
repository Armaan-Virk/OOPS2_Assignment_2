using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign2.Data
{
    class FlightsService
    {
		private readonly FlightManager flightManager;

		public FlightsService(FlightManager flightManager)
		{
			this.flightManager = flightManager;
		}
		/*
         * get the list of flights
         */
		public List<Flight> GetAllFlights()
		{
			return flightManager.GetFlights();
		}
	

	/*
	 * Find flights between specific airports on a given weekday.
	 * @param from Origin airport code.
	 * @param to Destination airport code.
	 * @param weekday Day of the week.
	 * @return list of matching flights.
	 */
	public List<Flight> GetFlightsByRouteAndDay(string from, string to, string weekday)
	{
		return flightManager.FindFlights(from, to, weekday);
	}

	/*
	 * Find a flight by its unique code.
	 * @param code Flight code.
	 * @return Flight object if found, null otherwise.
	 */
	public Flight GetFlightByCode(string code)
	{
		return flightManager.FindFlightByCode(code);
	}

	/*
	 * Check if an airport exists by code.
	 * @param code Airport code.
	 * @return true if the airport exists, false otherwise.
	 */
	public bool IsAirportValid(string code)
	{
		return flightManager.FindAirport(code) != null;
	}
}
}
