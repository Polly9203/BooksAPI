using BooksAPI.Interfaces;
using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BooksAPI.Repositories
{
    public class BooksRepository : IRepository<Book>
    {
        private BooksContext Db;
        public BooksRepository(BooksContext context)
        {
            this.Db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return Db.Books;
        }

        public Book Get(int id)
        {
            return Db.Books.Find(id);
        }

        public void Create(Book book)
        {
            Db.Books.Add(book);
        }

        public void Update(Book book)
        {
            Db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = Db.Books.Find(id);
            if (book != null)
                Db.Books.Remove(book);
        }
    }
}
