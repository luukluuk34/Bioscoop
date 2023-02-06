using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                    ticketCounter = 0;
                    Console.WriteLine(totalPrice);
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

            Console.WriteLine(totalPrice);

            if ((!this.isStudentOrder) && dateAndTime.DayOfWeek == DayOfWeek.Friday && tickets.Count >= 6 || (!this.isStudentOrder) && dateAndTime.DayOfWeek == DayOfWeek.Saturday && tickets.Count >= 6 || (!this.isStudentOrder) && dateAndTime.DayOfWeek == DayOfWeek.Sunday && tickets.Count >= 6)
            {
                
                totalPrice -= (totalPrice / 100) * 10;
            }
            return totalPrice;
        }

        public void Export(TicketExportFormat export)
        {
            string fileName = "C:\\Temp\\" +  orderNr.ToString() + ".";
            if (export == TicketExportFormat.PLAINTEXT)
            {
                fileName = fileName + "txt";
            }
            else if(export == TicketExportFormat.JSON)
            {
                fileName = fileName + "json";
            }

            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    foreach (MovieTicket mt in this.tickets)
                    {

                        if(export == TicketExportFormat.PLAINTEXT)
                        {
                            Console.WriteLine("test");
                            sw.WriteLine(mt.ToString());
                        }else if(export == TicketExportFormat.JSON)
                        {
                            string jsonMovie = JsonSerializer.Serialize(mt);
                            sw.WriteLine(jsonMovie);   
                        }

                    }
                }

                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
