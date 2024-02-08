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

        public override double CalculatePrice(List<MovieTicket> movieTickets)
        {
            double totalPrice = 0;
            for (int i = 0; i < movieTickets.Count; i++)
            {
                if (movieTickets[i].IsMidWeek() && i % 2 != 0)
                {

                } else
                {
                    totalPrice += movieTickets[i].GetPrice();
                    totalPrice += GetPremium(movieTickets[i].IsPremium());
                }
            }

            totalPrice -= CalculateGroupDiscount(movieTickets.Count(), totalPrice);
            return totalPrice;
        }

        public double GetPremium(bool isPremium)
        {
            if (isPremium)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        // Als de bestelling van een niet-student bestaat uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.
        public double CalculateGroupDiscount(int amountOfTickets, double costs)
        {
            if (amountOfTickets >= 6)
            {
                return costs *= 0.1;
            }
            return 0;
        }
    }
}
