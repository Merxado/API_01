using System.ComponentModel.DataAnnotations;

namespace API_01.DAL.Models.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]

        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; } 
        public DateTime CreateDate{ get; set; }
        public DateTime ModifiedDate{ get; set; }
    }
}
