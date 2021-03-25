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


        //Переробити 
        private readonly IRepository<Book> _bookServise;
        // GET: api/Books
        public BooksController(IRepository<Book> bookServise)
        {
            _bookServise = bookServise ?? throw new ArgumentNullException(nameof(bookServise));
        }

        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                //var allBooks = await _bookServise.GetList().ConfigureAwait(false);
                var allBooks = await _bookServise.GetList().ConfigureAwait(false);
                return (IActionResult)Ok(allBooks);
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
                var b = await _bookServise.GetObject(id).ConfigureAwait(false);
                return (IActionResult)Ok(b);

            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IActionResult> PostBook(Book model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                var created = _bookServise.Create(model);
                return (IActionResult)Ok(created);
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookServise.Delete(id).ConfigureAwait(false);
                return (IActionResult)Ok();

            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NoContent);
            }
        }
        [ResponseType(typeof(void))]
        public async Task<IActionResult> UpdateBook(Book model)
        {
            try
            {
                await _bookServise.Update(model).ConfigureAwait(false);
                return (IActionResult)Ok(model.Id);
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return(IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}