using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;

namespace PreCheckIn.Core.HotelSettingsManagement
{
    public interface IHotelSettingsManagement
    {
        Response AddHotelSettings(HotelSettings hotelSettings);
        HotelSettings GetHotelSettingsById(int id);

        HotelAdmin GetHotelSettingsBySignIn(HotelAdmin signIn);

        HotelSettings[] GetHotelsSettings();
        Response UpdateHotelSettings(HotelSettings hotelSettings);
        Response UpdateHotelAdmin(HotelAdmin hotelAdmin);
        Response DeleteHotelSettings(int id);
    }
}
