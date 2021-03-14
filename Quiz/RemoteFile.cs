using System;
using System.IO;
using System.Threading.Tasks;

namespace Quiz
{
    public class RemoteFile
    {
        private readonly string _link;

        private ReadonlyFile _file;

        public RemoteFile(string link)
        {
            _link = link ?? throw new ArgumentNullException(paramName: nameof(link));
        }

        public async Task<ReadonlyFile> DownloadAsync()
        {
            if (_file != null)
            {
                return _file;
            }

            var net = new System.Net.WebClient();

            var data = await net.DownloadStringTaskAsync(_link);

            var fileName = Path.GetTempFileName();
            await using var logFile = File.Create(fileName);
            await using var logWriter = new StreamWriter(logFile);

            await logWriter.WriteAsync(data);

            _file = new ReadonlyFile(logFile.Name);
            return _file;
        }
    }
}