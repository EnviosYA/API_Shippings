using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PS.Template.Domain.Entities
{
    public partial class EnvioDBContext : DbContext
    {
        public EnvioDBContext()
        {
        }

        public EnvioDBContext(DbContextOptions<EnvioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Envio> Envio { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Paquete> Paquete { get; set; }
        public virtual DbSet<SucursalPorEnvio> SucursalPorEnvio { get; set; }
        public virtual DbSet<TipoPaquete> TipoPaquete { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=EnvioDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio);

                entity.Property(e => e.IdEnvio)
                    .HasColumnName("idEnvio")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdSucDestino).HasColumnName("idSucDestino");

                entity.Property(e => e.IdSucOrigen).HasColumnName("idSucOrigen");

                entity.Property(e => e.IdUserDestino).HasColumnName("idUserDestino");

                entity.Property(e => e.IdUserOrigen).HasColumnName("idUserOrigen");

                entity.HasOne(d => d.CodPaqueteNavigation)
                    .WithMany(p => p.Envio)
                    .HasForeignKey(d => d.CodPaquete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Envio_Paquete");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paquete>(entity =>
            {
                entity.HasKey(e => e.IdPaquete);

                entity.Property(e => e.IdPaquete)
                    .HasColumnName("idPaquete")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTipoPaquete).HasColumnName("idTipoPaquete");

                entity.HasOne(d => d.IdTipoPaqueteNavigation)
                    .WithMany(p => p.Paquete)
                    .HasForeignKey(d => d.IdTipoPaquete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paquete_TipoPaquete");
            });

            modelBuilder.Entity<SucursalPorEnvio>(entity =>
            {
                entity.HasKey(e => e.IdSucursalPorEnvio);

                entity.Property(e => e.IdSucursalPorEnvio)
                    .HasColumnName("idSucursalPorEnvio")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEnvio).HasColumnName("idEnvio");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.SucursalPorEnvio)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SucursalPorEnvio_Envio");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.SucursalPorEnvio)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SucursalPorEnvio_Estado");
            });

            modelBuilder.Entity<TipoPaquete>(entity =>
            {
                entity.HasKey(e => e.IdTipoPaquete);

                entity.Property(e => e.IdTipoPaquete)
                    .HasColumnName("idTipoPaquete")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
