using Tourist.Common.Services;

namespace Tourist.Common.Models
{
    public class Booking : IIdentifiable
    {
        public Guid Id { get; set; }

        public string MovieTitle { get; set; }

        public DateTime ShowTime { get; set; }

        public double Price { get; set; }

        public Booking(string movieTitle, DateTime showTime, double price)
        {
            MovieTitle = movieTitle;
            ShowTime = showTime;
            Price = price;
        }

        public override string ToString()
        {
            return $"{MovieTitle} | {ShowTime} | {Price} EUR";
        }
    }
}
