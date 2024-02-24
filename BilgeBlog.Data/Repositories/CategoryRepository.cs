using BilgeBlog.Data.Context;
using BilgeBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BilgeBlogContext _db;

        public CategoryRepository(BilgeBlogContext db)
        {
            _db = db;
        }

       
        public void Add(CategoryEntity entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public IQueryable<CategoryEntity> GetAll(Expression<Func<CategoryEntity, bool>> predicate = null)
        {
            return predicate is not null ? _db.Categories.Where(predicate) : _db.Categories;

            // .GetAll(x => x.Name.StartsWith('A)).;

            // _db.Categories.Where(x => x.Name.StartsWith('A'));,

            // Yukarıdaki yerine, 
        }
    }
}

