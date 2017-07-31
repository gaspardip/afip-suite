using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAp_Parser.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSIApFormat(this decimal value, string format = "0.00", int padLeftWidth = 15)
        {
            return value.ToString(format).Replace(",", string.Empty).PadLeft(padLeftWidth, '0');
        }

        public static decimal GetSafeDecimal(this decimal value)
        {
            // reader went crazy
            if (value == decimal.MinValue || value == decimal.MaxValue)
                return 0;

            return value;
        }

        // http://stackoverflow.com/questions/5940222/how-to-properly-compare-decimal-values-in-c
        // http://programmers.stackexchange.com/questions/180309/is-this-a-good-way-to-compare-two-numbers
        /// <summary>
        /// Determines if the float value is less than or equal to the float parameter according to the defined precision.
        /// </summary>
        /// <param name="float1">The float1.</param>
        /// <param name="float2">The float2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool LessThan(this decimal decimal1, decimal decimal2, int precision)
        {
            return (Math.Round(decimal1 - decimal2, precision) < 0);
        }

        /// <summary>
        /// Determines if the float value is less than or equal to the float parameter according to the defined precision.
        /// </summary>
        /// <param name="float1">The float1.</param>
        /// <param name="float2">The float2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool LessThanOrEqualTo(this decimal decimal1, decimal decimal2, int precision)
        {
            return (Math.Round(decimal1 - decimal2, precision) <= 0);
        }

        /// <summary>
        /// Determines if the float value is greater than (>) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="float1">The float1.</param>
        /// <param name="float2">The float2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool GreaterThan(this decimal decimal1, decimal decimal2, int precision)
        {
            return (Math.Round(decimal1 - decimal2, precision) > 0);
        }

        /// <summary>
        /// Determines if the float value is greater than or equal to (>=) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="float1">The float1.</param>
        /// <param name="float2">The float2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool GreaterThanOrEqualTo(this decimal decimal1, decimal decimal2, int precision)
        {
            return (Math.Round(decimal1 - decimal2, precision) >= 0);
        }

        /// <summary>
        /// Determines if the float value is equal to (==) the float parameter according to the defined precision.
        /// </summary>
        /// <param name="float1">The float1.</param>
        /// <param name="float2">The float2.</param>
        /// <param name="precision">The precision.  The number of digits after the decimal that will be considered when comparing.</param>
        /// <returns></returns>
        public static bool AlmostEquals(this decimal decimal1, decimal decimal2, int precision)
        {
            return (Math.Round(decimal1 - decimal2, precision) == 0);
        }
    }
}
