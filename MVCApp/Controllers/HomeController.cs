/*using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;


using static DataLibrary.BusinessLogic.BugProcessor;
using System.IO;
using System.Text;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
*/
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using System.Security.Claims;
using Auth0.AuthenticationApi;

using static DataLibrary.BusinessLogic.BugProcessor;
using System.IO;
using System.Text;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using DataLibrary.Analytics;
using Newtonsoft.Json;



namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {

        public string UserId()
        {
            List<string> arr = new List<string>();
            // The user's ID is available in the NameIdentifier claim
            foreach (var claim in ((ClaimsIdentity)User.Identity).Claims)
            {
                arr.Add(claim.Value);
            }

            return arr[1];
        }


        public ActionResult Convert(int id)
        {
            var report = new Rotativa.ActionAsPdf("PdfView", new { id = id });
            return report;

        }

        public ActionResult PdfView(int id)
        {
            ViewBag.Message = "Update Bug info ";

            List<DataLibrary.Models.BugModel> bm = RemoveBug(id);
            return View(bm[0]);
        }

        public ActionResult Login(string returnUrl)
        {
            HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
            {
                RedirectUri = returnUrl ?? Url.Action("Index", "Home")
            },
                "Auth0");
            return new HttpUnauthorizedResult();
        }

        [Authorize]
        public void Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            HttpContext.GetOwinContext().Authentication.SignOut("Auth0");
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()

        {

            var res = Getstats();
            var datachart = new object[res.Count];

            int j = 0;
            foreach (var i in res)
            {
                datachart[j] = new object[] { i.Title.ToString(), i.Tres };
                j++;
            }
            string datastr = JsonConvert.SerializeObject(datachart, Formatting.None);
            ViewBag.dataj = new HtmlString(datastr);

            List<DataLibrary.Models.BugModel> bugs = LoadBugs();
            DataLibrary.Models.BugModel sorter = new DataLibrary.Models.BugModel();
            bugs.Sort(sorter);
            return View(bugs);
        }
        public ActionResult Sim()
        {

            List<DataLibrary.Models.BugModel> bugs = LoadBugs();
            DataLibrary.Models.BugModel sorter = new DataLibrary.Models.BugModel();
            bugs.Sort(sorter);
            List<DataLibrary.Models.BugModel> mbugs = new List<DataLibrary.Models.BugModel>();
            if (bugs.Count >= 3)
            {
                mbugs.Add(bugs[0]);
                mbugs.Add(bugs[1]);
                mbugs.Add(bugs[0]);
                return View(mbugs);
            }

            return View(bugs);

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

        public ActionResult Catalog()
        {
            string kx = UserId();

            List<DataLibrary.Models.CatalogModel> dlbm = ViewCatalog(kx);

            return View(dlbm);
        }


    }
}