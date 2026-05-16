using DentalClinic.ADL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

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


        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
           , IHttpContextAccessor httpContextAccessor
            )
        : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
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

            builder.Entity<Appointment>()
                .HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Patient>()
                .HasIndex(p => p.PatientIdentificationCard)
                .IsUnique();

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.UserIdentificationCard)
                .IsUnique();

            builder.Entity<Supplier>()
                .HasIndex(s => s.SupplierIdentificationCard)
                .IsUnique();

            
            


        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseModel>();

            var CurrentId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

           foreach(var EntityEntry in entries)
            {
                if(EntityEntry.State == EntityState.Added)
                {
                    EntityEntry.Property(x => x.CreatedBy).CurrentValue = CurrentId;
                    EntityEntry.Property(x=>x.CreatedAt).CurrentValue = DateTime.UtcNow;

                }
                else if (EntityEntry.State == EntityState.Modified)
                {
                    EntityEntry.Property(x=>x.UpdatedBy).CurrentValue = CurrentId;
                    EntityEntry.Property(x=>x.UpdatedAt).CurrentValue =DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default )
        {
            var entries = ChangeTracker.Entries<BaseModel>();
            if (_httpContextAccessor.HttpContext != null)
            {
                var CurrentUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                foreach (var EntriesState in entries)
                {
                    if (EntriesState.State == EntityState.Added)
                    {
                        EntriesState.Property(x => x.CreatedBy).CurrentValue = CurrentUser;
                        EntriesState.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                    }
                    else if (EntriesState.State == EntityState.Modified)
                    {
                        EntriesState.Property(x => x.UpdatedBy).CurrentValue = CurrentUser;
                        EntriesState.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
                    }
                }
            }



            return base.SaveChangesAsync(cancellationToken);
        }
    }

   
}
