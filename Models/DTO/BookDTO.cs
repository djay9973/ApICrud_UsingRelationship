using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApICrud_UsingRelationship.Models.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public PublisherDTO Publisher { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
    }
}
