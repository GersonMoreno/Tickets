using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITY
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public Usuario User { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Status { get; set; }
    }
}
