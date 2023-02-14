using BioscoopService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopServiceState
{
    public interface IOrderState
    {

        //public void Create(Order order);
        public void Submit(Order order);

        public void Update(Order order);

        public void Pay(Order order);

        public void Cancel(Order order);

    }
}
