using Tourist.Infrastructure.Models;

namespace Tourist.Common.Services
{
    public static class Extensions
    {
        public static double CalculateTotalPrice(this IEnumerable<BookingModel> tickets)
        {
            return tickets.Sum(t => t.Price);
        }
    }
}
