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

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);  
            if (existingUser == null) { return null; }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;

        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null) { return null; }

            existingUser.Id = id;
            existingUser.Name = user.Name ==null?existingUser.Name:user.Name;
            existingUser.Email = user.Email==null?existingUser.Email:user.Email;
            existingUser.ContactNo = user.ContactNo == null ? existingUser.ContactNo : user.ContactNo;
            existingUser.Password = user.Password == null ? existingUser.Password : user.Password;
            existingUser.Weight = user.Weight == null ? existingUser.Weight : user.Weight;  
            existingUser.ZipCode = user.ZipCode == null ? existingUser.ZipCode : user.ZipCode   ;
            existingUser.Age = user.Age == null ? existingUser.Age : user.Age   ;
            existingUser.BloodGrp = user.BloodGrp==null?existingUser.BloodGrp:user.BloodGrp;  
            existingUser.City = user.City==null?existingUser.City:user.City;
            existingUser.State = user.State == null ? existingUser.State : user.State;
            existingUser.City = user.City == null ? existingUser.City : user.City;
            existingUser.Height = user.Height == null ? existingUser.Height : user.Height;
            existingUser.District = user.District == null ? existingUser.District : user.District;
            

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
