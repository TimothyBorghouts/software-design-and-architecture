using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace software_design_and_architecture_3_colleges
{
    public class Order
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

        public double CalculatePrice()
        {
            if(_movieTickets.Count <= 0)
            {
                throw new InvalidOperationException("No movie tickets available. Cannot calculate total price.");
            }

            double totalPrice = 0;

            for (int i = 0; i < _movieTickets.Count; i++)
            {
                if ((i % 2 != 0))
                {
                    totalPrice += CalculateStudentAndMidWeekDiscount(_movieTickets[i]);
                } else
                {
                    totalPrice += _movieTickets[i].GetPrice();
                    totalPrice += CalculatePremium(_movieTickets[i]);
                }
            }
            totalPrice -= CalculateGroupDiscount(totalPrice);
            return totalPrice;            
        }

        // Elk 2e ticket is gratis voor studenten
        // Elk 2e ticket is gratis voor niet studenten op ma/di/wo/do.
        public double CalculateStudentAndMidWeekDiscount(MovieTicket movieTicket)
        {
            if (_isStudentOrder || movieTicket.IsMidWeek())
            {
                return 0;
            }

            double totalprice = movieTicket.GetPrice();
            totalprice += CalculatePremium(movieTicket);
            return totalprice;
        }

        // Een premium ticket is voor studenten 2,- duurder en voor niet studenten 3,- duurder.
        public double CalculatePremium(MovieTicket movieTicket)
        {
            if (movieTicket.IsPremium())
            {
                if (_isStudentOrder)
                {
                    return 2;
                }

                return 3;
            }
            return 0;
        }

        // Als de bestelling van een niet-student bestaat uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.
        public double CalculateGroupDiscount(double costs)
        {
            if (_movieTickets.Count >= 6 && !_isStudentOrder)
            {
                return costs *= 0.1;
            }
            return 0;
        }

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
