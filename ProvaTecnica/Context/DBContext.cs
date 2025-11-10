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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.ToTable("Agendamento");
                entity.HasKey(e => e.Id).HasName("PK_Agendamento");

                entity.Property(e => e.DataAgendamento).IsRequired();
                entity.Property(e => e.HoraInicio).IsRequired();
                entity.Property(e => e.HoraFim).IsRequired();

                entity.Property(e => e.Cafe).IsRequired();
                entity.Property(e => e.CafeQuantidade).IsRequired();
                entity.Property(e => e.CafeDescricao).HasMaxLength(500).IsRequired();
                entity.Property(e => e.Responsavel).HasMaxLength(50).IsRequired();

                entity.Property(e => e.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Sala).WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.SalaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamento_Sala");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");
                entity.HasKey(e => e.Id).HasName("PK_Sala");

                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Ativo).HasDefaultValue(true).IsRequired();

                entity.Property(e => e.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
