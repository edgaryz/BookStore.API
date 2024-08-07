using BookStore.API.Contracts;
using BookStore.API.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.API.Repositories
{
    public class BookStoreRepository: IBookStoreRepository
    {
        private readonly string _dbConnectionString;
        public BookStoreRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public List<Book> GetAllBooks()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<Book>(@"SELECT id, title, author, release_year AS ReleaseYear FROM books").ToList();
            dbConnection.Close();
            return result;
        }

        public Book GetBookById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.QueryFirst<Book>(
                @"SELECT id, title, author, release_year AS ReleaseYear FROM books WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }

        public void InsertBook(Book book)
        {
            string sqlCommand = "INSERT INTO books (title, author, release_year)" +
                "VALUES (@Title, @Author, @ReleaseYear)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, book);
            }
        }

        public void UpdateBook(Book book)
        {
            string sqlCommand = "UPDATE books SET " +
                "title = @Title, author = @Author, release_year = @ReleaseYear " +
                "WHERE id = @Id";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, book);
            }
        }

        public void DeleteBook(int id)
        {
            string sqlCommand = "DELETE FROM books WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, new { Id = id });
            }
        }
    }
}
