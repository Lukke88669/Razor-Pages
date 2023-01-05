using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccineRent.Data;
using VaccineRent.Models;

namespace VaccineRent.Pages.Hospitals
{
    public class CreateModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public CreateModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hospital Hospital { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hospital.Add(Hospital);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
