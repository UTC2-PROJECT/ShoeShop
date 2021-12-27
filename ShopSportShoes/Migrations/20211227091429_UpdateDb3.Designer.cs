﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using ShopSportShoes.Data;

namespace ShopSportShoes.Migrations
{
    [DbContext(typeof(ShoeShopDbContext))]
    [Migration("20211227091429_UpdateDb3")]
    partial class UpdateDb3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopSportShoes.Models.Evolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("NumberOfStar")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ShoeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("ShoeId");

                    b.HasIndex("UserId");

                    b.ToTable("Evolutions");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ShoeId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("ShoeId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("NUMBER(1)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShopSportShoes.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("IntoMoney")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ShoeId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("ShoeId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("Price")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("ShoeCatalogId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("ShoeCatalogId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("ShopSportShoes.Models.ShoeCatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("ShoeCatalogs");
                });

            modelBuilder.Entity("ShopSportShoes.Models.ShoeSize", b =>
                {
                    b.Property<int>("ShoeId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("SizeId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ShoeId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ShoeSize");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SizeName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("ShopSportShoes.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Evolution", b =>
                {
                    b.HasOne("ShopSportShoes.Models.Shoe", "ShoeNavigation")
                        .WithMany()
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopSportShoes.Models.User", "UserNavigation")
                        .WithMany("EvolutionsNavigation")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoeNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Image", b =>
                {
                    b.HasOne("ShopSportShoes.Models.Shoe", "ShoeNavigation")
                        .WithMany("ImagesNavigation")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoeNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Order", b =>
                {
                    b.HasOne("ShopSportShoes.Models.User", "UserNavigation")
                        .WithMany("OrdersNavigation")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.OrderDetails", b =>
                {
                    b.HasOne("ShopSportShoes.Models.Shoe", "ShoeNavigation")
                        .WithMany()
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoeNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Shoe", b =>
                {
                    b.HasOne("ShopSportShoes.Models.ShoeCatalog", "ShoeCatalogNavigation")
                        .WithMany("ShoesNavigation")
                        .HasForeignKey("ShoeCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoeCatalogNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.ShoeSize", b =>
                {
                    b.HasOne("ShopSportShoes.Models.Shoe", "ShoeNavigation")
                        .WithMany("ShoeSizesNavigation")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopSportShoes.Models.Size", "SizeNavigation")
                        .WithMany("ShoeSizesNavigation")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoeNavigation");

                    b.Navigation("SizeNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Shoe", b =>
                {
                    b.Navigation("ImagesNavigation");

                    b.Navigation("ShoeSizesNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.ShoeCatalog", b =>
                {
                    b.Navigation("ShoesNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.Size", b =>
                {
                    b.Navigation("ShoeSizesNavigation");
                });

            modelBuilder.Entity("ShopSportShoes.Models.User", b =>
                {
                    b.Navigation("EvolutionsNavigation");

                    b.Navigation("OrdersNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
