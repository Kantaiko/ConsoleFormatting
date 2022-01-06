namespace Kantaiko.ConsoleFormatting
{
    public enum TextDecoration
    {
        /// <summary>
        /// Reset all styles
        /// </summary>
        Reset = 0,

        /// <summary>
        /// Bold text
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Dim text
        /// </summary>
        Dim = 2,

        /// <summary>
        /// Italic text
        /// </summary>
        Italic = 3,

        /// <summary>
        /// Underlined text
        /// </summary>
        Underline = 4,

        /// <summary>
        /// Blinking text
        /// </summary>
        Blink = 5,

        /// <summary>
        /// Inverse text
        /// </summary>
        Inverse = 6,

        /// <summary>
        /// Invisible text
        /// </summary>
        Hidden = 8,

        /// <summary>
        /// Strikethrough text
        /// </summary>
        Strike = 9,

        /// <summary>
        /// Overline text (line above)
        /// </summary>
        Overline = 53
    }
}
