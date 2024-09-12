using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.Participant;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace AdventureManagement.API.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        private readonly IValidator<ParticipantCreateVM> _createValidator;
        private readonly IValidator<ParticipantUpdateVM> _updateValidator;

        public ParticipantController(IParticipantService participantService, IValidator<ParticipantCreateVM> createValidator, IValidator<ParticipantUpdateVM> updateValidator)
        {
            _participantService = participantService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var participants = await _participantService.GetAll();
            if (participants == null || participants.Count == 0)
            {
                return StatusCode(500, "Lỗi máy chủ");
            }
            return Ok(new { participants });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participants = await _participantService.GetById(id);
            if(participants == null)
            {
                return NotFound("người tham gia không tồn tại");
            }    
            return Ok(new { participants });    
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ParticipantCreateVM model)
        {
            ValidationResult validationResult = await _createValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.Select(e => new 
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                });
                return BadRequest(error);   
            }

            var succes = await _participantService.Create(model);
            if(!succes)
            {
                return BadRequest("Email đã tồn tại");
            }
            return StatusCode(201, "Tạo thành công");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ParticipantUpdateVM model)
        {
            ValidationResult validationResult = await _updateValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.Select(e => new
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                });
                return BadRequest(error);
            }
            var success = await _participantService.Update(id, model);
            if(!success)
            {
                return BadRequest("Người tham gia không tồn tại hoặc lỗi khi cập nhật");
            }  
            return Ok("Đã cập nhật thành công");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var succces = await _participantService.Delete(id);
            if(!succces)
            {
                return NotFound();
            }  
            return NoContent();
        }
    }
}
