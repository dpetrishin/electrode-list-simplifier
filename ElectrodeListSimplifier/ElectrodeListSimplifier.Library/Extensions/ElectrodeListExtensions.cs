using System.Collections.Generic;
using System.Linq;

namespace ElectrodeListSimplifier.Library.Extensions
{
    public static class ElectrodeListExtensions
    {
        public static string ToSimplifiedString(this IList<Electrode> input)
        {
            var result = new List<string>();
            var dictionary = new Dictionary<string, SortedSet<int>>();

            foreach (var item in input)
            {
                if (dictionary.ContainsKey(item.Name))
                {
                    dictionary[item.Name].Add(item.Number);
                    continue;
                }

                var set = new SortedSet<int>
                {
                    item.Number
                };

                dictionary.Add(item.Name, set);
            }

            foreach (KeyValuePair<string, SortedSet<int>> pair in dictionary)
            {
                string name = pair.Key;
                var list = new List<int>();

                foreach (var number in pair.Value)
                {
                    if (!list.Any())
                    {
                        list.Add(number);
                    }
                    else if (list.Any() && list[^1] == number - 1)
                    {
                        list.Add(number);
                    }
                    else if (list.Count > 2)
                    {
                        result.Add($"{name}{list[0]}...{name}{list[^1]}");
                        list.Clear();
                        list.Add(number);
                    }
                    else
                    {
                        result.AddRange(list.Select(x => $"{name}{x}"));
                        list.Clear();
                        list.Add(number);
                    }
                }

                if (list.Any())
                {
                    if (list.Count > 2)
                    {
                        result.Add($"{name}{list[0]}...{name}{list[^1]}");
                    }
                    else
                    {
                        result.AddRange(list.Select(x => $"{name}{x}"));
                    }
                }
            }

            return string.Join(", ", result);
        }
    }
}
