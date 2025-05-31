using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    public class TourModel : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Destination { get; set; }

        // Many-to-Many
        public ICollection<TouristModel> Tourists { get; set; }
    }
}
