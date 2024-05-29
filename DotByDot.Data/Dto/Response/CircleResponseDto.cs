using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotByDot.Data.Dto.Out
{
    public class CircleResponseDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int? CircleSetId { get; set; }

        [Required]
        public int CoordX { get; set; }
        [Required]
        public int CoordY { get; set; }

        [Required]
        public double Diameter { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
