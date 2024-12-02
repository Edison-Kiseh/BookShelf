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
        void AddBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
    }
}
