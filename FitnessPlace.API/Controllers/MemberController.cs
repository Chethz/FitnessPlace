using FitnessPlace.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPlace.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberService _service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetMembers()
        {
            return Ok(await _service.GetAsync());
        }
    }
}