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
    public class BookService : IRepository<Book>
    {
        private MyDbContext ctx;

        public BookService()
        {
            ctx = new MyDbContext();
        }
        public async Task Create(Book item)
        {
            ctx.Books.Add(item);
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = ctx.Books.FirstOrDefault(s => s.Id == id);
            ctx.Books.Remove(obj);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetList()
        {
            return await ctx.Books.ToListAsync();
        }

        public async Task<Book> GetObject(int id)
        {
            return await ctx.Books.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Save()
        {
            await ctx.SaveChangesAsync();
        }

        public Task Update(Book item)
        {
            ctx.Entry(item).State = EntityState.Modified;
            return ctx.SaveChangesAsync();
        }

    }
}
