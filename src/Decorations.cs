namespace Kantaiko.ConsoleFormatting
{
    public static class Decorations
    {
        public static FormattedText Decoration(this FormattedText text, TextDecoration textDecoration)
        {
            text.AddModifier((byte) textDecoration);
            return text;
        }

        public static FormattedText Reset(this FormattedText text) => Decoration(text, TextDecoration.Reset);

        public static FormattedText Bold(this FormattedText text) => Decoration(text, TextDecoration.Bold);

        public static FormattedText Dim(this FormattedText text) => Decoration(text, TextDecoration.Dim);

        public static FormattedText Italic(this FormattedText text) => Decoration(text, TextDecoration.Italic);

        public static FormattedText Underline(this FormattedText text) => Decoration(text, TextDecoration.Underline);

        public static FormattedText Blink(this FormattedText text) => Decoration(text, TextDecoration.Blink);

        public static FormattedText Inverse(this FormattedText text) => Decoration(text, TextDecoration.Inverse);

        public static FormattedText Hidden(this FormattedText text) => Decoration(text, TextDecoration.Hidden);

        public static FormattedText Strike(this FormattedText text) => Decoration(text, TextDecoration.Strike);

        public static FormattedText Overline(this FormattedText text) => Decoration(text, TextDecoration.Overline);
    }
}
