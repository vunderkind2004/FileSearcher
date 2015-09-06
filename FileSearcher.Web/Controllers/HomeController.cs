using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FS.Core;
using FS.Interfaces.Models;
using FS.Web.Helpers;
using FS.Web.ViewModels;

namespace FS.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/              

        public ActionResult Index()
        {
            var id = Guid.NewGuid().ToString("n");
            var model = new FileSearcherViewModel { FileSearcherId = id };
            return View("SearchFiles",model);
        }

        [HttpPost]
        public ActionResult SearchFiles(FileSearcherViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var searcher = new FileSearcher();           

            if (!string.IsNullOrEmpty(model.FileSearcherId))
            {
                FileSearchContainer.AddSearcher(model.FileSearcherId, searcher);                   
            }
            try
            {
                var result = searcher.SearchFiles(new FileSearcherQuery { SearchString = model.SearchString, TargetDirectory = model.Directory });
                model.Files = result.Files.Select(x => x.FullName);
            }
            catch (Exception ex)
            {
                return RedirectToAction("BadRequest", "Error");
            }
            finally
            {
                if (!string.IsNullOrEmpty(model.FileSearcherId))
                {
                    FileSearchContainer.RemoveSearcher(model.FileSearcherId);
                }
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult Stop(string fileSearcherId )
        {
            if (!string.IsNullOrEmpty(fileSearcherId))
            {
                FileSearchContainer.Stop(fileSearcherId);
            }
            return Json(null);
        }
                      
        public JsonResult GetProgress(string fileSearcherId)
        {
            var userProgress = FileSearchContainer.GetProgress(fileSearcherId);
            return Json(userProgress,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTemporaryResult(string fileSearcherId)
        {
            var tempSearchResult = FileSearchContainer.GetTemporaryResult(fileSearcherId);
            var fileNames = tempSearchResult.Files.Select(x => x.FullName).ToArray();
            return Json(fileNames, JsonRequestBehavior.AllowGet);
        }

    }
}
