using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    public class MovieScreening
    {
        public DateTime dateAndTime;
        private double pricePerSeat;

        private Movie movie;
        public MovieScreening(Movie movie, DateTime dateAndTime,double pricePerSeat) {
            this.pricePerSeat = pricePerSeat;
            this.dateAndTime = dateAndTime;
            this.movie = movie;
        }

        public double getPricePerSeat()
        {
            return pricePerSeat;
        }

        public string toString()
        {
            return "Price per seat: " + pricePerSeat.ToString() + " At: " + dateAndTime.ToString() + " for: " + movie.toString();
        }
    }
}
