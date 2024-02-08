namespace software_design_and_architecture_3_colleges
{
    public class StudentOrder : Order
    {
        private int orderNr;
        public StudentOrder(int orderNr) : base(orderNr)
        {
            this.orderNr = orderNr;
        }

        public override double CalculatePrice(List<MovieTicket> movieTickets)
        {
            double totalPrice = 0;
            for (int i = 0; i < movieTickets.Count(); i++)
            {
                if (i % 2 != 0)
                {

                }
                else
                {
                    totalPrice += movieTickets[i].GetPrice();
                    totalPrice += GetPremium(movieTickets[i].IsPremium());
                }
            }
            return totalPrice;
        }

        public double GetPremium(bool isPremium)
        {
            if (isPremium)
            {
                return 2;
            } else
            {
                return 0;
            }
        }
    }
}
