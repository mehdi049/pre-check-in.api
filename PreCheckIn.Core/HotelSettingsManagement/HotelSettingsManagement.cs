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
using PreCheckIn.Data.Models;

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
                hotelSettings.HotelAdmin = new HotelAdmin()
                {
                    Email = hotelSettings.Email,
                    Password = hotelSettings.Email,
                };
                _dbContext.HotelSettings.Add(hotelSettings);
                _dbContext.SaveChanges();

                string confirmationEmailBody = "Hi " + hotelSettings.HotelAdmin.Email + ", <br> " +
                                               "An account is created for you to manage the <b>" + hotelSettings.Name +
                                               "</b> hotel. <br>" +
                                               "Please click <a href='" + _configuration["SettingsUrl"] +
                                               "' target='_blank'>here</a> to sign in. <br>" +
                                               "Your credentials: <br>" +
                                               "<b>Email:</b> " + hotelSettings.HotelAdmin.Email + " <br>" +
                                               "<b>Password:</b> " + hotelSettings.HotelAdmin.Password;

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
                HotelAdmin hotelAdmin = _dbContext.HotelAdmin.Where(x => x.Email.Equals(hotelSettings.Email)).FirstOrDefault();
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

        public HotelSettings GetHotelSettingsBySignIn(HotelSettingsSignInModel signIn)
        {
            if (signIn == null)
                return null;

            HotelSettings hotelSettings = _dbContext.HotelSettings.Include(x => x.HotelAdmin).Where(x=>x.HotelAdmin.Email.Equals(signIn.Email) && x.HotelAdmin.Password.Equals(signIn.Password)).FirstOrDefault();

            return hotelSettings;
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
