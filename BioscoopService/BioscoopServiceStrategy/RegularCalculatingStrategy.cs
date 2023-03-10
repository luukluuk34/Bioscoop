using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    class RegularCalculatingStrategy : ICalculatingStrategy
    {
        private double _totalPrice = 0;
        private int _ticketCounter = 0;
        private DateTime _dateAndTime = DateTime.Now;
        public double calculatePrice(List<MovieTicket> _tickets)
        {
            Console.WriteLine(this._totalPrice);

            this.calculateTickets(_tickets);

            this.checkIfWeekend(_tickets);

            return this._totalPrice;
        }

        private void calculateTickets(List<MovieTicket> _tickets)
        {
            foreach (MovieTicket m in _tickets)
            {
                this._ticketCounter++;

                this.calculateTicket(m);
            }
        }
        private void calculateTicket(MovieTicket m)
        {
            if (this.checkTicket(m))
            {
                this._ticketCounter = 0;
                Console.WriteLine(this._totalPrice);
            }
            else
            {
                if (m.isPremiumTicket())
                {
                    this._totalPrice += (m.getPrice() + 3);
                }
                else
                {
                    this._totalPrice += m.getPrice();
                }
            }

            this._dateAndTime = m.screening.dateAndTime;
        }
        private bool checkTicket(MovieTicket m)
        {
            return (this._ticketCounter == 2 && ((int)m.screening.dateAndTime.DayOfWeek < 6 || (int)m.screening.dateAndTime.DayOfWeek != 0) ) ? true : false;
        }
        private void checkIfWeekend(List<MovieTicket> _tickets)
        {

            if ((int)this._dateAndTime.DayOfWeek >= 6 && _tickets.Count >= 6 || (int)this._dateAndTime.DayOfWeek == 0 && _tickets.Count >= 6)
            {

                this._totalPrice -= (this._totalPrice / 100) * 10;
            }
        }
    }
}
