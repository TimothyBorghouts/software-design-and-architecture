using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace software_design_and_architecture_3_colleges
{
    public class Order
    {
        private int _orderNr;
        private bool _isStudentOrder;
        private List<MovieTicket> _movieTickets;

        public Order(int orderNr, bool isStrudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStrudentOrder;
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
            if (exportFormat == TicketExportFormat.PLAINTEXT)
            {
                ExportJson();
            }
            else if (exportFormat == TicketExportFormat.JSON)
            {
                ExportPlaintText();
            }
        }

        public void ExportJson() 
        {
            string jsonDataFile = "C:\\Software projecten\\software-design-and-architecture-3-colleges\\software-design-and-architecture-3-colleges\\json.json";
            List<MovieTicket> _data = new List<MovieTicket>();

            foreach (MovieTicket movieTicket in _movieTickets)
            {
                _data.Add(movieTicket);
            }
            string json = JsonConvert.SerializeObject(_data.ToArray());
            File.WriteAllText(jsonDataFile, json);
            Console.WriteLine("Json data exported successfully.");
        }

        public void ExportPlaintText()
        {
            string plainTextFile = "C:\\Software projecten\\software-design-and-architecture-3-colleges\\software-design-and-architecture-3-colleges\\plaintext.txt";
            string tickets = "";

            foreach (MovieTicket movieTicket in _movieTickets)
            {
                tickets += movieTicket.ToString();
                tickets += "\n\n";
            }

            File.WriteAllText(plainTextFile, tickets);
            Console.WriteLine("Plaintext data exported successfully.");
        }
    }
}
