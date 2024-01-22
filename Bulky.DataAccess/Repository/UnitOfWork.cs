using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;


namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork(AppDbContext db) : IUnitOfWork
    {
        public ICategoryRepo Category { get;} = new CategoryRepo(db);

        void IUnitOfWork.Save()
        {
            db.SaveChanges();
        }
    }
}
