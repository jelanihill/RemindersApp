using System.Data.Entity;
using RemindersApp.DAL.Abstract;
using RemindersApp.Models;

namespace RemindersApp.DAL.Concrete
{
    public class ReminderAppUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly EfGenericRepository<Person> _personRepo;
        private readonly EfGenericRepository<Message> _messageRepo;

        public DbSet<Person> People { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ReminderAppUnitOfWork()
        {
            _personRepo = new EfGenericRepository<Person>(People);
            _messageRepo = new EfGenericRepository<Message>(Messages);
            base.Configuration.ProxyCreationEnabled = false;
        }

        public IGenericRepository<Person> PersonRepository
        {
            // ReSharper disable once ConvertPropertyToExpressionBody
            get { return _personRepo; }
            
        }

        public IGenericRepository<Message> MessageRepository
        {
            // ReSharper disable once ConvertPropertyToExpressionBody
            get {return _messageRepo;}
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
