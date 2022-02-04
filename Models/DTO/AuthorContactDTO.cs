using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApICrud_UsingRelationship.Models.DTO
{
    public class AuthorContactDTO
    {
        public AuthorContactDTO()
        {
        }

        public long AuthorId { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }
    }
}
