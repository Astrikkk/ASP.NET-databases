﻿// <auto-generated />
using ASPNET_databases.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPNET_databases.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20240325053109_init3")]
    partial class init3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASPNET_databases.Data.Enities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Artilery"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Light tank"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Medium tank"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Heavy tank"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Anti Air"
                        },
                        new
                        {
                            Id = 6,
                            Name = "SAU"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Armored Vehicle"
                        });
                });

            modelBuilder.Entity("ASPNET_databases.Data.Enities.Tank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Tanks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 4,
                            ImageUrl = "https://static.wikia.nocookie.net/warrior/images/9/99/%D0%9C%D0%B0%D1%83%D1%81.jpg/revision/latest?cb=20161026163157&path-prefix=ru",
                            InStock = false,
                            Mileage = 300000m,
                            Name = "Mous",
                            Price = 62000000m
                        },
                        new
                        {
                            Id = 2,
                            ClassId = 6,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIFoboNP10mBMf2M8iP5Oobk33BPO-D8Xnbg&usqp=CAU",
                            InStock = false,
                            Mileage = 50000m,
                            Name = "FV 4005",
                            Price = 5500000m
                        },
                        new
                        {
                            Id = 3,
                            ClassId = 4,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSd4pM8QXXE0pDnHCzYlFzo00Do0OM-Ji1QTw&usqp=CAU",
                            InStock = false,
                            Mileage = 1235600m,
                            Name = "Tiger 2 H",
                            Price = 3400000m
                        },
                        new
                        {
                            Id = 4,
                            ClassId = 3,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIVy6NiR6fNrBU4hUpEAJ8Rz4M8rKz4B1eVA&usqp=CAU",
                            InStock = false,
                            Mileage = 230435m,
                            Name = "M4A3E2",
                            Price = 1800400m
                        },
                        new
                        {
                            Id = 5,
                            ClassId = 6,
                            ImageUrl = "https://tankhistoria.com/wp-content/uploads/2022/05/Alkett-Factory-March-9th-1942.jpg",
                            InStock = false,
                            Mileage = 300000m,
                            Name = "Sturer Emil",
                            Price = 650000m
                        },
                        new
                        {
                            Id = 6,
                            ClassId = 1,
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHWf6GAXSoEUnSGyN5yErH3cdzeULJv5CIgA&usqp=CAU",
                            InStock = false,
                            Mileage = 350m,
                            Name = "Heavy Gustav",
                            Price = 5000000m
                        });
                });

            modelBuilder.Entity("ASPNET_databases.Data.Enities.Tank", b =>
                {
                    b.HasOne("ASPNET_databases.Data.Enities.Class", "Class")
                        .WithMany("Products")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("ASPNET_databases.Data.Enities.Class", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
