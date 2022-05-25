﻿// <auto-generated />
using System;
using CakeShopAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CakeShopAPI.Migrations
{
    [DbContext(typeof(CakeShopDbContext))]
    [Migration("20220517161047_v0.0.6")]
    partial class v006
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CakeShopAPI.Data.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts", "Person");
                });

            modelBuilder.Entity("CakeShopAPI.Data.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers", "Person");
                });

            modelBuilder.Entity("CakeShopAPI.Data.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("InvoiceHeaderguidInvoice")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<int?>("UnitMeasureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceHeaderguidInvoice");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitMeasureId");

                    b.ToTable("InvoiceDetails", "Sales");
                });

            modelBuilder.Entity("CakeShopAPI.Data.InvoiceHeader", b =>
                {
                    b.Property<Guid>("guidInvoice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("int");

                    b.HasKey("guidInvoice");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("InvoiceHeaders", "Sales");
                });

            modelBuilder.Entity("CakeShopAPI.Data.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods", "Sales");
                });

            modelBuilder.Entity("CakeShopAPI.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvgRating")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Photos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products", "Production");
                });

            modelBuilder.Entity("CakeShopAPI.Data.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", "Production");
                });

            modelBuilder.Entity("CakeShopAPI.Data.ProductReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductReviews", "Production");
                });

            modelBuilder.Entity("CakeShopAPI.Data.UnitMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UnitMeasures", "Production");
                });

            modelBuilder.Entity("CakeShopAPI.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users", "Person");
                });

            modelBuilder.Entity("CakeShopAPI.Data.Contact", b =>
                {
                    b.HasOne("CakeShopAPI.Data.Customer", "Customer")
                        .WithOne("Contact")
                        .HasForeignKey("CakeShopAPI.Data.Contact", "ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CakeShopAPI.Data.Customer", b =>
                {
                    b.HasOne("CakeShopAPI.Data.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("CakeShopAPI.Data.Customer", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CakeShopAPI.Data.InvoiceDetail", b =>
                {
                    b.HasOne("CakeShopAPI.Data.InvoiceHeader", "InvoiceHeader")
                        .WithMany()
                        .HasForeignKey("InvoiceHeaderguidInvoice");

                    b.HasOne("CakeShopAPI.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("CakeShopAPI.Data.UnitMeasure", "UnitMeasure")
                        .WithMany()
                        .HasForeignKey("UnitMeasureId");

                    b.Navigation("InvoiceHeader");

                    b.Navigation("Product");

                    b.Navigation("UnitMeasure");
                });

            modelBuilder.Entity("CakeShopAPI.Data.InvoiceHeader", b =>
                {
                    b.HasOne("CakeShopAPI.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("CakeShopAPI.Data.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId");

                    b.Navigation("Customer");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("CakeShopAPI.Data.Product", b =>
                {
                    b.HasOne("CakeShopAPI.Data.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("CakeShopAPI.Data.ProductReview", b =>
                {
                    b.HasOne("CakeShopAPI.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CakeShopAPI.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CakeShopAPI.Data.Customer", b =>
                {
                    b.Navigation("Contact");
                });

            modelBuilder.Entity("CakeShopAPI.Data.User", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
