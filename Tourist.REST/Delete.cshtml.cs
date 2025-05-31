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
    public class DeleteModel : PageModel
    {
        private readonly Tourist.Infrastructure.TouristContext _context;

        public DeleteModel(Tourist.Infrastructure.TouristContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingmodel = await _context.Bookings.FindAsync(id);
            if (bookingmodel != null)
            {
                BookingModel = bookingmodel;
                _context.Bookings.Remove(BookingModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
