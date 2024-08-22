﻿// <auto-generated />
using System;
using GraphqlSubscriptionImplement_HangfireJob.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GraphqlSubscriptionImplement_HangfireJob.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240821071650_ReArrangeForiegnkey")]
    partial class ReArrangeForiegnkey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GraphqlSubscriptionImplement_HangfireJob.Models.Attendence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Student_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("TimeIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Timeout")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("studentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("studentId");

                    b.ToTable("attendences");
                });

            modelBuilder.Entity("GraphqlSubscriptionImplement_HangfireJob.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Standard")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("GraphqlSubscriptionImplement_HangfireJob.Models.Attendence", b =>
                {
                    b.HasOne("GraphqlSubscriptionImplement_HangfireJob.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
