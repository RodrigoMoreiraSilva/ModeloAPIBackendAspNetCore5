using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoUnica_backend.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("DataInclusao")]
        public DateTime DataInclusao { get; set; }

        [Required]
        [Column("IdUserInclusao")]
        public int IdUserInclusao { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [Column("IdUserAlteracao")]
        public int IdUserAlteracao { get; set; }

        [MaxLength(200)]
        [Column("Observacao")]
        public string Observacao { get; set; }

        [Required]
        [Column("IsActive")]
        public bool IsActive { get; set; }
    }
}
