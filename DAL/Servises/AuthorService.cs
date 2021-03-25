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
    public class AuthorService : IRepository<Author>
    {
        private MyDbContext ctx;

        public AuthorService()
        {
            ctx = new MyDbContext();
        }
        public async Task Create(Author item)
        {
            ctx.Authors.Add(item);
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = ctx.Authors.FirstOrDefault(s => s.Id == id);
            ctx.Authors.Remove(obj);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetList()
        {
            return await ctx.Authors.ToListAsync();
        }

        public async Task<Author> GetObject(int id)
        {
            return await ctx.Authors.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Save()
        {
             await ctx.SaveChangesAsync();
        }

        public Task Update(Author item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            return ctx.SaveChangesAsync();
        }

    }
}
