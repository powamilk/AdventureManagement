using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.GuideViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuidesController : ControllerBase
    {
        private readonly IGuideService _guideService;

        public GuidesController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuides()
        {
            var guides = await _guideService.GetAllGuidesAsync();
            return Ok(guides);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuideById(int id)
        {
            var guide = await _guideService.GetGuideByIdAsync(id);
            if (guide == null) return NotFound(new { message = $"Không tồn tại nhà hướng dẫn với Id={id}" });
            return Ok(guide);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuide(CreateGuideVM model)
        {
            await _guideService.CreateGuideAsync(model);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuide(int id, UpdateGuideVM model)
        {
            await _guideService.UpdateGuideAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            await _guideService.DeleteGuideAsync(id);
            return NoContent();
        }
    }

}
