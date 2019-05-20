﻿// <auto-generated />
using System;
using BasketManagment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasketManagment.Migrations
{
    [DbContext(typeof(Repository))]
    [Migration("20190520080635_initial-create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketManagment.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<int?>("CustomerId1");

                    b.Property<int?>("ProductId");

                    b.HasKey("BasketId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("ProductId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("BasketManagment.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Dob");

                    b.Property<DateTime>("Dor");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BasketManagment.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BasketId");

                    b.Property<int>("Category");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ProductId");

                    b.HasIndex("BasketId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BasketManagment.Basket", b =>
                {
                    b.HasOne("BasketManagment.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("BasketManagment.Customer")
                        .WithMany("PreviousBaskets")
                        .HasForeignKey("CustomerId1");

                    b.HasOne("BasketManagment.Product")
                        .WithMany("baskets")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("BasketManagment.Customer", b =>
                {
                    b.HasOne("BasketManagment.Customer")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("BasketManagment.Product", b =>
                {
                    b.HasOne("BasketManagment.Basket")
                        .WithMany("Cart")
                        .HasForeignKey("BasketId");
                });
#pragma warning restore 612, 618
        }
    }
}