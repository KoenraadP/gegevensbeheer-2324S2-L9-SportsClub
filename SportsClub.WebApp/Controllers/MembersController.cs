using SportsClub.Bll;
using SportsClub.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsClub.WebApp.Controllers
{
    // deze NIET static!
    public class MembersController : Controller
    {
        // CREATE
        // eerste create methode maakt de create pagina aan
        public ActionResult Create()
        {
            return View();
        }

        // tweede create methode verwerkt de data van de create pagina
        // parameters = zelfde naam als de 'name' van de input tags
        [HttpPost]
        public ActionResult Create(string firstName, string lastName, HttpPostedFileBase picture)
        {
            // variabele voor bestandsnaam foto
            // standaard wordt dit dus een anonieme afbeelding
            string pictureName = "unknown.jpg";

            // checken of er effectief een foto doorkomt
            if (picture != null)
            {
                // pad voor opslaan foto's instellen
                string path = Server.MapPath("~/Content/images/members/");
                // foto nieuwe naam geven om te zorgen dat we niet per ongeluk
                // een foto overschrijven die dezelfde naam heeft
                // bvb: "8772c242-0eae-444e-9e1a-568e90a02dd8.jpg"
                pictureName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                // naam van de foto toevoegen aan pad voor opslaan
                path += pictureName;
                // foto effectief opslaan in map
                picture.SaveAs(path);
            }

            // create methode uit BLL uitvoeren en waarde opslaan
            bool createSuccessful = Members.Create(firstName, lastName, pictureName);

            // feedback maken
            if (createSuccessful)
            {
                // ViewBag is iets dat meegenomen wordt naar de view
                // je kunt de inhoud van de viewbag dus tonen op de view
                ViewBag.Feedback = firstName + " " + lastName + " werd toegevoegd.";  
            }
            else
            {
                ViewBag.Feedback = "Het is niet gelukt om een member aan te maken.";
            }

            return View();
        }

        // READ ALL
        public ActionResult Index()
        {
            // read methode uit Bll gebruiken
            List<Member> lstMembers = Members.Read();
            // lijst van members doorsturen naar Index View pagina
            return View(lstMembers);
        }

        // READ SINGLE
        public ActionResult Details(int id)
        {
            // Read methode uit BLL gebruiken om member op te zoeken
            Member m = Members.Read(id);
            // Member m doorgeven aan view
            return View(m);
        }

        // UPDATE

        // eerste Edit methode genereert de view/pagina
        public ActionResult Edit(int id)
        {
            // read methode uit bll uitvoeren om member op te zoeken
            Member m = Members.Read(id);
            // member doorgeven aan delete view
            return View(m);
        }

        // tweede Edit methode verwerkt de nieuwe gegevens
        [HttpPost]
        public ActionResult Edit(int memberId,
            string firstName, string lastName)
        {
            // bll update methode gebruiken met nieuwe data
            Members.Update(memberId, firstName, lastName);

            // terugkeren naar lijst members
            return RedirectToAction("Index");
        }

        // DELETE
        // eerste methode --> delete pagina (view) linken en maken
        public ActionResult Delete(int id)
        {
            // read methode uit bll uitvoeren om member op te zoeken
            Member m = Members.Read(id);
            // member doorgeven aan delete view
            return View(m);
        }

        // tweede methode --> verwerken van delete pagina
        // andere naam nodig methode --> want zelfde soort parameter (int)
        // naam parameter wel anders omdat dit moet overeen komen
        // met de naam van de 'verborgen' input op de view
        [HttpPost]
        public ActionResult DeleteConfirmed(int memberId) 
        {
            // member met specifieke memberId verwijderen
            // hiervoor gebruik maken van bll methode
            Members.Delete(memberId);
            // terugkeren naar index pagina van members
            return RedirectToAction("Index");
        }
    }
}