using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneDirectory.Shared.Data;

namespace PhoneDirectory.Shared.Migrations
{
    [DbContext(typeof(PhoneDirectoryDbContext))]
    partial class PhoneDirectoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhoneDirectory.Shared.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.ContactInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.ReportDetail", b =>
                {
                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("PersonCount")
                        .HasColumnType("integer");

                    b.Property<int>("PhoneNumberCount")
                        .HasColumnType("integer");

                    b.HasKey("ReportId", "Location");

                    b.ToTable("ReportDetails");
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.ContactInformation", b =>
                {
                    b.HasOne("PhoneDirectory.Shared.Models.Person", null)
                        .WithMany("ContactInformation")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.ReportDetail", b =>
                {
                    b.HasOne("PhoneDirectory.Shared.Models.Report", null)
                        .WithMany("Details")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.Person", b =>
                {
                    b.Navigation("ContactInformation");
                });

            modelBuilder.Entity("PhoneDirectory.Shared.Models.Report", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
} 