namespace software_design_and_architecture_3_colleges
{
    public class MovieScreening
    {
        private DateTime _dateAndTime;
        private double _pricePerSeat;
        private Movie _movie;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _movie = movie;
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public double getPricePerSeat()
        {
            return _pricePerSeat;
        }

        public string toString()
        {
            throw new NotImplementedException();
        }
    }
}
