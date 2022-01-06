using System.Drawing;

namespace Kantaiko.ConsoleFormatting
{
    public static class Colors
    {
        #region Default Palette

        public static FormattedText FgColor(this FormattedText text, Color color)
        {
            return TextFormatter.Color(text, color, true);
        }

        public static FormattedText BgColor(this FormattedText text, Color color)
        {
            return TextFormatter.Color(text, color, false);
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

        public static FormattedText FgGray(this FormattedText text) => FgColor(text, Color.Gray);

        public static FormattedText BgGray(this FormattedText text) => BgColor(text, Color.Gray);

        public static FormattedText FgWhite(this FormattedText text) => FgColor(text, Color.White);

        public static FormattedText BgWhite(this FormattedText text) => BgColor(text, Color.White);

        #endregion

        #region Rgb/Hex/Hsl

        public static FormattedText FgRgb(this FormattedText text, byte red, byte green, byte blue)
        {
            var color = Color.FromArgb(red, green, blue);
            return FgColor(text, color);
        }

        public static FormattedText BgRgb(this FormattedText text, byte red, byte green, byte blue)
        {
            var color = Color.FromArgb(red, green, blue);
            return BgColor(text, color);
        }

        public static FormattedText FgHex(this FormattedText text, string hex)
        {
            var color = ColorSystem.ColorTranslator.FromHex(hex);
            return FgColor(text, color);
        }

        public static FormattedText BgHex(this FormattedText text, string hex)
        {
            var color = ColorSystem.ColorTranslator.FromHex(hex);
            return BgColor(text, color);
        }

        public static FormattedText FgHsl(this FormattedText text, int hue, float saturation, float lightness)
        {
            var color = ColorSystem.ColorTranslator.FromHsl(hue, saturation, lightness);
            return FgColor(text, color);
        }

        public static FormattedText BgHsl(this FormattedText text, int hue, float saturation, float lightness)
        {
            var color = ColorSystem.ColorTranslator.FromHsl(hue, saturation, lightness);
            return BgColor(text, color);
        }

        #endregion
    }
}
