using EAD_WEB_API_Y4_S1.Models;
using EAD_WEB_API_Y4_S1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAD_WEB_API_Y4_S1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainScheduleController : Controller
    {
        private readonly TrainScheduleService _trainScheduleService;

        public TrainScheduleController(TrainScheduleService trainScheduleService)
        {
            _trainScheduleService = trainScheduleService;
        }

        [HttpGet]
        public async Task<List<TrainSchedule>> Get() => await _trainScheduleService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TrainSchedule>> Get(string id)
        {
            var trainSchedule = await _trainScheduleService.GetAsync(id);

            if (trainSchedule is null)
            {
                return NotFound();
            }

            return trainSchedule;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrainSchedule newTrainSchedules)
        {
            await _trainScheduleService.CreateAsync(newTrainSchedules);

            return CreatedAtAction(nameof(Get), new { id = newTrainSchedules.TrainScheduleId }, newTrainSchedules);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TrainSchedule updatedTrainSchedules)
        {
            var trainSchedule = await _trainScheduleService.GetAsync(id);

            if (trainSchedule is null)
            {
                return NotFound();
            }

            updatedTrainSchedules.TrainScheduleId = trainSchedule.TrainScheduleId;

            await _trainScheduleService.UpdateAsync(id, updatedTrainSchedules);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var trainSchedule = await _trainScheduleService.GetAsync(id);

            if (trainSchedule is null)
            {
                return NotFound();
            }

            await _trainScheduleService.RemoveAsync(id);

            return NoContent();
        }

        [HttpPut("cancel/{id:length(24)}")]
        public async Task<IActionResult> CancelTrainSchedule(string id)
        {
            var trainSchedule = await _trainScheduleService.GetAsync(id);

            if (trainSchedule is null)
            {
                return NotFound();
            }

            // Set the isCancelled property to true
            trainSchedule.IsCancelled = true;

            // Update the train schedule in the database
            await _trainScheduleService.UpdateAsync(id, trainSchedule);

            return NoContent();
        }

    }
}
