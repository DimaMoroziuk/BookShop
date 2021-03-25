using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfases
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreAsync(int id);
        Task<Genre> CreateGenreAsync(Genre item);
        Task<Genre> UpdateGenreAsync(Genre item);
        Task DeleteGenreAsync(int id);
    }
}
