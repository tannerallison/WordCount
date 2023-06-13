// See https://aka.ms/new-console-template for more information

var option = args[0];
var path = args[1];

if (option == "-c")
{
    // Get the current path that the application is running in
    var currentDirectory = Directory.GetCurrentDirectory();
    // Append the path passed in to the current directory
    var fullPath = Path.Combine(currentDirectory, path);

    //Count the number of characters in the file
    var text = File.ReadAllBytes(fullPath);
    var numberOfCharacters = text.Length;
    Console.WriteLine($"{numberOfCharacters} {path}");
}
