using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.OrganismVM;
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

        // GET /api/organisms
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

        // GET /api/organisms/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganismById(int id)
        {
            try
            {
                var organism = await _organismService.GetOrganismByIdAsync(id);
                if (organism == null)
                {
                    return NotFound(new { message = $"Không tồn tại sinh vật với Id={id}" });
                }
                return Ok(organism);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        // POST /api/organisms
        [HttpPost]
        public async Task<IActionResult> CreateOrganism([FromBody] CreateOrganismVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _organismService.CreateOrganismAsync(model);
                return StatusCode(201, new { message = "Sinh vật đã được tạo thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        // PUT /api/organisms/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganism(int id, [FromBody] UpdateOrganismVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _organismService.UpdateOrganismAsync(id, model);
                return Ok(new { message = "Cập nhật sinh vật thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        // DELETE /api/organisms/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganism(int id)
        {
            try
            {
                await _organismService.DeleteOrganismAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }
    }

}
