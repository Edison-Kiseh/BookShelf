using BookShelf.Models.Books;
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
        public async Task AddBook(Book book)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(book);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("http://192.168.1.13:5152/api/books/", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add book: {response.ReasonPhrase}");
            }
        }

        public async Task DeleteBook(Book book)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.DeleteAsync($"http://192.168.1.13:5152/api/books/{book.Id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete book: {response.ReasonPhrase}");
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            HttpClient client = new HttpClient();
            String response = await client.GetStringAsync("http://192.168.1.13:5152/api/books/");

            return JsonConvert.DeserializeObject<List<Book>>(response);
        }

        public async Task UpdateBook(Book book)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(book);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"http://192.168.1.13:5152/api/books/{book.Id}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update book: {response.ReasonPhrase}");
            }
        }
    }
}
