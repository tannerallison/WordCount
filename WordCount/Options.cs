public struct Options
{
    public const string Bytes = "-c";
    public const string Characters = "-m";
    public const string Lines = "-l";
    public const string Words = "-w";
    public bool CountBytes { get; set; }
    public bool CountCharacters { get; set; }
    public bool CountLines { get; set; }
    public bool CountWords { get; set; }
    public string FilePath { get; set; }
}
