using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=DbShopBooks")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

    }

}