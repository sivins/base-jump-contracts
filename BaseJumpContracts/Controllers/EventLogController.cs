using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BaseJumpContracts.DAL;
using BaseJumpContracts.Models;

namespace BaseJumpContracts.Controllers
{
    public class EventLogController : ApiController
    {
        private ContractContext db = new ContractContext();

        // GET: api/EventLog
        public IQueryable<EventLog> GetEventLogs()
        {
            return db.EventLogs;
        }

        // GET: api/EventLog/5
        [ResponseType(typeof(EventLog))]
        public IHttpActionResult GetEventLog(int id)
        {
            EventLog eventLog = db.EventLogs.Find(id);
            if (eventLog == null)
            {
                return NotFound();
            }

            return Ok(eventLog);
        }

        // PUT: api/EventLog/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventLog(int id, EventLog eventLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventLog.ID)
            {
                return BadRequest();
            }

            db.Entry(eventLog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventLogExists(id))
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

        // POST: api/EventLog
        [ResponseType(typeof(EventLog))]
        public IHttpActionResult PostEventLog([FromBody] EventLog[] eventLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var log in eventLog)
            {
                db.EventLogs.Add(log);
            }

            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/EventLog/5
        [ResponseType(typeof(EventLog))]
        public IHttpActionResult DeleteEventLog(int id)
        {
            EventLog eventLog = db.EventLogs.Find(id);
            if (eventLog == null)
            {
                return NotFound();
            }

            db.EventLogs.Remove(eventLog);
            db.SaveChanges();

            return Ok(eventLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventLogExists(int id)
        {
            return db.EventLogs.Count(e => e.ID == id) > 0;
        }
    }
}