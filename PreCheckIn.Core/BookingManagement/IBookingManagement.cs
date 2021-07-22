using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;

namespace PreCheckIn.Core.BookingManagement
{
    public interface IBookingManagement
    {
        Response AddBooking(Booking booking);
        Response GetBookingById(int id);
        Response GetBookingByReference(string reference);
    }
}
