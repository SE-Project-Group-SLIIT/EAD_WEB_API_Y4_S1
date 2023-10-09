using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAD_WEB_API_Y4_S1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainController : Controller
    {
        private readonly TrainService _trainService;

        public TrainController(TrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public async Task<List<Trains>> Get() => await _trainService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Trains>> Get(string id)
        {
            var train = await _trainService.GetAsync(id);

            if (train is null)
            {
                return NotFound();
            }

            return train;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Trains newTrains)
        {
            await _trainService.CreateAsync(newTrains);

            return CreatedAtAction(nameof(Get), new { id = newTrains.TrainId }, newTrains);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Trains updatedTrains)
        {
            var train = await _trainService.GetAsync(id);

            if (train is null)
            {
                return NotFound();
            }

            updatedTrains.TrainId = train.TrainId;

            await _trainService.UpdateAsync(id, updatedTrains);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var train = await _trainService.GetAsync(id);

            if (train is null)
            {
                return NotFound();
            }

            await _trainService.RemoveAsync(id);

            return NoContent();
        }
       
    }
}
