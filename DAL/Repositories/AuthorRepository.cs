using DAL.Entities;
using DAL.Interfases;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MyDbContext _myDbContext;

        public AuthorRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<Author> CreateAuthorAsync(Author item)
        {
            _myDbContext.Authors.Add(item);
            await _myDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _myDbContext.Authors.ToListAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var obj = _myDbContext.Authors.FirstOrDefault(s => s.Id == id);
            _myDbContext.Authors.Remove(obj);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _myDbContext.Authors.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Author> UpdateAuthorAsync(Author item)
        {
            _myDbContext.Entry(item).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return item;
        }

    }
}
