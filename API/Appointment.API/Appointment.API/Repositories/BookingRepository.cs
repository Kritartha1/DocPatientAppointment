using Appointment.API.Data;
using Appointment.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Appointment.API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppointmentApiDbContext dbContext;

        public BookingRepository(AppointmentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Booking> CreateAsync(Booking booking)
        {
            await dbContext.Bookings.AddAsync(booking);
            await dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> DeleteAsync(DateTime id)
        {
            var existingBooking = await dbContext.Bookings.FirstOrDefaultAsync(x =>x.Id== id);
            if (existingBooking == null) { return null; }

            dbContext.Bookings.Remove(existingBooking);
            await dbContext.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await dbContext.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(DateTime id)
        {
            return await dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Booking?> UpdateAsync(DateTime id, Booking booking)
        {
            var existingBooking = await dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBooking == null) { return null; }

            existingBooking.Id = id;
            existingBooking.User =booking.User;
            existingBooking.Doctor = booking.Doctor;

            await dbContext.SaveChangesAsync();
            return existingBooking;
        }
    }
}
