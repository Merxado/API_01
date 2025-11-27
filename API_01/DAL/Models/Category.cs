using API_01.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace API_01.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //Clave primaria
        public string Name { get; set; }
    }
}

