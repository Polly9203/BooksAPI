using BooksAPI.Models;
using System;

namespace BooksAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<LoveAnswer> LoveAnswers { get; }
        IRepository<TwilioAnswer> TwilioAnswers { get; }
        void Save();
    }
}
