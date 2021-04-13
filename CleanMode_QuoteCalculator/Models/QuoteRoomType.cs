using System;
using System.Collections.Generic;

#nullable disable

namespace CleanMode_QuoteCalculator.Models
{
    public partial class QuoteRoomType
    {
        public int? QuoteId { get; set; }
        public int? RoomTypeId { get; set; }

        public virtual Quote Quote { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
