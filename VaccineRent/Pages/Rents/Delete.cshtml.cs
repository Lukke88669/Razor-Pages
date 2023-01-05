using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccineRent.Data;
using VaccineRent.Models;

namespace VaccineRent.Pages.Rents
{
    public class DeleteModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public DeleteModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rent Rent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent.FirstOrDefaultAsync(m => m.ID == id);

            if (rent == null)
            {
                return NotFound();
            }
            else 
            {
                Rent = rent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }
            var rent = await _context.Rent.FindAsync(id);

            if (rent != null)
            {
                Rent = rent;
                _context.Rent.Remove(Rent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
