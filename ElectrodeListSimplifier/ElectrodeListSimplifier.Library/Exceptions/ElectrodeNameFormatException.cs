using System;

namespace ElectrodeListSimplifier.Library.Exceptions
{
    public class ElectrodeNameFormatException : Exception
    {
        public ElectrodeNameFormatException(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public override string Message => $"Incorrect format of the name: {this.Name}.";
        public string UserMessage => $"{this.Message}\n The correct format should contain String + Number. For example: E10, IC2 etc.";
    }
}
