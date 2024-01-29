namespace software_design_and_architecture_3_colleges
{
    public class Order
    {
        private int _orderNr;
        private bool _isStudentOrder;

        public Order(int orderNr, bool isStrudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStrudentOrder;
        }

        public int getOrderNr()
        {
            return _orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            throw new NotImplementedException();
        }

        public double calculatePrice()
        {
            return 0;
        }

        public void export(TicketExportFormat exportFormat)
        {

        }
    }
}
