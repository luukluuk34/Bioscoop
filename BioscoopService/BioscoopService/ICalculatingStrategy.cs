using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopService
{
    public interface ICalculatingStrategy
    {
        public double calculatePrice(List<MovieTicket> _tickets);
    }
}
