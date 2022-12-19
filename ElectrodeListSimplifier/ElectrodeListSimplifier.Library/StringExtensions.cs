using ElectrodeListSimplifier.Library.Exceptions;
using System;

namespace ElectrodeListSimplifier.Library
{
    public static class StringExtensions
    {
        /// <summary>
        /// String extension method to be able to split a string on two parts: text and numeral.
        /// The sequence must be always only StringNumber.
        /// </summary>
        /// <param name="input">A string.</param>
        /// <returns>Tuple pair with string and number.</returns>
        public static Tuple<string, int> SplitNameAndNumber(this string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            input = input.Trim();
            if (input.Length < 2 || !char.IsLetter(input[0]))
            {
                throw new ElectrodeNameFormatException(input);
            }

            string name = string.Empty;
            string number = string.Empty;
            foreach (char item in input)
            {
                if (!char.IsDigit(item) && string.IsNullOrEmpty(number))
                {
                    name += item;
                }
                else if (!char.IsDigit(item) && !string.IsNullOrEmpty(number))
                {
                    throw new ElectrodeNameFormatException(input);
                }
                else
                {
                    number += item;
                }
            }

            return new Tuple<string, int>(name, int.Parse(number));
        }
    }
}
