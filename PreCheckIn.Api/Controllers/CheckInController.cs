using System.Net;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<CheckInController> _logger;

        public CheckInController(ILogger<CheckInController> logger, IBookingManagement bookingManagement)
        {
            _logger = logger;
            _bookingManagement = bookingManagement;
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post(Booking booking)
        {
            Response response = _bookingManagement.AddBooking(booking);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

        [HttpGet]
        [Route("signin/{token}")]
        public IActionResult SignIn(string token)
        {
            Booking booking = _bookingManagement.GetBookingByToken(token);
            if (booking == null)
                return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." });
            return Ok(new Response { Status = HttpStatusCode.OK, Body = booking.BookingReference });
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(SignInModel model)
        {
            Booking booking = _bookingManagement.GetBookingBySignIn(model);
            if (booking == null)
                return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." });
            return Ok(new Response { Status = HttpStatusCode.OK });
        }


        [HttpGet]
        [Route("booking/{reference}")]
        public IActionResult Booking(string reference)
        {
            Booking booking = _bookingManagement.GetBookingByReference(reference);
            if (booking == null)
                return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = "Booking information not found." });
            return Ok(new Response { Status = HttpStatusCode.OK, Body = booking });
        }


        [HttpPut]
        [Route("guests/{reference}")]
        public IActionResult UpdateGuests(string reference, [FromBody] Guest[] guests)
        {
            Response response = _bookingManagement.UpdateBookingGuests(reference, guests);
            if (response.Status == HttpStatusCode.OK)
                return Ok(new Response { Status = HttpStatusCode.OK, Body = response.Body, Message = response.Message });

            return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message });
        }

    }
}
