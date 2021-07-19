﻿// <auto-generated />
using System;
using MHP.Books.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MHP.Books.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20210719160954_DatabaseInitial")]
    partial class DatabaseInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MHP.Books.Business.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("SpecificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Illustrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("SpecificationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SpecificationId");

                    b.ToTable("Illustrators");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Specification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OriginallyPublished")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Genre", b =>
                {
                    b.HasOne("MHP.Books.Business.Models.Specification", "Specification")
                        .WithMany("Genres")
                        .HasForeignKey("SpecificationId")
                        .IsRequired();

                    b.Navigation("Specification");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Illustrator", b =>
                {
                    b.HasOne("MHP.Books.Business.Models.Specification", "Specification")
                        .WithMany("Illustrators")
                        .HasForeignKey("SpecificationId")
                        .IsRequired();

                    b.Navigation("Specification");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Specification", b =>
                {
                    b.HasOne("MHP.Books.Business.Models.Book", "Book")
                        .WithMany("Specifications")
                        .HasForeignKey("BookId")
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Book", b =>
                {
                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("MHP.Books.Business.Models.Specification", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Illustrators");
                });
#pragma warning restore 612, 618
        }
    }
}