namespace DotByDot.Utils
{
    public static class Helpers
    {
        public static string GetRandomHexColor()
        {
            Random random = new Random();
            int red = random.Next(256); // 0 to 255
            int green = random.Next(256); // 0 to 255
            int blue = random.Next(256); // 0 to 255

            return $"#{red:X2}{green:X2}{blue:X2}";
        }
    }
}
