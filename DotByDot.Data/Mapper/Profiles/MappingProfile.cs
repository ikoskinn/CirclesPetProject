using AutoMapper;
using DotByDot.Core.Domain.Models;
using DotByDot.Data.Dto;
using DotByDot.Data.Dto.In;
using DotByDot.Data.Dto.In.CreateCircleSet;
using DotByDot.Data.Dto.Out;

namespace DotByDot.Data.Mapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCircleSetRequestDto, CircleSet>();
            CreateMap<CircleSetResponseDto, CircleSet>();

            CreateMap<CircleRequestDto, Circle>()
                .AfterMap((dto, circle) => circle.CreatedAt = DateTime.UtcNow);

            CreateMap<Circle, CircleResponseDto>();
            CreateMap<CircleSet, CircleSetResponseDto>();
        }
    }
}
