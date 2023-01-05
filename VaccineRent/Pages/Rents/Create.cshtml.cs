using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccineRent.Data;
using VaccineRent.Models;

namespace VaccineRent.Pages.Rents
{
    public class CreateModel : PageModel
    {
        private readonly VaccineRent.Data.ApplicationDbContext _context;

        public CreateModel(VaccineRent.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> NameQuery = from m in _context.Hospital
                                           orderby m.Name
                                           select m.Name;
            var hospitals = from m in _context.Hospital select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                hospitals = hospitals.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(HospitalName))
            {
                hospitals = hospitals.Where(x => x.Name == HospitalName);
            }
            Name = new SelectList(await NameQuery.Distinct().ToListAsync());
            Hospital = await hospitals.ToListAsync();
            return Page();
        }
        [BindProperty]
        public Rent Rent { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Rent.Add(Rent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public IList<Hospital> Hospital { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? HospitalName { get; set; }
    }
}
