using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Models;

namespace PhoneDirectory.Shared.Data
{
    public class PhoneDirectoryDbContext : DbContext
    {
        public PhoneDirectoryDbContext(DbContextOptions<PhoneDirectoryDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<ContactInformation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PersonId).IsRequired();
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Content).IsRequired();

                entity.HasOne<Person>()
                    .WithMany(p => p.ContactInformation)
                    .HasForeignKey(ci => ci.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequestDate).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });

            modelBuilder.Entity<ReportDetail>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.Location });
                entity.Property(e => e.Location).IsRequired();
                entity.Property(e => e.PersonCount).IsRequired();
                entity.Property(e => e.PhoneNumberCount).IsRequired();

                entity.HasOne<Report>()
                    .WithMany(r => r.Details)
                    .HasForeignKey(rd => rd.ReportId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
} 