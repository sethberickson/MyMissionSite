using MyMissionSite.DAL;
using MyMissionSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMissionSite.Controllers
{
    public class MissionController : Controller
    {
        public static int userID;
        public static int missionID;
        private MissionContext db = new MissionContext();

        // GET: Mission
        public ActionResult Index()
        {
            return View(db.Missions);
        }
        [Authorize]
        public ActionResult IndexLog(int user)
        {
            userID = user; 

        
            return View(db.Missions);
        }


        [Authorize]
        [HttpGet]
        public ActionResult MissionFAQ(int id)
        {
            missionID = id;
            ViewBag.Message = "Ask us a question!";
            return View(db.Mission_Questions.Where(x => x.Mission_ID == id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateQuestion()
        {
            ViewBag.missionID = missionID;
            ViewBag.userID = userID;

            ViewBag.Message = "Ask us a question!";

            ViewBag.Missions = db.Missions.ToList();
            ViewBag.Users = db.Users.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateQuestion([Bind(Include = "Mission_Question_ID, Mission_ID, User_ID, Question, Answer")] Mission_Questions mqID)
        {
            mqID.Mission_ID = missionID;
            mqID.User_ID = userID;
            mqID.Answer = "";


            if (ModelState.IsValid)
            {
                //add entry
                db.Mission_Questions.Add(mqID);
                //edit entries
                //db.Entry(wo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mqID);

        }

        [Authorize]
        [HttpGet]
        public ActionResult EditAnswer(int id)
        {
            ViewBag.Message = "Ask us a question!";

            Mission_Questions mqID = db.Mission_Questions.Find(id);
            return View(mqID);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnswer([Bind(Include = "Mission_Question_ID, Mission_ID, User_ID, Question, Answer")] Mission_Questions mqID)
        {
            if (ModelState.IsValid)
            {
                //add entry
                //db.Mission_Questions.Add(mqID);
                //edit entries
                db.Entry(mqID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MissionFAQ");
            }

            return View(mqID);

        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateMission()
        {
            ViewBag.Message = "Ask us a question!";

            ViewBag.Missions = db.Missions.ToList();
            ViewBag.Users = db.Users.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMission([Bind(Include = "Mission_ID, Mission_Name, Mission_President_Name, Mission_Address, Mission_Language, Mission_Climate, Mission_Dominant_Religion, Mission_Flag")] Mission_Questions mish)
        {
            if (ModelState.IsValid)
            {
                //add entry
                db.Mission_Questions.Add(mish);
                //edit entries
                //db.Entry(mish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mish);

        }

        [Authorize]
        [HttpGet]
        public ActionResult EditMission(int id)
        {
            ViewBag.Message = "Ask us a question!";

            ViewBag.Missions = db.Missions.ToList();
            ViewBag.Users = db.Users.ToList();
            Missions mish = db.Missions.Find(id);

            return View(mish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMission([Bind(Include = "Mission_ID, Mission_Name, Mission_President_Name, Mission_Address, Mission_Language, Mission_Climate, Mission_Dominant_Religion, Mission_Flag")] Mission_Questions mish)
        {
            if (ModelState.IsValid)
            {
                //add entry
                //db.Mission_Questions.Add(mish);
                //edit entries
                db.Entry(mish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mish);

        }
    }
}
