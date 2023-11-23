using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
