﻿// <auto-generated />
using System;
using LoanBackendIntegration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanBackendIntegration.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20231108084112_add_dob")]
    partial class add_dob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LoanBackendIntegration.Entities.Loan", b =>
                {
                    b.Property<string>("LoanId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("AmountLeft")
                        .HasColumnType("float");

                    b.Property<int>("CreditScore")
                        .HasColumnType("int");

                    b.Property<double>("LoanInterest")
                        .HasColumnType("float");

                    b.Property<double>("LoanPrincipal")
                        .HasColumnType("float");

                    b.Property<DateTime>("LoanRepaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoanTakenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoanType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<double>("Repay")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("LoanId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LoanBackendIntegration.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("CreditScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
