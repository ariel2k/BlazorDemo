﻿// <auto-generated />
using System;
using BlazorDemo.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorDemo.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BlazorDemo.Shared.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnBillboard")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.GenderFilm", b =>
                {
                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("GenderId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("GenderFilms");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.PersonFilm", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("PersonFilms");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.GenderFilm", b =>
                {
                    b.HasOne("BlazorDemo.Shared.Models.Film", "Film")
                        .WithMany("GenderFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorDemo.Shared.Models.Gender", "Gender")
                        .WithMany("GenderFilms")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.PersonFilm", b =>
                {
                    b.HasOne("BlazorDemo.Shared.Models.Film", "Film")
                        .WithMany("PersonFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorDemo.Shared.Models.Person", "Person")
                        .WithMany("PersonFilms")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.Film", b =>
                {
                    b.Navigation("GenderFilms");

                    b.Navigation("PersonFilms");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.Gender", b =>
                {
                    b.Navigation("GenderFilms");
                });

            modelBuilder.Entity("BlazorDemo.Shared.Models.Person", b =>
                {
                    b.Navigation("PersonFilms");
                });
#pragma warning restore 612, 618
        }
    }
}