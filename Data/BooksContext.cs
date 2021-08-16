using Microsoft.EntityFrameworkCore;
using BooksAPI.Models;

namespace BooksAPI
{
    public class BooksContext : DbContext
    {
        private string connectionString;

        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }

        public BooksContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
