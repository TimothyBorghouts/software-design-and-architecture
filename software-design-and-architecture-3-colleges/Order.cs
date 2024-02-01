using Newtonsoft.Json;
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
            double totalPrice = 0;
            if(_movieTickets.Count > 0)
            {
                for (int i = 0; i < _movieTickets.Count; i++)
                {
                    if (_movieTickets.Count > 1)
                    {
                        //•	Elk 2e ticket is gratis voor iedereen (ma/di/wo/do) 
                        //•	Elk 2e ticket is gratis voor studenten (elke dag van de week) 
                        if (!((i % 2 != 0) && (_isStudentOrder || _movieTickets[0].IsMidWeek())))
                        {
                            totalPrice += _movieTickets[i].GetPrice();

                            //•	Een premium ticket is voor studenten 2,- duurder dan de standaardprijs per stoel 
                            if (_movieTickets[i].IsPremium() && _isStudentOrder)
                            {
                                totalPrice += 2;
                            }
                            //•	Een premium ticket is voor niet studenten 3,- duurder dan de standaardprijs per stoel 
                            else if (_movieTickets[i].IsPremium())
                            {
                                totalPrice += 3;
                            }
                        }
                    }     
                }
                CalculateGroupDiscount(totalPrice);
            }
            return totalPrice;
        }

        //public double CalculateMidWeekDiscount(double costs)
        //{
        //    if ()
        //    {
        //        return costs;
        //    }

        //    return costs;
        //}

        //public double CalculateStudentDiscount(double costs)
        //{
        //    if ()
        //    {
        //        return costs;
        //    }

        //    return costs;
        //}

        //public double CalculatePremium(double costs)
        //{
        //    if()
        //    {
        //        return costs;
        //    }
        //    return costs;
        //}


        //•	Als de bestelling van een niet-student bestaat uit 6 kaartjes of meer bestaat, dan krijg je 10% groepskorting.
        public double CalculateGroupDiscount(double costs)
        {
            if (_movieTickets.Count >= 6 && !_isStudentOrder)
            {
                return costs *= 0.9;
            }
            return costs;
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
