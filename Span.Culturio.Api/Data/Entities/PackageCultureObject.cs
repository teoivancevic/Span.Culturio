using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Api.Data.Entities
{
	public class PackageCultureObject
	{
		public int Id { get; set; }
		//public int SubscriptionId { get; set; }
		public int CultureObjectId { get; set; }

		
		public int AvailableVisits { get; set; }

		[ForeignKey("Package")]
        public int PackageId { get; set; }
        //nezz dal se ovo ovako radi
        //public Package Package { get; set; }

		public virtual Package Package { get; set; }
	}

    public class PackageCultureObjectConfigurationBuilder : IEntityTypeConfiguration<PackageCultureObject>
    {
        public void Configure(EntityTypeBuilder<PackageCultureObject> builder)
        {
            builder.ToTable(nameof(PackageCultureObject));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CultureObjectId)
                .IsRequired();
            //builder.Property(x => x.CultureObjects)
            //    .IsRequired();
            builder.Property(x => x.PackageId)
                .IsRequired();
            builder.Property(x => x.AvailableVisits)
                .IsRequired();


            builder.HasOne(p => p.Package)
                .WithMany(b => b.CultureObjects)
                .HasForeignKey(x => x.PackageId);
        }
    }
}

