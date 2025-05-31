using Tourist.Common.Services;

namespace Tourist.Infrastructure.Models
{
    public class TourPackageModel : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public double Rating { get; set; }


        public TourPackageModel()
        {
        }

        public TourPackageModel(string title, string genre, int year, double rating)
        {
            Title = title;
            Genre = genre;
            Year = year;
            Rating = rating;
        }
    }
}
