using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(100), MinLength(5), Required]
        public string Name { get; set; }
        [MaxLength(100), MinLength(5), Required]
        public string Language { get; set; }
        public int Count { get; set; }
        public bool IsExist { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
