using System.ComponentModel.DataAnnotations;

namespace DotByDot.Data.Dto.Out
{
    public class BaseResponseDto
    {
        [Required]
        public bool Success { get; set; }
        public string? Error { get; set; } = null;

        public int? CircleSetId { get; set; } = null;
        public CircleSetResponseDto? CircleSet { get; set; } = null;

        public BaseResponseDto(bool success, CircleSetResponseDto? circleSet = null, string? error = null)
        {
            Success = success;

            if (Success)
            {
                CircleSet = circleSet;
            }
            else
                Error = error;
        }

        public BaseResponseDto(bool success, int circleSetId, string? error = null)
        {
            Success = success;

            if (Success)
            {
                CircleSetId = circleSetId;
            }
            else
                Error = error;
        }
    }
}
