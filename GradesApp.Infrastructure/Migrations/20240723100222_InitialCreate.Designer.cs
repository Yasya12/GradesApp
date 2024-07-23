﻿// <auto-generated />
using System;
using GradesApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GradesApp.Infrastructure.Migrations
{
    [DbContext(typeof(GradesAppDbContext))]
    [Migration("20240723100222_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GradesApp.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28393252-1ff9-48ff-8a11-c574797b71e0"),
                            Email = "john@example.com",
                            FullName = "John Doe",
                            Speciality = "Computer Science",
                            Year = 2
                        },
                        new
                        {
                            Id = new Guid("76c14f2f-0ec6-41a4-a6a4-22b137d817e0"),
                            Email = "jane@example.com",
                            FullName = "Jane Smith",
                            Speciality = "Mathematics",
                            Year = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
