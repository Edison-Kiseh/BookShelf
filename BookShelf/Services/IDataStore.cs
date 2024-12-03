using BookShelf.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Services
{
    public interface IDataStore
    {
        Task<List<Book>> GetAllBooks();
        Task AddBook(Book book);
        Task DeleteBook(Book book);
        Task UpdateBook(Book book);
    }
}
