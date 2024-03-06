﻿// <auto-generated />
using System;
using CHC.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CHC.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240306134300_Add-Price-Material")]
    partial class AddPriceMaterial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("chc")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CHC.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("fullname");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone_number");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("account", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("AgreementDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("agreement_date");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<double>("FinalOffer")
                        .HasMaxLength(500)
                        .HasColumnType("double precision")
                        .HasColumnName("final_offer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("contract", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("feedback", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Interior", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("interior", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.InteriorDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<Guid>("InteriorId")
                        .HasColumnType("uuid")
                        .HasColumnName("interior_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid")
                        .HasColumnName("material_id");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision")
                        .HasColumnName("total_price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("InteriorId")
                        .IsUnique();

                    b.ToTable("interior_detail", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("material", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Quotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<double>("EstimatePrice")
                        .HasColumnType("double precision")
                        .HasColumnName("estimate_price");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("request_date");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("quotation", "chc");
                });

            modelBuilder.Entity("InteriorDetailMaterial", b =>
                {
                    b.Property<Guid>("InteriorDetailsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaterialsId")
                        .HasColumnType("uuid");

                    b.HasKey("InteriorDetailsId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("interior_detail_material", "chc");
                });

            modelBuilder.Entity("InteriorQuotation", b =>
                {
                    b.Property<Guid>("InteriorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuotationsId")
                        .HasColumnType("uuid");

                    b.HasKey("InteriorsId", "QuotationsId");

                    b.HasIndex("QuotationsId");

                    b.ToTable("quotation_detail", "chc");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Contract", b =>
                {
                    b.HasOne("CHC.Domain.Entities.Account", "Customer")
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Feedback", b =>
                {
                    b.HasOne("CHC.Domain.Entities.Account", "Customer")
                        .WithMany("Feedbacks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CHC.Domain.Entities.InteriorDetail", b =>
                {
                    b.HasOne("CHC.Domain.Entities.Interior", "Interior")
                        .WithOne("InteriorDetail")
                        .HasForeignKey("CHC.Domain.Entities.InteriorDetail", "InteriorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interior");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Quotation", b =>
                {
                    b.HasOne("CHC.Domain.Entities.Account", "Customer")
                        .WithMany("Quotations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("InteriorDetailMaterial", b =>
                {
                    b.HasOne("CHC.Domain.Entities.InteriorDetail", null)
                        .WithMany()
                        .HasForeignKey("InteriorDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHC.Domain.Entities.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InteriorQuotation", b =>
                {
                    b.HasOne("CHC.Domain.Entities.Interior", null)
                        .WithMany()
                        .HasForeignKey("InteriorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHC.Domain.Entities.Quotation", null)
                        .WithMany()
                        .HasForeignKey("QuotationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CHC.Domain.Entities.Account", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Feedbacks");

                    b.Navigation("Quotations");
                });

            modelBuilder.Entity("CHC.Domain.Entities.Interior", b =>
                {
                    b.Navigation("InteriorDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
