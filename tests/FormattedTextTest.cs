using Xunit;

namespace Kantaiko.ConsoleFormatting.Tests
{
    public class FormattedTextTest
    {
        [Theory]
        [InlineData(Color.Black, "\u001b[30m123\u001b[0m", "\u001b[40m123\u001b[0m")]
        [InlineData(Color.Red, "\u001b[31m123\u001b[0m", "\u001b[41m123\u001b[0m")]
        [InlineData(Color.Green, "\u001b[32m123\u001b[0m", "\u001b[42m123\u001b[0m")]
        [InlineData(Color.Yellow, "\u001b[33m123\u001b[0m", "\u001b[43m123\u001b[0m")]
        [InlineData(Color.Blue, "\u001b[34m123\u001b[0m", "\u001b[44m123\u001b[0m")]
        [InlineData(Color.Magenta, "\u001b[35m123\u001b[0m", "\u001b[45m123\u001b[0m")]
        [InlineData(Color.Cyan, "\u001b[36m123\u001b[0m", "\u001b[46m123\u001b[0m")]
        [InlineData(Color.White, "\u001b[37m123\u001b[0m", "\u001b[47m123\u001b[0m")]
        public void ShouldReturnCorrectColorAnsiCode(Color color, string expectedFg, string expectedBg)
        {
            var fgResult = Colors.FgColor("123", color).ToString();
            var bgResult = Colors.BgColor("123", color).ToString();

            Assert.Equal(fgResult, expectedFg);
            Assert.Equal(bgResult, expectedBg);
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
            var result = Decorations.Decoration("123", decoration);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void ShouldReturnCorrentMultiFormatAnsiCode()
        {
            var result = Colors.FgYellow("123").Bold().Blink().ToString();
            var expected = "\u001b[33;1;5m123\u001b[0m";

            Assert.Equal(result, expected);
        }
    }
}