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

        [Route("api/Book/GetAll")]
        public async Task<IHttpActionResult> GetAllBooks()
        {
            return Ok(await _books.GetAllBooksAsync());
        }

        // GET: api/Books/5
        [Route("api/Book/GetById")]
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            return Ok(await _books.GetBookAsync(id));
        }

        // POST: api/Books\
        [Route("api/Book/AddNew")]
        [ResponseType(typeof(Book))]
        [HttpPost]
        public async Task<IHttpActionResult> PostBook([FromBody] Book model)
        {
            return Ok(await _books.CreateBookAsync(model));
        }

        // DELETE: api/Books/5
        [Route("api/Book/Delete")]
        [ResponseType(typeof(Book))]
        [HttpDelete]
        public async Task DeleteBook(int id)
        {
            await _books.DeleteBookAsync(id);
        }

        [Route("api/Book/Update")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBook(Book model)
        {
            return Ok(await _books.UpdateBookAsync(model));
        }

    }
}