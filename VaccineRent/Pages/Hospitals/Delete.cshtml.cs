using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccineRent.Data;
using VaccineRent.Models;

namespace VaccineRent.Pages.Hospitals
{
    public class DeleteModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public DeleteModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Hospital Hospital { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital.FirstOrDefaultAsync(m => m.ID == id);

            if (hospital == null)
            {
                return NotFound();
            }
            else 
            {
                Hospital = hospital;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }
            var hospital = await _context.Hospital.FindAsync(id);

            if (hospital != null)
            {
                Hospital = hospital;
                _context.Hospital.Remove(Hospital);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
