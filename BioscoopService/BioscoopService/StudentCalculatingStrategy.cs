using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    class StudentCalculatingStrategy : ICalculatingStrategy
    {
        public double calculatePrice(List<MovieTicket> _tickets)
        {
            double totalPrice = 0;
            int ticketCounter = 0;
            DateTime dateAndTime = DateTime.Now;

            foreach (MovieTicket m in _tickets)
            {
                ticketCounter++;
                if (ticketCounter == 2 || (int)m.screening.dateAndTime.DayOfWeek < 6 && ticketCounter == 2 || (int)m.screening.dateAndTime.DayOfWeek != 0 && ticketCounter == 2)
                {
                    ticketCounter = 0;
                    Console.WriteLine(totalPrice);
                }
                else
                {
                    if (m.isPremiumTicket())
                    {
                        totalPrice += (m.getPrice() + 2);
                    }
                    else
                    {
                        totalPrice += m.getPrice();
                    }
                }
                dateAndTime = m.screening.dateAndTime;
            }

            Console.WriteLine(totalPrice);

            if ((int)dateAndTime.DayOfWeek >= 6 && _tickets.Count >= 6 || ((int)dateAndTime.DayOfWeek == 0 && _tickets.Count >= 6))
            {

                totalPrice -= (totalPrice / 100) * 10;
            }
            return totalPrice;
        }
    }
}
