﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UpdateQ.Data;

namespace UpdateQ.Data.Migrations
{
    [DbContext(typeof(UpdateQContext))]
    [Migration("20180619161356_UpdateInfoNodeSelfRelationship")]
    partial class UpdateInfoNodeSelfRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UpdateQ.Model.InfoNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<Guid>("OwnerId");

                    b.Property<int?>("ParentInfoNodeId");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentInfoNodeId");

                    b.ToTable("InfoNodes");
                });

            modelBuilder.Entity("UpdateQ.Model.TimeSeriesNode", b =>
                {
                    b.Property<Guid>("SensorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InfoNodeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("Type");

                    b.HasKey("SensorId");

                    b.HasIndex("InfoNodeId");

                    b.ToTable("TimeSeriesNodes");
                });

            modelBuilder.Entity("UpdateQ.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UpdateQ.Model.InfoNode", b =>
                {
                    b.HasOne("UpdateQ.Model.User", "Owner")
                        .WithMany("InfoNodes")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UpdateQ.Model.InfoNode", "ParentInfoNode")
                        .WithMany("ChildInfoNodes")
                        .HasForeignKey("ParentInfoNodeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("UpdateQ.Model.TimeSeriesNode", b =>
                {
                    b.HasOne("UpdateQ.Model.InfoNode", "InfoNode")
                        .WithMany("TimeSeriesNodes")
                        .HasForeignKey("InfoNodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}