﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Span.Culturio.Api.Models
{
	public class PackageCultureObjectDto
	{
        public int Id { get; set; }
        public int CultureObjectId { get; set; }

        public int PackageId { get; set; }
        public int AvailableVisits { get; set; }

        


        // Zbog ovog nije radilo prije, ne smije bit u Dto-u
        //public virtual PackageDto Package { get; set; }
    }
}

