using DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=DbShopBooks")
        {
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

    }

}