using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Traveler>> Get(string id)
        {
            var traveler = await _travelerService.GetAsync(id);

            if (traveler is null)
            {
                return NotFound();
            }

            return traveler;
        }


        [HttpPost]
        public async Task<IActionResult> Post(Traveler newTraveler)
        {
            await _travelerService.CreateAsync(newTraveler);

            return CreatedAtAction(nameof(Get), new { id = newTraveler.Id }, newTraveler);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Traveler updatedTraveler)
        {
            var traveler = await _travelerService.GetAsync(id);

            if (traveler is null)
            {
                return NotFound();
            }

            updatedTraveler.Id = traveler.Id;

            await _travelerService.UpdateAsync(id, updatedTraveler);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
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
