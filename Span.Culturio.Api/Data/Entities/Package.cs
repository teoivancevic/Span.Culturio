using System;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Data.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CultureObject> CultureObjects { get; set; }
        public string ValidDays { get; set; }
    }
}

