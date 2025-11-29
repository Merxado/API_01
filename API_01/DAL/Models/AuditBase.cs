using System.ComponentModel.DataAnnotations;

namespace API_01.DAL.Models
{
    public class AuditBase
    {
        [Key] //Clave primaria
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }

        public virtual DateTime? ModifiedDate { get; set; }
    }
}
