﻿using System;
namespace Span.Culturio.Api.Models
{
    public class TrackVisitDto
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }
        public DateTime TimeEntered { get; set; }
    }
}

