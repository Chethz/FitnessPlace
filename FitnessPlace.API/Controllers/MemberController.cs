using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Services.IServices;
using FitnessPlace.DataAccess.Models;
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
        public async Task<ActionResult> GetWithMemberDetails()
        {
            return Ok(await _service.GetAllWithMemberDetailsSpecificationAsync());
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
            return Ok(await _service.GetWithMemberDetailsAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MemberDto>> Create([FromBody] MemberCreateDto memberDto)
        {
            var member = new Member
            {
                FirstName = memberDto.FirstName,
                LastName = memberDto.LastName,
                MemberDetail = new MemberDetail { Address = memberDto.Address, Email = memberDto.Email, MobileNumber = memberDto.MobileNumber }
            };
            await _service.AddAsync(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = member.Id }, member);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Member>> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be grater tha 0");
            }

            await _service.DeleteByIdAsync(id);
            return Ok($"Member with id: {id} is deleted successfully.");
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Member>> Update(int id, MemberCreateDto memberDto)
        {
            var member = new Member
            {
                FirstName = memberDto.FirstName,
                LastName = memberDto.LastName,
                MemberDetail = new MemberDetail { Address = memberDto.Address, Email = memberDto.Email, MobileNumber = memberDto.MobileNumber }
            };

            await _service.UpdateAsync(id, member);
            return Ok(memberDto);
        }
    }
}