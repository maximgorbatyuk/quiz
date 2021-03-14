using System;
using System.IO;
using System.Threading.Tasks;

namespace Quiz
{
    public class ReadonlyFile
    {
        private readonly FileInfo _file;
        private FileContent _content;

        public ReadonlyFile(string fileName)
        {
            _file = new FileInfo(fileName);
        }

        public async Task<string> ContentAsync()
        {
            if (_content != null)
            {
                return _content.Content;
            }

            if (!_file.Exists)
            {
                throw new InvalidOperationException("The file does not exists");
            }

            await using var stream = _file.OpenRead();
            using var streamReader = new StreamReader(stream);

            _content = new FileContent(await streamReader.ReadToEndAsync());
            return _content.Content;
        }

        public FileInfo Info()
        {
            if (!_file.Exists)
            {
                throw new InvalidOperationException("The file does not exists");
            }

            return _file;
        }

        private class FileContent
        {
            public FileContent(string content)
            {
                Content = content;
            }

            public string Content { get; }
        }
    }
}