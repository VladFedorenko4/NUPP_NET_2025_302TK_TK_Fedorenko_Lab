using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    // Inheritance (Table-per-Type)
    public class GuideModel : TouristModel, IIdentifiable
    {
        public string LicenseNumber { get; set; }
    }
}
