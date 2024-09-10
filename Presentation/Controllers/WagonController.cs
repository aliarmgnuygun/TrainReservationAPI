using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WagonController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public WagonController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }



        // Tüm vagonları listeleme
        [HttpGet]
        public async Task<IActionResult> GetAllWagons()
        {
            var wagons = await serviceManager.WagonManager.GetAllWagonsAsync();
            return Ok(wagons);
        }

        // Belirli bir vagonu ID ile alma
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWagonById([FromRoute(Name = "id")] int id)
        {
            var wagon = await serviceManager.WagonManager.GetWagonByIdAsync(id);
            if (wagon == null)
            {
                return NotFound("Wagon not found.");
            }
            return Ok(wagon);
        }

        // Yeni bir vagon ekleme
        [HttpPost]
        public async Task<IActionResult> AddWagon([FromBody] Wagon wagon)
        {
            if (wagon == null)
            {
                return BadRequest("Invalid wagon data.");
            }

            await serviceManager.WagonManager.AddWagonAsync(wagon);
            return CreatedAtAction(nameof(GetWagonById), new { id = wagon.Id }, wagon);
        }

        // Vagon güncelleme
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateWagon([FromRoute(Name = "id")] int id, [FromBody] Wagon wagon)
        {
            if (wagon == null || id != wagon.Id)
            {
                return BadRequest("Wagon data is invalid.");
            }

            var existingWagon = await serviceManager.WagonManager.GetWagonByIdAsync(id);
            if (existingWagon == null)
            {
                return NotFound("Wagon not found.");
            }

            await serviceManager.WagonManager.UpdateWagonAsync(wagon);
            return NoContent();
        }

        // Vagon silme
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteWagon([FromRoute(Name = "id")] int id)
        {
            var wagon = await serviceManager.WagonManager.GetWagonByIdAsync(id);
            if (wagon == null)
            {
                return NotFound("Wagon not found.");
            }

            await serviceManager.WagonManager.DeleteWagonAsync(wagon);
            return NoContent();
        }
    }
}
