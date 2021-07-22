using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PreCheckIn.Data;

namespace PreCheckIn.Core.BookingManagement
{
    public class BookingManagement : IBookingManagement
    {
        private ApplicationDbContext _dbContext;

        public BookingManagement(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Response AddBooking(Booking booking)
        {
            if (booking.ArrivalDate > booking.DepartureDate)
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Invalid 'arrival / departure date'."
                };

            string signInToken = Guid.NewGuid().ToString();

            try
            {
                booking.BookedBy = new Guest
                {
                    FirstName = booking.BookedBy.FirstName,
                    LastName = booking.BookedBy.LastName,
                    Email = booking.BookedBy.Email,
                    SignInToken = signInToken
                };

                booking.Timestamp = DateTime.Now;

                _dbContext.Booking.Add(booking);
                _dbContext.SaveChanges();
                return new Response
                {
                    Status = HttpStatusCode.OK,
                    Body = signInToken
                };

            }
            catch
            {
                return new Response()
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Error occurred, please try again."
                };
            }
        }

        public Response GetBookingById(int id)
        {
            throw new NotImplementedException();
        }

        public Response GetBookingByReference(string reference)
        {
            throw new NotImplementedException();
        }
    }
}
