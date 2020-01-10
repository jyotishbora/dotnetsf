﻿// <auto-generated />
using System;
using Conference.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confapi.Migrations
{
    [DbContext(typeof(ConferenceDbContext))]
    [Migration("20200110135304_SpeakerModelUpdate")]
    partial class SpeakerModelUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Confapi.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentTimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommenterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Confapi.Data.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpeakerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Track")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Confapi.Data.Entities.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterHandle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Confapi.Data.Entities.Comment", b =>
                {
                    b.HasOne("Confapi.Data.Entities.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("Confapi.Data.Entities.Session", b =>
                {
                    b.HasOne("Confapi.Data.Entities.Speaker", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId");
                });
#pragma warning restore 612, 618
        }
    }
}