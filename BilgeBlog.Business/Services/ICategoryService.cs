using BilgeBlog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Business.Services
{
    public interface ICategoryService
    {
        void AddCategory(CategoryAddDto categoryAddDto);

        // 3 -> Controllerda tetiklendiğinde geriye CategoryListDto listesi dönecek olan servisimi tanımladım. (Buradan CategoryManager'a gittim.)
        List<CategoryListDto> GetCategories();
    }
}
