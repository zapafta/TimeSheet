﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210710104312_modifyExternalKeys")]
    partial class modifyExternalKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("DataAccess.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NIF")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DataAccess.Models.Colaborador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("DataAccess.Models.ColaboradorXTipoServico", b =>
                {
                    b.Property<Guid>("IdColaborador")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdTipoServico")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("IdColaborador", "IdTipoServico");

                    b.HasIndex("IdTipoServico");

                    b.ToTable("ColaboradorXTipoServico");
                });

            modelBuilder.Entity("DataAccess.Models.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdColaborador")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdLocalizacao")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdTipoServico")
                        .HasColumnType("char(36)");

                    b.Property<string>("Obs")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdColaborador");

                    b.HasIndex("IdLocalizacao");

                    b.HasIndex("IdTipoServico");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("DataAccess.Models.HistoricoLocalizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("HistoricoLocalizacao");
                });

            modelBuilder.Entity("DataAccess.Models.Localizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Localizacao");
                });

            modelBuilder.Entity("DataAccess.Models.TipoServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoServico");
                });

            modelBuilder.Entity("DataAccess.Models.ColaboradorXTipoServico", b =>
                {
                    b.HasOne("DataAccess.Models.Colaborador", "Colaborador")
                        .WithMany("ColaboradorXTipoServico")
                        .HasForeignKey("IdColaborador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("IdTipoServico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("TipoServico");
                });

            modelBuilder.Entity("DataAccess.Models.Evento", b =>
                {
                    b.HasOne("DataAccess.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("IdColaborador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("IdLocalizacao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("IdTipoServico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Colaborador");

                    b.Navigation("Localizacao");

                    b.Navigation("TipoServico");
                });

            modelBuilder.Entity("DataAccess.Models.Colaborador", b =>
                {
                    b.Navigation("ColaboradorXTipoServico");
                });
#pragma warning restore 612, 618
        }
    }
}
