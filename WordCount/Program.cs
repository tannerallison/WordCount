// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var options = new Options();

bool foundOption = false;
foreach (var arg in args)
{
    switch (arg)
    {
        case Options.Characters:
            options.CountCharacters = true;
            foundOption = true;
            break;
        case Options.Bytes:
            options.CountBytes = true;
            foundOption = true;
            break;
        case Options.Lines:
            options.CountLines = true;
            foundOption = true;
            break;
        case Options.Words:
            options.CountWords = true;
            foundOption = true;
            break;
        default:
            options.FilePath = arg;
            break;
    }
}

if (!foundOption)
{
    options.CountBytes = true;
    options.CountCharacters = false;
    options.CountLines = true;
    options.CountWords = true;
}

// Get the current path that the application is running in
var currentDirectory = Directory.GetCurrentDirectory();
// Append the path passed in to the current directory
var fullPath = Path.Combine(currentDirectory, options.FilePath);
var text = File.ReadAllBytes(fullPath);

if (options.CountLines)
{
    var lines = text.Count(b => b == Convert.ToByte('\n'));
    Console.Write($"{lines} ");
}

if (options.CountWords || options.CountCharacters)
{
    var stringText = System.Text.Encoding.UTF8.GetString(text);
    var words = Regex.Count(stringText, "\\s+");
    var characters = stringText.Length;
    if (options.CountWords) Console.Write($"{words} ");
    if (options.CountCharacters) Console.Write($"{characters} ");
}

if (options.CountBytes)
{
    var chars = text.Length;
    Console.Write($"{chars} ");
}

Console.WriteLine($"{options.FilePath}");
