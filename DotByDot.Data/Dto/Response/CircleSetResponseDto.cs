using DotByDot.Core.Domain.Models;
using DotByDot.Data.Dto.Out;
using System.ComponentModel.DataAnnotations;

namespace DotByDot.Data.Dto
{
    public class CircleSetResponseDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public List<CircleResponseDto> Circles { get; set; }
    }
}
