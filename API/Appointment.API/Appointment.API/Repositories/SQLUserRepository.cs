using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Repositories
{
    public class SQLUserRepository: IUserRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public SQLUserRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
        //public async Task<User?> DeleteAsync(Guid id)
        public async Task<User?> DeleteAsync(string id)
        {
            
            
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));  
            if (existingUser == null) { return null; }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;

        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

       //public async Task<User?> GetByIdAsync(Guid id)
        public async Task<User?> GetByIdAsync(string id)
        {
            //return await dbContext.Users.FirstOrDefaultAsync(x => x.Id.Trim().Equals(id, StringComparison.OrdinalIgnoreCase));
            return await dbContext.Users.FirstOrDefaultAsync(x => (x.Id).Equals(id));
           
        }

        //public async Task<User?> UpdateAsync(Guid id, User user)
        public async Task<User?> UpdateAsync(string id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => (x.Id).Equals(id));
            if (existingUser == null) { return null; }

            existingUser.Id = id;
            existingUser.UserName = user.UserName == null ? existingUser.UserName : user.UserName;
            existingUser.Email = user.Email == null ? existingUser.Email : user.Email;
            existingUser.PhoneNumber = user.PhoneNumber == null ? existingUser.PhoneNumber : user.PhoneNumber;
            existingUser.PasswordHash = user.PasswordHash == null ? existingUser.PasswordHash : user.PasswordHash;

            existingUser.Age = user.Age==0?existingUser.Age:user.Age;
            existingUser.Appts=user.Appts==null?null:user.Appts.ToList();
            




            await dbContext.SaveChangesAsync();
            return existingUser;
            
        }
    }
}
