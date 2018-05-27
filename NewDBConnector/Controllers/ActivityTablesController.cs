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
using NewDBConnector;

namespace NewDBConnector.Controllers
{
    public class ActivityTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ActivityTables
        public IQueryable<ActivityTable> GetActivityTable()
        {
            return db.ActivityTable;
        }

        // GET: api/ActivityTables/5
        [ResponseType(typeof(ActivityTable))]
        public IHttpActionResult GetActivityTable(string id)
        {
            ActivityTable activityTable = db.ActivityTable.Find(id);
            if (activityTable == null)
            {
                return NotFound();
            }

            return Ok(activityTable);
        }

        // PUT: api/ActivityTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActivityTable(string id, ActivityTable activityTable)
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

            db.ActivityTable.Add(activityTable);

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
        public IHttpActionResult DeleteActivityTable(string id)
        {
            ActivityTable activityTable = db.ActivityTable.Find(id);
            if (activityTable == null)
            {
                return NotFound();
            }

            db.ActivityTable.Remove(activityTable);
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

        private bool ActivityTableExists(string id)
        {
            return db.ActivityTable.Count(e => e.ID == id) > 0;
        }
    }
}