using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Appointment.API.Repositories
{
    public class SlotRepository : ISlotRepository
    {
        private readonly AppointmentApiDbContext dbContext;
        private readonly IBookingRepository bookingRepository;

        public SlotRepository(AppointmentApiDbContext dbContext,IBookingRepository bookingRepository)
        {
            this.dbContext = dbContext;
            this.bookingRepository = bookingRepository;
        }
        public async Task<Slot> CreateAsync(Slot slot)
        {
           
            await dbContext.Slots.AddAsync(slot);
            await dbContext.SaveChangesAsync();
            return slot;
        }

        public async Task<Slot?> DeleteAsync(Guid id)
        {
            var existingSlot = await dbContext.Slots.FirstOrDefaultAsync(x => x.Id == id);
            if (existingSlot == null) { return null; }

            var bookingDomainModel =await bookingRepository.GetByIdAsync(existingSlot.StartTime);
           
            bookingDomainModel.Users.Remove(existingSlot.User);
            bookingDomainModel.Doctors.Remove(existingSlot.Doctor);



            dbContext.Slots.Remove(existingSlot);
            await dbContext.SaveChangesAsync();
            return existingSlot;
        }

        public async Task<List<Slot>> GetAllAsync()
        {
            return await dbContext.Slots.ToListAsync();
        }

        public async Task<Slot?> GetByIdAsync(Guid id)
        {
            return await dbContext.Slots.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Slot?> UpdateAsync(Guid id, Slot slot)
        {
            var existingSlot = await dbContext.Slots.FirstOrDefaultAsync(x => x.Id== id);
            if (existingSlot == null) { return null; }

            existingSlot.Id = id;
            existingSlot.StartTime = slot.StartTime;
            existingSlot.EndTime = slot.EndTime;
            existingSlot.UserId = slot.UserId;
            existingSlot.DoctorId = slot.DoctorId;
            existingSlot.User = slot.User;
            existingSlot.Doctor = slot.Doctor;


            await dbContext.SaveChangesAsync();
            return existingSlot;
        }
    }
}
