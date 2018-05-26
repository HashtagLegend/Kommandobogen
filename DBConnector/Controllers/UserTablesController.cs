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
    public class UserTablesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/UserTables
        public IQueryable<UserTable> GetUserTable()
        {
            return db.UserTable;
        }

        // GET: api/UserTables/5
        [ResponseType(typeof(UserTable))]
        public IHttpActionResult GetUserTable(string id)
        {
            UserTable userTable = db.UserTable.Find(id);
            if (userTable == null)
            {
                return NotFound();
            }

            return Ok(userTable);
        }

        // PUT: api/UserTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserTable(string id, UserTable userTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTable.MaNummer)
            {
                return BadRequest();
            }

            db.Entry(userTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
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

        // POST: api/UserTables
        [ResponseType(typeof(UserTable))]
        public IHttpActionResult PostUserTable(UserTable userTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserTable.Add(userTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserTableExists(userTable.MaNummer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userTable.MaNummer }, userTable);
        }

        // DELETE: api/UserTables/5
        [ResponseType(typeof(UserTable))]
        public IHttpActionResult DeleteUserTable(string id)
        {
            UserTable userTable = db.UserTable.Find(id);
            if (userTable == null)
            {
                return NotFound();
            }

            db.UserTable.Remove(userTable);
            db.SaveChanges();

            return Ok(userTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTableExists(string id)
        {
            return db.UserTable.Count(e => e.MaNummer == id) > 0;
        }
    }
}