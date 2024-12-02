using BookShelf.Models.Book;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Services
{
    internal class MysqlDataStore : IDataStore
    {
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            HttpClient client = new HttpClient();
            String response = await client.GetStringAsync("http://localhost:5152/api/books/");

            return JsonConvert.DeserializeObject<List<Book>>(response);
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
