using GestaoUnica_backend.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoUnica_backend.Models
{
    [Table("Usuarios")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Column("UserName")]
        public string Username { get; set; }

        [MaxLength(100)]
        [Column("Password")]
        public string Password { get; set; }

        [MaxLength(50)]
        [Column("Role")]
        public string Role { get; set; }
    }
}
