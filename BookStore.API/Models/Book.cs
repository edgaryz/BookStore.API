namespace BookStore.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }

        public Book() { }

        public Book(int id, string title, string author, int releaseYear)
        {
            Id = id;
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"ID: {Id}, {Author} - {Title}, Release year: {ReleaseYear}.";
        }
    }
}
