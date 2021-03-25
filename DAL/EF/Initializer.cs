using System.Data.Entity;
namespace DAL.EF
{
    public class Initializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);
        }
    }
}
