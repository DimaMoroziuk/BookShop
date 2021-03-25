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
    public class GenresController : ApiController
    {
        private readonly IGenreRepository _genres;
        // GET: api/Books
        public GenresController(IGenreRepository genres)
        {
            _genres = genres;
        }

        // GET: api/Genres
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                return (IActionResult)Ok(await _genres.GetAllGenresAsync());
            }
            catch (DbUpdateConcurrencyException)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }

        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public async Task<IActionResult> GetGenre(int id)
        {
            try
            {
                return (IActionResult)Ok(await _genres.GetGenreAsync(id));

            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public async Task<IActionResult> UpdateBook(Genre model)
        {
            try
            {
                return (IActionResult)Ok(await _genres.UpdateGenreAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Genres
        [ResponseType(typeof(Genre))]
        public async Task<IActionResult> PostGenre(Genre model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                return (IActionResult)Ok(await _genres.CreateGenreAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
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