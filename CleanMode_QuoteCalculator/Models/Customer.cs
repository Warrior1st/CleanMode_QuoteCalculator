using System;
using System.Collections.Generic;

#nullable disable

namespace CleanMode_QuoteCalculator.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Quotes = new HashSet<Quote>();
        }

        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhysicalAddress { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
