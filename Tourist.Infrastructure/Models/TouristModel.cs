using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    public class TouristModel : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        // One-to-One
        public PassportModel Passport { get; set; }

        public Guid? PassportId { get; set; }

        public string FavoriteGenre { get; set; }

        // One-to-Many
        public ICollection<TourModel> Tours { get; set; }
    }
}