using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Appointment.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public AddressRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Address> CreateAsync(Address address)
        {
            await dbContext.Addresses.AddAsync(address);
            await dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address?> DeleteAsync(Guid id)
        {
            var existingAddr = await dbContext.Addresses.FirstOrDefaultAsync(x =>x.AddressId == id);
            if (existingAddr == null) { return null; }

            dbContext.Addresses.Remove(existingAddr);
            await dbContext.SaveChangesAsync();
            return existingAddr;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await dbContext.Addresses.ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(Guid id)
        {
            return await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
        }

        public async Task<Address?> UpdateAsync(Guid id, Address address)
        {
            var existingAddress = await dbContext.Addresses.FirstOrDefaultAsync(x => x.AddressId == id);
            if (existingAddress == null) { return null; }

            existingAddress.AddressId = id;
            existingAddress.State=(address.State==null)?existingAddress.State:address.State;    
            existingAddress.City=address.City==null?existingAddress.City:address.City;
            existingAddress.Locality=address.Locality==null?existingAddress.Locality:address.Locality;

            await dbContext.SaveChangesAsync();
            return existingAddress;
        }
    }
}
