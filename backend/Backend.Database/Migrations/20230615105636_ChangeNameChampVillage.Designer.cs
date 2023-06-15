﻿// <auto-generated />
using Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Business.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230615105636_ChangeNameChampVillage")]
    partial class ChangeNameChampVillage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Common.DAO.LevelMine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DiamondMaxRate")
                        .HasColumnType("integer");

                    b.Property<int>("DiamondRate")
                        .HasColumnType("integer");

                    b.Property<int>("EmeraldMaxRate")
                        .HasColumnType("integer");

                    b.Property<int>("EmeraldRate")
                        .HasColumnType("integer");

                    b.Property<int>("IronMaxRate")
                        .HasColumnType("integer");

                    b.Property<int>("IronRate")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("levelMines");
                });

            modelBuilder.Entity("Backend.Common.DAO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("varchar");

                    b.Property<int>("VillageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("VillageId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Backend.Common.DAO.Village", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Diamonds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(20);

                    b.Property<int>("Emeralds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(10);

                    b.Property<int>("Golems")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Irons")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(30);

                    b.Property<int>("LastUpdate")
                        .HasColumnType("integer");

                    b.Property<int>("LevelHDV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<int>("LevelMineId")
                        .HasColumnType("integer");

                    b.Property<int>("Walls")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("LevelMineId");

                    b.ToTable("villages");
                });

            modelBuilder.Entity("Backend.Common.DAO.User", b =>
                {
                    b.HasOne("Backend.Common.DAO.Village", "Village")
                        .WithMany()
                        .HasForeignKey("VillageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Backend.Common.DAO.Village", b =>
                {
                    b.HasOne("Backend.Common.DAO.LevelMine", "LevelMine")
                        .WithMany()
                        .HasForeignKey("LevelMineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LevelMine");
                });
#pragma warning restore 612, 618
        }
    }
}
