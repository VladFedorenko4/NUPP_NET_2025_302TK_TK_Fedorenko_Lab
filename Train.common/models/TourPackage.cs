using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourist.common.services;

namespace Tourist.common.models
{
    public class TourPackage : IIdentifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public TourPackage(string title, string genre, int year, double rating)
        {
            Title = title;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"{Title} ({Year}) - {Genre}, Рейтинг: {Rating}/10";
        }
    }
}
