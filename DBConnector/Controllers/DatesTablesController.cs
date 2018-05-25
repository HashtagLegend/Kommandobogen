﻿using System;
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
    public class DatesTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DatesTables
        public IQueryable<DatesTable> GetDatesTables()
        {
            return db.DatesTables;
        }

        // GET: api/DatesTables/5
        [ResponseType(typeof(DatesTable))]
        public IHttpActionResult GetDatesTable(int id)
        {
            DatesTable datesTable = db.DatesTables.Find(id);
            if (datesTable == null)
            {
                return NotFound();
            }

            return Ok(datesTable);
        }

        // PUT: api/DatesTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDatesTable(int id, DatesTable datesTable)
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

            db.DatesTables.Add(datesTable);

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
        public IHttpActionResult DeleteDatesTable(int id)
        {
            DatesTable datesTable = db.DatesTables.Find(id);
            if (datesTable == null)
            {
                return NotFound();
            }

            db.DatesTables.Remove(datesTable);
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

        private bool DatesTableExists(int id)
        {
            return db.DatesTables.Count(e => e.Id == id) > 0;
        }
    }
}