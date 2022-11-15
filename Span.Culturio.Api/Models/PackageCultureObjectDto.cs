using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Span.Culturio.Api.Models
{
	public class PackageCultureObjectDto
	{
        public int Id { get; set; }
        //public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }
        
        
        public int AvailableVisits { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }
        //public PackageDto Package { get; set; }

        public virtual PackageDto Package { get; set; }
    }
}

