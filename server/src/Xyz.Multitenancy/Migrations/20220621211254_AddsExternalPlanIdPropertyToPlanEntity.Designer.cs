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
    [Migration("20220621211254_AddsExternalPlanIdPropertyToPlanEntity")]
    partial class AddsExternalPlanIdPropertyToPlanEntity
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
                            Id = new Guid("b03339c7-4f2a-471a-97e9-aedac9ce2b74"),
                            Name = "Localhost"
                        });
                });

            modelBuilder.Entity("Xyz.Core.Entities.Multitenancy.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ExternalPlanId")
                        .HasColumnType("varchar(256)")
                        .HasColumnName("external_plan_id");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("integer")
                        .HasColumnName("max_user_count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<bool>("PaymentRequired")
                        .HasColumnType("boolean")
                        .HasColumnName("payment_required");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("RenewalRate")
                        .IsRequired()
                        .HasColumnType("varchar(24)")
                        .HasColumnName("renewal_rate");

                    b.HasKey("Id")
                        .HasName("pk_plans");

                    b.HasIndex("ExternalPlanId")
                        .IsUnique()
                        .HasDatabaseName("ix_plans_external_plan_id");

                    b.ToTable("plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"),
                            MaxUserCount = 2,
                            Name = "Free",
                            PaymentRequired = false,
                            Price = 0.00m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b8"),
                            MaxUserCount = 5,
                            Name = "Basic",
                            PaymentRequired = true,
                            Price = 10.00m,
                            RenewalRate = "MONTHLY"
                        },
                        new
                        {
                            Id = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b9"),
                            MaxUserCount = 100,
                            Name = "Pro",
                            PaymentRequired = true,
                            Price = 100.00m,
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
                            Id = new Guid("e9effde3-7bcb-432f-82b6-230430f5ce4c"),
                            CompanyId = new Guid("b03339c7-4f2a-471a-97e9-aedac9ce2b74"),
                            ConnectionString = "Server=localhost;Port=5432;Database=xyz_localhost_company;User Id=xyz;Password=password;",
                            DisplayName = "Localhost",
                            DomainNames = "",
                            Guid = "52dbdfe0-84a5-44a6-b139-44b4b3cce8e5",
                            IpAddresses = "",
                            IsActive = false,
                            IsConfigured = false,
                            Name = "localhost",
                            TenantPlanId = new Guid("e0690465-7749-4c4e-a40f-ac6970270045")
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
                            Id = new Guid("e0690465-7749-4c4e-a40f-ac6970270045"),
                            MaxUserCount = 2,
                            PlanId = new Guid("81048da5-948f-4304-a5b2-908ac1ee44b7"),
                            Price = 0.00m,
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
