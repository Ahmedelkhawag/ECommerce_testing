﻿// <auto-generated />
using System;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceAPI.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    [Migration("20241117183501_Mig3")]
    partial class Mig3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerceAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john.doe@example.com",
                            FullName = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jane.smith@example.com",
                            FullName = "Jane Smith"
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            OrderDate = new DateTime(2024, 11, 17, 20, 35, 1, 502, DateTimeKind.Local).AddTicks(8707),
                            TotalAmount = 2300.00m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            OrderDate = new DateTime(2024, 11, 17, 20, 35, 1, 502, DateTimeKind.Local).AddTicks(9160),
                            TotalAmount = 800.00m
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("orderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1,
                            TotalPrice = 1500.00m
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            ProductId = 3,
                            Quantity = 4,
                            TotalPrice = 800.00m
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            ProductId = 2,
                            Quantity = 1,
                            TotalPrice = 800.00m
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Laptop",
                            Price = 1500.00m,
                            StockQuantity = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Smartphone",
                            Price = 800.00m,
                            StockQuantity = 20
                        },
                        new
                        {
                            Id = 3,
                            Name = "Headphones",
                            Price = 200.00m,
                            StockQuantity = 50
                        });
                });

            modelBuilder.Entity("ECommerceAPI.Models.Order", b =>
                {
                    b.HasOne("ECommerceAPI.Models.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("ECommerceAPI.Models.OrderItem", b =>
                {
                    b.HasOne("ECommerceAPI.Models.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceAPI.Models.Product", "product")
                        .WithMany("orederItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Customer", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Order", b =>
                {
                    b.Navigation("orderItems");
                });

            modelBuilder.Entity("ECommerceAPI.Models.Product", b =>
                {
                    b.Navigation("orederItems");
                });
#pragma warning restore 612, 618
        }
    }
}
