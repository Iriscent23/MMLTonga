﻿// <auto-generated />
using MMLTonga.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MMLTonga.Migrations
{
    [DbContext(typeof(DbRateContext))]
    partial class DbRateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MMLTonga.Models.ExchangeRate", b =>
                {
                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiveRate")
                        .HasColumnType("int");

                    b.Property<int>("SendRate")
                        .HasColumnType("int");

                    b.HasKey("Country");

                    b.ToTable("ExchangeRates");
                });
#pragma warning restore 612, 618
        }
    }
}