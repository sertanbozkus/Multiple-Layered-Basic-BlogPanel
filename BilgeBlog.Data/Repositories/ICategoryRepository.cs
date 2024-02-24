using BilgeBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Repositories
{
    public interface ICategoryRepository
    {
        void Add(CategoryEntity entity);


        IQueryable<CategoryEntity> GetAll(Expression<Func<CategoryEntity, bool>> predicate = null );

        //  _categoryRepository.GetAll(x => x.Name.Contains("Tek"))
        // _categoryRepository.GetAll(x => x.Id == 4 || x.Id == 5)
        // _category.Repository.GetAll();
        // null da çalışabilir.

    }
}



