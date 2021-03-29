using DAL.Entities;
using DAL.Interfases;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories

{
    public class BookRepository : IBookRepository
    {
        private readonly MyDbContext _myDbContext;

        public BookRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<Book> CreateBookAsync(Book item)
        {
            _myDbContext.Books.Add(item);
            await _myDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _myDbContext.Books.ToListAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = _myDbContext.Books.FirstOrDefault(s => s.Id == id);
            _myDbContext.Books.Remove(book);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _myDbContext.Books.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Book> UpdateBookAsync(Book item)
        {
            _myDbContext.Entry(item).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return item;
        }
    }
}
