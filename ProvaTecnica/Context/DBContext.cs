using Microsoft.EntityFrameworkCore;
using ProvaTecnica.Models;

namespace ProvaTecnica.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }







    }
}
