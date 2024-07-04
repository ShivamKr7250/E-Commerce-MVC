using E_Commerce.DataAccess.Data;
using E_Commerce.DataAccess.Repository.IRepository;
using E_Commerce.Models;

namespace E_Commerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
           _db.Categories.Update(obj);
        }
    }
}
