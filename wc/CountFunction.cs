using System.Text;
using System.Text.RegularExpressions;

namespace wc;

public class CountFunction
{
    private static readonly CountFunction LineCount = new(0, options: new[] { "-l", "--lines" },
        count: s => s.Count(c => c == Convert.ToByte('\n')));

    private static readonly CountFunction WordCount = new(1, options: new[] { "-w", "--words" },
        count: s => Regex.Count(Encoding.UTF8.GetString(s), "\\s+"));

    private static readonly CountFunction CharacterCount = new(2, options: new[] { "-m", "--chars" },
        count: s => Encoding.UTF8.GetString(s).Length);

    private static readonly CountFunction ByteCount = new(3, options: new[] { "-c", "--bytes" }, count: s => s.Length);

    private static readonly CountFunction MaxLineLength = new(4, options: new[] { "-L", "--max-line-length" },
        count: s => s.Max(c => c == '\n' ? 0 : c));

    public static readonly IList<CountFunction> All = new List<CountFunction>
    {
        LineCount,
        WordCount,
        CharacterCount,
        ByteCount,
        MaxLineLength
    };

    private CountFunction(int order, string[] options, Func<byte[], int> count)
    {
        Options = options;
        Count = count;
        Order = order;
    }

    public string[] Options { get; private set; }
    public Func<byte[], int> Count { get; private set; }
    public int Order { get; private set; }
}
