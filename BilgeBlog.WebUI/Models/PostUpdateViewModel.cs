using System.ComponentModel.DataAnnotations;

namespace BilgeBlog.WebUI.Models
{
    public class PostUpdateViewModel
    {
        public int Id { get; set; }

        // [] -> Data.Annotation
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık bilgisi girmek zorunlu.")] // hepsinde default olarak bu var. (? konulmazsa)
        public string Title { get; set; }


        [Display(Name = "Özet")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Özet bilgisi girmek zorunlu.")]
        public string Summary { get; set; }


        [Display(Name = "İçerik")]
        [Required(ErrorMessage = "İçerik bilgisi girmek zorunlu.")]
        public string Content { get; set; }


        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori seçilmesi zorunlu.")]
        public int CategoryId { get; set; }

    }
}
