using System;
using System.Collections.Generic;
using System.Text;

namespace ElectrodeListSimplifier.Library.Extensions
{
    public static class ArrayExtensions
    {
        public static List<Electrode> ToElectrodeList(this string[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            var result = new List<Electrode>();

            foreach(var item in input)
            {
                result.Add(item.ToElectode());
            }

            return result;
        }
    }
}
