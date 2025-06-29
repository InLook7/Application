﻿// <auto-generated />
using System;
using DeskBooking.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeskBooking.Infrastructure.Persistence.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250603021136_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DeskBooking.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BookedByEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("BookedByName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("WorkspaceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("WorkspaceTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkspaceTypeId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Workspace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("WorkspaceTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("WorkspaceTypeId");

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.WorkspaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("WorkspaceTypes");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.WorkspaceTypeAmenity", b =>
                {
                    b.Property<int>("WorkspaceTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("AmenityId")
                        .HasColumnType("integer");

                    b.HasKey("WorkspaceTypeId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("WorkspaceTypeAmenities");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Booking", b =>
                {
                    b.HasOne("DeskBooking.Domain.Entities.Workspace", "Workspace")
                        .WithMany("Bookings")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Photo", b =>
                {
                    b.HasOne("DeskBooking.Domain.Entities.WorkspaceType", "WorkspaceType")
                        .WithMany("Photos")
                        .HasForeignKey("WorkspaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkspaceType");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Workspace", b =>
                {
                    b.HasOne("DeskBooking.Domain.Entities.WorkspaceType", "WorkspaceType")
                        .WithMany("Workspaces")
                        .HasForeignKey("WorkspaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkspaceType");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.WorkspaceTypeAmenity", b =>
                {
                    b.HasOne("DeskBooking.Domain.Entities.Amenity", "Amenity")
                        .WithMany("WorkspaceTypeAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeskBooking.Domain.Entities.WorkspaceType", "WorkspaceType")
                        .WithMany("WorkspaceTypeAmenities")
                        .HasForeignKey("WorkspaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("WorkspaceType");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Amenity", b =>
                {
                    b.Navigation("WorkspaceTypeAmenities");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.Workspace", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("DeskBooking.Domain.Entities.WorkspaceType", b =>
                {
                    b.Navigation("Photos");

                    b.Navigation("WorkspaceTypeAmenities");

                    b.Navigation("Workspaces");
                });
#pragma warning restore 612, 618
        }
    }
}
