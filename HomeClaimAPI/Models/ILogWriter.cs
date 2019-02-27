using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeClaimAPI.Models
{
    public interface ILogWriter
    {
        string FilePath { get; set; }

        bool Write(string content);
        bool WriteSeperator();
    }
}
