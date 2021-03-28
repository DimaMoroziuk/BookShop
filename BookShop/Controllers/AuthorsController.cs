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
    public class AuthorsController : ApiController
    {
        private readonly IAuthorRepository _authors;
        public AuthorsController(IAuthorRepository authors)
        {
            _authors = authors;
        }

        // GET: api/Authors
        public async Task<IHttpActionResult> GetAuthors()
        {
            try
            {
                return Ok(await _authors.GetAllAuthorsAsync());
            }
            catch (DbUpdateConcurrencyException)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }

        }

        // GET: api/Authors/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            try
            {
                return Ok(await _authors.GetAuthorAsync(id));

            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }
        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAuthor(Author model)
        {
            try
            {
                return Ok(await _authors.UpdateAuthorAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        [HttpPost]
        public async Task<IHttpActionResult> PostAuthor(Author model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                return Ok(await _authors.CreateAuthorAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        [HttpDelete]
        public async Task DeleteAuthor(int id)
        {
            try
            {
                await _authors.DeleteAuthorAsync(id);

            }
            catch (Exception exception)
            {
                // todo: add logging

            }
        }
    }
}