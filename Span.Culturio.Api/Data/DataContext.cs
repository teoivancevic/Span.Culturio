using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data.Entities;
using System.Reflection;
using System.Reflection.Metadata;

namespace Span.Culturio.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageCultureObject> PackageCultureObjects { get; set; }
        public DbSet<CultureObject> CultureObjects { get; set; }
        public DbSet<TrackVisit> TrackVisits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ovo mi se cini prilicno krivo
            /*
            modelBuilder.Entity<PackageCultureObject>()
                .HasOne(p => p.Package)
                .WithMany(b => b.CultureObjects)
                .HasForeignKey(x => x.PackageId);
            */
            modelBuilder.Entity<Package>()
                .HasMany(p => p.CultureObjects)
                .WithOne(b => b.Package)
                .HasForeignKey(x => x.PackageId);

            /*
            modelBuilder.Entity<PackageCultureObject>()
                .HasOne(p => p.Package)
                .WithMany()
                .HasForeignKey(x => x.PackageId);
            */
            /*
            modelBuilder.Entity<Package>()
                .HasMany(p => p.CultureObjects)
                .WithOne();


            modelBuilder.Entity<Package>()
                .Navigation(b => b.CultureObjects)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            */
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedData.CreateData(modelBuilder);
        }
    }
}