using Microsoft.AspNetCore.Mvc;
using global::MediCare.Application.BackEnd.Dto.Dto.Specialization;
using global::MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationAppService _specializationAppService;

        public SpecializationsController(ISpecializationAppService specializationAppService)
        {
            _specializationAppService = specializationAppService;
        }

        private string CurrentCulture =>
            Request.Headers["Accept-Language"].ToString().Split(',')[0] switch
            {
                var lang when lang.StartsWith("ar", StringComparison.OrdinalIgnoreCase) => "ar",
                _ => "en"
            };

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<SpecializationDto>>> GetAll()
        {
            var items = await _specializationAppService.GetAllAsync(CurrentCulture);
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<SpecializationDto>> GetById(int id)
        {
            var item = await _specializationAppService.GetByIdAsync(id, CurrentCulture);
            if (item == null)
            {
                return NotFound(new { message = $"Specialization with ID {id} was not found." });
            }
            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<SpecializationDto>> Create([FromBody] CreateSpecializationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _specializationAppService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.SpecializationId }, created);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSpecializationDto dto)
        {
            if (id != dto.SpecializationId)
            {
                return BadRequest(new { message = "ID in URL route does not match ID in payload." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _specializationAppService.UpdateAsync(dto);
            if (!updated)
            {
                return NotFound(new { message = $"Specialization with ID {id} was not found." });
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _specializationAppService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = $"Specialization with ID {id} was not found." });
            }

            return NoContent();
        }
    }
}
