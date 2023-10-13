using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace EAD_WEB_API_Y4_S1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelerController : Controller
    {
        private readonly TravelerService _travelerService;

        public TravelerController(TravelerService travelerService)
        {
            _travelerService = travelerService;
        }

        [HttpGet]
        public async Task<List<Traveler>> Get() => await _travelerService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Traveler>> Get(string id)
        {
                var traveler = await _travelerService.GetAsync(id);

                if (traveler is null)
                {
                    return NotFound();
                }

                return traveler;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string nic, string email)
        {
            var traveler = await _travelerService.LoginAsync(nic, email);

            if (traveler == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Return the token to the client
            return Ok(traveler);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Traveler newTraveler)
        {
            try { 
                await _travelerService.CreateAsync(newTraveler);
                return CreatedAtAction(nameof(Get), new { id = newTraveler.NIC }, newTraveler);
            }
            catch (MongoWriteException ex)
            {
                if (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    throw new Exception("A traveler with the same NIC already exists.");
                }
                throw;

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Traveler updatedTraveler)
        {
            var traveler = await _travelerService.GetAsync(id);

            if (traveler is null)
            {
                return NotFound();
            }

            updatedTraveler.NIC = traveler.NIC;

            await _travelerService.UpdateAsync(id, updatedTraveler);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var traveler = await _travelerService.GetAsync(id);

            if (traveler is null)
            {
                return NotFound();
            }

            await _travelerService.RemoveAsync(id);

            return NoContent();
        }

    }
}
