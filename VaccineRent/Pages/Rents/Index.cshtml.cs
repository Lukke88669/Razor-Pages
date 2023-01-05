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
    public class IndexModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public IndexModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Rent> Rent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rent != null)
            {
                Rent = await _context.Rent.ToListAsync();
            }
        }
    }
}
