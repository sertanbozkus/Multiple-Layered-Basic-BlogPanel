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
    public class PostRepository : IPostRepository
    {
        private readonly BilgeBlogContext _db;

        public PostRepository(BilgeBlogContext db)
        {
            _db = db;
        }
        public void AddPost(PostEntity entity)
        {
            _db.Posts.Add(entity);
            _db.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var entity = _db.Posts.Find(id);

            //entity.IsDeleted = true;
            //entity.ModifiedDate = DateTime.Now;
            //_db.Posts.Update(entity);
            //_db.SaveChanges();

            DeletePost(entity);
        }

        public void DeletePost(PostEntity entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            _db.Posts.Update(entity);
            _db.SaveChanges();
            
        }

        public IQueryable<PostEntity> GetAll(Expression<Func<PostEntity, bool>> predicate = null)
        {
            return predicate is not null ? _db.Posts.Where(predicate) : _db.Posts;
        }

        public PostEntity GetPostById(int id)
        {
            var entity = _db.Posts.Find(id);

            return entity;
        }

        public void UpdatePost(PostEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _db.Posts.Update(entity);
            _db.SaveChanges();

           
        }
    }
}
