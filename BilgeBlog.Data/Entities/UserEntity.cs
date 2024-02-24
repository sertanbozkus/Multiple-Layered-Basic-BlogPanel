using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Data.Entities
{
    public class UserEntity: BaseEntity
    {

        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

    }
}
