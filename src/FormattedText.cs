using System.Collections.Generic;
using Kantaiko.ConsoleFormatting.Internal;

namespace Kantaiko.ConsoleFormatting
{
    public class FormattedText
    {
        static FormattedText()
        {
            NativeMethods.EnableWindowsSupport();
        }

        private readonly string _value;
        private readonly List<byte> _modifiers = new();

        public FormattedText(string value, params byte[] moditifers) : this(value)
        {
            _modifiers.AddRange(moditifers);
        }

        public FormattedText(string value)
        {
            _value = value;
        }

        public int Length => _value.Length;

        public IReadOnlyList<byte> Modifiers => _modifiers;

        public void AddModifier(byte modifier) => _modifiers.Add(modifier);

        public void AddModifiers(params byte[] modifiers) => _modifiers.AddRange(modifiers);

        public void RemoveModifier(byte modifier)
        {
            _modifiers.Remove(modifier);
        }

        public override string ToString()
        {
            if (_modifiers.Count == 0)
            {
                return _value;
            }

            var modifiers = string.Join(";", Modifiers);
            return $"\u001b[{modifiers}m{_value}\u001b[m";
        }

        public static implicit operator FormattedText(string value) => new(value);

        public static implicit operator string(FormattedText text) => text.ToString();
    }
}
