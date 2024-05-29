using DotByDot.Core.Domain.Models;
using DotByDot.Data.Dto.In;
using DotByDot.Data.Dto.In.CreateCircleSet;
using DotByDot.Data.Dto.Out;

namespace DotByDot.Services
{
    public interface ICircleService
    {

        public Task<BaseResponseDto> CreateAsync();
        public Task<BaseResponseDto> CreateAsync(CreateCircleSetRequestDto createCircleSetDto);

        public Task<BaseResponseDto> GetAsync(int id);
        public Task<BaseResponseDto> AddAsync(int id, CircleRequestDto circleDefaultDto);
    }
}
