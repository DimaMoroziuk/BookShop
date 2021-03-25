using DAL.Entities;
using DAL.Interfases;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Servises
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MyDbContext _myDbContext;

        public GenreRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<Genre> CreateGenreAsync(Genre item)
        {
            _myDbContext.Genres.Add(item);
            await _myDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _myDbContext.Genres.ToListAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            var obj = _myDbContext.Authors.FirstOrDefault(s => s.Id == id);
            _myDbContext.Authors.Remove(obj);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<Genre> GetGenreAsync(int id)
        {
            return await _myDbContext.Genres.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Genre> UpdateGenreAsync(Genre item)
        {
            _myDbContext.Entry(item).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return item;
        }
    }
}
