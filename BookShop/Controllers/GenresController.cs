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
    public class GenresController : ApiController
    {
        private readonly IGenreRepository _genres;
        // GET: api/Books
        public GenresController(IGenreRepository genres)
        {
            _genres = genres;
        }

        // GET: api/Genres
        [Route("api/Genre/GetAll")]
        public async Task<IHttpActionResult> GetGenres()
        {
            return Ok(await _genres.GetAllGenresAsync());
        }

        // GET: api/Genres/5
        [Route("api/Genre/GetById")]
        [ResponseType(typeof(Genre))]
        public async Task<IHttpActionResult> GetGenre(int id)
        {
            return Ok(await _genres.GetGenreAsync(id));
        }

        // PUT: api/Genres/5
        [Route("api/Genre/Update")]
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBook(Genre model)
        {
            return Ok(await _genres.UpdateGenreAsync(model));
        }

        // POST: api/Genres
        [Route("api/Genre/AddNew")]
        [ResponseType(typeof(Genre))]
        [HttpPost]
        public async Task<IHttpActionResult> PostGenre(Genre model)
        {
            return Ok(await _genres.CreateGenreAsync(model));
        }

        // DELETE: api/Genres/5
        [Route("api/Genre/Delete")]
        [ResponseType(typeof(Genre))]
        [HttpDelete]
        public async Task DeleteGenre(int id)
        {
            await _genres.DeleteGenreAsync(id);
        }

    }
}