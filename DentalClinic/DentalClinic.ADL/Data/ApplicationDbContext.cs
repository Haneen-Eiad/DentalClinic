using DentalClinic.ADL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Appointment> Appointment {  get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentCategories> EquipmentCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientTreatment> PatientTreatment { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<AppointmentTranslation> AppointmentTranslation { get; set; }
        public DbSet<TreatmentTranslation> TreatmentTranslations { get; set; }


        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");


        }
    }
}
