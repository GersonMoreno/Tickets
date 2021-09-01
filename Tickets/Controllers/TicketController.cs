using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENTITY;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tickets.Models;
using DAL;

namespace Tickets.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly TicketService _TicketService;
        public IConfiguration Configuration { get; }
        public TicketController(TicketsContext _context)
        {
            _TicketService = new TicketService(_context);
        }

        

        // DELETE: api//5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response = _TicketService.Delete(id);
            if (!response.Equals("¡Se elimino el tickect con exito!"))
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(TicketInputModel ticketInput)
        {
            Ticket ticket = MapearTicket(ticketInput);
            ticket.Id = 0;
            var Response = _TicketService.Save(ticket);
            if (!Response.Equals("¡Se ha guardado con exito!"))
            {
                return BadRequest(Response);
            }
            return Ok(Response);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, TicketInputModel ticketInput)
        {
            Ticket ticket = MapearTicket(ticketInput);
            var response = _TicketService.Update(id, ticket);

            if (!response.Equals("¡Se modifico el ticket con exito!"))
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        private Ticket MapearTicket(TicketInputModel ticketInput)
        {
            return new Ticket
            {
                Id = ticketInput.Id,
                User = null,
                FechaCreacion = ticketInput.FechaCreacion,
                FechaActualizacion = ticketInput.FechaActualizacion,
                Status = ticketInput.Status,
                UsuarioId = ticketInput.UsuarioId
                
            };
        }
        

    }
}

