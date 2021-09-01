using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENTITY
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public List<Ticket> Tickets { get; set; }
        
    }
}