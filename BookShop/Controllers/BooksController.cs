using DAL.Entities;
using DAL.Interfases;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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

        public async Task<IHttpActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _books.GetAllBooksAsync());
            }
            catch (DbUpdateConcurrencyException)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }

        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            try
            {
                return Ok(await _books.GetBookAsync(id));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Books\
        [ResponseType(typeof(Book))]
        [HttpPost]
        public async Task<IHttpActionResult> PostBook([FromBody] Book model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                return Ok(await _books.CreateBookAsync(model));
            }
            catch (Exception exception)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        [HttpDelete]
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
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBook(Book model)
        {
            try
            {
                return Ok(await _books.UpdateBookAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

    }
}