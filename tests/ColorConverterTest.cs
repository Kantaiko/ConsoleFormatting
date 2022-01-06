using System;
using Kantaiko.ConsoleFormatting.ColorSystem;
using Xunit;

namespace Kantaiko.ConsoleFormatting.Tests
{
    public class ColorConverterTest
    {
        [Theory]
        [InlineData(0, 0, 1, 255, 255, 255)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(254, 0.69f, 0.494f, 80, 39, 213)]
        public void ShouldConvertHslToRgb(int hue, float saturation, float lightness, byte expectedRed, byte expectedGreen, byte expectedBlue)
        {
            var color = ColorTranslator.FromHsl(hue, saturation, lightness);

            var actual = (color.R, color.G, color.B);
            var expected = (expectedRed, expectedGreen, expectedBlue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(370)]
        public void ShouldThrowExceptionWhenHueOutOfRange(int hue)
        {
            void Action()
            {
                ColorTranslator.FromHsl(hue, 0f, 0f);
            }

            var exception = Assert.Throws<ArgumentOutOfRangeException>(Action);
            Assert.Equal(nameof(hue), exception.ParamName);
        }

        [Theory]
        [InlineData(-0.2f)]
        [InlineData(1.2f)]
        public void ShouldThrowExceptionWhenSaturationOutOfRange(float saturation)
        {
            void Action()
            {
                ColorTranslator.FromHsl(0, saturation, 0f);
            }

            var exception = Assert.Throws<ArgumentOutOfRangeException>(Action);
            Assert.Equal(nameof(saturation), exception.ParamName);
        }

        [Theory]
        [InlineData(-0.2f)]
        [InlineData(1.2f)]
        public void ShouldThrowExceptionWhenLightnessOutOfRange(float lightness)
        {
            void Action()
            {
                ColorTranslator.FromHsl(0, 0f, lightness);
            }

            var exception = Assert.Throws<ArgumentOutOfRangeException>(Action);
            Assert.Equal(nameof(lightness), exception.ParamName);
        }

        [Theory]
        [InlineData("#FFFFFF", 255, 255, 255)]
        [InlineData("#000000", 0, 0, 0)]
        [InlineData("#CCC", 204, 204, 204)]
        [InlineData("#FFCC00", 255, 204, 0)]
        public void ShouldConvertHexToRgb(string hex, byte expectedRed, byte expectedGreen, byte expectedBlue)
        {
            var color = ColorTranslator.FromHex(hex);

            var actual = (color.R, color.G, color.B);
            var expected = (expectedRed, expectedGreen, expectedBlue);

            Assert.Equal(expected, actual);
        }
    }
}
