using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeTrabajoAPI.DBContexts
{
    public class BDTContext : IdentityDbContext<User>
    {
        public DbSet<Career> Careers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public BDTContext(DbContextOptions<BDTContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Career>().HasData(
                new Career
                {
                    CareerId = 1,
                    CareerName = "Ingeniería en Sistemas",
                    CareerType = CareerTypes.Grado,
                },

                new Career
                {
                    CareerId = 2,
                    CareerName = "Tecnicatura en Programación",
                    CareerType = CareerTypes.Tecnicatura,
                });

            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ADMIN_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            string STUDENT_ID = "76895656-8a86-4562-8007-f494db986a04";
            string ROLE_STUDENT_ID = "90112155-6078-4ba1-8561-72a86ee26eb4";

            string ENTERPRISE_ID = "b6057533-f445-484d-9fba-55d31c733ae2";
            string ROLE_ENTERPRISE_ID = "dfcde332-19d2-4078-8deb-72f54818bf20";


            //seed admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ROLE_ADMIN_ID,
                ConcurrencyStamp = ROLE_ADMIN_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Enterprise",
                NormalizedName = "ENTERPRISE",
                Id = ROLE_ENTERPRISE_ID,
                ConcurrencyStamp = ROLE_ENTERPRISE_ID
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                Id = ROLE_STUDENT_ID,
                ConcurrencyStamp = ROLE_STUDENT_ID
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ADMIN_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_STUDENT_ID,
                UserId = STUDENT_ID
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ENTERPRISE_ID,
                UserId = ENTERPRISE_ID
            });

            var appAdmin = new Admin
            {
                Id = ADMIN_ID,
                Email = "administracion@frro.utn.edu.ar",
                NormalizedEmail = "ADMINISTRACION@FRRO.UTN.EDU.AR",
                EmailConfirmed = true,
                FirstName = "Administracion",
                LastName = "Utn",
                UserName = "admin1",
                NormalizedUserName = "ADMIN1"
            };

            PasswordHasher<Admin> ph = new PasswordHasher<Admin>();
            appAdmin.PasswordHash = ph.HashPassword(appAdmin, "MyPassword_?");

            modelBuilder.Entity<Admin>().HasData(appAdmin);

            var appStudent = new Student
            {
                Id = STUDENT_ID,
                Email = "jp@mail.com",
                NormalizedEmail = "JP@MAIL.COM",
                EmailConfirmed = true,
                FileNumber = 456872,
                FirstName = "Juan",
                LastName = "Perez",
                NormalizedUserName = "STUDENT1",
                CareerName = "Tecnicatura en Programación",
                PhoneNumber = "",
                AccountStatus = AccountStatusTypes.Accepted,
                Curriculum = null,
                Cuit = "23382255021",
                CurrentCity = "",
                PersonalId = "",
                Name = "jp@mail.com",
            };

            PasswordHasher<Student> ph2 = new PasswordHasher<Student>();
            appStudent.PasswordHash = ph2.HashPassword(appStudent, "123456789");

            modelBuilder.Entity<Student>().HasData(appStudent);

            var appEnterprise = new Enterprise
            {
                Id = ENTERPRISE_ID,
                FirstName = "Empresa",
                LastName = "Soluciones",
                Email = "empresa@mail.com",
                NormalizedEmail = "EMPRESA@MAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedUserName = "ENTERPRISE1",
                Name = "Soluciones SA",
                Cuit = "3024502563",
                Location = "Rosario",
                AccountStatus = AccountStatusTypes.Accepted,
                Field = "IT",
                Address = "",
                PhoneNumber = "",
                Website = "",
                ContactName = "",
                ContactPosition = "",
                ContactEmail = "",
                ContactPhoneNumber = "",
                EnterpriseRelation = EnterpriseRelationTypes.Member,
                OfferedJobs = new List<JobOffer>(),
            };

            PasswordHasher<Enterprise> ph3 = new PasswordHasher<Enterprise>();
            appEnterprise.PasswordHash = ph3.HashPassword(appEnterprise, "123456789");

            modelBuilder.Entity<Enterprise>().HasData(appEnterprise);

            modelBuilder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = 1,
                    Title = "Fullstack Developer Junior",
                    Description = "Estamos buscando 3 desarrolladores FullStack para nuestra empresa que sepan React, .Net y SQL. Deben ser proactivos y estar dispuestos a aprender cosas nuevas, iran pasando por distintos equipos de desarrollo para aprender como funciona la empresa y poder determinar en cual equipo quedarán asignados.",
                    CreationDate = new DateTime(2022, 9, 23),
                    EndDate = new DateTime(2022, 10, 23),
                    Experience = 1,
                    Active = true,
                    WorkSchedule = "Media jornada",
                    JobType = "Trabajo",
                    JobPostulations = new List<Postulation>(),
                    EnterpriseId = ENTERPRISE_ID,
                    EnterpriseName = "Soluciones SA",
                }
                );

            modelBuilder.Entity<Postulation>().HasData(
               new Postulation
               {
                   Id = 1,
                   Presentation = "Voy con la mejor de las ondas",
                   CreationDate = new DateTime(2022, 9, 23),
                   LinkCV = "Link a CV",
                   StudentId = STUDENT_ID,
                   JobOfferId = 1,
               }
               );

            modelBuilder.Entity<Skill>().HasData(
                new Skill
                {
                    SkillId = 1,
                    SkillName = "C#",
                    Level = "0",
                    StudentId = STUDENT_ID,
                },

               new Skill
               {
                   SkillId = 2,
                   SkillName = "React",
                   Level = "0",
                   StudentId = STUDENT_ID,
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}