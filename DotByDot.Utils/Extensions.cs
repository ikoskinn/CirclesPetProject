using DotByDot.Core.Domain.Models;

namespace DotByDot.Utils
{
    public static class Extensions
    {
        public static (bool Success, string Error) CheckValues(this Circle circle)
        {
            if(circle.Diameter <= 0)
                return (false, "Diameter must be more than 0!");
            if (circle.CoordX < 0)
                return (false, "X coord can't be less than 0!");
            if (circle.CoordY < 0)
                return (false, "X coord can't be less than 0!");
            if (!circle.Color.StartsWith("#") || circle.Color.Length != 7)
                return (false, "Color must be in HEX format!");

            return (true, "");
        }
    }
}
