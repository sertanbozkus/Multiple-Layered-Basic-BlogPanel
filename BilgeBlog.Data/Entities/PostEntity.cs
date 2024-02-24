using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }

        // Relational Property
        public CategoryEntity Category { get; set; }
    }
}
