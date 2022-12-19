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
                throw new ArgumentException();
            }
            else if (input.Length < 1)
            {
                throw new ArgumentException();
            }
            //else if (input[0].)
            //{

            //}
            string name = string.Empty;
            string number = string.Empty;
            foreach (char item in input)
            {
                if (!char.IsDigit(item))
                {
                    name += item;
                }
                else
                {
                    number += item;
                }
            }

            return new Tuple<string, int>(name.Trim(), int.Parse(number));
        }
    }
}
