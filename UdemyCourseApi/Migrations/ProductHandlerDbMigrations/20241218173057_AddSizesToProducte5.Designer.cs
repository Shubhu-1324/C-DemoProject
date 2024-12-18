﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UdemyCourseApi.Data;

#nullable disable

namespace UdemyCourseApi.Migrations.ProductHandlerDbMigrations
{
    [DbContext(typeof(ProductHandlerDb))]
    [Migration("20241218173057_AddSizesToProducte5")]
    partial class AddSizesToProducte5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductProductSize", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SizesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "SizesId");

                    b.HasIndex("SizesId");

                    b.ToTable("ProductProductSizes", (string)null);
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.CartHandler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("CartHandlers");
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea0eedd0-72ba-4b8b-a3ba-c11dcddd67f8"),
                            Name = "Men"
                        },
                        new
                        {
                            Id = new Guid("cc14ba8f-c4d7-452f-ad32-bc396ea0d346"),
                            Name = "Women"
                        },
                        new
                        {
                            Id = new Guid("6dc45eed-2d08-470f-9489-52b33ea86b14"),
                            Name = "Child"
                        });
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Stock")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.ProductImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.ProductSize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductSizes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("833ee945-e6e0-4948-a179-6906ec9f7eda"),
                            Size = "Small"
                        },
                        new
                        {
                            Id = new Guid("efbafc15-9242-4630-8b7e-e10a8c3b8028"),
                            Size = "Medium"
                        },
                        new
                        {
                            Id = new Guid("e95509a3-7ea7-4bbc-9d44-9227c6fadafd"),
                            Size = "Large"
                        },
                        new
                        {
                            Id = new Guid("5842ef55-f6bf-4bbe-9987-c9ff15607877"),
                            Size = "X-Large"
                        });
                });

            modelBuilder.Entity("ProductProductSize", b =>
                {
                    b.HasOne("UdemyCourseApi.Models.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UdemyCourseApi.Models.Domain.ProductSize", null)
                        .WithMany()
                        .HasForeignKey("SizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.Category", b =>
                {
                    b.HasOne("UdemyCourseApi.Models.Domain.Category", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.ProductImages", b =>
                {
                    b.HasOne("UdemyCourseApi.Models.Domain.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("UdemyCourseApi.Models.Domain.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}