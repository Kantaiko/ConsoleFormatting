using System;
using System.Runtime.InteropServices;

namespace Kantaiko.ConsoleFormatting.Internal
{
    internal class NativeMethods
    {
        private const int StdOutputHandle = -11;
        private const uint EnableVirtualTerminalProcessing = 0x0004;

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        public static void EnableWindowsSupport()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var hConsole = GetStdHandle(StdOutputHandle);

                if (!GetConsoleMode(hConsole, out var mode))
                {
                    return;
                }

                SetConsoleMode(hConsole, mode | EnableVirtualTerminalProcessing);
            }
        }
    }
}
