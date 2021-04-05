using System;
using System.Collections.Generic;

#nullable disable

namespace CleanMode_QuoteCalculator.Models
{
    public partial class Quote
    {
        public int QuoteId { get; set; }
        public int? CustomerId { get; set; }
        public float? Quote1 { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
