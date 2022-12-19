using System;

namespace ElectrodeListSimplifier.Library.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// String extension method to be able to split a string on two parts: text and numeral.
        /// The sequence must be always only StringNumber.
        /// </summary>
        /// <param name="input">A string.</param>
        /// <returns>Tuple pair with string and number.</returns>
        public static Electrode ToElectode(this string input)
        {
            return input == null 
                ? throw new ArgumentNullException() 
                : new Electrode(input);
        }
    }
}
