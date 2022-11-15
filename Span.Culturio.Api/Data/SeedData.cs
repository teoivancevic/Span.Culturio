using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Span.Culturio.Api.Data.Entities;

namespace Span.Culturio.Api.Data
{
	public static class SeedData
	{


        public static void CreateData(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Package>().HasData(
			new Package
			{
				Id = 1,
				Name = "Muzeji",
				ValidDays = 30
			},
			new Package
			{
                Id = 2,
                Name = "Premium",
                ValidDays = 365
            });


			
        }
	}
}

