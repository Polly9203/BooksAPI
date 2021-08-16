using BooksAPI.Interfaces;
using BooksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BooksContext Db;
        private BooksRepository bookRepository;

        public EFUnitOfWork(string connectionString)
        {
            Db = new BooksContext(connectionString);
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BooksRepository(Db);
                return bookRepository;
            }
        }

        public IRepository<LoveAnswer> LoveAnswers => throw new NotImplementedException();
        public IRepository<TwilioAnswer> TwilioAnswers => throw new NotImplementedException();

        public void Save()
        {
            Db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
