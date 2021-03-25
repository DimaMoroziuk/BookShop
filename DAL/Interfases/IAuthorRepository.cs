using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfases
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> CreateAuthorAsync(Author item);
        Task<Author> UpdateAuthorAsync(Author item);
        Task DeleteAuthorAsync(int id);
    }
}
