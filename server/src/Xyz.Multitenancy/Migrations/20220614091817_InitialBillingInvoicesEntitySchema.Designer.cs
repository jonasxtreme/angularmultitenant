﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Xyz.Multitenancy.Data;

#nullable disable

namespace Xyz.Multitenancy.Migrations
{
    [DbContext(typeof(MultitenancyDbContext))]
    [Migration("20220614091817_InitialBillingInvoicesEntitySchema")]
    partial class InitialBillingInvoicesEntitySchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.BillingInvoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("DeleteOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delete_on")
                        .HasColumnOrder(3);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("status");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_id");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("transaction_date");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_on")
                        .HasColumnOrder(2);

                    b.HasKey("Id")
                        .HasName("pk_billing_invoices");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("ix_billing_invoices_tenant_id");

                    b.ToTable("billing_invoices", (string)null);
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f9d180c4-cf23-41be-a467-25b88b67cbd0"),
                            Name = "Localhost"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_user_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("RenewalRate")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("renewal_rate");

                    b.HasKey("Id")
                        .HasName("pk_plans");

                    b.ToTable("plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("eaeb5455-d1c0-49cf-99ee-a24364babe23"),
                            MaxUserCount = 5,
                            Name = "Free",
                            Price = 0.00m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("4d46efc2-2687-4b68-ac82-65bd5803eeac"),
                            MaxUserCount = 10,
                            Name = "Basic",
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<string>("ConnectionString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("connection_string");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("display_name");

                    b.Property<string>("DomainNames")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("domain_names");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("guid");

                    b.Property<string>("IpAddresses")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ip_addresses");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsConfigured")
                        .HasColumnType("boolean")
                        .HasColumnName("is_configured");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("TenantPlanId")
                        .HasColumnType("uuid")
                        .HasColumnName("tenant_plan_id");

                    b.HasKey("Id")
                        .HasName("pk_tenants");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_tenants_company_id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_tenants_name");

                    b.HasIndex("TenantPlanId")
                        .IsUnique()
                        .HasDatabaseName("ix_tenants_tenant_plan_id");

                    b.ToTable("tenants", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3251f41-a601-41fc-b77b-29806107352f"),
                            CompanyId = new Guid("f9d180c4-cf23-41be-a467-25b88b67cbd0"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;",
                            DisplayName = "Localhost",
                            DomainNames = "",
                            Guid = "3cc2caa4-7a1a-471b-8f50-b317ce8456fb",
                            IpAddresses = "",
                            IsActive = false,
                            IsConfigured = false,
                            Name = "localhost",
                            TenantPlanId = new Guid("642682f4-23c5-48db-8d74-81a473507284")
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_user_count");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid")
                        .HasColumnName("plan_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("RenewalRate")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("renewal_rate");

                    b.HasKey("Id")
                        .HasName("pk_tenant_plans");

                    b.HasIndex("PlanId")
                        .HasDatabaseName("ix_tenant_plans_plan_id");

                    b.ToTable("tenant_plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("642682f4-23c5-48db-8d74-81a473507284"),
                            MaxUserCount = 10,
                            PlanId = new Guid("4d46efc2-2687-4b68-ac82-65bd5803eeac"),
                            Price = 0m,
                            RenewalRate = "MONTHLY"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.BillingInvoice", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_billing_invoices_tenants_tenant_id");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Tenant", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Company", "Company")
                        .WithMany("Tenants")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_companies_company_id");

                    b.HasOne("Xyz.Core.Entities.Multitenancy.TenantPlan", "TenantPlan")
                        .WithOne("Tenant")
                        .HasForeignKey("Xyz.Core.Entities.Multitenancy.Tenant", "TenantPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenants_tenant_plans_tenant_plan_id");

                    b.Navigation("Company");

                    b.Navigation("TenantPlan");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.HasOne("Xyz.Core.Entities.Multitenancy.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tenant_plans_plans_plan_id");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Company", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.TenantPlan", b =>
                {
                    b.Navigation("Tenant")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}