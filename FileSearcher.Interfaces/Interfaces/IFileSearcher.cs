using System.Collections.Generic;
using FS.Interfaces.Models;

namespace FS.Interfaces
{
    public interface IFileSearcher
    {
        SearchFileResult SearchFiles(FileSearcherQuery query);
        SearchFileResult GetTemporaryResult();
        int Progress { get; set; }
        void Stop();
    }
}
