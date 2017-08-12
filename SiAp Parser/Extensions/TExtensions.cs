namespace SiAp_Parser.Extensions
{
    public static class TExtensions
    {
        public static int SafeGetHashCode<T>(this T value) where T : class
        {
            return value == null ? 0 : value.GetHashCode();
        }
    }
}
