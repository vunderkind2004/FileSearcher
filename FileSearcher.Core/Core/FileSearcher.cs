using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FS.Core.Helpers;
using FS.Interfaces;
using FS.Interfaces.Models;
using System.Linq;

namespace FS.Core
{
    public class FileSearcher : IFileSearcher
    {
        public int Progress { get; set; }
        private bool _isCanceled;
        private List<FileInfo>  _foundFiles = new List<FileInfo>();

        public SearchFileResult SearchFiles(FileSearcherQuery query)
        {
            _foundFiles.Clear();
            if (string.IsNullOrEmpty(query.SearchString))
                throw new ArgumentNullException("SearchString");
            if (!Directory.Exists(query.TargetDirectory))
                throw new DirectoryNotFoundException(string.Format("Directory {0} was not found", query.TargetDirectory));            
            _isCanceled = false;
            var files = FileDirectoryHelper.GetAllFilesInDirectoryAndSubDirectories(query.TargetDirectory).ToArray();
            var totalCount = files.Count();            
            for (var i = 0; i < totalCount; i++)
            {
                if (_isCanceled)
                    break;
                Progress = (int)Math.Round((decimal)i * 100 / totalCount);
                var fileName = files[i];
                if (IsFileContains(fileName, query.SearchString))
                    _foundFiles.Add(new FileInfo(fileName));                
            }
            return new SearchFileResult { Files = _foundFiles };
        }

        public SearchFileResult GetTemporaryResult()
        {
            return new SearchFileResult { Files = _foundFiles.ToArray() };
        }

        public void Stop()
        {
            _isCanceled = true;
        }

        private bool IsArrayContainsSequence(byte[] array, byte[] sequence, int initPosition)
        {
            var position = Array.IndexOf(array, sequence[0], initPosition);
            if (position < 0)
                return false;
            if (position < array.Length - sequence.Length)
            {
                var interestingPart = new byte[sequence.Length];
                Array.Copy(array,position, interestingPart,0, interestingPart.Length);
                if (sequence.SequenceEqual(interestingPart))
                    return true;
                return IsArrayContainsSequence(array, sequence, position+1);
            }
            return false;
        }

        private bool IsFileContains(string file, string searchString)
        {              
            foreach(var encoding in Constants.AvailableEncoding)
            {
                if(_isCanceled)
                    return false;
                var searchData = encoding.GetBytes(searchString);
                if (searchData.Length >= Constants.BufferSize)
                    throw new ArgumentOutOfRangeException(searchString);
                var array = new byte[Constants.BufferSize];
                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    if (fileStream.Length == searchData.Length)
                    { 

                        var fileBytes = new byte[searchData.Length];
                        var j = 0;
                        while(j<fileBytes.Length)
                        {
                            var readBytes = fileStream.Read(fileBytes,0,fileBytes.Length);
                            j+=readBytes;
                        }
                        return fileBytes.SequenceEqual(searchData);
                    }
                    if (fileStream.Length>searchData.Length)
                    {
                        long i = 0;
                        while (!_isCanceled && i < fileStream.Length - searchData.Length)
                        {
                            Array.Clear(array, 0, array.Length);
                            var readCount = fileStream.Read(array, 0, array.Length);                                                        
                            if(IsArrayContainsSequence(array,searchData,0))
                                return true;
                            fileStream.Position -= searchData.Length;
                            i += readCount-searchData.Length;
                        }
                    }
                }
            }
            return false;
        }
          

        
    }
}
