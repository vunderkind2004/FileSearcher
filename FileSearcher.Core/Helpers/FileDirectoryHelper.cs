using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FS.Core.Helpers
{
    public static class FileDirectoryHelper
    {
        public static IEnumerable<string> GetAllFilesInDirectoryAndSubDirectories(string directory)
        {
            var fileList = new List<string>();
            GetFiles( directory, ref fileList);
            return fileList;
        }

        private static void GetFiles(string directory, ref List<string> fileList)
        {
            var files = Directory.GetFiles(directory);
            if (files.Any())
            {
                fileList.AddRange(files);
            }
            var directories = Directory.GetDirectories(directory);
            foreach (var dir in directories)
            {
                GetFiles(dir, ref fileList);
            }
        }

        


    }
}
