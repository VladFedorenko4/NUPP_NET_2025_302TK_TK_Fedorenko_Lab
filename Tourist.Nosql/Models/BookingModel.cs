using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tourist.Nosql.Models
{
    public class BookingModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

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
