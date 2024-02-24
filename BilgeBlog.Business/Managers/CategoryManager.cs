using BilgeBlog.Business.Dtos;
using BilgeBlog.Business.Services;
using BilgeBlog.Data.Entities;
using BilgeBlog.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Business.Managers
{
    // Bir yapıyı interface üzerinden çağırırsan class'ının constructorının parametre olarak istediği yapıya bağımlılığın olmaz.

    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(CategoryAddDto categoryAddDto)
        {

            var entity = new CategoryEntity()
            {
                Name = categoryAddDto.Name
            };

            _categoryRepository.Add(entity);

                
        }

        // 4 -> Servisimin detay kodlarını yazdım. Repository'deki metodu kullanarak verilerin sql/entity/query hallerini buraya getirdim. İhtiyacım olan verileri filtreleyerek dto listesine çevirdim.
        public List<CategoryListDto> GetCategories()
        {
            var categoriesQuery = _categoryRepository.GetAll().OrderBy(x => x.Name);

            var categoryDtoList = categoriesQuery.Select(x => new CategoryListDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            // Kategoriler tablosundaki her bir veri için "x" bir adet CategoryListDto oluşturdum. dto hangi veri için oluştuysa o veriye ait Id ve Name bilgilerini aktardım ve bu yapıları listeye çevirdim. Ardından bu listeyi controller'a geri döndüm.

            return categoryDtoList;
        }
    }
}
