using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }


        // Relational Property

        public List<PostEntity> Posts { get; set; }
    }
}
