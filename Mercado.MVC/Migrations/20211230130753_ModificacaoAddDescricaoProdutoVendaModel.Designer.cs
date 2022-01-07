﻿// <auto-generated />
using Mercado.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mercado.MVC.Migrations
{
    [DbContext(typeof(MercadoMVCContext))]
    [Migration("20211230130753_ModificacaoAddDescricaoProdutoVendaModel")]
    partial class ModificacaoAddDescricaoProdutoVendaModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mercado.MVC.Models.CategoriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Mercado.MVC.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DescricaoCategoria")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoUnidade")
                        .HasColumnType("decimal(12,2)");

                    b.Property<double>("QuantidadeProduto")
                        .HasColumnType("float");

                    b.Property<int>("UnidadeDeMedida")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Mercado.MVC.Models.VendaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProduto");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Mercado.MVC.Models.ProdutoModel", b =>
                {
                    b.HasOne("Mercado.MVC.Models.CategoriaModel", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Mercado.MVC.Models.VendaModel", b =>
                {
                    b.HasOne("Mercado.MVC.Models.ProdutoModel", "Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Mercado.MVC.Models.CategoriaModel", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Mercado.MVC.Models.ProdutoModel", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
