using Microsoft.EntityFrameworkCore; 
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Data
{
    class AppDBContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        public DbSet<Security> Securities => Set<Security>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=investments.db");
        }
    }
}
