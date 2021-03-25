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
        private readonly IAuthorRepository _authors;
        public AuthorsController(IAuthorRepository authors)
        {
            _authors = authors;
        }

        // GET: api/Authors
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                return (IActionResult)Ok(_authors.GetAllAuthorsAsync());
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
                return (IActionResult)Ok(_authors.GetAuthorAsync(id));

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
                return (IActionResult)Ok(_authors.UpdateAuthorAsync(model));
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

                return (IActionResult)Ok(_authors.CreateAuthorAsync(model));
            }
            catch (Exception exception)
            {
                // todo: add logging 
                return (IActionResult)StatusCode(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
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