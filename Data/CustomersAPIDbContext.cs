using CustomerManagementWebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace CustomerManagementWebAPI.Data
{
    public class CustomersAPIDbContext : IdentityDbContext<IdentityUser>
    {
        public CustomersAPIDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
