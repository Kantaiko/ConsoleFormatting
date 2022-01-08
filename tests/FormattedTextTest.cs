using System.Drawing;
using Xunit;

namespace Kantaiko.ConsoleFormatting.Tests
{
    public class FormattedTextTest
    {
        [Theory]
        [InlineData("Black", "\u001b[38;2;0;0;0m123\u001b[m", "\u001b[48;2;0;0;0m123\u001b[m")]
        [InlineData("Red", "\u001b[38;2;255;0;0m123\u001b[m", "\u001b[48;2;255;0;0m123\u001b[m")]
        [InlineData("Green", "\u001b[38;2;0;128;0m123\u001b[m", "\u001b[48;2;0;128;0m123\u001b[m")]
        [InlineData("Yellow", "\u001b[38;2;255;255;0m123\u001b[m", "\u001b[48;2;255;255;0m123\u001b[m")]
        [InlineData("Blue", "\u001b[38;2;0;0;255m123\u001b[m", "\u001b[48;2;0;0;255m123\u001b[m")]
        [InlineData("Magenta", "\u001b[38;2;255;0;255m123\u001b[m", "\u001b[48;2;255;0;255m123\u001b[m")]
        [InlineData("Cyan", "\u001b[38;2;0;255;255m123\u001b[m", "\u001b[48;2;0;255;255m123\u001b[m")]
        [InlineData("Gray", "\u001b[38;2;128;128;128m123\u001b[m", "\u001b[48;2;128;128;128m123\u001b[m")]
        [InlineData("White", "\u001b[38;2;255;255;255m123\u001b[m", "\u001b[48;2;255;255;255m123\u001b[m")]
        public void ShouldReturnCorrectColorAnsiCode(string colorName, string expectedFg, string expectedBg)
        {
            // Act
            var color = Color.FromName(colorName);
            var fgResult = Colors.FgColor("123", color).ToString();
            var bgResult = Colors.BgColor("123", color).ToString();

            // Assert
            Assert.Equal(expectedFg, fgResult);
            Assert.Equal(expectedBg, bgResult);
        }

        [Theory]
        [InlineData(TextDecoration.Reset, "\u001b[0m123\u001b[m")]
        [InlineData(TextDecoration.Bold, "\u001b[1m123\u001b[m")]
        [InlineData(TextDecoration.Dim, "\u001b[2m123\u001b[m")]
        [InlineData(TextDecoration.Italic, "\u001b[3m123\u001b[m")]
        [InlineData(TextDecoration.Underline, "\u001b[4m123\u001b[m")]
        [InlineData(TextDecoration.Blink, "\u001b[5m123\u001b[m")]
        [InlineData(TextDecoration.Inverse, "\u001b[6m123\u001b[m")]
        [InlineData(TextDecoration.Hidden, "\u001b[8m123\u001b[m")]
        [InlineData(TextDecoration.Strike, "\u001b[9m123\u001b[m")]
        [InlineData(TextDecoration.Overline, "\u001b[53m123\u001b[m")]
        public void ShouldReturnCorrectDecorationAnsiCode(TextDecoration decoration, string expected)
        {
            // Act
            var actual = Decorations.Decoration("123", decoration);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturnCorrentMultiFormatAnsiCode()
        {
            // Act
            var actual = Colors.FgYellow("123").Bold().Blink().ToString();
            var expected = "\u001b[38;2;255;255;0;1;5m123\u001b[m";

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
