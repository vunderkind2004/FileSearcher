using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Interfaces;

namespace FS.Web.ViewModels
{
    public class FileSearcherViewModel 
    {
        public string FileSearcherId { get; set; }

        [Display(Name = "Directory for searching file")]
        [Required(ErrorMessage = "Please, specify directory")]
        public string Directory { get; set; }

        [Display(Name = "Search string")]
        [Required(ErrorMessage = "Please, specify search string")]
        public string SearchString { get; set; }

        public IEnumerable<String> Files { get; set; }
        
    }
}
