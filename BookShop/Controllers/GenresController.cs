﻿using System;
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
        private readonly IRepository<Genre> _genreServise;
        // GET: api/Books
        public GenresController(IRepository<Genre> bookServise)
        {
            _genreServise = bookServise ?? throw new ArgumentNullException(nameof(bookServise));
        }

        // GET: api/Genres
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                //var allBooks = await _bookServise.GetList().ConfigureAwait(false);
                var allGeners = await _genreServise.GetList().ConfigureAwait(false);
                return (IActionResult)Ok(allGeners);
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
                var g = await _genreServise.GetObject(id).ConfigureAwait(false);
                return (IActionResult)Ok(g);

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
                await _genreServise.Update(model).ConfigureAwait(false);
                return (IActionResult)Ok(model.Id);
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

                var created = _genreServise.Create(model);
                return (IActionResult)Ok(created);
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            try
            {
                await _genreServise.Delete(id).ConfigureAwait(false);
                return (IActionResult)Ok();
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NoContent);
            }
        }

    }
}