using DotByDot.Core.Domain.Models;
using DotByDot.Data.Dto.In;
using DotByDot.Data.Dto.In.CreateCircleSet;
using DotByDot.Data.Dto.Out;
using DotByDot.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotByDot.App.Server.Controllers
{
    [ApiController]
    [Route("")]
    public class CircleSetController : Controller
    {
        private readonly ICircleService _circleService;

        public CircleSetController(ICircleService circleService)
        {
            _circleService = circleService;
        }

        [HttpGet("api/circles/create")]
        public async Task<ActionResult<BaseResponseDto>> CreateCircleSet()
        {
            var result = await _circleService.CreateAsync();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("api/circles/create")]
        public async Task<ActionResult<BaseResponseDto>> CreateCircleSet([FromBody] CreateCircleSetRequestDto createCircleDto)
        {
            var result = await _circleService.CreateAsync(createCircleDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("api/circles/{circleSetId:int}")]
        public async Task<ActionResult<BaseResponseDto>> GetCircleSet([FromRoute] int circleSetId)
        {
            var result = await _circleService.GetAsync(circleSetId);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("api/circles/{circleSetId:int}")]
        public async Task<ActionResult<BaseResponseDto>> AddCircle([FromRoute] int circleSetId, [FromBody] CircleRequestDto circleDto)
        {
            var result = await _circleService.AddAsync(circleSetId, circleDto);
            
            if (result.Success)
                return Ok(result);
            else 
                return BadRequest(result);
        }
    }
}
