using System;
using System.Drawing;

namespace Kantaiko.ConsoleFormatting.ColorSystem
{
    internal static class ColorTranslator
    {
        public static Color FromHex(string hex)
        {
            return System.Drawing.ColorTranslator.FromHtml(hex);
        }

        public static Color FromHsl(int hue, float saturation, float lightness)
        {
            if (hue < 0 || hue > 360)
            {
                throw new ArgumentOutOfRangeException(nameof(hue));
            }

            if (saturation < 0 || saturation > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(saturation));
            }

            if (lightness < 0 || lightness > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(lightness));
            }

            if (saturation == 0)
            {
                var color = (byte) (lightness * 255);
                return Color.FromArgb(color, color, color);
            }

            var q = lightness < 0.5
                ? lightness * (1 + saturation)
                : lightness + saturation - lightness * saturation;

            var p = 2 * lightness - q;
            var h = (float) hue / 360;

            var red = (byte)Math.Round(255 * ConvertHueToRgb(p, q, h + 1.0f / 3));
            var green = (byte)Math.Round(255 * ConvertHueToRgb(p, q, h));
            var blue = (byte)Math.Round(255 * ConvertHueToRgb(p, q, h - 1.0f / 3));

            return Color.FromArgb(red, green, blue);
        }

        private static float ConvertHueToRgb(float p, float q, float hue)
        {
            if (hue < 0) hue += 1;
            if (hue > 1) hue -= 1;

            if (6 * hue < 1) return p + (q - p) * 6 * hue;
            if (2 * hue < 1) return q;
            if (3 * hue < 2) return p + (q - p) * (2.0f / 3 - hue) * 6;

            return p;
        }
    }
}
