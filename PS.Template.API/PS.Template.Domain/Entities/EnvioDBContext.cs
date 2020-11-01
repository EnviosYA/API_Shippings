using Microsoft.EntityFrameworkCore;

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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>(entity =>
            {
                entity.HasKey(e => e.IdEnvio);

                entity.Property(e => e.IdEnvio)
                    .HasColumnName("idEnvio");

                entity.Property(e => e.IdDireccionDestino).HasColumnName("idDireccionDestino");

                entity.Property(e => e.IdUserOrigen).HasColumnName("idUserOrigen");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.Property(e => e.IdEstado)
                    .HasColumnName("idEstado")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paquete>(entity =>
            {
                entity.HasKey(e => e.IdPaquete);

                entity.Property(e => e.IdPaquete)
                    .HasColumnName("idPaquete");

                entity.Property(e => e.IdEnvio).HasColumnName("idEnvio");

                entity.HasOne(d => d.EnvioNavigation)
                    .WithMany(p => p.Paquete)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paquete_Envio");

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
                    .HasColumnName("idSucursalPorEnvio");

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

            modelBuilder.Entity<TipoPaquete>(entity =>
            {
                entity.ToTable("TipoPaquete");
                entity.HasData(
                    new TipoPaquete
                    {
                        IdTipoPaquete = 1,
                        Descripcion = "Caja",
                        Valor = 600
                    });
                entity.HasData(
                    new TipoPaquete
                    {
                        IdTipoPaquete = 2,
                        Descripcion = "Bolsin",
                        Valor = 500
                    });
                entity.HasData(
                    new TipoPaquete
                    {
                        IdTipoPaquete = 3,
                        Descripcion = "Carta documento",
                        Valor = 950
                    });
                entity.HasData(
                    new TipoPaquete
                    {
                        IdTipoPaquete = 4,
                        Descripcion = "Telegrama",
                        Valor = 500
                    });
                entity.HasData(
                    new TipoPaquete
                    {
                        IdTipoPaquete = 5,
                        Descripcion = "Carta simple",
                        Valor = 300
                    });
            });

            modelBuilder.Entity<Estado>(entity => {
                entity.ToTable("Estado");
                entity.HasData(
                    new Estado
                    {
                        IdEstado = 1,
                        Descripcion = "Ingreso a la sucursal"
                    });
                entity.HasData(
                    new Estado
                    {
                        IdEstado = 2,
                        Descripcion = "En espera"
                    });
                entity.HasData(
                    new Estado
                    {
                        IdEstado = 3,
                        Descripcion = "Despachado"
                    });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}