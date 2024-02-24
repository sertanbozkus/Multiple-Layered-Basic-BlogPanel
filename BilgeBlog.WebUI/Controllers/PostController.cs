using BilgeBlog.Business.Dtos;
using BilgeBlog.Business.Services;
using BilgeBlog.Data.Repositories;
using BilgeBlog.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        public PostController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService; 
            _postService = postService;
        }

        // Bütün dependency injectionları tek constructor içerisinde yapıyorum. Çünkü aynı anda tek constructor tetikleyebilirsin.
        public IActionResult List()
        {
            var postDtoList = _postService.GetAll();

            var viewModel = postDtoList.Select(x => new PostListViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                CategoryName = x.CategoryName
            }).ToList();

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _categoryService.GetCategories();
            // 1 -> GetCategories metodunu çağır. (Buradan CategoryListDto'ya gittim.)
            return View();
        }

        [HttpPost]
        public IActionResult Add(PostAddViewModel formData)
        {

            if (!ModelState.IsValid) // Modelim ViewModel'deki data annotation kurallarına uygun değilse
            {
                ViewBag.Categories = _categoryService.GetCategories();
                return View(formData); // gelen formData'yı aynen geri gönderiyorum ki, girdi verileri kaybolmasın.
            }

            var postAddDto = new PostAddDto()
            {
                Title = formData.Title.Trim(),
                Summary = formData.Summary.Trim(),
                Content = formData.Content.Trim(),
                CategoryId = formData.CategoryId
            };

            _postService.AddPost(postAddDto);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var postUpdateDto = _postService.GetPostById(id);

            var postUpdateViewModel = new PostUpdateViewModel()
            {
                Id = postUpdateDto.Id,
                Title = postUpdateDto.Title,
                Summary = postUpdateDto.Summary,
                Content = postUpdateDto.Content,
                CategoryId = postUpdateDto.CategoryId
            };


            ViewBag.Categories = _categoryService.GetCategories();
            return View(postUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Update(PostUpdateViewModel formData)
        {

            if (!ModelState.IsValid) // Modelim ViewModel'deki data annotation kurallarına uygun değilse
            {
                ViewBag.Categories = _categoryService.GetCategories();
                return View(formData); // gelen formData'yı aynen geri gönderiyorum ki, girdi verileri kaybolmasın.
            }

            var postUpdateDto = new PostUpdateDto()
            {
                Id = formData.Id,
                Title = formData.Title,
                Summary = formData.Summary,
                Content = formData.Content,
                CategoryId = formData.CategoryId

            };

            _postService.UpdatePost(postUpdateDto);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);


            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var postDetailDto = _postService.GetPostDetail(id);

            var postDetailViewModel = new PostDetailViewModel()
            {
                Id = postDetailDto.Id,
                Title = postDetailDto.Title,
                Summary = postDetailDto.Summary,
                Content = postDetailDto.Content,

            };

            return View(postDetailViewModel);
        }
    }
}
