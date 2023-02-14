using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    public class MovieTicket
    {
        private int rowNr;
        private int seatNr;
        private bool isPremium;

        public MovieScreening screening;

        public MovieTicket(MovieScreening movieScreening,bool isPremiumReservation, int seatRow, int seatNr)
        {
            this.isPremium = isPremiumReservation;
            this.rowNr = seatRow;
            this.seatNr = seatNr;
            this.screening = movieScreening;
        }

        public bool isPremiumTicket()
        {
            return isPremium;
        }

        public double getPrice()
        {
            return screening.getPricePerSeat();
        }

        public string toString()
        {
            return "Premimum ticket: " + isPremium.ToString() + " RowNr: " + rowNr.ToString() + " SeatNr: " + seatNr.ToString(); 
        }



    }
}
