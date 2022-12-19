using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectrodeListSimplifier.Library
{
    public static class ListStringExtensions
    {
        public static string ToSimplifiedString(this List<string> input)
        {
            var result = new List<string>();
            var dictionary = new Dictionary<string, SortedSet<int>>();

            foreach(var item in input)
            {
                (string name, int number) = item.SplitNameAndNumber();

                if (dictionary.ContainsKey(name))
                {
                    dictionary[name].Add(number);
                    continue;
                }

                var set = new SortedSet<int>
                {
                    number
                };
                dictionary.Add(name, set);     
            }

            foreach (KeyValuePair<string, SortedSet<int>> pair in dictionary)
            {
                var list = new List<int>();

                foreach(var number in pair.Value)
                {
                    if (list.Count != 3)
                    {
                        list.Add(number);
                    }
                    else if (list.Count == 3 && list[0] == list[1] && list[1] == list[2])
                    {
                        list[2] = number;
                    }
                    else
                    {

                    }
                }

                
            }

            return string.Join(", ", result);
        }
    }
}
