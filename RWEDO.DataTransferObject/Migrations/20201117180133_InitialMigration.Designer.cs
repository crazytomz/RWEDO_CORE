﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RWEDO.DataTransferObject;

namespace RWEDO.DataTransferObject.Migrations
{
    [DbContext(typeof(RWEDODbContext))]
    [Migration("20201117180133_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RWEDO.DataTransferObject.SurveyFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillDate");

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("EstimateDate");

                    b.Property<string>("FollowUpDate");

                    b.Property<int>("Index");

                    b.Property<string>("Insured")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("InsurerID");

                    b.Property<int>("RepairerID");

                    b.HasKey("ID");

                    b.ToTable("SurveyFiles");
                });
#pragma warning restore 612, 618
        }
    }
}