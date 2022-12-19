using System;

namespace ElectrodeListSimplifier.Library
{
    public static class StringExtensions
    {
        public static bool TrySplitNameAndNumber(this string input, out Tuple<string, int> result)
        {
            result = null;
            if (input == null)
            {
                return false;
            }
            else if (input.Length < 1)
            {
                return false;
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

            result = new Tuple<string, int>(name.Trim(), int.Parse(number));
            return true;
        }
    }
}
