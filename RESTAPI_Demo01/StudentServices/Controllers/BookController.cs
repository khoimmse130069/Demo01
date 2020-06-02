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
using Model;
using StudentServices.Models;

namespace StudentServices.Controllers
{
    public class BookController : ApiController
    {
        private BookStoreEntities ctx;


        //public IHttpActionResult getAllBooks()
        //{
        //    IList<BookViewModel> bookList = null;
        //    using (ctx = new BookStoreEntities())
        //    {
        //        bookList = ctx.Books.Select(book => new BookViewModel()
        //        {
        //            BookId = book.BookId,
        //            Bookname = book.Bookname,
        //            Bookprice = book.Bookprice
        //        }).ToList<BookViewModel>();
        //    }
        //    if (bookList.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(bookList);
        //}

        public IHttpActionResult getBooksByName(string bookName)
        {
            IList<BookViewModel> bookList = null;
            using (ctx = new BookStoreEntities())
            {
                bookList = ctx.Books
                    .Where(book => book.Bookname.ToLower() == bookName.ToLower())
                    //.Where(book => book.Bookprice == )
                    .Select(book => new BookViewModel()
                    {
                        BookId = book.BookId,
                        Bookname = book.Bookname,
                        Bookprice = book.Bookprice
                    }).ToList<BookViewModel>();
            }
            if (bookList.Count == 0)
            {
                return NotFound();
            }
            return Ok(bookList);
        }

        public IQueryable<Books> GetBooks()
        {
            ctx = new BookStoreEntities();
            return ctx.Books;
        }

        // GET: api/BookB/5
        [ResponseType(typeof(Books))]
        public IHttpActionResult GetBooks(int id)
        {
            Books books = ctx.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
    }
}