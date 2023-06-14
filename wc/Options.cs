namespace wc;

public class Options
{
    public ISet<CountFunction> AppliedFunctions { get; set; } = new HashSet<CountFunction>();
    public string FilePath { get; set; }
}
