
namespace BookShelf.Classes.Book
{
    public class Book
    {
        public string CoverImageUrl { get; set; }      
        public string Title { get; set; }         
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
