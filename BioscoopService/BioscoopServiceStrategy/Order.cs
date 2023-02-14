using System;
using System.Collections.Generic;
using System.IO;
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
        private int _orderNr;
        private bool _isStudentOrder;
        private ICalculatingStrategy _calculatingStrategy;
        private List<MovieTicket> _tickets = new List<MovieTicket>();

        public Order(int orderNr, ICalculatingStrategy calculatingStrategy)
        {
            this._orderNr = orderNr;
            this._calculatingStrategy = calculatingStrategy;
        }

        public int getOrderNr()
        {
            return _orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            _tickets.Add(ticket);
        }

        public double calculatePrice()
        {
            return this._calculatingStrategy.calculatePrice(_tickets);
        }

        public void Export(TicketExportFormat export)
        {
            string fileName = "C:\\Temp\\" +  _orderNr.ToString() + ".";
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
                    foreach (MovieTicket mt in this._tickets)
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
