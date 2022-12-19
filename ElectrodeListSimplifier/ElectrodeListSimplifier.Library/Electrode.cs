using ElectrodeListSimplifier.Library.Exceptions;

namespace ElectrodeListSimplifier.Library
{
    public class Electrode
    {
        public Electrode(string input)
        {
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

            this.Name = name;
            this.Number = int.Parse(number);
        }

        public string Name { get; }
        public int Number { get; }
    }
}
