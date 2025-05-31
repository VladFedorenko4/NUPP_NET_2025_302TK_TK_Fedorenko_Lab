using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tourist.Infrastructure;
using Tourist.Infrastructure.Models;

namespace Tourist.REST
{
    public class CreateModel : PageModel
    {
        private readonly Tourist.Infrastructure.TouristContext _context;

        public CreateModel(Tourist.Infrastructure.TouristContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookingModel BookingModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bookings.Add(BookingModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
