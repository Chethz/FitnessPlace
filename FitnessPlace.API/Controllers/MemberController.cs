using System.Linq.Expressions;
using FitnessPlace.Business.DTOs;
using FitnessPlace.Business.Services;
using FitnessPlace.DataAccess.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlace.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberService _service;

        public MemberController(MemberService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetMembers()
        {
            return Ok(await _service.GetAsync(true));
        }

        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetWithMemberDetailsAsync()
        {
            Expression<Func<Member, object>> expression = item => item.MemberDetail;
            return Ok(await _service.GetWithMemberDetailsAsync(expression));
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
    }
}