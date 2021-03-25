using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfases
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> CreateBookAsync(Book item);
        Task<Book> UpdateBookAsync(Book item);
        Task DeleteBookAsync(int id);
    }
}
