using System.Collections.Generic;
using System.Linq;
using ENTITY;
using DAL;

namespace BLL
{
    public class UsuarioService
    {
        private readonly TicketsContext _context;

        public UsuarioService(TicketsContext context)
        {
            _context = context;
        }
        public string Save(Usuario usuario)
        {
            try
            {
                var usuarioBusqueda = _context.Usuario.Find(usuario.Id);
                if (usuarioBusqueda != null)
                {
                    return "¡Error, el usuario ya se encuentra registrado!";
                }
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return "¡Se ha guardado con exito!";
            }
            catch (System.Exception e)
            {

                return "¡Error en la aplicacion! " + e.Message;
            }
        }
        public List<Usuario> Gets(int posicionPaginacion)
        {
            return _context.Usuario.Where(usuario => (usuario.Id >= posicionPaginacion -5 && usuario.Id <= posicionPaginacion)).ToList();

        }
        public Usuario Get(int Id, int posicionPaginacionTickets)
        {
            Usuario usuario = new Usuario();
            usuario = _context.Usuario.Find(Id);
            List<Ticket> tickets = new List<Ticket>();
            if (usuario != null)
            {
                tickets = _context.Ticket.Where(ticket => (ticket.UsuarioId == Id) && 
                (ticket.Id >= posicionPaginacionTickets - 5 && ticket.Id <= posicionPaginacionTickets))
                .Select(ticket => new Ticket()
                {
                    Id = ticket.Id,
                    User = null,
                    UsuarioId = ticket.UsuarioId,
                    FechaCreacion = ticket.FechaCreacion,
                    FechaActualizacion = ticket.FechaActualizacion,
                    Status = ticket.Status
                }).ToList();
            }
            usuario.Tickets = tickets;
            return usuario;
        }
    }
}
