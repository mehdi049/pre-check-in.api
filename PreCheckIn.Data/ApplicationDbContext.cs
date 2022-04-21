using Microsoft.EntityFrameworkCore;
using PreCheckIn.Data.Entities;

namespace PreCheckIn.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Booking> Booking { get; set; }
        public DbSet<BookingAdd> BookingAdd { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<InvoiceAddress> InvoiceAddress { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomAdd> RoomAdds { get; set; }

        public DbSet<HotelSettings> HotelSettings { get; set; }
        public DbSet<HotelAdmin> HotelAdmin { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
