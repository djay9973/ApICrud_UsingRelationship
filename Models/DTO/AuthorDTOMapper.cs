using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApICrud_UsingRelationship.Models.DTO
{
    public static class AuthorDTOMapper
    {
        public static AuthorDTO MapToDto(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                Name = author.Name,

                AuthorContact = new AuthorContactDTO()
                {
                    AuthorId = author.Id,
                    Address = author.AuthorContact.Address,
                    ContactNumber = author.AuthorContact.ContactNumber
                }
            };
        }
    }
}
