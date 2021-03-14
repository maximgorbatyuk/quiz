using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz
{
    /// <summary>
    /// This class is thread safe.
    /// </summary>
    public class Parser
    {
        private readonly object _locker = new ();
        private FileInfo _file;

        public void SetFile(FileInfo f)
        {
            lock (_locker)
            {
                _file = f;
            }
        }

        public FileInfo GetFile()
        {
            lock (_locker)
            {
                return _file;
            }
        }

        /// <summary>
        /// Get Content.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <returns></returns>
        public string GetContent()
        {
            StreamReader i = new (_file.OpenRead());

            string output = "";
            int data;

            while ((data = i.Read()) > 0)
            {
                output += (char)data;
            }

            return output;
        }

        /// <summary>
        /// Get Content Without Unicode.
        /// </summary>
        /// <exception cref="IOException"></exception>
        /// <returns></returns>
        public string GetContentWithoutUnicode()
        {
            StreamReader i = new (_file.OpenRead());

            string output = "";

            int data;
            while ((data = i.Read()) > 0)
            {
                if (data < 0x80)
                {
                    output += (char)data;
                }
            }

            return output;
        }

        public async Task SaveContentAsync(string content)
        {
            StreamWriter o = new (_file.OpenWrite());

            try
            {
                for (int i = 0; i < content.Length; i += 1)
                {
                    await o.WriteAsync(content.ElementAt(i));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}