using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlace.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _service;

        public MemberController(IMemberService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetMembers()
        {
            return Ok(await _service.GetAsync());
        }

        [HttpGet("withdetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetWithMemberDetails()
        {
            return Ok(_service.GetAllWithMemberDetailsSpecification());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MemberDto>> GetMemberById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be grater than 0");
            }
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("memberdetails/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MemberDto>> GetMemberWithMemberDetailsById(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be grater than 0");
            }
            return Ok(await _service.GetWithMemberDetails(id));
        }
    }
}