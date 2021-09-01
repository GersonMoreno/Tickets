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
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _UsuarioService;
        public IConfiguration Configuration { get; }
        public UsuarioController(TicketsContext _context)
        {
            _UsuarioService = new UsuarioService(_context);
        }
        
        [HttpPost("todos")]
        public ActionResult Gets(int posicionPaginacion)
        {
            var Usuarios = _UsuarioService.Gets(posicionPaginacion).Select(x => new UsuarioViewModel(x));
            return Ok(Usuarios);
        }

        [HttpPost("uno")]
        public ActionResult GetUsuario(int id, int posicionPaginacionTickets)
        {
            var Usuario = _UsuarioService.Get(id, posicionPaginacionTickets);
            return Ok(Usuario);
        }
        
        [HttpPost("guardar")]
        public ActionResult Post(UsuarioInputModel usuariosInput)
        {
            Usuario usuario = MapearUsuario(usuariosInput);
            usuario.Id = 0;
            var Response = _UsuarioService.Save(usuario);
            if (!Response.Equals("¡Se ha guardado con exito!"))
            {
                return BadRequest(Response);
            }
            return Ok(Response);
        }
        private Usuario MapearUsuario(UsuarioInputModel UsuarioInput)
        {
            return new Usuario
            {
                Id = UsuarioInput.Id,
                User = UsuarioInput.User,
                Nombre = UsuarioInput.Nombre,
                Tickets = null

            };
        }
    }
}
