using SportsClub.Bll;
using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace SportsClub.WebApp.Controllers
{
    public class ActivitiesController : Controller
    {
        // CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name, int maxParticipants)
        {
            if (Activities.Create(name, maxParticipants)) 
            {
                ViewBag.Feedback = name + " werd toegevoegd.";
            }
            else
            {
                ViewBag.Feedback = "Toevoegen activity mislukt.";
            }

            return View();
        }
        
        // READ ALL
        public ActionResult Index()
        {
            // read methode uit Bll gebruiken
            List<Activity> lstActivities = Activities.Read();
            // lijst van members doorsturen naar Index View pagina
            return View(lstActivities);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            Activity a = Activities.Read(id);
            return View(a);
        }
    }
}