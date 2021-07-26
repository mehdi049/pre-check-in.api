using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;
using PreCheckIn.Data.Models;

namespace PreCheckIn.Core.BookingManagement
{
    public interface IBookingManagement
    {
        Response AddBooking(Booking booking);
        Booking GetBookingByReference(string reference);
        Booking GetBookingByToken(string bookingToken);
        Booking GetBookingBySignIn(SignInModel signIn);
        Response UpdateBookingGuests(string bookingReference, Guest[] guests);

    }
}
