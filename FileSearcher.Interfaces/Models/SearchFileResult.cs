using System.Collections.Generic;
using System.IO;

namespace FS.Interfaces.Models
{
    public class SearchFileResult
    {
        public IEnumerable<FileInfo> Files {get;set;}

        public SearchFileResult()
        {
            Files = new FileInfo[0];
        }
    }
}
