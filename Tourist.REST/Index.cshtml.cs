using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tourist.Infrastructure;
using Tourist.Infrastructure.Models;

namespace Tourist.REST
{
    public class IndexModel : PageModel
    {
        private readonly Tourist.Infrastructure.TouristContext _context;

        public IndexModel(Tourist.Infrastructure.TouristContext context)
        {
            _context = context;
        }

        public IList<BookingModel> BookingModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookingModel = await _context.Bookings.ToListAsync();
        }
    }
}
