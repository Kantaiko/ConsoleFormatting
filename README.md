# Kantaiko.ConsoleFormatting

A library for coloring console output using ANSI escape codes.

## Support

[x] Windows (cmd, powershell, Windows Terminal, ...)
[x] Linux
[ ] MacOS

## Colors

All color methods has Fg (Foreground) and Bg (Background) versions.

### Default palette

```C#
Colors.FgColor(...)
Colors.FgBlack(...)
Colors.FgRed(...)
Colors.FgGreen(...)
Colors.FgYellow(...)
Colors.FgBlue(...)
Colors.FgMagenta(...)
Colors.FgCyan(...)
Colors.FgWhite(...)

Colors.BgColor(...)
Colors.BgBlack(...)
Colors.BgRed(...)
Colors.BgGreen(...)
Colors.BgYellow(...)
Colors.BgBlue(...)
Colors.BgMagenta(...)
Colors.BgCyan(...)
Colors.BgWhite(...)
```

```C#
Console.WriteLine(Colors.FgColor("Color", Color.Black));
Console.WriteLine(Colors.BgColor("Color", Color.Black));

Console.WriteLine(Colors.FgRed("Red"));
Console.WriteLine(Colors.BgRed("Green"));
```

### RGB / HEX / HSL

```C#
Console.WriteLine(Colors.FgHex(".NET", "#FFCC00"));
Console.WriteLine(Colors.FgRgb(".NET", 80, 39, 213));
Console.WriteLine(Colors.FgHsl(".NET", 290, 1f, 0.25f));
```

## Decorations

```C#
Decorations.Decoration(...)
Decorations.Reset(...)
Decorations.Bold(...)
Decorations.Dim(...)
Decorations.Italic(...)
Decorations.Underline(...)
Decorations.Blink(...)
Decorations.Inverse(...)
Decorations.Hidden(...)
Decorations.Strike(...)
Decorations.Overline(...)
```

```C#
Console.WriteLine(Decorations.Decoration("Blink", TextDecoration.Blink));

Console.WriteLine(Decorations.Underline("Underline"));
```

## Chain formatting

```C#
Console.WriteLine(Colors.FgYellow("Custom Text").BgRed().Bold().Underline());

Console.WriteLine(Decorations.Italic("Custom Text").FgRed());
```
