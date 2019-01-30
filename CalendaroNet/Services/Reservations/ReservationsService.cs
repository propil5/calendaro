using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendaroNet.Data;
using CalendaroNet.Models;
using CalendaroNet.Models.ServiceReservations;
using CalendaroNet.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CalendaroNet.Services.Resevations
{
    public class ReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceReservation[]> GetReservationsForUser(IdentityUser user)
        {
            var reservations = await _context.ServiceReservations
                .Where(x => x.Done == false && x.CustomerId == user.Id)
                .ToArrayAsync();
            return reservations;
        }

        public async Task<ServiceReservation[]> GetReservationsForEmployee(IdentityUser user)
        {
            var reservations = await _context.ServiceReservations
                .Where(x => x.Done == false && x.EmployeeId == user.Id)
                .ToArrayAsync();
            return reservations;
        }

        //public async Task<bool> MarkReservationAsDone(Guid id)
        //{
        //    ar reservations = await _context.ServiceReservations
        //        .Where(x => x.Done == false && x.EmployeeId == user.Id)
        //        .ToArrayAsync();
        //}

        public async Task<bool> AddServiceReservationAsync(ServiceReservation reservation, IdentityUser user)
        {
            reservation.Id = Guid.NewGuid();
            reservation.Done = false;
            reservation.CustomerId = user.Id;

            _context.ServiceReservations.Add(reservation);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }



        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            var item = await _context.Items
                .Where(x => x.Id == id && x.UserId == user.Id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}