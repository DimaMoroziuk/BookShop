using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Initializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);
            context.Authors.Add(new Author() { Name = "Dale", Surname = "Carnegi", Country = "USA" });
            //context.SaveChangesAsync();
            context.Genres.Add(new Genre() { Name = "Self Development" });
            //context.SaveChangesAsync();
            context.Books.Add(new Book() { Name = "How to Win Friends", GenreId = 1, AuthorId = 1, Count = 20, IsExist = true });
            //context.SaveChangesAsync();
            context.Books.Add(new Book() { Name = "How to Stop Worrying and Start Living", GenreId = 1, AuthorId = 1, Count = 20, IsExist = true });
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
