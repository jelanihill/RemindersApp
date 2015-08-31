using System;
using RemindersApp.Models;

namespace RemindersApp.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Person> PersonRepository { get; }
        IGenericRepository<Message> MessageRepository { get; }

        void Commit();
    }
}
