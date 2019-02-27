using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeClaimAPI.Models
{
    public class LogWriter : ILogWriter
    {
        public string FilePath { get; set; }

        public LogWriter(string path, string fileName)
        {
            FilePath = string.Concat(path, fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }

        public bool Write(string content)
        {
            try
            {
                File.AppendAllLines(FilePath, new string[] { content });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WriteSeperator()
        {
            try
            {
                File.AppendAllLines(FilePath, new string[] { "======================================================================================" });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
