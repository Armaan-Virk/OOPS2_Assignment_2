using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Icu.Util.Calendar;
//using static Java.Text.Normalizer;

namespace Assign2.Data
{
    class Flight
    {
        private string code;
        private string airline;
        private string from;
        private string to;
        private string weekday;
        private string time;
        private int seats;
        private double costPerSeat;

		/*
         * flight constructor with flight code
         */
		public Flight(string code)
		{
			this.code = code;
		}

		/*
         * flight constructor with all data members
         */
		public Flight(string code, string airline, string from, string to, string weekday, string time, int seats, double costPerSeat)
		{
			this.code = code;
			this.airline = airline;
			this.from = from;
			this.to = to;
			this.weekday = weekday;
			this.time = time;
			this.seats = seats;
			this.costPerSeat = costPerSeat;
		}
		/*
         * getter setter of all menmbers
         */
		public string Code { get => code; set => code = value; }
        public string Airline { get => airline; set => airline = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Weekday { get => weekday; set => weekday = value; }
        public string Time { get => time; set => time = value; }
        public int Seats { get => seats; set => seats = value; }
        public double CostPerSeat { get => costPerSeat; set => costPerSeat = value; }

		/*
        
        public string toString()
        {
           // return this.Code;
        }

        */
		public override string ToString()
		{
			return $"{code}: {airline} from {from} to {to} on {weekday} at {time}, ${costPerSeat} per seat, {seats} seats available.";
		}

		public override bool Equals(object obj)
        {
            return obj is Flight flight &&
                   code == flight.code &&
                   airline == flight.airline &&
                   from == flight.from &&
                   to == flight.to &&
                   weekday == flight.weekday &&
                   time == flight.time &&
                   seats == flight.seats &&
                   costPerSeat == flight.costPerSeat &&
                    Code == flight.Code &&
                   Airline == flight.Airline &&
                    From == flight.From &&
                   To == flight.To &&
                   Weekday == flight.Weekday &&
                   Time == flight.Time &&
                   Seats == flight.Seats &&
                   CostPerSeat == flight.CostPerSeat;
        }

    }
}
