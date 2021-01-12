using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApuestasApi.Models
{
    public partial class ApuestasMContext : DbContext
    {
        public ApuestasMContext()
        {
        }

        public ApuestasMContext(DbContextOptions<ApuestasMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apuestum> Apuesta { get; set; }
        public virtual DbSet<ResultadoApuestum> ResultadoApuesta { get; set; }
        public virtual DbSet<Ruletum> Ruleta { get; set; }
        public virtual DbSet<UsuarioApostador> UsuarioApostadors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS2012;Database=ApuestasM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Apuestum>(entity =>
            {
                entity.Property(e => e.Apuesta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaApuesta).HasColumnType("datetime");

                entity.Property(e => e.ValorApuesta).HasColumnType("money");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Apuesta_UsuarioApostador");
            });

            modelBuilder.Entity<ResultadoApuestum>(entity =>
            {
                entity.HasOne(d => d.IdApuestaGanadoraNavigation)
                    .WithMany(p => p.ResultadoApuesta)
                    .HasForeignKey(d => d.IdApuestaGanadora)
                    .HasConstraintName("FK_ResultadoApuesta_Apuesta");

                entity.HasOne(d => d.IdRuletaNavigation)
                    .WithMany(p => p.ResultadoApuesta)
                    .HasForeignKey(d => d.IdRuleta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResultadoApuesta_Ruleta");
            });

            modelBuilder.Entity<Ruletum>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioApostador>(entity =>
            {
                entity.ToTable("UsuarioApostador");

                entity.Property(e => e.Credito).HasColumnType("money");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
