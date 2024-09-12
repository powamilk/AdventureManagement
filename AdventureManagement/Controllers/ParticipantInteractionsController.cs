using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.ParticipantInteraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureManagement.API.Controllers
{
    [ApiController]
    [Route("api/participant-interactions")]
    public class ParticipantInteractionsController : ControllerBase
    {
        private readonly IParticipantInteractionService _interactionService;

        public ParticipantInteractionsController(IParticipantInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        // GET /api/participant-interactions
        [HttpGet]
        public async Task<IActionResult> GetAllParticipantInteractions()
        {
            try
            {
                var interactions = await _interactionService.GetAllParticipantInteractionsAsync();
                return Ok(interactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        // GET /api/participant-interactions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantInteractionById(int id)
        {
            var interaction = await _interactionService.GetParticipantInteractionByIdAsync(id);
            if (interaction == null)
                return NotFound(new { message = $"Không tồn tại tương tác với Id={id}" });

            return Ok(interaction);
        }

        // POST /api/participant-interactions
        [HttpPost]
        public async Task<IActionResult> CreateParticipantInteraction([FromBody] CreateParticipantInteractionVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _interactionService.CreateParticipantInteractionAsync(model);
                return StatusCode(201, new { message = "Tương tác đã được tạo thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        // PUT /api/participant-interactions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipantInteraction(int id, [FromBody] UpdateParticipantInteractionVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _interactionService.UpdateParticipantInteractionAsync(id, model);
                return Ok(new { message = "Cập nhật tương tác thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }

        // DELETE /api/participant-interactions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipantInteraction(int id)
        {
            try
            {
                await _interactionService.DeleteParticipantInteractionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi máy chủ: " + ex.Message });
            }
        }
    }

}
