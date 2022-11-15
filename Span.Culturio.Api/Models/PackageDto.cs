using System;
namespace Span.Culturio.Api.Models
{
    public class PackageDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ValidDays { get; set; }

        public virtual ICollection<PackageCultureObjectDto> CultureObjects { get; set; }


    }
}

