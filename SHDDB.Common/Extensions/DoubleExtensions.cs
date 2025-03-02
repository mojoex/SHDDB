namespace SHDDB.Common.Extensions
{
    public static class DoubleExtensions
    {
        public static string AsString(this double value, string suffix = "", bool round = true)
        {
            if (round)
            {
                return $"{Math.Round(value * 100, 2)}{suffix}";
            }

            return $"{value * 100}{suffix}";
        }
    }
}
