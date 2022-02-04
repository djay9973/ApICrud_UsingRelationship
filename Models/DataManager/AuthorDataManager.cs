using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApICrud_UsingRelationship.Models;
using ApICrud_UsingRelationship.Models.Repository;
using ApICrud_UsingRelationship.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApICrud_UsingRelationship.Models.DataManager
{
    public class AuthorDataManager : IDataRepository<Author, AuthorDTO>
    {
        readonly BookStoreContext _bookStoreContext;
        public AuthorDataManager(BookStoreContext storeContext)
        {
            _bookStoreContext = storeContext;
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookStoreContext.Authors
                .Include(author => author.AuthorContact)
                .ToList();
        }

        public Author Get(long id)
        {
            var author = _bookStoreContext.Authors
                .SingleOrDefault(b => b.Id == id);

            return author;
        }

        public AuthorDTO GetDto(long id)
        {
            _bookStoreContext.ChangeTracker.LazyLoadingEnabled = true;

            using (var context = new BookStoreContext())
            {
                var author = context.Authors
                    .SingleOrDefault(b => b.Id == id);

                return AuthorDTOMapper.MapToDto(author);
            }
        }


        public void Add(Author entity)
        {
            _bookStoreContext.Authors.Add(entity);
            _bookStoreContext.SaveChanges();
        }

        public void Update(Author entityToUpdate, Author entity)
        {
            entityToUpdate = _bookStoreContext.Authors
                .Include(a => a.BookAuthors)
                .Include(a => a.AuthorContact)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;

            entityToUpdate.AuthorContact.Address = entity.AuthorContact.Address;
            entityToUpdate.AuthorContact.ContactNumber = entity.AuthorContact.ContactNumber;

            var deletedBooks = entityToUpdate.BookAuthors.Except(entity.BookAuthors).ToList();
            var addedBooks = entity.BookAuthors.Except(entityToUpdate.BookAuthors).ToList();

            deletedBooks.ForEach(bookToDelete =>
                entityToUpdate.BookAuthors.Remove(
                    entityToUpdate.BookAuthors
                        .First(b => b.BookId == bookToDelete.BookId)));

            foreach (var addedBook in addedBooks)
            {
                _bookStoreContext.Entry(addedBook).State = EntityState.Added;
            }

            _bookStoreContext.SaveChanges();
        }

        public void Delete(Author entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
