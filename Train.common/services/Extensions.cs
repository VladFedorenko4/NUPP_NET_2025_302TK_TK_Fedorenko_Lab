using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tourist.common.models;

namespace Tourist.common.services
{
    public static class Extensions
    {
        public static double CalculateTotalPrice(this List<Booking> tickets)
        {
            return tickets.Sum(t => t.Price);
        }
    }
}
