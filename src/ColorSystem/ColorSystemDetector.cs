using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Kantaiko.ConsoleFormatting.Internal;

namespace Kantaiko.ConsoleFormatting.ColorSystem
{
    internal static class ColorSystemDetector
    {
        public static ColorSystem Detect()
        {
            if (Environment.GetEnvironmentVariable("NO_COLOR") is not null)
            {
                return ColorSystem.None;
            }

            if (TryGetForcedColor(out var forcedColor))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Windows.TryEnableColors();
                }

                return forcedColor.Value;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (!Windows.TryEnableColors())
                {
                    return ColorSystem.None;
                }

                return Environment.OSVersion.Version switch
                {
                    { Major: > 10 } => ColorSystem.TrueColor,
                    { Major: 10, Minor: >= 1 } => ColorSystem.TrueColor,
                    { Major: 10, Build: >= 14931 } => ColorSystem.TrueColor,
                    { Major: 10, Build: >= 10586 } => ColorSystem.EightBit,
                    _ => ColorSystem.Basic
                };
            }

            if (TryGetColorTerm(out var colorTerm))
            {
                if (colorTerm.Equals("truecolor", StringComparison.OrdinalIgnoreCase) ||
                    colorTerm.Equals("24bit", StringComparison.OrdinalIgnoreCase))
                {
                    return ColorSystem.TrueColor;
                }
            }

            if (TryGetTerm(out var term))
            {
                if (Regex.IsMatch(term, "(?i)-256(color)?$"))
                {
                    return ColorSystem.EightBit;
                }

                if (Regex.IsMatch(term, "(?i)^screen|^xterm|^vt100|^vt220|^rxvt|color|ansi|cygwin|linux"))
                {
                    return ColorSystem.Basic;
                }
            }

            return ColorSystem.None;
        }

        private static bool TryGetForcedColor([NotNullWhen(true)] out ColorSystem? colorSystem)
        {
            colorSystem = Environment.GetEnvironmentVariable("FORCE_COLOR") switch
            {
                "none" => ColorSystem.None,
                "256" => ColorSystem.EightBit,
                "8bit" => ColorSystem.EightBit,
                "16m" => ColorSystem.TrueColor,
                "full" => ColorSystem.TrueColor,
                "24bit" => ColorSystem.TrueColor,
                "truecolor" => ColorSystem.TrueColor,
                _ => null,
            };

            return colorSystem is not null;
        }

        private static bool TryGetColorTerm([NotNullWhen(true)] out string? colorTerm)
        {
            colorTerm = Environment.GetEnvironmentVariable("COLORTERM");
            return !string.IsNullOrWhiteSpace(colorTerm);
        }

        private static bool TryGetTerm([NotNullWhen(true)] out string? term)
        {
            term = Environment.GetEnvironmentVariable("TERM");
            return !string.IsNullOrWhiteSpace(term);
        }
    }
}
