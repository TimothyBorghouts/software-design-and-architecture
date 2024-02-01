using Microsoft.VisualBasic;

namespace software_design_and_architecture_3_colleges
{
    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private bool _isPremium;
        private MovieScreening _movieScreening;

        public int Id { get; internal set; }

        public MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
        {
            _rowNr = rowNr;
            _seatNr = seatNr;
            _isPremium = isPremium;
            _movieScreening = movieScreening;
        }

        public MovieTicket(int rowNr, int seatNr, bool isPremium)
        {
            _rowNr = rowNr;
            _seatNr = seatNr;
            _isPremium = isPremium;
        }

        public bool IsPremium()
        {
            return _isPremium;
        }

        public double GetPrice()
        {
            return _movieScreening.GetPricePerSeat();
        }

        public string ToString()
        {
            string ticket = "Ticket:\nRow: " + _rowNr + "\nSeat Number: " + _seatNr;
            if(_isPremium )
            {
                ticket += "\nPremium ticket";
            }
            return ticket;
        }

        public bool IsMidWeek()
        {
            DayOfWeek wk = _movieScreening.GetDateTime().DayOfWeek;
            if (wk == DayOfWeek.Monday || wk == DayOfWeek.Tuesday || wk == DayOfWeek.Wednesday || wk == DayOfWeek.Thursday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}