using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.AdventureViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdventuresController : ControllerBase
    {
        private readonly IAdventureService _adventureService;

        public AdventuresController(IAdventureService adventureService)
        {
            _adventureService = adventureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdventures()
        {
            try
            {
                var adventures = await _adventureService.GetAllAdventuresAsync();
                return Ok(adventures);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdventureById(int id)
        {
            var adventure = await _adventureService.GetAdventureByIdAsync(id);
            if (adventure == null) return NotFound(new { message = $"Không tồn tại chuyến phiêu lưu với Id={id}" });
            return Ok(adventure);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdventure(CreateAdventureVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _adventureService.CreateAdventureAsync(model);
            return StatusCode(201, new { message = "Chuyến phiêu lưu đã được tạo thành công." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdventure(int id, UpdateAdventureVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _adventureService.UpdateAdventureAsync(id, model);
            return Ok(new { message = "Cập nhật chuyến phiêu lưu thành công." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdventure(int id)
        {
            await _adventureService.DeleteAdventureAsync(id);
            return NoContent();
        }
    }

}
