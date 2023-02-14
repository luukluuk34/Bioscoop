using BioscoopService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopServiceState
{
    public class CreatedState : IOrderState
    {

        public void Submit(Order order)
        {
            Console.WriteLine("Submitting order ready to be paid");
            order.orderState = new SubmitState();
        }

        public void Pay(Order order)
        {
            throw new InvalidOperationException();
        }

        public void Update(Order order)
        {
            throw new InvalidOperationException();
        }

        public void Cancel(Order order)
        {
            throw new InvalidOperationException();
        }
    }
}
