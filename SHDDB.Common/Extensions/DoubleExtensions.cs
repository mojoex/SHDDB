namespace SHDDB.Common.Extensions
{
    public static class DoubleExtensions
    {
        public static string AsString(this double value, bool round = true)
        {
            if (round)
            {
                return Math.Round(value * 100, 2).ToString();
            }

            return (value * 100).ToString();
        }
    }
}
