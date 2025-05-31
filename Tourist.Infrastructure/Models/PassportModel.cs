using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    public class PassportModel : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public TouristModel Tourist { get; set; }
    }
}
