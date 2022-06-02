﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudApi.D_Repository;

namespace crudApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220602014159_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ProductPurchaseOrder", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrdersId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "PurchaseOrdersId");

                    b.HasIndex("PurchaseOrdersId");

                    b.ToTable("ProductPurchaseOrder");
                });

            modelBuilder.Entity("crudApi.C_Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Value")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImgPath = "assets/gopro.jpg",
                            Name = "GoPro Camera",
                            Value = 750.00m
                        },
                        new
                        {
                            Id = 2,
                            ImgPath = "assets/gopro.jpg",
                            Name = "GoPro Camera",
                            Value = 750.00m
                        },
                        new
                        {
                            Id = 3,
                            ImgPath = "assets/headset.jpg",
                            Name = "HeadSet",
                            Value = 55.50m
                        },
                        new
                        {
                            Id = 4,
                            ImgPath = "assets/keyboard.jpg",
                            Name = "Keyboard",
                            Value = 99.99m
                        },
                        new
                        {
                            Id = 5,
                            ImgPath = "assets/laptop.jpg",
                            Name = "Laptop",
                            Value = 1525.00m
                        },
                        new
                        {
                            Id = 6,
                            ImgPath = "assets/mousepad.jpg",
                            Name = "MousePad",
                            Value = 15.50m
                        },
                        new
                        {
                            Id = 7,
                            ImgPath = "assets/webcam.jpg",
                            Name = "webcam",
                            Value = 100.00m
                        });
                });

            modelBuilder.Entity("crudApi.C_Domain.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("IdUserata")
                        .HasColumnType("int");

                    b.Property<string>("StatusDelivery")
                        .HasColumnType("longtext");

                    b.Property<string>("StatusPO")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Total")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalToPay")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("purchaseOrders");
                });

            modelBuilder.Entity("crudApi.C_Domain.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvatarUrl = "",
                            Email = "admin",
                            Name = "Ademir",
                            Password = "admin"
                        });
                });

            modelBuilder.Entity("ProductPurchaseOrder", b =>
                {
                    b.HasOne("crudApi.C_Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("crudApi.C_Domain.PurchaseOrder", null)
                        .WithMany()
                        .HasForeignKey("PurchaseOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}