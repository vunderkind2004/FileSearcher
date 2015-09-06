using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Interfaces;
using FS.Interfaces.Models;

namespace FS.Web.Helpers
{
    public static class FileSearchContainer
    {
        private static ConcurrentDictionary<string, IFileSearcher> SearcherDictionary = new ConcurrentDictionary<string, IFileSearcher>();

        public static void AddSearcher(string searcherId, IFileSearcher fileSearcher)
        {
            SearcherDictionary[searcherId] = fileSearcher;
        }

        public static int GetProgress(string searcherId)
        {
            if (SearcherDictionary.ContainsKey(searcherId) && SearcherDictionary[searcherId]!=null)
                return SearcherDictionary[searcherId].Progress;
            return 0;
        }

        public static SearchFileResult GetTemporaryResult(string searcherId)
        {
            if (SearcherDictionary.ContainsKey(searcherId) && SearcherDictionary[searcherId] != null)
                return SearcherDictionary[searcherId].GetTemporaryResult();
            return new SearchFileResult();
        }

        public static void RemoveSearcher(string searcherId)
        { 
            IFileSearcher searcher;
            SearcherDictionary.TryRemove(searcherId, out searcher);
        }

        public static void Stop(string searcherId)
        {
            if (SearcherDictionary.ContainsKey(searcherId) && SearcherDictionary[searcherId] != null)
                SearcherDictionary[searcherId].Stop();
        }
    }
}
