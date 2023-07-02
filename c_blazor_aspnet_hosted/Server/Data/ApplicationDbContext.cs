using c_scharp_companies.Models;
using Microsoft.EntityFrameworkCore;

namespace c_scharp_companies.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Address> Address { get; set; } = default!;
}

