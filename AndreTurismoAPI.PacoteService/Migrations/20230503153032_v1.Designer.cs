﻿// <auto-generated />
using System;
using AndreTurismoAPI.PacoteService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AndreTurismoAPI.PacoteService.Migrations
{
    [DbContext(typeof(AndreTurismoAPIPacoteServiceContext))]
    [Migration("20230503153032_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AndreTurismoAPI.Models.Cidade", b =>
                {
                    b.Property<int>("IdCidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCidade"), 1L, 1);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCidade");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoIdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("EnderecoIdEndereco");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEndereco"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CidadeIdCidade")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("IdEndereco");

                    b.HasIndex("CidadeIdCidade");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Hotel", b =>
                {
                    b.Property<int>("IdHotel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHotel"), 1L, 1);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnderecoIdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdHotel");

                    b.HasIndex("EnderecoIdEndereco");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Pacote", b =>
                {
                    b.Property<int>("IdPacote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPacote"), 1L, 1);

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelIdHotel")
                        .HasColumnType("int");

                    b.Property<int>("PassagemIdPassagem")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPacote");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("HotelIdHotel");

                    b.HasIndex("PassagemIdPassagem");

                    b.ToTable("Pacote");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Passagem", b =>
                {
                    b.Property<int>("IdPassagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPassagem"), 1L, 1);

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinoIdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("OrigemIdEndereco")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPassagem");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("DestinoIdEndereco");

                    b.HasIndex("OrigemIdEndereco");

                    b.ToTable("Passagem");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Cliente", b =>
                {
                    b.HasOne("AndreTurismoAPI.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoIdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Endereco", b =>
                {
                    b.HasOne("AndreTurismoAPI.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeIdCidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Hotel", b =>
                {
                    b.HasOne("AndreTurismoAPI.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoIdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Pacote", b =>
                {
                    b.HasOne("AndreTurismoAPI.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndreTurismoAPI.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelIdHotel")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndreTurismoAPI.Models.Passagem", "Passagem")
                        .WithMany()
                        .HasForeignKey("PassagemIdPassagem")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Hotel");

                    b.Navigation("Passagem");
                });

            modelBuilder.Entity("AndreTurismoAPI.Models.Passagem", b =>
                {
                    b.HasOne("AndreTurismoAPI.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndreTurismoAPI.Models.Endereco", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoIdEndereco")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndreTurismoAPI.Models.Endereco", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemIdEndereco")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });
#pragma warning restore 612, 618
        }
    }
}
