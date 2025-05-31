using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tourist.Infrastructure;
using Tourist.Infrastructure.Models;

namespace Tourist.REST
{
    public class EditModel : PageModel
    {
        private readonly Tourist.Infrastructure.TouristContext _context;

        public EditModel(Tourist.Infrastructure.TouristContext context)
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

            var bookingmodel =  await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);
            if (bookingmodel == null)
            {
                return NotFound();
            }
            BookingModel = bookingmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelExists(BookingModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingModelExists(Guid id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
