using System;
namespace Span.Culturio.Api.Models
{
	public class CreatePackageDto
	{
        //public int Id { get; set; }
        public string Name { get; set; }
        public List<PackageCultureObjectDto> CultureObjects { get; set; }
        public string ValidDays { get; set; }
    }
}

