namespace software_design_and_architecture_3_colleges
{
    public abstract class Movie
    {
        private string _title;
        private List<MovieScreening> _movieScreening;

        public Movie(string title)
        {
            _title = title;
            _movieScreening = new List<MovieScreening>();
        }

        public void AddScreening(MovieScreening screening)
        {
            _movieScreening.Add(screening);
        }

        public override string ToString()
        {
            return "Movie: " + _title;
        }
    }
}