using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreCheckIn.Data.Entities;

namespace PreCheckIn.Core.GuestManagement
{
    public interface IGuestManagement
    {
        Guest GetGuestByEmail(string email);
    }
}
