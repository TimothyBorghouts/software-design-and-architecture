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

        public double GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public DateTime GetDateTime()
        {
            return _dateAndTime;
        }

        public override string ToString()
        {
            return "MovieScreening: \n" + _movie.ToString() + "\nDateTime: " + _dateAndTime.ToString() + "\nPricePerSeat: " + _pricePerSeat.ToString();
        }
    }
}
