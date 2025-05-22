using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourist.common.services;

namespace Tourist.common.models
{
    public class Booking : IIdentifiable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
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
