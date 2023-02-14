using BioscoopService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopServiceState
{
    public class DoneState : IOrderState
    {
        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Pay(Order order)
        {
            throw new NotImplementedException();
        }

        public void Submit(Order order)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
