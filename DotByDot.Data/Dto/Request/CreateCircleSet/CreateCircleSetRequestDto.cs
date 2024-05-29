using System.ComponentModel.DataAnnotations;

namespace DotByDot.Data.Dto.In.CreateCircleSet
{
    public class CreateCircleSetRequestDto
    {
        [Required]
        public List<CircleRequestDto> Circles { get; set; }
    }
}
