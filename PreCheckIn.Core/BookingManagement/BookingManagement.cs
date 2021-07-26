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
using PreCheckIn.Data.Models;

namespace PreCheckIn.Core.BookingManagement
{
    public class BookingManagement : IBookingManagement
    {
        private ApplicationDbContext _dbContext;

        private IEmailManagement _sendEmail;

        public BookingManagement(ApplicationDbContext dbContext, IEmailManagement sendEmail)
        {
            _dbContext = dbContext;
            _sendEmail = sendEmail;
        }

        public Response AddBooking(Booking booking)
        {
            if (booking.Rooms == null || booking.Rooms.Count == 0)
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Room(s) information is required."
                };

            foreach (var room in booking.Rooms)
                if (room.ArrivalDate > room.DepartureDate)
                    return new Response
                    {
                        Status = HttpStatusCode.BadRequest,
                        Message = "Invalid Arrival / Departure date for the room " + room.RoomNumber + "."
                    };

            if (_dbContext.BookingStatus.Find(1) == null)
                _dbContext.BookingStatus.Add(new BookingStatus()
                {
                    Status = "Pending"
                });
            if (_dbContext.BookingStatus.Find(2) == null)
                _dbContext.BookingStatus.Add(new BookingStatus()
                {
                    Status = "Confirmed"
                });
            _dbContext.SaveChanges();

            string bookingToken = Guid.NewGuid().ToString();
            booking.Token = bookingToken;
            booking.LastStatusUpdate = DateTime.Now;
            booking.StatusId = 1;

            try
            {
                Booking b = _dbContext.Booking.Where(x => x.BookingReference.ToLower().Equals(booking.BookingReference.ToLower()))
                    ?.FirstOrDefault();
                if (b != null)
                    return new Response
                    {
                        Status = HttpStatusCode.BadRequest,
                        Message = "Booking reference already exists."
                    };

                Guest bookedBy = booking.Rooms[0].Guests[0];

                _dbContext.Booking.Add(booking);
                _dbContext.SaveChanges();
                string confirmationEmailBody = "Hi " + bookedBy.FirstName + ", <br>" +
                                           "Please click <a href='https://localhost:44386/api/CheckIn/signin/" + bookingToken + "' target='_blank'>here</a> to sign in.";

                string message = "";
                if (!_sendEmail.SendConfirmationEmail(bookedBy.Email, confirmationEmailBody))
                    message = "Error occurred when sending a confirmation email.";

                return new Response
                {
                    Status = HttpStatusCode.OK,
                    Body = bookingToken,
                    Message = message
                };

            }
            catch (Exception e)
            {
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Error occurred, please try again."
                };
            }
        }

        public Booking GetBookingByReference(string reference)
        {
            Booking booking = _dbContext.Booking
                .Include(x => x.BookingAdds)
                .Include(x => x.InvoiceAddress)
                .Include(x => x.Status)
                .Where(x => x.BookingReference.ToLower().Equals(reference.ToLower())
                )?.FirstOrDefault();

            if (booking != null)
            {
                List<Room> rooms = _dbContext.Room
                    .Include(x => x.Guests)
                    .Include(x => x.Rates)
                    .Include(x => x.RoomAdds)
                    .Where(x => x.BookingId == booking.Id).ToList();

                booking.Rooms = rooms;
            }

            return booking;
        }

        public Booking GetBookingBySignIn(SignInModel signIn)
        {
            if (signIn == null)
                return null;

            Booking booking = _dbContext.Booking
                .Where(x => x.BookingReference.ToLower().Equals(signIn.BookingReference.ToLower()) &&
                x.Rooms.Any(y => y.ArrivalDate == signIn.ArrivalDate && y.DepartureDate == signIn.DepartureDate)
                )?.FirstOrDefault();

            if (booking != null)
            {
                List<Room> rooms = _dbContext.Room
                    .Include(x => x.Guests)
                    .Where(x => x.BookingId == booking.Id).ToList();

                booking.Rooms = rooms;

                if (!string.IsNullOrEmpty(signIn.Email))
                    if (booking.Rooms[0].Guests[0].Email.ToLower() != signIn.Email.ToLower())
                        return null;
            }

            return booking;
        }

        public Booking GetBookingByToken(string bookingToken)
        {
            if (string.IsNullOrEmpty(bookingToken))
                return null;

            return _dbContext.Booking.Where(x => x.Token.ToLower().Equals(bookingToken.ToLower()))?.FirstOrDefault();
        }

        public Response UpdateBookingGuests(string bookingReference, Guest[] guests)
        {
            if (string.IsNullOrEmpty(bookingReference))
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Booking reference is missing."
                };
            if (guests == null || guests.Length == 0)
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "The booking should have at least 1 guest."
                };

            try
            {
                Booking booking = GetBookingByReference(bookingReference);
                if (booking == null)
                    return new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." };

                foreach (var room in booking.Rooms)
                    room.Guests = guests.Where(x => x.RoomId.Equals(room.Id)).ToList();

                _dbContext.Booking.Update(booking);
                _dbContext.SaveChanges();

                return new Response { Status = HttpStatusCode.OK};
            }
            catch (Exception e)
            {
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Error occurred, please try again."
                };
            }
        }
    }
}
