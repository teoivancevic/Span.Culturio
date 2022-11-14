using System;
namespace Span.Culturio.Api.Models
{
	public class CreatePackageCultureObjectDto
	{
        //public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }
        public int PackageId { get; set; }
        public int AvailableVisits { get; set; }

        //public PackageDto Package { get; set; }
    }
}

