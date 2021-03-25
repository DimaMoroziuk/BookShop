using DAL.Entities;
using DAL.Interfases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servises
{
    public class GenreService : IRepository<Genre>
    {
        private MyDbContext ctx;

        public GenreService()
        {
            ctx = new MyDbContext();
        }
        public async Task Create(Genre item)
        {
            ctx.Genres.Add(item);
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = ctx.Genres.FirstOrDefault(s => s.Id == id);
            ctx.Genres.Remove(obj);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetList()
        {
            return await ctx.Genres.ToListAsync();
        }

        public async Task<Genre> GetObject(int id)
        {
            return await ctx.Genres.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Save()
        {
            await ctx.SaveChangesAsync();
        }

        public Task Update(Genre item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            return ctx.SaveChangesAsync();
        }

    }
}
