using System.Collections.Generic;
using ENTITY;

namespace Tickets.Models
{
    public class UsuarioInputModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
    }
    public class UsuarioViewModel : UsuarioInputModel
    {
        public List<Ticket> Tickets { get; set; }
        public UsuarioViewModel()
        {

        }
        public UsuarioViewModel(Usuario pUsuario)
        {
            Id = pUsuario.Id;
            User = pUsuario.User;
            Nombre = pUsuario.Nombre;
            Tickets = pUsuario.Tickets;
        }
    }
}
