using System;
using System.Collections.Generic;
using RemindersApp.DAL.Concrete;
using RemindersApp.Models;

namespace RemindersApp.DAL
{
    public class ItemsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReminderAppUnitOfWork>
    {
        protected override void Seed(ReminderAppUnitOfWork context)
        {
            var people = new List<Person>
            {
                new Person {Id = 1, Firstname = "Jelani", Lastname = "Hill"},
                new Person {Id = 2, Firstname = "Jared", Lastname = "Henry"},
                new Person {Id = 3, Firstname = "Taylor", Lastname = "Burford"}
            };
            people.ForEach(p => context.PersonRepository.Add(p));

            var messages = new List<Message>
            {
                new Message {PersonId = 1, Id = 1, Content = "I hate everyone", CreationTime = DateTime.Parse("2015-10-10")},
                new Message {PersonId = 1, Id = 2, Content = "This girl is hot", CreationTime = DateTime.Parse("2014-02-13")},
                new Message {PersonId = 2, Id = 3, Content = "I have the best name ever", CreationTime = DateTime.Parse("2014-03-13")},
                new Message {PersonId = 3, Id = 4, Content = "Pickles", CreationTime = DateTime.Parse("2014-12-12")},
                new Message {PersonId = 3, Id = 5, Content = "Go Gators", CreationTime = DateTime.Parse("2015-02-13")},
                new Message {PersonId = 3, Id = 6, Content = "I am so unoriginal", CreationTime = DateTime.Parse("2015-08-31")},
            };
            messages.ForEach(m => context.MessageRepository.Add(m));
            context.SaveChanges();

        }
    }
}
