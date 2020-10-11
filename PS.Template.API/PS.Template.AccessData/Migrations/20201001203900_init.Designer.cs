﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.Template.AccessData;

namespace PS.Template.AccessData.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20201001203900_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PS.Template.Domain.Entities.Envio", b =>
                {
                    b.Property<int>("IdEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idEnvio")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodPaquete")
                        .HasColumnType("int");

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<int>("IdSucDestino")
                        .HasColumnName("idSucDestino")
                        .HasColumnType("int");

                    b.Property<int>("IdSucOrigen")
                        .HasColumnName("idSucOrigen")
                        .HasColumnType("int");

                    b.Property<int>("IdUserDestino")
                        .HasColumnName("idUserDestino")
                        .HasColumnType("int");

                    b.Property<int>("IdUserOrigen")
                        .HasColumnName("idUserOrigen")
                        .HasColumnType("int");

                    b.HasKey("IdEnvio");

                    b.HasIndex("CodPaquete");

                    b.ToTable("Envio");
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .HasColumnName("idEstado")
                        .HasColumnType("int");

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdEstado");

                    b.ToTable("Estado");

                    b.HasData(
                        new
                        {
                            IdEstado = 1,
                            Descripción = "En espera"
                        },
                        new
                        {
                            IdEstado = 2,
                            Descripción = "Despachado"
                        },
                        new
                        {
                            IdEstado = 3,
                            Descripción = "Ingreso a la sucursal"
                        });
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.Paquete", b =>
                {
                    b.Property<int>("IdPaquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idPaquete")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodPaquete")
                        .HasColumnType("int");

                    b.Property<int>("Dimension")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPaquete")
                        .HasColumnName("idTipoPaquete")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("IdPaquete");

                    b.HasIndex("IdTipoPaquete");

                    b.ToTable("Paquete");
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.SucursalPorEnvio", b =>
                {
                    b.Property<int>("IdSucursalPorEnvio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("idSucursalPorEnvio")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("IdEnvio")
                        .HasColumnName("idEnvio")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnName("idEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdSucursal")
                        .HasColumnName("idSucursal")
                        .HasColumnType("int");

                    b.HasKey("IdSucursalPorEnvio");

                    b.HasIndex("IdEnvio");

                    b.HasIndex("IdEstado");

                    b.ToTable("SucursalPorEnvio");
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.TipoPaquete", b =>
                {
                    b.Property<int>("IdTipoPaquete")
                        .HasColumnName("idTipoPaquete")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("IdTipoPaquete");

                    b.ToTable("TipoPaquete");

                    b.HasData(
                        new
                        {
                            IdTipoPaquete = 1,
                            Descripcion = "Caja",
                            Valor = 600
                        },
                        new
                        {
                            IdTipoPaquete = 2,
                            Descripcion = "Bolsin",
                            Valor = 500
                        },
                        new
                        {
                            IdTipoPaquete = 3,
                            Descripcion = "Carta documento",
                            Valor = 950
                        },
                        new
                        {
                            IdTipoPaquete = 4,
                            Descripcion = "Telegrama",
                            Valor = 500
                        },
                        new
                        {
                            IdTipoPaquete = 5,
                            Descripcion = "Carta simple",
                            Valor = 300
                        });
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.Envio", b =>
                {
                    b.HasOne("PS.Template.Domain.Entities.Paquete", "CodPaqueteNavigation")
                        .WithMany("Envio")
                        .HasForeignKey("CodPaquete")
                        .HasConstraintName("FK_Envio_Paquete")
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.Paquete", b =>
                {
                    b.HasOne("PS.Template.Domain.Entities.TipoPaquete", "IdTipoPaqueteNavigation")
                        .WithMany("Paquete")
                        .HasForeignKey("IdTipoPaquete")
                        .HasConstraintName("FK_Paquete_TipoPaquete")
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Template.Domain.Entities.SucursalPorEnvio", b =>
                {
                    b.HasOne("PS.Template.Domain.Entities.Envio", "IdEnvioNavigation")
                        .WithMany("SucursalPorEnvio")
                        .HasForeignKey("IdEnvio")
                        .HasConstraintName("FK_SucursalPorEnvio_Envio")
                        .IsRequired();

                    b.HasOne("PS.Template.Domain.Entities.Estado", "IdEstadoNavigation")
                        .WithMany("SucursalPorEnvio")
                        .HasForeignKey("IdEstado")
                        .HasConstraintName("FK_SucursalPorEnvio_Estado")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
