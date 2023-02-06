using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    public class Order
    {
        private int orderNr;
        private bool isStudentOrder;
        private List<MovieTicket> tickets = new List<MovieTicket>();

        public Order(int orderNr, bool isStudentOrder)
        {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
        }

        public int getOrderNr()
        {
            return orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            tickets.Add(ticket);
        }

        public double calculatePrice()
        {
            double totalPrice = 0;
            int ticketCounter = 0;
            DateTime dateAndTime = DateTime.Now;

            foreach (MovieTicket m in this.tickets)
            {
                ticketCounter++;
                if (this.isStudentOrder && ticketCounter == 2 || m.screening.dateAndTime.DayOfWeek == DayOfWeek.Monday && ticketCounter == 2 || m.screening.dateAndTime.DayOfWeek == DayOfWeek.Tuesday && ticketCounter == 2 || m.screening.dateAndTime.DayOfWeek == DayOfWeek.Wednesday && ticketCounter == 2 || m.screening.dateAndTime.DayOfWeek == DayOfWeek.Thursday && ticketCounter == 2)
                {
                    ticketCounter= 0;
                }
                else
                {
                    if (this.isStudentOrder && m.isPremiumTicket())
                    {
                        totalPrice += (m.getPrice() + 2);
                    }
                    else if (m.isPremiumTicket())
                    {
                        totalPrice += (m.getPrice() + 3);
                    }
                    else
                    {
                        totalPrice += m.getPrice();
                    }   
                }
                dateAndTime = m.screening.dateAndTime;
            }

            if ((!this.isStudentOrder) && dateAndTime.DayOfWeek == DayOfWeek.Friday || (!this.isStudentOrder) && dateAndTime.DayOfWeek == DayOfWeek.Saturday || (!this.isStudentOrder) && dateAndTime.DayOfWeek == DayOfWeek.Sunday)
            {
                totalPrice -= (totalPrice / 100) * 10; 
            }
            return totalPrice;
        }

        public void Export(TicketExportFormat export)
        {
            string fileName = orderNr.ToString();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream fs = File.Create(fileName))
            {

            }


        }





    }
}
