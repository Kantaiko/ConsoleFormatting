

using Kantaiko.ConsoleFormatting.Internal;

namespace Kantaiko.ConsoleFormatting
{
    public static class Colors
    {
        #region Default Palette
        public static FormattedText FgColor(this FormattedText text, Color color)
        {
            text.AddModifier((byte)color);
            return text;
        }

        public static FormattedText BgColor(this FormattedText text, Color color)
        {
            text.AddModifier((byte) (color + 10));
            return text;
        }

        public static FormattedText FgBlack(this FormattedText text) => FgColor(text, Color.Black);
        public static FormattedText BgBlack(this FormattedText text) => BgColor(text, Color.Black);

        public static FormattedText FgRed(this FormattedText text) => FgColor(text, Color.Red);
        public static FormattedText BgRed(this FormattedText text) => BgColor(text, Color.Red);

        public static FormattedText FgGreen(this FormattedText text) => FgColor(text, Color.Green);
        public static FormattedText BgGreen(this FormattedText text) => BgColor(text, Color.Green);

        public static FormattedText FgYellow(this FormattedText text) => FgColor(text, Color.Yellow);
        public static FormattedText BgYellow(this FormattedText text) => BgColor(text, Color.Yellow);

        public static FormattedText FgBlue(this FormattedText text) => FgColor(text, Color.Blue);
        public static FormattedText BgBlue(this FormattedText text) => BgColor(text, Color.Blue);

        public static FormattedText FgMagenta(this FormattedText text) => FgColor(text, Color.Magenta);
        public static FormattedText BgMagenta(this FormattedText text) => BgColor(text, Color.Magenta);

        public static FormattedText FgCyan(this FormattedText text) => FgColor(text, Color.Cyan);
        public static FormattedText BgCyan(this FormattedText text) => BgColor(text, Color.Cyan);

        public static FormattedText FgWhite(this FormattedText text) => FgColor(text, Color.White);
        public static FormattedText BgWhite(this FormattedText text) => BgColor(text, Color.White);
        #endregion

        #region Rgb/Hex
        public static FormattedText FgRgb(this FormattedText text, byte red, byte green, byte blue)
        {
            text.AddModifiers(38, 2, red, green, blue);
            return text;
        }

        public static FormattedText BgRgb(this FormattedText text, byte red, byte green, byte blue)
        {
            text.AddModifiers(48, 2, red, green, blue);
            return text;
        }

        public static FormattedText FgHex(this FormattedText text, string hex)
        {
            var (red, green, blue) = ColorConverter.ConvertHexToRgb(hex);
            return FgRgb(text, red, green, blue);
        }

        public static FormattedText BgHex(this FormattedText text, string hex)
        {
            var (red, green, blue) = ColorConverter.ConvertHexToRgb(hex);
            return BgRgb(text, red, green, blue);
        }
        #endregion

        #region Hsl
        public static FormattedText FgHsl(this FormattedText text, int hue, float saturation, float lightness)
        {
            var (red, green, blue) = ColorConverter.ConvertHslToRgb(hue, saturation, lightness);
            return FgRgb(text, red, green, blue);
        }

        public static FormattedText BgHsl(this FormattedText text, int hue, float saturation, float lightness)
        {
            var (red, green, blue) = ColorConverter.ConvertHslToRgb(hue, saturation, lightness);
            return BgRgb(text, red, green, blue);
        }
        #endregion
    }
}
