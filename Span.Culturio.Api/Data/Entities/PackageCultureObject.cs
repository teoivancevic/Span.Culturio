using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Package Package { get; set; }
	}
}

