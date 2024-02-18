﻿// <auto-generated />
using System;
using Brewtiful.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Brewtiful.Migrations
{
    [DbContext(typeof(BrewtifulContext))]
    [Migration("20240119135147_Vendor")]
    partial class Vendor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Brewtiful.Models.Caffee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int?>("VendorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VendorID");

                    b.ToTable("Caffee");
                });

            modelBuilder.Entity("Brewtiful.Models.Vendor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Brewtiful.Models.Caffee", b =>
                {
                    b.HasOne("Brewtiful.Models.Vendor", "Vendor")
                        .WithMany("Caffees")
                        .HasForeignKey("VendorID");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Brewtiful.Models.Vendor", b =>
                {
                    b.Navigation("Caffees");
                });
#pragma warning restore 612, 618
        }
    }
}
