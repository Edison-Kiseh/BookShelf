using BookShelf.Models.Book;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShelf.Services
{
    internal class MockDataStore : IDataStore
    {
        public Task AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "The Great Gatsby",
                    Description = "A novel about the mysterious millionaire Jay Gatsby and his obsession with Daisy Buchanan, set in the Jazz Age.",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Classic",
                    ISBN = "978-0743273565",
                    PublicationDate = new DateTime(1925, 4, 10)
                },
                new Book
                {
                    Id = 2,
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "To Kill a Mockingbird",
                    Description = "A powerful tale of racial injustice and moral growth in the American South.",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    ISBN = "978-0061120084",
                    PublicationDate = new DateTime(1960, 7, 11)
                },
                new Book
                {
                    Id = 3,
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "1984",
                    Description = "A dystopian novel about totalitarianism, surveillance, and the suppression of individuality.",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    ISBN = "978-0451524935",
                    PublicationDate = new DateTime(1949, 6, 8)
                },
                new Book
                {
                    Id = 4,
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "Pride and Prejudice",
                    Description = "A classic romantic tale about Elizabeth Bennet and Mr. Darcy navigating love and societal expectations.",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    ISBN = "978-1503290563",
                    PublicationDate = new DateTime(1813, 1, 28)
                },
                new Book
                {
                    Id = 5,
                    CoverImageUrl = "novel_cover_2.jpeg",
                    Title = "The Catcher in the Rye",
                    Description = "A coming-of-age story about Holden Caulfield, a teenager navigating alienation and identity in post-war America.",
                    Author = "J.D. Salinger",
                    Genre = "Fiction",
                    ISBN = "978-0316769488",
                    PublicationDate = new DateTime(1951, 7, 16)
                },
                new Book
                {
                    Id = 6,
                    CoverImageUrl = "fantasy_cover.jpeg",
                    Title = "The Hobbit",
                    Description = "A fantasy adventure about Bilbo Baggins, a hobbit who embarks on an epic journey to reclaim treasure guarded by the dragon Smaug.",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    ISBN = "978-0547928227",
                    PublicationDate = new DateTime(1937, 9, 21)
                }
            };

            return books;

        }

        public Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
