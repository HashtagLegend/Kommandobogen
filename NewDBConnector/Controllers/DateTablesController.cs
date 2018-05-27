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
    public class DateTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DateTables
        public IQueryable<DateTable> GetDateTable()
        {
            return db.DateTable;
        }

        // GET: api/DateTables/5
        [ResponseType(typeof(DateTable))]
        public IHttpActionResult GetDateTable(string id)
        {
            DateTable dateTable = db.DateTable.Find(id);
            if (dateTable == null)
            {
                return NotFound();
            }

            return Ok(dateTable);
        }

        // PUT: api/DateTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDateTable(string id, DateTable dateTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dateTable.Id)
            {
                return BadRequest();
            }

            db.Entry(dateTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DateTableExists(id))
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

        // POST: api/DateTables
        [ResponseType(typeof(DateTable))]
        public IHttpActionResult PostDateTable(DateTable dateTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DateTable.Add(dateTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DateTableExists(dateTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dateTable.Id }, dateTable);
        }

        // DELETE: api/DateTables/5
        [ResponseType(typeof(DateTable))]
        public IHttpActionResult DeleteDateTable(string id)
        {
            DateTable dateTable = db.DateTable.Find(id);
            if (dateTable == null)
            {
                return NotFound();
            }

            db.DateTable.Remove(dateTable);
            db.SaveChanges();

            return Ok(dateTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DateTableExists(string id)
        {
            return db.DateTable.Count(e => e.Id == id) > 0;
        }
    }
}