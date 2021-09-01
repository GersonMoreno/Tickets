using DAL;
using ENTITY;
using System;

namespace BLL
{
    public class TicketService
    {
        private readonly TicketsContext _context;

        public TicketService(TicketsContext context)
        {
            _context = context;
        }
        public string Save(Ticket ticket)
        {
            try
            {
                var usuarioBusqueda = _context.Ticket.Find(ticket.Id);
                if (usuarioBusqueda != null)
                {
                    return "¡Error, el ticket ya se encuentra registrado!";
                }
                ticket.FechaCreacion = DateTime.Now;
                ticket.FechaActualizacion = DateTime.Now;
                _context.Ticket.Add(ticket);
                _context.SaveChanges();
                return "¡Se ha guardado con exito!";
            }
            catch (System.Exception e)
            {

                return "¡Error en la aplicacion! "+e.Message;
            }
        }
        
        public string Update(int Id, Ticket Ticket)
        {
            try
            {
                var oldTicket = _context.Ticket.Find(Id);
                if (oldTicket != null)
                {
                    oldTicket.Id = Ticket.Id;
                    oldTicket.User = Ticket.User;
                    oldTicket.UsuarioId = Ticket.UsuarioId;
                    oldTicket.FechaActualizacion = DateTime.Now;
                    oldTicket.Status = Ticket.Status;
                    _context.Ticket.Update(oldTicket);
                    _context.SaveChanges();
                    return "¡Se modifico el ticket con exito!";
                }
                return "¡No existe el ticket!";
            }
            catch (Exception e)
            {

                return "¡Error en la aplicacion! " + e.Message;
            }
        }
        public string Delete(int Id)
        {
            try
            {
                var ticket = _context.Ticket.Find(Id);
                if (ticket != null)
                {
                    _context.Ticket.Remove(ticket);
                    _context.SaveChanges();
                    return "¡Se elimino el tickect con exito!";
                }
                return "!El ticket no existo!";
            }
            catch (Exception e)
            {

                return "!Error en la aplicacion! "+e.Message;
            }
        }
    }
}
