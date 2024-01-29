namespace software_design_and_architecture_3_colleges
{
    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private bool _isPremium;

        public MovieTicket(int rowNr, int seatNr, bool isPremium)
        {
            _rowNr = rowNr;
            _seatNr = seatNr;
            _isPremium = isPremium;
        }

        public bool isPremium()
        {
            return _isPremium;
        }

        public int getPrice()
        {
            throw new NotImplementedException();
        }

        public string toString()
        {
            throw new NotImplementedException();
        }
    }
}