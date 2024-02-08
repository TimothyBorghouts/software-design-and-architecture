namespace software_design_and_architecture_3_colleges
{
    public abstract class Order
    {
        private int _orderNr;
        private List<MovieTicket> _movieTickets;
        private IExport export;

        public Order(int orderNr)
        {
            _orderNr = orderNr;
            _movieTickets = new List<MovieTicket>();
        }

        public int GetOrderNr()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
           _movieTickets.Add(ticket);
        }

        public double CalculateAndCheckPrice()
        {
            if( _movieTickets.Count <= 0)
            {
                throw new InvalidOperationException("No movie tickets available. Cannot calculate total price.");
            }
            return CalculatePrice(_movieTickets);
        }

        public abstract double CalculatePrice(List<MovieTicket> movieTickets);
       
        public void Export(TicketExportFormat exportFormat)
        {
            if (exportFormat == TicketExportFormat.JSON)
            {
                export = new ExportJson();
                export.Export(_movieTickets);
            }
            else if (exportFormat == TicketExportFormat.PLAINTEXT)
            {
                export = new ExportText();
                export.Export(_movieTickets);
            }
        }
    }
}
