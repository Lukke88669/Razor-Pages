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
    public class IndexModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public IndexModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Hospital> Hospital { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Country { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? HospitalCountry { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> countryQuery = from m in _context.Hospital
                                              orderby m.Country
                                              select m.Country;
            var hospitals = from m in _context.Hospital select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                hospitals = hospitals.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(HospitalCountry))
            {
                hospitals = hospitals.Where(x => x.Country == HospitalCountry);
            }
            Country = new SelectList(await countryQuery.Distinct().ToListAsync());
            Hospital = await hospitals.ToListAsync();
            //Hospital = await _context.Hospital.ToListAsync();
        }
    }
}