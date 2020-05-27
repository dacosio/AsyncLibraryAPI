using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Entities;

namespace Library.API.Services
{
    public interface IBooksRepository
    {

        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(Guid id);

        void AddBook(Book book);

        Task<bool> SaveChangesAsync();
    }
}
