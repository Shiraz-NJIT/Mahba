using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Njit.Common
{
    public static class StandardNumericFormatStrings
    {
        /// <summary>
        /// "C" or "c"
        /// A currency value
        /// 123.456 ("C", en-US) -> $123.46
        /// 123.456 ("C", fr-FR) -> 123,46 €
        /// </summary>
        public static string Currency
        {
            get
            {
                return "C";
            }
        }

        /// <summary>
        /// "D" or "d"
        /// Integer digits with optional negative sign
        /// 1234 ("D") -> 1234
        /// -1234 ("D6") -> -001234
        /// </summary>
        public static string Decimal
        {
            get
            {
                return "D";
            }
        }

        /// <summary>
        /// "E" or "e"
        /// Exponential notation.
        /// 1052.0329112756 ("E", en-US) -> 1.052033E+003
        /// 1052.0329112756 ("e", fr-FR) -> 1,052033e+003
        /// -1052.0329112756 ("e2", en-US) -> -1.05e+003
        /// -1052.0329112756 ("E2", fr_FR) -> -1,05E+003
        /// </summary>
        public static string Exponential
        {
            get
            {
                return "E";
            }
        }

        /// <summary>
        /// "F" or "f"
        /// Integral and decimal digits with optional negative sign
        /// 1234.567 ("F", en-US) -> 1234.57
        /// 1234.567 ("F", de-DE) -> 1234,57
        /// 1234 ("F1", en-US) -> 1234.0
        /// 1234 ("F1", de-DE) -> 1234,0
        /// -1234.56 ("F4", en-US) -> -1234.5600
        /// -1234.56 ("F4", de-DE) -> -1234,5600
        /// </summary>
        public static string FixedPoint
        {
            get
            {
                return "F";
            }
        }

        /// <summary>
        /// "G" or "g"
        /// The most compact of either fixed-point or scientific notation
        /// -123.456 ("G", en-US) -> -123.456
        /// 123.456 ("G", sv-SE) -> -123,456
        /// 123.4546 ("G4", en-US) -> 123.5
        /// 123.4546 ("G4", sv-SE) -> 123,5
        /// -1.234567890e-25 ("G", en-US) -> -1.23456789E-25
        /// -1.234567890e-25 ("G", sv-SE) -> -1,23456789E-25
        /// </summary>
        public static string General
        {
            get
            {
                return "G";
            }
        }

        /// <summary>
        /// N or n
        /// Integral and decimal digits, group separators, and a decimal separator with optional negative sign
        /// 1234.567 ("N", en-US) -> 1,234.57
        /// 1234.567 ("N", ru-RU) -> 1 234,57
        /// 1234 ("N1", en-US) -> 1,234.0
        /// 1234 ("N1", ru-RU) -> 1 234,0
        /// -1234.56 ("N3", en-US) -> -1,234.560
        /// -1234.56 ("N3", ru-RU) -> -1 234,560
        /// </summary>
        public static string Number
        {
            get
            {
                return "N";
            }
        }

        /// <summary>
        /// P or p
        /// Number multiplied by 100 and displayed with a percent symbol
        /// 1 ("P", en-US) -> 100.00 %
        /// 1 ("P", fr-FR) -> 100,00 %
        /// -0.39678 ("P1", en-US) -> -39.7 %
        /// -0.39678 ("P1", fr-FR) -> -39,7 %
        /// </summary>
        public static string Percent
        {
            get
            {
                return "P";
            }
        }

        /// <summary>
        /// R or r
        /// A string that can round-trip to an identical number
        /// 123456789.12345678 ("R") -> 123456789.12345678 
        /// -1234567890.12345678 ("R") -> -1234567890.1234567
        /// </summary>
        public static string RoundTrip
        {
            get
            {
                return "R";
            }
        }

        /// <summary>
        /// X or x
        /// A hexadecimal string
        /// 255 ("X") -> FF
        /// 255 ("x4") -> 00ff
        /// </summary>
        public static string Hexadecimal
        {
            get
            {
                return "X";
            }
        }
    }
}
