using System.ComponentModel.DataAnnotations;

namespace API_01.DAL.Models.Dtos.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la película es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres para el nombre es 100.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La duración es obligatoria.")]
        [MaxLength(20, ErrorMessage = "El número máximo de caracteres para la duración es 20.")]
        public string Duration { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clasificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres para la clasificación es 10.")]
        public string Clasification { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

