using System.ComponentModel.DataAnnotations;

namespace API_01.DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Duration { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string Clasification { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

