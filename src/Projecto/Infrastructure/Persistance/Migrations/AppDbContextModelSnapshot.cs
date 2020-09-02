﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Projecto.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Projecto.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime?>("UpdatedUtc")
                        .IsConcurrencyToken()
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
