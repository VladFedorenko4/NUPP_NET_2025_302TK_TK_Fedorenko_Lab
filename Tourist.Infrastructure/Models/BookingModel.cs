using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    public class BookingModel : IIdentifiable
    {
        public Guid Id { get; set; }

        public string MovieTitle { get; set; }

        public DateTime ShowTime { get; set; }

        public double Price { get; set; }

        public BookingModel()
        {
        }

        public BookingModel(string movieTitle, DateTime showTime, double price)
        {
            MovieTitle = movieTitle;
            ShowTime = DateTime.SpecifyKind(showTime, DateTimeKind.Utc);
            Price = price;
        }
    }
}
