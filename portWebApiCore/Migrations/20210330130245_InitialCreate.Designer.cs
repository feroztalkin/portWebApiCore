﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portWebApiCore.DAL;

namespace portWebApiCore.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20210330130245_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("portWebApiCore.Model.dynamicPort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("httpport")
                        .HasColumnType("INTEGER");

                    b.Property<int>("httpsport")
                        .HasColumnType("INTEGER");

                    b.Property<string>("uniqueCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("dynamicPort");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            httpport = 11101,
                            httpsport = 22201,
                            uniqueCode = "Caliber01"
                        },
                        new
                        {
                            Id = 2,
                            httpport = 11102,
                            httpsport = 22202,
                            uniqueCode = "Caliber02"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
