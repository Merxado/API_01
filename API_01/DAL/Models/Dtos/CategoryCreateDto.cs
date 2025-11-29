using System.ComponentModel.DataAnnotations;

namespace API_01.DAL.Models.Dtos.Category
{
    public class CategoryCreateUpdateDto
    {

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio.")]

        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public required string Name { get; set; }  
    }
}
