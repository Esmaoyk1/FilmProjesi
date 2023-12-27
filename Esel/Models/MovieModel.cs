using System.ComponentModel.DataAnnotations;

namespace Esel.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Film adı alanı boş bırakılamaz!")]
        [StringLength(50, ErrorMessage = "Film adı 50 karakterden uzun olamaz!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Çıkış yılı alanı boş bırakılamaz!")]
        public string ProductionYear { get; set; }
        public string Description { get; set; }
        public string IMDbStar { get; set; }
        public string Yonetmen { get; set; }
        public string Oyuncular { get; set; }

        [Required(ErrorMessage = "Fotoğraf alanı boş bırakılamaz!")]
        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        [Required(ErrorMessage = "Kategori alanı boş bırakılamaz!")]
        public int CategoryId { get; set; }
    }
}
