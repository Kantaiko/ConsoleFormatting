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

        private readonly List<int> _modifiers = new();

        public FormattedText(string value, params int[] moditifers) : this(value)
        {
            _modifiers.AddRange(moditifers);
        }

        public FormattedText(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public IReadOnlyCollection<int> Modifiers => _modifiers;

        public void AddModifier(int modifier) => _modifiers.Add(modifier);

        public void AddModifiers(params int[] modifiers) => _modifiers.AddRange(modifiers);

        public void RemoveModifier(int modifier)
        {
            _modifiers.Remove(modifier);
        }

        public override string ToString()
        {
            if (_modifiers.Count == 0)
            {
                return Value;
            }

            var modifiers = string.Join(";", Modifiers);
            return $"\u001b[{modifiers}m{Value}\u001b[0m";
        }

        public static implicit operator FormattedText(string value) => new(value);

        public static implicit operator string(FormattedText text) => text.ToString();
    }
}
