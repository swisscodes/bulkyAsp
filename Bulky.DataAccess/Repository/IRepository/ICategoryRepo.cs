using Bulky.Models.Models;

namespace Bulky.DataAccess.Repository.IRepository;

public interface ICategoryRepo : IRepository<Category>
{
    void Update(Category obj);
}
