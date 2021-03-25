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
    public class AuthorsController : ApiController
    {
        private readonly IRepository<Author> _authorServise;
        public AuthorsController(IRepository<Author> authorServise)
        {
            _authorServise = authorServise ?? throw new ArgumentNullException(nameof(authorServise));
        }

        // GET: api/Authors
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var allBooks = await _authorServise.GetList().ConfigureAwait(false);
                return (IActionResult)Ok(allBooks);
            }
            catch (DbUpdateConcurrencyException)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }

        }

        // GET: api/Authors/5
        [ResponseType(typeof(Author))]
        public async Task<IActionResult> GetAuthor(int id)
        {
            try
            {
                var b = await _authorServise.GetObject(id).ConfigureAwait(false);
                return (IActionResult)Ok(b);

            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }
        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public async Task<IActionResult> UpdateBook(Author model)
        {
            try
            {
                await _authorServise.Update(model).ConfigureAwait(false);
                return (IActionResult)Ok(model.Id);
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public async Task<IActionResult> PostAuthor(Author model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                var created = _authorServise.Create(model);
                return (IActionResult)Ok(created);
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                await _authorServise.Delete(id).ConfigureAwait(false);
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