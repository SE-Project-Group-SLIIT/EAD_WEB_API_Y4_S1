////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TicketBookingController.cs

//FileType: Visual C# Source file

//Author : Madiwilage I.E

//Created On : 2/10/20123 9:56:39 AM

//Last Modified On :  13/10/20123 10:53:23 AM

//Copy Rights : N/A

//Description : Controller for defining database related functions

////////////////////////////////////////////////////////////////////////////////////////////////////////


using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAD_WEB_API_Y4_S1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketBookingController : Controller
    {
        private readonly TicketBookingService _ticketBookingService;
        private readonly TrainService _trainService;
        private readonly TrainScheduleService _trainScheduleService;

        public TicketBookingController(TicketBookingService ticketBookingService, TrainService trainService, TrainScheduleService trainScheduleService)
        {
            _ticketBookingService = ticketBookingService;
            _trainService = trainService;
            _trainScheduleService = trainScheduleService;
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
            if (newTicketBookings == null)
            {
                return BadRequest("Invalid input: newTicketBookings is null.");
            }

            if ((newTicketBookings.TravelDate - newTicketBookings.BookingDate).TotalDays <= 30)
            {
                // Check the existing reservations for the same reference ID
                var existingReservationsCount = await _ticketBookingService.CountReservationsByReferenceId(newTicketBookings.TravelerId);

                if (existingReservationsCount >= 4)
                {
                    // Return a bad request response if the maximum reservation limit is exceeded
                    return BadRequest("The maximum limit of 4 reservations per reference ID has been reached.");
                }

                await _ticketBookingService.CreateAsync(newTicketBookings);
                return CreatedAtAction(nameof(Get), new { id = newTicketBookings.BookingId }, newTicketBookings);
            }
            else
            {
                // Return a bad request response if the reservation date validation fails
                return BadRequest("The reservation date must be within 30 days from the booking date.");
            }

        }
        [HttpGet("countreservations/{referenceId}")]
        public async Task<IActionResult> CountReservations(string referenceId)
        {
            long count = await _ticketBookingService.CountReservationsByReferenceId(referenceId);
            return Ok(count);
        }

        [HttpGet("getreservations/{referenceId}")]
        public async Task<IActionResult> GetReservations(string referenceId)
        {

            List<TicketBookings> reservations = await _ticketBookingService.GetReservationsByReferenceId(referenceId);
            return Ok(reservations);

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

        [HttpGet("gettraindetails/")]
        public async Task<ActionResult> GetTrainSchedulesByStations( string arrivalStation, string departureStation)
        {
            if (string.IsNullOrEmpty(arrivalStation) || string.IsNullOrEmpty(departureStation))
            {
                return BadRequest("Both station1 and station2 must be provided.");
            }

            var trainSchedules = await _trainScheduleService.GetTrainSchedulesByStations(arrivalStation, departureStation);

            if (trainSchedules == null || trainSchedules.Count == 0)
            {
                return NotFound("No matching train schedules found.");
            }

            return Ok(trainSchedules);
        }

        [HttpPut("cancel/{id:length(24)}")]
        public async Task<IActionResult> CancelReservation(string id)
        {
            var reservation = await _ticketBookingService.GetAsync(id);

            if (reservation is null)
            {
                return NotFound();
            }

            // Set the isCancelled property to true
            reservation.Status = "Cancelled";

            // Update the train schedule in the database
            await _ticketBookingService.UpdateAsync(id, reservation);

            return NoContent();
        }
    }
}
