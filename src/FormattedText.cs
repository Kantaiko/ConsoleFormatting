using System.Collections.Generic;

namespace Kantaiko.ConsoleFormatting
{
    public sealed class FormattedText
    {
        private readonly string _value;
        private readonly List<byte> _modifiers = new();

        public FormattedText(string value, params byte[] moditifers) : this(value)
        {
            AddModifiers(moditifers);
        }

        public FormattedText(string value)
        {
            _value = value;
        }

        public IReadOnlyList<byte> Modifiers => _modifiers;

        public int Length => _value.Length;

        public void AddModifiers(params byte[] modifiers) => _modifiers.AddRange(modifiers);

        public override string ToString()
        {
            if (_modifiers.Count == 0)
            {
                return _value;
            }

            var modifiers = string.Join(";", Modifiers);
            return $"\u001b[{modifiers}m{_value}\u001b[0m";
        }

        public static implicit operator FormattedText(string value) => new(value);

        public static implicit operator string(FormattedText text) => text.ToString();
    }
}
