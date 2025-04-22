using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PhoneDirectory.Shared.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PhoneDirectoryDbContext>
    {
        public PhoneDirectoryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneDirectoryDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=phonedirectory;Username=postgres;Password=postgres");

            return new PhoneDirectoryDbContext(optionsBuilder.Options);
        }
    }
} 