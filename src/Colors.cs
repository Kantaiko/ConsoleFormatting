using System.Drawing;

namespace Kantaiko.ConsoleFormatting
{
    public static class Colors
    {
        public static FormattedText FgBlack(this FormattedText text)
        {
            text.AddModifiers(30);
            return text;
        }

        public static FormattedText BgBlack(this FormattedText text)
        {
            text.AddModifiers(40);
            return text;
        }

        public static FormattedText FgRed(this FormattedText text)
        {
            text.AddModifiers(31);
            return text;
        }

        public static FormattedText BgRed(this FormattedText text)
        {
            text.AddModifiers(41);
            return text;
        }

        public static FormattedText FgGreen(this FormattedText text)
        {
            text.AddModifiers(32);
            return text;
        }

        public static FormattedText BgGreen(this FormattedText text)
        {
            text.AddModifiers(42);
            return text;
        }

        public static FormattedText FgYellow(this FormattedText text)
        {
            text.AddModifiers(33);
            return text;
        }

        public static FormattedText BgYellow(this FormattedText text)
        {
            text.AddModifiers(43);
            return text;
        }

        public static FormattedText FgBlue(this FormattedText text)
        {
            text.AddModifiers(34);
            return text;
        }

        public static FormattedText BgBlue(this FormattedText text)
        {
            text.AddModifiers(44);
            return text;
        }

        public static FormattedText FgMagenta(this FormattedText text)
        {
            text.AddModifiers(35);
            return text;
        }

        public static FormattedText BgMagenta(this FormattedText text)
        {
            text.AddModifiers(45);
            return text;
        }

        public static FormattedText FgCyan(this FormattedText text)
        {
            text.AddModifiers(36);
            return text;
        }

        public static FormattedText BgCyan(this FormattedText text)
        {
            text.AddModifiers(46);
            return text;
        }

        public static FormattedText FgWhite(this FormattedText text)
        {
            text.AddModifiers(37);
            return text;
        }

        public static FormattedText BgWhiteCyan(this FormattedText text)
        {
            text.AddModifiers(47);
            return text;
        }

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
            var color = ColorTranslator.FromHtml(hex);
            return FgRgb(text, color.R, color.G, color.B);
        }

        public static FormattedText BgHex(this FormattedText text, string hex)
        {
            var color = ColorTranslator.FromHtml(hex);
            return BgRgb(text, color.R, color.G, color.B);
        }
    }
}
