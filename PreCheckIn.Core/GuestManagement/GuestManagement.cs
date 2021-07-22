using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreCheckIn.Data;
using PreCheckIn.Data.Entities;

namespace PreCheckIn.Core.GuestManagement
{
    public class GuestManagement : IGuestManagement
    {
        private ApplicationDbContext _dbContext;

        public GuestManagement(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guest GetGuestByEmail(string email)
        {
            return _dbContext.Guest.Where(x => x.Email.ToLower().Equals(email.ToLower()))?.FirstOrDefault();
        }
    }
}
