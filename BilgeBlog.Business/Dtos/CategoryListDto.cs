using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Business.Dtos
{
    // 2 -> Controller'a dönülmesi gereken verileri taşıyacak Dto classını tanımladım. (Buradan CategoryService'e gittim.)
    public class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
