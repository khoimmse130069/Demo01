//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using Model;

//namespace StudentServices.Controllers
//{
//    public class BookBController : ApiController
//    {
//        private BookStoreEntities db = new BookStoreEntities();

//        // GET: api/BookB
//        public IQueryable<Books> GetBooks()
//        {
//            return db.Books;
//        }

//        // GET: api/BookB/5
//        [ResponseType(typeof(Books))]
//        public IHttpActionResult GetBooks(int id)
//        {
//            Books books = db.Books.Find(id);
//            if (books == null)
//            {
//                return NotFound();
//            }

//            return Ok(books);
//        }

//        // PUT: api/BookB/5
//        [ResponseType(typeof(void))]
//        public IHttpActionResult PutBooks(int id, Books books)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != books.BookId)
//            {
//                return BadRequest();
//            }

//            db.Entry(books).State = EntityState.Modified;

//            try
//            {
//                db.SaveChanges();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!BooksExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/BookB
//        [ResponseType(typeof(Books))]
//        public IHttpActionResult PostBooks(Books books)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.Books.Add(books);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = books.BookId }, books);
//        }

//        // DELETE: api/BookB/5
//        [ResponseType(typeof(Books))]
//        public IHttpActionResult DeleteBooks(int id)
//        {
//            Books books = db.Books.Find(id);
//            if (books == null)
//            {
//                return NotFound();
//            }

//            db.Books.Remove(books);
//            db.SaveChanges();

//            return Ok(books);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool BooksExists(int id)
//        {
//            return db.Books.Count(e => e.BookId == id) > 0;
//        }
//    }
//}