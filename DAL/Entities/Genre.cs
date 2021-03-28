using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Genre
    {
        public Genre()
        {
            this.Books = new HashSet<Book>();
        }
        public int Id { get; set; }

        [MaxLength(100), MinLength(5), Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
