namespace software_design_and_architecture_3_colleges
{
    public class StudentOrder : Order
    {
        private int orderNr;
        public StudentOrder(int orderNr) : base(orderNr)
        {
            this.orderNr = orderNr;
        }


    }
}
