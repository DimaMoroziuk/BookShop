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
        [Route("api/Author/GetAll")]
        public async Task<IHttpActionResult> GetAuthors()
        {
            return Ok(await _authors.GetAllAuthorsAsync());
        }

        // GET: api/Authors/5
        [Route("api/Author/GetById")]
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            return Ok(await _authors.GetAuthorAsync(id));
        }
        // PUT: api/Authors/5
        [Route("api/Author/Update")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAuthor(Author model)
        {
            return Ok(await _authors.UpdateAuthorAsync(model));
        }

        // POST: api/Authors
        [Route("api/Author/AddNew")]
        [ResponseType(typeof(Author))]
        [HttpPost]
        public async Task<IHttpActionResult> PostAuthor(Author model)
        {
            return Ok(await _authors.CreateAuthorAsync(model));
        }

        // DELETE: api/Authors/5
        [Route("api/Author/Delete")]
        [ResponseType(typeof(Author))]
        [HttpDelete]
        public async Task DeleteAuthor(int id)
        {
            await _authors.DeleteAuthorAsync(id);
        }
    }
}