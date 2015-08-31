using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RemindersApp.DAL;
using RemindersApp.DAL.Concrete;
using RemindersApp.Models;

namespace RemindersApp.Controllers
{
    public class PersonController : ApiController
    {
        private readonly ReminderAppUnitOfWork _context = null;

        public PersonController()
        {
            _context = new ReminderAppUnitOfWork();
        }

        [HttpGet]
        public IQueryable<Person> GetPeople()
        {
            return _context.PersonRepository.GetAll().AsQueryable();
        }
            
        [HttpGet]
        [ResponseType(typeof(Person))]
        public IHttpActionResult GetPerson(int id)
        {
            var person = _context.PersonRepository.GetbyId(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Person))]
        public IHttpActionResult CreatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonRepository.Add(person);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        [HttpDelete]
        [ResponseType(typeof(Person))]
        public IHttpActionResult DeletePerson(int id)
        {
            Person person = _context.PersonRepository.GetbyId(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.PersonRepository.Delete(person);
            _context.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return _context.PersonRepository.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}