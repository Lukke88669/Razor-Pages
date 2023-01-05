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
    public class DetailsModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public DetailsModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
