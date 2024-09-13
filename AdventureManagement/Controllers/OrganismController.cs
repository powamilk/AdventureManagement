using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.OrganismViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganismsController : ControllerBase
    {
        private readonly IOrganismService _organismService;

        public OrganismsController(IOrganismService organismService)
        {
            _organismService = organismService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganisms()
        {
            try
            {
                var organisms = await _organismService.GetAllOrganismsAsync();
                return Ok(organisms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganismById(int id)
        {
            var organism = await _organismService.GetOrganismByIdAsync(id);
            if (organism == null) return NotFound(new { message = $"Không tồn tại sinh vật với Id={id}" });
            return Ok(organism);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganism(CreateOrganismVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _organismService.CreateOrganismAsync(model);
            return StatusCode(201, new { message = "Sinh vật đã được tạo thành công." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganism(int id, UpdateOrganismVM model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _organismService.UpdateOrganismAsync(id, model);
            return Ok(new { message = "Cập nhật sinh vật thành công." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganism(int id)
        {
            await _organismService.DeleteOrganismAsync(id);
            return NoContent();
        }
    }

}
