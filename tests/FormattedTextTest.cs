using System.Drawing;
using Xunit;

namespace Kantaiko.ConsoleFormatting.Tests
{
    public class FormattedTextTest
    {
        [Theory]
        [InlineData("Black", "\u001b[30m123\u001b[0m", "\u001b[40m123\u001b[0m")]
        [InlineData("Red", "\u001b[31m123\u001b[0m", "\u001b[41m123\u001b[0m")]
        [InlineData("Green", "\u001b[32m123\u001b[0m", "\u001b[42m123\u001b[0m")]
        [InlineData("Yellow", "\u001b[33m123\u001b[0m", "\u001b[43m123\u001b[0m")]
        [InlineData("Blue", "\u001b[34m123\u001b[0m", "\u001b[44m123\u001b[0m")]
        [InlineData("Magenta", "\u001b[35m123\u001b[0m", "\u001b[45m123\u001b[0m")]
        [InlineData("Cyan", "\u001b[36m123\u001b[0m", "\u001b[46m123\u001b[0m")]
        [InlineData("Gray", "\u001b[38;2;128;128;128m123\u001b[0m", "\u001b[48;2;128;128;128m123\u001b[0m")]
        [InlineData("White", "\u001b[37m123\u001b[0m", "\u001b[47m123\u001b[0m")]
        public void ShouldReturnCorrectColorAnsiCode(string colorName, string expectedFg, string expectedBg)
        {
            var color = Color.FromName(colorName);

            var actualFg = Colors.FgColor("123", color).ToString();
            var actualBg = Colors.BgColor("123", color).ToString();

            Assert.Equal(expectedFg, actualFg);
            Assert.Equal(expectedBg, actualBg);
        }

        [Theory]
        [InlineData(TextDecoration.Reset, "\u001b[0m123\u001b[0m")]
        [InlineData(TextDecoration.Bold, "\u001b[1m123\u001b[0m")]
        [InlineData(TextDecoration.Dim, "\u001b[2m123\u001b[0m")]
        [InlineData(TextDecoration.Italic, "\u001b[3m123\u001b[0m")]
        [InlineData(TextDecoration.Underline, "\u001b[4m123\u001b[0m")]
        [InlineData(TextDecoration.Blink, "\u001b[5m123\u001b[0m")]
        [InlineData(TextDecoration.Inverse, "\u001b[6m123\u001b[0m")]
        [InlineData(TextDecoration.Hidden, "\u001b[8m123\u001b[0m")]
        [InlineData(TextDecoration.Strike, "\u001b[9m123\u001b[0m")]
        [InlineData(TextDecoration.Overline, "\u001b[53m123\u001b[0m")]
        public void ShouldReturnCorrectDecorationAnsiCode(TextDecoration decoration, string expected)
        {
            var actual = Decorations.Decoration("123", decoration);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnCorrentMultiFormatAnsiCode()
        {
            var actual = Colors.FgYellow("123").Bold().Blink().ToString();
            var expected = "\u001b[33;1;5m123\u001b[0m";

            Assert.Equal(expected, actual);
        }
    }
}
