using System.Drawing.Imaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Parking.Models;

namespace Parking.Data.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            if (reservation.StartDate < DateTime.Now.ToUniversalTime())
            {
                throw new Exception("The start date cannot be from the past");
            }

            if (reservation.EndDate < reservation.StartDate)
            {
                throw new Exception("The end date cannot be before start date");
            }
            reservation.StartDate = reservation.StartDate.ToUniversalTime();
            reservation.EndDate = reservation.EndDate.ToUniversalTime();
            reservation.ReservationDate = DateTime.Now.ToUniversalTime();
            reservation.IsActive = true;
            reservation.Car = await _context.Cars.FindAsync(reservation.CarId) ?? throw new Exception("Couldn't assign car");
            
            var parkingSlot = await _context.ParkingSlots.FindAsync(reservation.ParkingSlotId) ?? throw new Exception("Couldn't assign parking slot");
            await _context.Entry(parkingSlot).Collection(p => p.Reservations).LoadAsync();
            if (!parkingSlot.IsAvailable(reservation.StartDate, reservation.EndDate))
            {
                throw new Exception("Couldn't assign parking slot - the slot is not available at selected time.");
            }

            reservation.ParkingSlot = parkingSlot;
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllForUser(ApplicationUser user)
        {
            return await _context.Reservations.Where(r => r.UserId == user.Id)
                .Include(r => r.Car)
                .Include(r => r.ParkingSlot)
                .ThenInclude(ps => ps.Parking)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Reservation>> GetAllForParkingSlot(ParkingSlot parkingSlot)
        {
            return await _context.Reservations.Where(r => r.ParkingSlotId == parkingSlot.Id)
                .Include(r => r.User)
                .Include(r => r.Car)
                .Include(r => r.ParkingSlot)
                .ThenInclude(ps => ps.Parking)
                .ToListAsync();
        }
    }
}