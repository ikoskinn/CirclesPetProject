using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotByDot.Data.Dto.In
{
    public class CircleRequestDto
    {
        [Required]
        [Range(0, 1000, ErrorMessage = "X coordinate must be greater than {1}.")]
        public int CoordX { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Y coordinate must be greater than {1}.")]
        public int CoordY { get; set; }

        [Required]
        [Range(0.1, 1000, ErrorMessage = "Diameter must be greater than zero")]
        public double Diameter { get; set; }

        [Required]
        [RegularExpression("#[A-Fa-f0-9]{6}", ErrorMessage = "Color must be in HEX-format.")]
        public string Color { get; set; }
    }
}
