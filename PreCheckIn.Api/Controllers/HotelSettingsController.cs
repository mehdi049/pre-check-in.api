using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PreCheckIn.Core.HotelSettingsManagement;
using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;
using PreCheckIn.Data.Models;

namespace PreCheckIn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelSettingsController : ControllerBase
    {
        private readonly IHotelSettingsManagement _hotelSettingsManagement;
        private IConfiguration _configuration;
        private readonly ILogger<CheckInController> _logger;

        public HotelSettingsController(ILogger<CheckInController> logger, IHotelSettingsManagement hotelSettingsManagement, IConfiguration configuration)
        {
            _logger = logger;
            _hotelSettingsManagement = hotelSettingsManagement;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(HotelSettings hotelSettings)
        {
            Response response = _hotelSettingsManagement.AddHotelSettings(hotelSettings);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(HotelSettingsSignInModel model)
        {
            HotelSettings hotelSettings = _hotelSettingsManagement.GetHotelSettingsBySignIn(model);
            if (hotelSettings == null)
                return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = "Hotel settings not found." });
            return Ok(new Response { Status = HttpStatusCode.OK, Body = hotelSettings });
        }

        [HttpGet]
        [Route("hotelSettings/{id}")]
        public IActionResult HotelSettings(int id)
        {
            HotelSettings hotelSettings = _hotelSettingsManagement.GetHotelSettingsById(id);
            if (hotelSettings == null)
                return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = "Hotel settings not found." });
            return Ok(new Response { Status = HttpStatusCode.OK, Body = hotelSettings });
        }

        [HttpGet]
        [Route("hotelSettings")]
        public IActionResult GetAllHotelSettings()
        {
            HotelSettings[] hotelSettings = _hotelSettingsManagement.GetHotelsSettings();
            return Ok(new Response { Status = HttpStatusCode.OK, Body = hotelSettings });
        }

        [HttpPost]
        [Route("updateHotelSettings/")]
        public IActionResult UpdateHotelSettings([FromBody] HotelSettings hotelSettings)
        {
            Response response = _hotelSettingsManagement.UpdateHotelSettings(hotelSettings);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

        [HttpPost]
        [Route("updateHotelAdmin/")]
        public IActionResult UpdateHotelAdmin([FromBody] HotelAdmin hotelAdmin)
        {
            Response response = _hotelSettingsManagement.UpdateHotelAdmin(hotelAdmin);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

        [HttpPost]
        [Route("updateHotelImage/{id}/{name}")]
        public IActionResult UpdateHotelImage([FromBody] byte[] image, int id, string name)
        {
            Response response = _hotelSettingsManagement.UpdateHotelImages(id, image, name);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

        [HttpDelete]
        [Route("hotelSettings/{id}")]
        public IActionResult DeleteHotelSettings(int id)
        {
            Response response = _hotelSettingsManagement.DeleteHotelSettings(id);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });
            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

    }
}
