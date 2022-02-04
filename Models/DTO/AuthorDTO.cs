using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApICrud_UsingRelationship.Models.DTO
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public AuthorContactDTO AuthorContact { get; set; }
    }
}
