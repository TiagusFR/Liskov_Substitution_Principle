using Microsoft.EntityFrameworkCore;
using Liskov_Substitution_Principle.DatabaseContext;
using Liskov_Substitution_Principle.DataTransferObject;

namespace Liskov_Substitution_Principle.DatabaseContext
{
    public class SavingsAccountDbContext : DbContext
    {
        public SavingsAccountDbContext(DbContextOptions<SavingsAccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
