﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PreCheckIn.Core.BookingManagement;
using PreCheckIn.Data.Common;
using PreCheckIn.Data.Entities;

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
            if (ModelState.IsValid)
            {
                Response response = _bookingManagement.AddBooking(booking);
                if (response.Status == HttpStatusCode.OK)
                    return Ok(new Response {Status = HttpStatusCode.OK});

                return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = response.Message, Body = response.Body });
            }
            return BadRequest(new Response { Status = HttpStatusCode.BadRequest, Message = "Invalid received information." });

        }

    }
}
