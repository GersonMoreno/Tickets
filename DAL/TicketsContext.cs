using ENTITY;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TicketsContext : DbContext
    {
        public TicketsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
    }
}
