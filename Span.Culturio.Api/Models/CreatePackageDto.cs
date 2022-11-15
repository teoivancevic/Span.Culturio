using System;
using Span.Culturio.Api.Data.Entities;

namespace Span.Culturio.Api.Models
{
	public class CreatePackageDto
	{
        //public int Id { get; set; }
        public string Name { get; set; }
        public string ValidDays { get; set; }

        //public virtual IEnumerable<PackageCultureObjectDto> CultureObjects { get; set; }
    }
}

