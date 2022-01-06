using System;
using System.Drawing;
using System.Linq;
using Kantaiko.ConsoleFormatting.ColorSystem;

namespace Kantaiko.ConsoleFormatting
{
    internal static class TextFormatter
    {
        private static ColorSystem.ColorSystem _colorSystem = ColorSystemDetector.Detect();

        public static FormattedText Color(FormattedText text, Color color, bool foreground)
        {
            var modifiers = _colorSystem switch
            {
                ColorSystem.ColorSystem.Basic => GetBasicModifiers(color, foreground),

                _ => Array.Empty<byte>()
            };

            text.AddModifiers(modifiers);
            return text;
        }

        public static FormattedText Decoration(FormattedText text, TextDecoration decoration)
        {
            if (_colorSystem != ColorSystem.ColorSystem.None)
            {
                text.AddModifiers((byte) decoration);
            }

            return text;
        }

        private static byte[] GetBasicModifiers(Color color, bool foreground)
        {
            var parameters = new[] { color.R, color.G, color.B };
            var value = Math.Round((double)(parameters.Max() / 64));
        }
    }
}
