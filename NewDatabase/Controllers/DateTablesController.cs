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
using NewDatabase;

namespace NewDatabase.Controllers
{
    public class DateTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DateTables
        public IQueryable<DateTable> GetDateTables()
        {
            return db.DateTables;
        }

        // GET: api/DateTables/5
        [ResponseType(typeof(DateTable))]
        public IHttpActionResult GetDateTable(int id)
        {
            DateTable dateTable = db.DateTables.Find(id);
            if (dateTable == null)
            {
                return NotFound();
            }

            return Ok(dateTable);
        }

        // PUT: api/DateTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDateTable(int id, DateTable dateTable)
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

            db.DateTables.Add(dateTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dateTable.Id }, dateTable);
        }

        // DELETE: api/DateTables/5
        [ResponseType(typeof(DateTable))]
        public IHttpActionResult DeleteDateTable(int id)
        {
            DateTable dateTable = db.DateTables.Find(id);
            if (dateTable == null)
            {
                return NotFound();
            }

            db.DateTables.Remove(dateTable);
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

        private bool DateTableExists(int id)
        {
            return db.DateTables.Count(e => e.Id == id) > 0;
        }
    }
}