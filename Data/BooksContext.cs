using Microsoft.EntityFrameworkCore;
using BooksAPI.Models;

namespace BooksAPI
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
