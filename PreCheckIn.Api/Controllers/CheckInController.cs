using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PreCheckIn.Core.BookingManagement;
using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;
using PreCheckIn.Data.Models;

namespace PreCheckIn.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly IBookingManagement _bookingManagement;
        private IConfiguration _configuration;
        private readonly ILogger<CheckInController> _logger;

        public CheckInController(ILogger<CheckInController> logger, IBookingManagement bookingManagement, IConfiguration configuration)
        {
            _logger = logger;
            _bookingManagement = bookingManagement;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(Booking booking)
        {
            Response response = _bookingManagement.AddBooking(booking);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

        [HttpGet]
        [Route("signin/{token}")]
        public IActionResult SignIn(string token)
        {
            Booking booking = _bookingManagement.GetBookingByToken(token);
            if (booking == null)
                return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." });
            return Redirect(_configuration["UIUrl"] +"?ref=" + booking.BookingReference);
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(SignInModel model)
        {
            Booking booking = _bookingManagement.GetBookingBySignIn(model);
            if (booking == null)
                return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." });
            return Ok(new Response { Status = HttpStatusCode.OK, Body = booking });
        }


        [HttpGet]
        [Route("booking/{reference}")]
        public IActionResult Booking(string reference)
        {
            Booking booking = _bookingManagement.GetBookingByReference(reference);
            if (booking == null)
                return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." });
            return Ok(new Response { Status = HttpStatusCode.OK, Body = booking });
        }


        [HttpPost]
        [Route("guest/")]
        public IActionResult UpdateGuests([FromBody] Guest guest)
        {
            Response response = _bookingManagement.UpdateBookingGuest(guest);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }


        [HttpPost]
        [Route("confirm/{reference}")]
        public IActionResult ConfirmBooking(string reference)
        {
            Response response = _bookingManagement.ConfirmBooking(reference);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return Ok(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

    }
}
