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
using DatabaseConnector;

namespace DatabaseConnector.Controllers
{
    public class DatesTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DatesTables
        public IQueryable<DatesTable> GetDatesTable()
        {
            return db.DatesTable;
        }

        // GET: api/DatesTables/5
        [ResponseType(typeof(DatesTable))]
        public IHttpActionResult GetDatesTable(string id)
        {
            DatesTable datesTable = db.DatesTable.Find(id);
            if (datesTable == null)
            {
                return NotFound();
            }

            return Ok(datesTable);
        }

        // PUT: api/DatesTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDatesTable(string id, DatesTable datesTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datesTable.Id)
            {
                return BadRequest();
            }

            db.Entry(datesTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatesTableExists(id))
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

        // POST: api/DatesTables
        [ResponseType(typeof(DatesTable))]
        public IHttpActionResult PostDatesTable(DatesTable datesTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DatesTable.Add(datesTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DatesTableExists(datesTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = datesTable.Id }, datesTable);
        }

        // DELETE: api/DatesTables/5
        [ResponseType(typeof(DatesTable))]
        public IHttpActionResult DeleteDatesTable(string id)
        {
            DatesTable datesTable = db.DatesTable.Find(id);
            if (datesTable == null)
            {
                return NotFound();
            }

            db.DatesTable.Remove(datesTable);
            db.SaveChanges();

            return Ok(datesTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatesTableExists(string id)
        {
            return db.DatesTable.Count(e => e.Id == id) > 0;
        }
    }
}