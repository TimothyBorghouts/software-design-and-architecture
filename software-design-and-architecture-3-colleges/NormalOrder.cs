using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace software_design_and_architecture_3_colleges
{
    public class NormalOrder : Order
    {
        private int orderNr;
        public NormalOrder(int orderNr) : base(orderNr)
        {
            this.orderNr = orderNr;
        }
    }
}
