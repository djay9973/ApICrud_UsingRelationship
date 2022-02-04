using System;
using System.Collections.Generic;

#nullable disable

namespace ApICrud_UsingRelationship.Models
{
    public partial class AuthorContact
    {
        public long AuthorId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public virtual Author Author { get; set; }
    }
}
