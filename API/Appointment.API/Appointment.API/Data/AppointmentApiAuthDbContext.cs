using Appointment.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Appointment.API.Data
{
    public class AppointmentApiAuthDbContext : IdentityDbContext
    {
        public AppointmentApiAuthDbContext(DbContextOptions<AppointmentApiAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var userRoleId = "b62bc63a-78f6-4fc3-b2ab-16b0244a222d";
            var doctorRoleId = "3eaa109c-4a46-4cfe-a88c-b96e5f98eea4";
            var adminRoleId = "987c7f4b-3a86-4c16-a2cf-a3f172b63175";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId,
                    Name="User",
                    NormalizedName="User".ToUpper()
                },
                new IdentityRole
                {
                    Id=doctorRoleId,
                    ConcurrencyStamp =doctorRoleId,
                    Name="Doctor",
                    NormalizedName="Doctor".ToUpper()
                },
                new IdentityRole
                {
                    Id=adminRoleId,
                    ConcurrencyStamp =adminRoleId,
                    Name="Admin",
                    NormalizedName="Admin".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

           /* var adminUserId = "7030d237-37df-456c-88dd-63a9871db722";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin123@gmail.com",
                Email = "admin123@gmail.com",
                NormalizedEmail = "admin123@gmail.com".ToUpper(),
                NormalizedUserName = "admin123@gmail.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin123@123");
            builder.Entity<IdentityUser>().HasData(adminUserId);

            var adminRoles = new IdentityUserRole<string>()
            {
                UserId = adminUserId,
                RoleId = adminRoleId,
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);*/

            /* var doctorUserId = "16c3414f-f6c4-4c88-b913-70865cddab63";
             var doctor = new Doctor()
             {
                 Id = doctorUserId,
                 UserName = "admin123@gmail.com",
                 Email = "admin123@gmail.com",
                 NormalizedEmail = "admin123@gmail.com".ToUpper(),
                 NormalizedUserName = "admin123@gmail.com".ToUpper(),
                 Qualifications = "MBBS,MD",
                 Specialization = "Heart specialist",
                 Hospital = "GMCH",
                 Name = "Dr Sins",
                 Fees = 5000
             };

             admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(doctor, "Sins@123");
             builder.Entity<IdentityUser>().HasData(doctorUserId);

             var doctorRoles = new IdentityUserRole<string>()
             {
                 UserId = doctorUserId,
                 RoleId = doctorRoleId,
             };
             builder.Entity<IdentityUserRole<string>>().HasData(doctorRoles);
 */


        }
    }
}
