using System.ComponentModel.DataAnnotations;

namespace DotByDot.Core.Domain.Models
{
    public class Circle
    {
        public Guid Id { get; set; }

        [Required]
        public int? CircleSetId { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "X coordinate must be greater than {1}.")]
        public int CoordX { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Y coordinate must be greater than {1}.")]
        public int CoordY { get; set; }

        [Required]
        [Range(0.1, 1000.0, ErrorMessage = "Diameter must be greater than zero")]
        public double Diameter { get; set; }

        [Required]
        [RegularExpression("#[A-Fa-f0-9]{6}", ErrorMessage = "Color must be in HEX-format.")]
        public string Color { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
