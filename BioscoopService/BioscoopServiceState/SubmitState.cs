using BioscoopService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopServiceState
{
    public class SubmitState : IOrderState
    {
        public void Cancel(Order order)
        {
            Console.WriteLine("Cancelling Order");
            order.orderState = new CancelState();
        }

        public void Pay(Order order)
        {
            Console.WriteLine("Doing payment process");
            order.orderState = new DoneState();
        }

        public void Submit(Order order)
        {
            throw new InvalidOperationException();
        }

        public void Update(Order order)
        {
            Console.WriteLine("Saving tickets but ready to Update order");
            order.orderState = new UpdateState();
        }
    }
}
