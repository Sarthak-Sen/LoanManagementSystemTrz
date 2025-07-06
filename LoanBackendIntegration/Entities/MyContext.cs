using Microsoft.EntityFrameworkCore;

namespace LoanBackendIntegration.Entities
{
    public class MyContext : DbContext
    {

        private IConfiguration configuration;

        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection"));
        }
    }
}
