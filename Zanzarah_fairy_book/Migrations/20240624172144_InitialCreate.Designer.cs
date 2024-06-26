﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zanzarah_fairy_book;

#nullable disable

namespace Zanzarah_fairy_book.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240624172144_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.20");

            modelBuilder.Entity("Zanzarah_fairy_book.Models.Fairy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanEvolve")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dexterity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Element")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EvolveFormId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EvolveLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JumpAbility")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Special")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EvolveFormId");

                    b.ToTable("Fairies");
                });

            modelBuilder.Entity("Zanzarah_fairy_book.Models.Fairy", b =>
                {
                    b.HasOne("Zanzarah_fairy_book.Models.Fairy", "EvolveForm")
                        .WithMany()
                        .HasForeignKey("EvolveFormId");

                    b.Navigation("EvolveForm");
                });
#pragma warning restore 612, 618
        }
    }
}
