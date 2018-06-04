using S2ITSolution_MVC.Models;
using S2ITSolution_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2ITSolution_MVC.Controllers
{
    public class EmprestimoController : Controller
    {
        private RepositorioEmprestimo rEmp = new RepositorioEmprestimo();
        private RepositorioAmigo rAmigo = new RepositorioAmigo();
        private RepositorioJogo rJogo = new RepositorioJogo();


        // GET: Emprestimo
        public ActionResult Index()
        {
            var emp = rEmp.DemonstraEmprestimos();

            return View(emp);
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            ViewBag.ID_Jogo = new SelectList(rJogo.DemonstraJogos(), "ID_Jogo", "NM_Jogo");
            ViewBag.ID_Amigo = new SelectList(rAmigo.DemonstraAmigos(), "ID_Amigo", "NM_Amigo");
            return View();
        }

        // POST: Emprestimo/Create
        [HttpPost]
        public ActionResult Create(EmprestimoViewModel emp)
        {
            if (ModelState.IsValid)
            {
                rEmp.CriarEmprestimo(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Emprestimo/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = rEmp.GetEmprestimoById(id);

            ViewBag.ID_Jogo = new SelectList(rJogo.DemonstraJogos(), "ID_Jogo", "NM_Jogo", emp.ID_Jogo);
            ViewBag.ID_Amigo = new SelectList(rAmigo.DemonstraAmigos(), "ID_Amigo", "NM_Amigo", emp.ID_Amigo);

            return View(emp);
        }

        // POST: Emprestimo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmprestimoViewModel emp)
        {
            if (ModelState.IsValid)
            {
                rEmp.UpdateEmprestimo(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        // GET: Emprestimo/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = rEmp.GetEmprestimoById(id);

            return View(emp);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmprestimoViewModel emp)
        {
            rEmp.DeleteEmprestimo(emp);

            return RedirectToAction("Index");
        }
    }
}
