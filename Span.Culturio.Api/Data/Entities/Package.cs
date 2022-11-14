using System;
using Span.Culturio.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Span.Culturio.Api.Data.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //nezz dal se ovo ovako radi
        public ICollection<PackageCultureObject> CultureObjects { get; set; }
        public string ValidDays { get; set; }
    }

    public class PackageConfigurationBuilder : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable(nameof(Package));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            //builder.Property(x => x.CultureObjects)
            //    .IsRequired();
            builder.Property(x => x.ValidDays)
                .IsRequired();
        }
    }
}

