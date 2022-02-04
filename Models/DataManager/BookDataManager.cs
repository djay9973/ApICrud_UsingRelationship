using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApICrud_UsingRelationship.Models;
using ApICrud_UsingRelationship.Models.Repository;
using ApICrud_UsingRelationship.Models.DTO;

namespace ApICrud_UsingRelationship.Models.DataManager
{
    public class BookDataManager : IDataRepository<Book, BookDTO>
    {
        readonly BookStoreContext _bookStoreContext;

        public BookDataManager(BookStoreContext storeContext)
        {
            _bookStoreContext = storeContext;
        }

        public IEnumerable<Book> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Book Get(long id)
        {
            _bookStoreContext.ChangeTracker.LazyLoadingEnabled = false;

            var book = _bookStoreContext.Books
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            _bookStoreContext.Entry(book)
                .Collection(b => b.BookAuthors)
                .Load();

            _bookStoreContext.Entry(book)
                .Reference(b => b.Publisher)
                .Load();

            return book;
        }

        public BookDTO GetDto(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Book entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Book entityToUpdate, Book entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
