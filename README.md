# Kantaiko.ConsoleFormatting

A C# library for coloring console output using ANSI escape codes.

## Support

- [x] Windows (cmd, powershell, Windows Terminal, ...)
- [x] Linux
- [ ] MacOS (not tested yet)

## Colors

All color methods have Fg (Foreground) and Bg (Background) versions.

Library uses colors from [System.Drawing.Color](https://docs.microsoft.com/ru-ru/dotnet/api/system.drawing.color) 

#### Default palette

```C#
Console.WriteLine(Colors.FgColor("Foreground Color", Color.Black));
Console.WriteLine(Colors.BgColor("Background Color", Color.Black));

Console.WriteLine(Colors.FgRed("Red"));
Console.WriteLine(Colors.BgRed("Green"));
```

- Black
- Red
- Green
- Yellow
- Blue
- Magenta
- Cyan
- Gray
- White

#### RGB / HEX / HSL

```C#
Console.WriteLine(Colors.FgHex(".NET", "#FFCC00"));
Console.WriteLine(Colors.FgRgb(".NET", 80, 39, 213));
Console.WriteLine(Colors.FgHsl(".NET", 290, 1f, 0.25f));
```

## Decorations

```C#
Console.WriteLine(Decorations.Decoration("Blink", TextDecoration.Blink));

Console.WriteLine(Decorations.Underline("Underline"));
```

- Reset
- Bold
- Dim
- Italic
- Underline
- Blink
- Inverse
- Hidden
- Strike
- Overline

## Chain formatting

```C#
Console.WriteLine(Colors.FgYellow("Custom Text").BgRed().Bold().Underline());

Console.WriteLine(Decorations.Italic("Custom Text").FgRed());
```
