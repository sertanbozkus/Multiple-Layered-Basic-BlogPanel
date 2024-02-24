using BilgeBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Context
{
    public class BilgeBlogContext : DbContext
    {
        public BilgeBlogContext(DbContextOptions<BilgeBlogContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PostEntity>().HasQueryFilter(x => x.IsDeleted == false);
            modelBuilder.Entity<CategoryEntity>().HasQueryFilter(x => x.IsDeleted == false);

            // Migration atıldıktan sonra bu proje için çalıştırılan bütün queryler sanki ".Where(x => x.IsDeleted == false)" diye filtrelenmiş gibi çalışacak.


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

        public DbSet<PostEntity> Posts => Set<PostEntity>();

        public DbSet<UserEntity> Users => Set<UserEntity>();

    }
}
