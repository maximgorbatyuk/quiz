using System.Threading.Tasks;

namespace Quiz;

class Program
{
    private const string ReadmeFileLink = "https://raw.githubusercontent.com/maximgorbatyuk/quiz/main/README.md";

    public static async Task Main(string[] args)
    {
        var remoteFile = new RemoteFile(ReadmeFileLink);

        ReadonlyFile readonlyFile = await remoteFile.DownloadAsync();

        new Output("Content of the downloaded file", await readonlyFile.ContentAsync());

        var parser = new Parser();

        parser.SetFile(readonlyFile.Info());

        new Output("Parser.GetContent()", parser.GetContent());

        new Output("Parser.GetContentWithoutUnicode()", parser.GetContentWithoutUnicode());
    }
}