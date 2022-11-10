﻿using System;
namespace Span.Culturio.Api.Data.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string State { get; set; }
        public int RecordedVisits { get; set; }
    }
}

