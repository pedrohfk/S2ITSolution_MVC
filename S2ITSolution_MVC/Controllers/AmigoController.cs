using S2ITSolution_MVC.Models;
using S2ITSolution_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2ITSolution_MVC.Controllers
{
    public class AmigoController : Controller
    {
        RepositorioAmigo r = new RepositorioAmigo();

        // GET: Amigo
        public ActionResult Index()
        {
            var lst = r.DemonstraAmigos();

            return View(lst);
        }

        // GET: Amigo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amigo/Create
        [HttpPost]
        public ActionResult Create(AmigoViewModel amigo)
        {
            if (ModelState.IsValid)
            {
                r.CriarAmigo(amigo);
                return RedirectToAction("Index");
            }

            return View(amigo);
        }

        // GET: Amigo/Edit/5
        public ActionResult Edit(int id)
        {
            var amigo = r.GetAmigoById(id);

            return View(amigo);
        }

        // POST: Amigo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AmigoViewModel amigo)
        {
            if (ModelState.IsValid)
            {
                r.UpdateAmigo(amigo);
                return RedirectToAction("Index");
            }

            return View(amigo);
        }

        // GET: Amigo/Delete/5
        public ActionResult Delete(int id)
        {
            var amigo = r.GetAmigoById(id);

            return View(amigo);
        }

        // POST: Amigo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AmigoViewModel amigo)
        {
            r.DeleteAmigo(amigo);
            return RedirectToAction("Index");
        }
    }
}
