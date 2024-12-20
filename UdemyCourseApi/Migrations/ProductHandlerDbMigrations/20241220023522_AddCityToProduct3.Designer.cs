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
    [Migration("20241220023522_AddCityToProduct3")]
    partial class AddCityToProduct3
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
                            Id = new Guid("b0cfed6e-65f4-43e2-8d21-1cae3b34557d"),
                            Name = "Men"
                        },
                        new
                        {
                            Id = new Guid("2dba9d08-4ffb-4a95-9ada-29f146a55e3a"),
                            Name = "Women"
                        },
                        new
                        {
                            Id = new Guid("6081664d-f3f0-4e57-b3ac-796150145330"),
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

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Fabric")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
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

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<int?>("RentalDuration")
                        .HasColumnType("int");

                    b.Property<decimal>("SecurityDeposit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

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
                            Id = new Guid("91766ec7-1efc-44ff-bd36-bffa18e5ef20"),
                            Size = "Small"
                        },
                        new
                        {
                            Id = new Guid("acf1dc39-dc67-4b6d-bdd6-25dd9fcd90d6"),
                            Size = "Medium"
                        },
                        new
                        {
                            Id = new Guid("c001358d-d66e-4563-8f48-1d8bda05e17c"),
                            Size = "Large"
                        },
                        new
                        {
                            Id = new Guid("926f53fe-2591-4872-be84-047c0f6a8d2b"),
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
