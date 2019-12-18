using MyMissionSite.DAL;
using MyMissionSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyMissionSite.Controllers
{

    public class HomeController : Controller
    {
        private MissionContext db = new MissionContext();

        private Users currentUser = new Users();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            List<SelectListItem> subjects = new List<SelectListItem>();
            subjects.Add(new SelectListItem { Text = "I have a question.", Value = "0" });
            subjects.Add(new SelectListItem { Text = "Thank you so much!", Value = "1" });
            subjects.Add(new SelectListItem { Text = "I have a suggestion for the website.", Value = "2" });
            ViewBag.Subjects = subjects;
        
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();
            currentUser = db.Users.FirstOrDefault(x => x.User_Email == email);
           
            

            if (currentUser != null)
            {
                //it's a customer email
                if (currentUser.User_Password == password)
                {
                    FormsAuthentication.SetAuthCookie(email, rememberMe);
                    return RedirectToAction("IndexLog", "Mission", new { user = currentUser.User_ID });
                    //authenticate
                }
                else
                {
                    ViewBag.PasswordMessage = "Password is incorrect";
                }
            }
            else
            {
                ViewBag.PasswordMessage = "There is no account associated with that Email address. Please try another Email.";

                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.Message = "Create New User";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "User_ID, User_Email, User_Password, First_Name, Last_Name")] Users user)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Users.Add(user);
                //edit entries
                //db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}