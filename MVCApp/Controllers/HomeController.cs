using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.EmployeeProcessor;
using static DataLibrary.BusinessLogic.BugProcessor;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()

        {
            ViewBag.Message = "Bug Dashboard";
            List<DataLibrary.Models.BugModel> bm = new List<DataLibrary.Models.BugModel>();
            List<DataLibrary.Models.BugModel> cm = GetUpdates();
            while (bm.Count <3 && cm.Count>3)
            {
                bm.Add(cm[0]);
                cm.RemoveAt(0);
            }
            
            return View(bm);
        }

        [HttpPost]
        public ActionResult ViewPDF()
        {
            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";
            TempData["Embed"] = string.Format(embed, VirtualPathUtility.ToAbsolute("~/Files/Changes.pdf"));
            
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewBugs()
        {
            ViewBag.Message = "Current Employees List";

            var data = LoadBugs();
            List<DataLibrary.Models.BugModel> bugs = new List<DataLibrary.Models.BugModel>();
            foreach (var row in data)
            {
                
                bugs.Add(new DataLibrary.Models.BugModel
                {   ID = row.ID,
                    Title = row.Title,
                    Source = row.Source,
                    Description = row.Description,
                    Priority = row.Priority,
                    Deadline1 = row.Deadline1,
                    Deadline2 = row.Deadline2,
                    DeadLineFinal = row.DeadLineFinal,
                    ErrorMsg = row.ErrorMsg,
                    AssignTeam = row.AssignTeam,
                    PatchDetails = row.PatchDetails,    
                    Status=row.Status
                    
                });
                
            }
            return View(bugs);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign Up Portal";

            return View();
        }

        public ActionResult CreateIssue()
        {
            ViewBag.Message = "Create a Report";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                var data = ValidateEmployee(model.FirstName);
                int x = data.Count;
                if (data.Count == 0)
                {
                    CreateEmployee(model.EmployeeID, model.FirstName, model.LastName, model.Email);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Contact");
                }
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIssue(BugModel model)
        {
            if (ModelState.IsValid)
            {

                CreateBug(model.Title, model.Source, model.Description, model.Priority, model.Deadline1, model.Deadline2, model.DeadLineFinal, model.ErrorMsg,
                    model.AssignTeam, model.PatchDetails, model.IsResolved, model.Status);
                return RedirectToAction("Index");
            }

            else
            {
                return RedirectToAction("Contact");
            }
        
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Update Bug info ";

            List<DataLibrary.Models.BugModel> bm = RemoveBug(id);
            return View(bm[0]);
        }

        public ActionResult Delete(int id)
        {
           List<DataLibrary.Models.BugModel> bm = RemoveBug(id);
            return View(bm[0]);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DataLibrary.Models.BugModel model)
        {
            if (ModelState.IsValid)
            {

                UpdateBug2(model);
                return RedirectToAction("ViewBugs");
            }

            else
            {
                return RedirectToAction("Contact");
            }

        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            RemoveById(id);
            return RedirectToAction("ViewBugs");
        }
    }
}