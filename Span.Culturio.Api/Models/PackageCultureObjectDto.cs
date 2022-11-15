using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Span.Culturio.Api.Models
{
	public class PackageCultureObjectDto
	{
        //public int Id { get; set; }
        //public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }

        public int PackageId { get; set; }
        public int AvailableVisits { get; set; }

        
        //public PackageDto Package { get; set; }


        //Zbog ovog nije valjalo
        //public virtual PackageDto Package { get; set; }
    }
}

