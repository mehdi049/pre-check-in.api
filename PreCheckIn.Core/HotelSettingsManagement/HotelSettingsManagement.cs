using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PreCheckIn.Core.EmailManagement;
using PreCheckIn.Data;

namespace PreCheckIn.Core.HotelSettingsManagement
{
    public class HotelSettingsManagement : IHotelSettingsManagement
    {
        private ApplicationDbContext _dbContext;

        private IEmailManagement _sendEmail;
        private IConfiguration _configuration;

        public HotelSettingsManagement(ApplicationDbContext dbContext, IEmailManagement sendEmail, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _sendEmail = sendEmail;
            _configuration = configuration;
        }

        public Response AddHotelSettings(HotelSettings hotelSettings)
        {
            try
            {
                _dbContext.HotelSettings.Add(hotelSettings);
                HotelAdmin hotelAdmin = new HotelAdmin()
                {
                    Email = hotelSettings.Email,
                    Password = hotelSettings.Email,
                    HotelSettingsId = hotelSettings.Id
                };
                _dbContext.HotelAdmin.Add(hotelAdmin);

                string confirmationEmailBody = "Hi " + hotelAdmin.Email + ", <br> " +
                                               "An account is created for you to manage the <b>" + hotelSettings.Name +
                                               "</b> hotel. <br>" +
                                               "Please click <a href='" + _configuration["SettingsUrl"] +
                                               "' target='_blank'>here</a> to sign in. <br>" +
                                               "Your credentials: <br>" +
                                               "<b>Email:</b> " + hotelAdmin.Email + " <br>" +
                                               "<b>Password:</b> " + hotelAdmin.Password;

                string message = "";
                if (!_sendEmail.SendConfirmationEmail(hotelSettings.Email, confirmationEmailBody))
                    message = "Error occurred when sending a confirmation email.";

                return new Response
                {
                    Status = HttpStatusCode.OK,
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

        public Response DeleteHotelSettings(int id)
        {
            HotelSettings hotelSettings = GetHotelSettingsById(id);
            if (hotelSettings == null)
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Hotel settings not found."
                };

            try
            {
                HotelAdmin hotelAdmin = _dbContext.HotelAdmin.Where(x => x.HotelSettingsId == id).FirstOrDefault();
                if (hotelAdmin != null)
                    _dbContext.Remove(hotelAdmin);
                _dbContext.Remove(hotelSettings);
                _dbContext.SaveChanges();

                return new Response { Status = HttpStatusCode.OK };
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

        public HotelSettings GetHotelSettingsById(int id)
        {
            return _dbContext.HotelSettings.Find(id);
        }

        public HotelAdmin GetHotelSettingsBySignIn(HotelAdmin signIn)
        {
            if (signIn == null)
                return null;

            HotelAdmin hotelAdmin = _dbContext.HotelAdmin
                .Where(x => x.Email == signIn.Email && x.Password == signIn.Password).Include(x => x.HotelSettings).FirstOrDefault();

            return hotelAdmin;
        }

        public HotelSettings[] GetHotelsSettings()
        {
            return _dbContext.HotelSettings.ToArray();
        }

        public Response UpdateHotelSettings(HotelSettings hotelSettings)
        {
            if (hotelSettings == null || _dbContext.HotelSettings.Find(hotelSettings.Id) == null)
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Hotel settings not found, please try again."
                };

            try
            {
                _dbContext.Entry(hotelSettings).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return new Response { Status = HttpStatusCode.OK };
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

        public Response UpdateHotelAdmin(HotelAdmin hotelAdmin)
        {
            if (hotelAdmin == null || _dbContext.HotelAdmin.Find(hotelAdmin.Id) == null)
                return new Response
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = "Hotel admin not found, please try again."
                };

            try
            {
                _dbContext.Entry(hotelAdmin).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return new Response { Status = HttpStatusCode.OK };
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
