using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;


namespace Bulky.DataAccess.Repository;

public class CategoryRepo(AppDbContext db) : Repository<Category>(db), ICategoryRepo
{

    public void Update(Category obj)
    {
        dbSet.Update(obj);
    }
}
