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
using DBConnector;

namespace DBConnector.Controllers
{
    public class ActivityTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ActivityTables
        public IQueryable<ActivityTable> GetActivityTables()
        {
            return db.ActivityTables;
        }

        // GET: api/ActivityTables/5
        [ResponseType(typeof(ActivityTable))]
        public IHttpActionResult GetActivityTable(int id)
        {
            ActivityTable activityTable = db.ActivityTables.Find(id);
            if (activityTable == null)
            {
                return NotFound();
            }

            return Ok(activityTable);
        }

        // PUT: api/ActivityTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivityTable(int id, ActivityTable activityTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityTable.ID)
            {
                return BadRequest();
            }

            db.Entry(activityTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTableExists(id))
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

        // POST: api/ActivityTables
        [ResponseType(typeof(ActivityTable))]
        public IHttpActionResult PostActivityTable(ActivityTable activityTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActivityTables.Add(activityTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ActivityTableExists(activityTable.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = activityTable.ID }, activityTable);
        }

        // DELETE: api/ActivityTables/5
        [ResponseType(typeof(ActivityTable))]
        public IHttpActionResult DeleteActivityTable(int id)
        {
            ActivityTable activityTable = db.ActivityTables.Find(id);
            if (activityTable == null)
            {
                return NotFound();
            }

            db.ActivityTables.Remove(activityTable);
            db.SaveChanges();

            return Ok(activityTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityTableExists(int id)
        {
            return db.ActivityTables.Count(e => e.ID == id) > 0;
        }
    }
}