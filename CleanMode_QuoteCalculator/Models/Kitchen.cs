using System;
using System.Collections.Generic;

#nullable disable

namespace CleanMode_QuoteCalculator.Models
{
    public partial class Kitchen
    {
        public int? RoomTypeId { get; set; }
        public float? PricePerSqft { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
