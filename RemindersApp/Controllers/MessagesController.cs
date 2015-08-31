using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RemindersApp.DAL.Concrete;
using RemindersApp.Models;

namespace RemindersApp.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly ReminderAppUnitOfWork _context = null;

        public MessagesController()
        {
            _context = new ReminderAppUnitOfWork();
        }

        // GET: api/Messages
        public IQueryable<Message> GetMessages()
        {
            return _context.MessageRepository.GetAll().AsQueryable();
        }

        [Route("api/Person/{personId}/Messages")]
        public IEnumerable<Message> GetMessagesByPerson(int personId)
        {
            return _context.MessageRepository.GetAll().Where((m => m.PersonId == personId));
        }

            // GET: api/Messages/5
        [ResponseType(typeof(Message))]
        public IHttpActionResult GetMessage(int id)
        {
            Message message = _context.MessageRepository.GetbyId(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Messages.Add(message);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        public IHttpActionResult DeleteMessage(int id)
        {
            Message message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            _context.SaveChanges();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Count(e => e.Id == id) > 0;
        }
    }
}