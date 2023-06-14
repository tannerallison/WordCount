// See https://aka.ms/new-console-template for more information

using wc;

Options ParseArguments(string[] args)
{
    var options = new Options();
    foreach (var arg in args)
    {
        var func = CountFunction.All.FirstOrDefault(cF => cF.Options.Contains(arg));
        if (func != null)
        {
            options.AppliedFunctions.Add(func);
            continue;
        }

        options.FilePath = arg;
    }

    return options;
}

var options = ParseArguments(args);

// Get the current path that the application is running in
var currentDirectory = Directory.GetCurrentDirectory();

// Append the path passed in to the current directory
var fullPath = Path.IsPathRooted(options.FilePath)
    ? options.FilePath
    : Path.Combine(currentDirectory, options.FilePath);

var text = File.ReadAllBytes(fullPath);

foreach (var f in options.AppliedFunctions.OrderBy(f => f.Order))
{
    var count = f.Count(text);
    Console.Write($"{count} ");
}

Console.WriteLine($"{options.FilePath}");
