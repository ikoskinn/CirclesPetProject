
using AutoMapper;
using DotByDot.Core.Domain.Models;
using DotByDot.Data.Dto;
using DotByDot.Data.Dto.In;
using DotByDot.Data.Dto.In.CreateCircleSet;
using DotByDot.Data.Dto.Out;
using DotByDot.Repository;
using DotByDot.Utils;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotByDot.Services
{
    public class CircleService : ICircleService
    {
        private readonly IMapper _mapper;
        private readonly ICircleRepository _circleRepository;

        public CircleService(IMapper mapper, ICircleRepository circleRepository)
        {
            _mapper = mapper;
            _circleRepository = circleRepository;
        }

        public async Task<BaseResponseDto> CreateAsync(CreateCircleSetRequestDto createCircleDto)
        {
            try
            {
                var circleSet = _mapper.Map<CircleSet>(createCircleDto);

                var id = await _circleRepository.CreateAsync(circleSet);

                return new BaseResponseDto(
                    true,
                    circleSetId: id
                );
            }
            catch (DbUpdateException ex)
            {
                return new BaseResponseDto(false, error: "An error occurred while saving the CircleSet." );
            }
            catch (ValidationException ex)
            {
                return new BaseResponseDto(false, error: ex.ValidationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                return new BaseResponseDto(false, error: $"Error happened on server side!");
            }
        }
        public async Task<BaseResponseDto> CreateAsync()
        {
            try
            {
                var circleSet = new CircleSet();
                var circleId = await _circleRepository.CreateAsync(circleSet);

                return new BaseResponseDto(
                    true,
                    circleId
                );
            }
            catch (Exception ex)
            {
                return new BaseResponseDto(false, error: $"Error happened on server side! More info: {ex.Message}");
            }
        }

        public async Task<BaseResponseDto> GetAsync(int id)
        {
            try
            {
                var circleSet = await _circleRepository.GetAsync(id);

                if (circleSet is null)
                    return new BaseResponseDto(false, error: "CircleSet not found!");
                else
                    return new BaseResponseDto(true, circleSet: _mapper.Map<CircleSetResponseDto>(circleSet));
            }
            catch (Exception ex)
            {
                return new BaseResponseDto(false, error: $"Error happened on server side! More info: {ex.Message}");
            }
        }

        public async Task<BaseResponseDto> AddAsync(int id, CircleRequestDto circleDto)
        {
            try
            {
                var circle = _mapper.Map<Circle>(circleDto);

                var circleSet = await _circleRepository.AddAsync(id, circle);

                if (circleSet is null)
                    return new BaseResponseDto(false, error: "CircleSet not found!");
                else
                    return new BaseResponseDto(true);
            }
            catch (DbUpdateException ex)
            {
                return new BaseResponseDto(false, error: "An error occurred while saving the CircleSet.");
            }
            catch (ValidationException ex)
            {
                return new BaseResponseDto(false, error: ex.ValidationResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                return new BaseResponseDto(false, error: $"Error happened on server side!");
            }
        }
    }
}
