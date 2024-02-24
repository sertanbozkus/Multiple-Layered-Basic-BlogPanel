using BilgeBlog.Business.Dtos;
using BilgeBlog.Business.Services;
using BilgeBlog.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeBlog.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // CategoryController'a her istek atıldığında (içindeki herhangi bir action tetiklendiğinde) bir adet categoryService nesnesi getir. Bunu _categoryService değişkenine ata. Ben gerekli metotları bu değişken üzerinden çağırabileyim.

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddViewModel formData)
        {

            var categoryDto = new CategoryAddDto()
            {
                Name = formData.Name.Trim()
            };

            _categoryService.AddCategory(categoryDto);



            return RedirectToAction("List", "Post");
        }
    }
}
