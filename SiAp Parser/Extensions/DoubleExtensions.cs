using System;

namespace SiAp_Parser.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="padLeftWidth"></param>
        /// <returns></returns>
        public static string ToSIApFormat(this double value, string format = "0.00", int padLeftWidth = 15)
        {
            return Math.Abs(value).ToString(format).Replace(",", string.Empty).PadLeft(padLeftWidth, '0');
        }

        // http://stackoverflow.com/questions/5940222/how-to-properly-compare-double-values-in-c
        // http://programmers.stackexchange.com/questions/180309/is-this-a-good-way-to-compare-two-numbers
        /// <summary>
        /// Determines if the double value is less than or equal to the float parameter according to the defined precision.
        /// </summary>
        /// <param name="double1">The double1.</param>
        /// <param name="double2">The double2.</param>
        /// <param name="precision">The precision. The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool LessThan(this double double1, double double2, int precision)
        {
            return Math.Round(double1 - double2, precision) < 0;
        }

        /// <summary>
        /// Determines if the double value is less than or equal to the float parameter according to the defined precision.
        /// </summary>
        /// <param name="double1">The double1.</param>
        /// <param name="double2">The double2.</param>
        /// <param name="precision">The precision. The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool LessThanOrEqualTo(this double double1, double double2, int precision)
        {
            return Math.Round(double1 - double2, precision) <= 0;
        }

        /// <summary>
        /// Determines if the double value is greater than (>) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="double1">The double1.</param>
        /// <param name="double2">The double2.</param>
        /// <param name="precision">The precision. The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool GreaterThan(this double double1, double double2, int precision)
        {
            return Math.Round(double1 - double2, precision) > 0;
        }

        /// <summary>
        /// Determines if the double value is greater than or equal to (>=) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="double1">The double1.</param>
        /// <param name="double2">The double2.</param>
        /// <param name="precision">The precision. The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool GreaterThanOrEqualTo(this double double1, double double2, int precision)
        {
            return Math.Round(double1 - double2, precision) >= 0;
        }

        /// <summary>
        /// Determines if the double value is equal to (==) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="double1">The double1.</param>
        /// <param name="double2">The double2.</param>
        /// <param name="precision">The precision. The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool AlmostEquals(this double double1, double double2, int precision)
        {
            return Math.Round(double1 - double2, precision) == 0;
        }
    }
}
