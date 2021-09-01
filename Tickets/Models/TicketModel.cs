using System;
using ENTITY;

namespace Tickets.Models
{
    public class TicketInputModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Status { get; set; }
    }
    public class TicketViewModel : TicketInputModel
    {
        public Usuario Usuario { get; set; }
        public TicketViewModel()
        {

        }
        public TicketViewModel(Ticket pTicket)
        {
            Id = pTicket.Id;
            UsuarioId = pTicket.UsuarioId;
            FechaCreacion = pTicket.FechaCreacion;
            FechaActualizacion = pTicket.FechaActualizacion;
            Status = pTicket.Status;
            Usuario = pTicket.User;
        }
    }
}
