using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Context;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Services
{
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private BooksContext _booksContext;

        public BooksRepository(BooksContext booksContext)
        {
            _booksContext = booksContext ?? throw new ArgumentException(nameof(booksContext));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_booksContext != null)
                {
                    _booksContext.Dispose();
                    _booksContext = null;
                }
            }
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _booksContext.Books.Include(b=>b.Author).FirstOrDefaultAsync(b => b.Id == id);

        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _booksContext.Books.Include(b=>b.Author).ToListAsync();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _booksContext.Add(book);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //return true if 1 or more entities were changed
            return (await _booksContext.SaveChangesAsync() > 0);
        }
    }
}
