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
        public async Task<IHttpActionResult> GetGenres()
        {
            try
            {
                return Ok(await _genres.GetAllGenresAsync());
            }
            catch (DbUpdateConcurrencyException)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }

        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public async Task<IHttpActionResult> GetGenre(int id)
        {
            try
            {
                return Ok(await _genres.GetGenreAsync(id));

            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateBook(Genre model)
        {
            try
            {
                return Ok(await _genres.UpdateGenreAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Genres
        [ResponseType(typeof(Genre))]
        [HttpPost]
        public async Task<IHttpActionResult> PostGenre(Genre model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                return Ok(await _genres.CreateGenreAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
        [HttpDelete]
        public async Task DeleteGenre(int id)
        {
            try
            {
                await _genres.DeleteGenreAsync(id);
                //return (IActionResult)Ok();
            }
            catch (Exception exception)
            {
                // todo: add logging 
                //return (IActionResult)StatusCode(HttpStatusCode.NoContent);
            }
        }

    }
}