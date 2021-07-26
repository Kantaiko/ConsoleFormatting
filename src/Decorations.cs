namespace Kantaiko.ConsoleFormatting
{
    public static class Decorations
    {
        public static FormattedText Reset(this FormattedText text)
        {
            text.AddModifier(0);
            return text;
        }

        public static FormattedText Bold(this FormattedText text)
        {
            text.AddModifier(1);
            return text;
        }

        public static FormattedText Dim(this FormattedText text)
        {
            text.AddModifier(2);
            return text;
        }

        public static FormattedText Italic(this FormattedText text)
        {
            text.AddModifier(3);
            return text;
        }

        public static FormattedText Underline(this FormattedText text)
        {
            text.AddModifier(4);
            return text;
        }

        public static FormattedText Blink(this FormattedText text)
        {
            text.AddModifier(5);
            return text;
        }

        public static FormattedText Inverse(this FormattedText text)
        {
            text.AddModifier(7);
            return text;
        }

        public static FormattedText Hidden(this FormattedText text)
        {
            text.AddModifier(8);
            return text;
        }

        public static FormattedText Strike(this FormattedText text)
        {
            text.AddModifier(9);
            return text;
        }

        public static FormattedText Overline(this FormattedText text)
        {
            text.AddModifier(53);
            return text;
        }
    }
}
