using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccineRent.Data;
using VaccineRent.Models;

namespace VaccineRent.Pages.Hospitals
{
    public class EditModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public EditModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hospital Hospital { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital =  await _context.Hospital.FirstOrDefaultAsync(m => m.ID == id);
            if (hospital == null)
            {
                return NotFound();
            }
            Hospital = hospital;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hospital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(Hospital.ID))
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

        private bool HospitalExists(int id)
        {
          return _context.Hospital.Any(e => e.ID == id);
        }
    }
}
