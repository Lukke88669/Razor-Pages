using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaccineRent.Models;

namespace VaccineRent.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VaccineRent.Models.Hospital> Hospital { get; set; }
        public DbSet<VaccineRent.Models.Rent> Rent { get; set; }
    }
}