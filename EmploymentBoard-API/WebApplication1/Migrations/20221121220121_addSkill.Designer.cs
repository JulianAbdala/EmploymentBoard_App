﻿// <auto-generated />
using System;
using BolsaDeTrabajoAPI.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BolsaDeTrabajoAPI.Migrations
{
    [DbContext(typeof(BDTContext))]
    [Migration("20221121220121_addSkill")]
    partial class addSkill
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Career", b =>
                {
                    b.Property<int>("CareerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CareerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("CareerType")
                        .HasMaxLength(50)
                        .HasColumnType("INTEGER");

                    b.HasKey("CareerId");

                    b.ToTable("Careers");

                    b.HasData(
                        new
                        {
                            CareerId = 1,
                            CareerName = "Ingeniería en Sistemas",
                            CareerType = 1
                        },
                        new
                        {
                            CareerId = 2,
                            CareerName = "Tecnicatura en Programación",
                            CareerType = 0
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EnterpriseId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EnterpriseName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Experience")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkSchedule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnterpriseId");

                    b.HasIndex("StudentId");

                    b.ToTable("JobOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreationDate = new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Estamos buscando 3 desarrolladores FullStack para nuestra empresa que sepan React, .Net y SQL. Deben ser proactivos y estar dispuestos a aprender cosas nuevas, iran pasando por distintos equipos de desarrollo para aprender como funciona la empresa y poder determinar en cual equipo quedarán asignados.",
                            EndDate = new DateTime(2022, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnterpriseId = "b6057533-f445-484d-9fba-55d31c733ae2",
                            EnterpriseName = "Soluciones SA",
                            Experience = 1,
                            JobType = "Trabajo",
                            Title = "Fullstack Developer Junior",
                            WorkSchedule = "Media jornada"
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Postulation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobOfferId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkCV")
                        .HasColumnType("TEXT");

                    b.Property<string>("Presentation")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("StudentId");

                    b.ToTable("Postulations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2022, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobOfferId = 1,
                            LinkCV = "Link a CV",
                            Presentation = "Voy con la mejor de las ondas",
                            StudentId = "76895656-8a86-4562-8007-f494db986a04"
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SkillName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SkillId");

                    b.HasIndex("StudentId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            SkillId = 1,
                            Level = "0",
                            SkillName = "C#",
                            StudentId = "76895656-8a86-4562-8007-f494db986a04"
                        },
                        new
                        {
                            SkillId = 2,
                            Level = "0",
                            SkillName = "React",
                            StudentId = "76895656-8a86-4562-8007-f494db986a04"
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            ConcurrencyStamp = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "dfcde332-19d2-4078-8deb-72f54818bf20",
                            ConcurrencyStamp = "dfcde332-19d2-4078-8deb-72f54818bf20",
                            Name = "Enterprise",
                            NormalizedName = "ENTERPRISE"
                        },
                        new
                        {
                            Id = "90112155-6078-4ba1-8561-72a86ee26eb4",
                            ConcurrencyStamp = "90112155-6078-4ba1-8561-72a86ee26eb4",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6"
                        },
                        new
                        {
                            UserId = "76895656-8a86-4562-8007-f494db986a04",
                            RoleId = "90112155-6078-4ba1-8561-72a86ee26eb4"
                        },
                        new
                        {
                            UserId = "b6057533-f445-484d-9fba-55d31c733ae2",
                            RoleId = "dfcde332-19d2-4078-8deb-72f54818bf20"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Admin", b =>
                {
                    b.HasBaseType("BolsaDeTrabajoAPI.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b13f4dc-9570-4487-9b30-5b53b1539b12",
                            Email = "administracion@frro.utn.edu.ar",
                            EmailConfirmed = true,
                            FirstName = "Administracion",
                            LastName = "Utn",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRACION@FRRO.UTN.EDU.AR",
                            NormalizedUserName = "ADMIN1",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ4smsNEkWUMl/CKupWhsrG5z1f2ykcKRmAYMpCofDu/NB9AfvU6jD9hSiQ3I3ohlg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fe0f2892-ffa8-4c75-8600-7a0518f4f5bd",
                            TwoFactorEnabled = false,
                            UserName = "admin1"
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Enterprise", b =>
                {
                    b.HasBaseType("BolsaDeTrabajoAPI.Entities.User");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Enterprise_AccountStatus");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPosition")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cuit")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Enterprise_Cuit");

                    b.Property<int>("EnterpriseRelation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Enterprise_Name");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Enterprise");

                    b.HasData(
                        new
                        {
                            Id = "b6057533-f445-484d-9fba-55d31c733ae2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "558241e7-6b6a-4b02-bb77-933ed221dd31",
                            Email = "empresa@mail.com",
                            EmailConfirmed = true,
                            FirstName = "Empresa",
                            LastName = "Soluciones",
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPRESA@MAIL.COM",
                            NormalizedUserName = "ENTERPRISE1",
                            PasswordHash = "AQAAAAEAACcQAAAAEGmuxm978UBHsnaQk9lPXsI610F71APU+dMlw7PkD0hLYCte7uQx1P4UoDNEuQgnlA==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "7b96f6dc-b453-4ad6-8b1d-c99df2a98104",
                            TwoFactorEnabled = false,
                            AccountStatus = 0,
                            Address = "",
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhoneNumber = "",
                            ContactPosition = "",
                            Cuit = "3024502563",
                            EnterpriseRelation = 0,
                            Field = "IT",
                            Location = "Rosario",
                            Name = "Soluciones SA",
                            Website = ""
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Student", b =>
                {
                    b.HasBaseType("BolsaDeTrabajoAPI.Entities.User");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CareerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CareerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cuit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Curriculum")
                        .HasColumnType("BLOB");

                    b.Property<int>("FileNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("CareerId");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = "76895656-8a86-4562-8007-f494db986a04",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6e685784-5f40-408c-95f9-57675153453f",
                            Email = "jp@mail.com",
                            EmailConfirmed = true,
                            FirstName = "Juan",
                            LastName = "Perez",
                            LockoutEnabled = false,
                            NormalizedEmail = "JP@MAIL.COM",
                            NormalizedUserName = "STUDENT1",
                            PasswordHash = "AQAAAAEAACcQAAAAECgf1gCyNJY+xqaTj2Pdecz7iHntZQ9oyAR7HYLpBzEbLepWoHKWLv8cPxKEL78NJw==",
                            PhoneNumber = "",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e25498bc-5f47-45fe-875a-5e8156120f3f",
                            TwoFactorEnabled = false,
                            AccountStatus = 0,
                            CareerName = "Tecnicatura en Programación",
                            Cuit = "23382255021",
                            CurrentCity = "",
                            FileNumber = 456872,
                            Name = "jp@mail.com",
                            PersonalId = ""
                        });
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.JobOffer", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.Enterprise", "OffererEnterprise")
                        .WithMany("OfferedJobs")
                        .HasForeignKey("EnterpriseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolsaDeTrabajoAPI.Entities.Student", null)
                        .WithMany("SavedJobs")
                        .HasForeignKey("StudentId");

                    b.Navigation("OffererEnterprise");
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Postulation", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.JobOffer", "JobOfferPostulation")
                        .WithMany("JobPostulations")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolsaDeTrabajoAPI.Entities.Student", "Student")
                        .WithMany("Postulations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOfferPostulation");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Skill", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolsaDeTrabajoAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Student", b =>
                {
                    b.HasOne("BolsaDeTrabajoAPI.Entities.Career", "Career")
                        .WithMany()
                        .HasForeignKey("CareerId");

                    b.Navigation("Career");
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.JobOffer", b =>
                {
                    b.Navigation("JobPostulations");
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Enterprise", b =>
                {
                    b.Navigation("OfferedJobs");
                });

            modelBuilder.Entity("BolsaDeTrabajoAPI.Entities.Student", b =>
                {
                    b.Navigation("Postulations");

                    b.Navigation("SavedJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
