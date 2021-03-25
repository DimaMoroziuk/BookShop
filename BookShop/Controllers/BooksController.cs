using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using DAL.Entities;
using DAL.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _books;
        // GET: api/Books
        public BooksController(IBookRepository books)
        {
            _books = books;
        }

        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return (IActionResult)Ok(await _books.GetAllBooksAsync());
            }
            catch (DbUpdateConcurrencyException)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }

        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                return (IActionResult)Ok(await _books.GetBookAsync(id));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IActionResult> PostBook([FromBody] Book model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                return (IActionResult)Ok(await _books.CreateBookAsync(model));
            }
            catch (Exception exception)
            {
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task DeleteBook(int id)
        {
            try
            {
                //return (IActionResult)Ok();
                await _books.DeleteBookAsync(id);
            }
            catch (Exception exception)
            {
                // todo: add logging 
               // return (IActionResult)StatusCode(HttpStatusCode.NoContent);
            }
        }
        [ResponseType(typeof(void))]
        public async Task<IActionResult> UpdateBook(Book model)
        {
            try
            {
                return (IActionResult)Ok(await _books.UpdateBookAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return(IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}