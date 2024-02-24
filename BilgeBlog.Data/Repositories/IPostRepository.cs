using BilgeBlog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Repositories
{
    public interface IPostRepository
    {
        void AddPost(PostEntity entity);

        IQueryable<PostEntity> GetAll(Expression<Func<PostEntity, bool>> predicate = null);
        // Geriye List dönülürse sonradan yapılan .Select - .OrderBy gibi işlemleri ilave edemeyiz. Fakat Query olarak dönülürse ilave yapılabilir.

        void DeletePost(int id);

        void DeletePost(PostEntity entity);

        PostEntity GetPostById(int id);

        void UpdatePost(PostEntity entity); 

    }
}
