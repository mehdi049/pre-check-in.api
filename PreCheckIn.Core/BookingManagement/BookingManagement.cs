using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PreCheckIn.Core.EmailManagement;
using PreCheckIn.Data;

namespace PreCheckIn.Core.BookingManagement
{
    public class BookingManagement : IBookingManagement
    {
        private ApplicationDbContext _dbContext;

        private EmailManagement.IEmailManagement _sendEmail;

        public BookingManagement(ApplicationDbContext dbContext, EmailManagement.IEmailManagement sendEmail)
        {
            _dbContext = dbContext;
            _sendEmail = sendEmail;
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
            booking.Timestamp = DateTime.Now;

            try
            {
                Booking b = _dbContext.Booking.Where(x => x.Reference.ToLower().Equals(booking.Reference.ToLower()))
                    ?.FirstOrDefault();
                if (b != null)
                    return new Response
                    {
                        Status = HttpStatusCode.BadRequest,
                        Message = "Booking reference already exists."
                    };

                Guest guest = _dbContext.Guest.Where(x => x.Email.ToLower().Equals(booking.BookedBy.Email.ToLower()))?.FirstOrDefault();
                if (guest == null)
                    booking.BookedBy = new Guest
                    {
                        FirstName = booking.BookedBy.FirstName,
                        LastName = booking.BookedBy.LastName,
                        Email = booking.BookedBy.Email,
                        SignInToken = signInToken
                    };
                else
                {
                    booking.GuestId = guest.Id;
                    _dbContext.Entry(booking).State = EntityState.Added;
                }

                _dbContext.Booking.Add(booking);
                _dbContext.SaveChanges();
                string confirmationEmailBody = "Hi " + guest.FirstName + ", <br>" +
                                           "Please click <a href='https://localhost:44386/api/CheckIn/signin/" + signInToken + "' target='_blank'>here</a> to sign in.";

                string message = "";
                if (!_sendEmail.SendConfirmationEmail(guest.Email, confirmationEmailBody))
                    message = "Error occurred when sending a confirmation email.";

                return new Response
                {
                    Status = HttpStatusCode.OK,
                    Body = signInToken,
                    Message = message
                };

            }
            catch (Exception e)
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
