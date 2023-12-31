﻿using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAD_WEB_API_Y4_S1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketBookingController : Controller
    {
        private readonly TicketBookingService _ticketBookingService;

        public TicketBookingController(TicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        [HttpGet]
        public async Task<List<TicketBookings>> Get() => await _ticketBookingService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TicketBookings>> Get(string id)
        {
            var booking = await _ticketBookingService.GetAsync(id);

            if (booking is null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TicketBookings newTicketBookings)
        {
            await _ticketBookingService.CreateAsync(newTicketBookings);

            return CreatedAtAction(nameof(Get), new { id = newTicketBookings.BookingId }, newTicketBookings);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TicketBookings updatedTicketBookings)
        {
            var booking = await _ticketBookingService.GetAsync(id);

            if (booking is null)
            {
                return NotFound();
            }

            updatedTicketBookings.BookingId = booking.BookingId;

            await _ticketBookingService.UpdateAsync(id, updatedTicketBookings);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var booking = await _ticketBookingService.GetAsync(id);

            if (booking is null)
            {
                return NotFound();
            }

            await _ticketBookingService.RemoveAsync(id);

            return NoContent();
        }
    }
}
