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
    public class DetailsModel : PageModel
    {
        private readonly Tourist.Infrastructure.TouristContext _context;

        public DetailsModel(Tourist.Infrastructure.TouristContext context)
        {
            _context = context;
        }

        public BookingModel BookingModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingmodel = await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);
            if (bookingmodel == null)
            {
                return NotFound();
            }
            else
            {
                BookingModel = bookingmodel;
            }
            return Page();
        }
    }
}
