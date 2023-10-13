////////////////////////////////////////////////////////////////////////////////////////////////////////

//FileName: TrainScheduleController.cs

//FileType: Visual C# Source file

//Author : J.A.M.G.Jayakody

//Created On : 8/8/2023 9:56:39 AM

//Last Modified On : 10/13/2023 15:26:23 PM

//Copy Rights : N/A

//Description : Class controller for defining database related functions

////////////////////////////////////////////////////////////////////////////////////////////////////////
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
    }
}
