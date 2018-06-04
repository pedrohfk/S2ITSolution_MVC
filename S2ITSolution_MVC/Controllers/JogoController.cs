using S2ITSolution_MVC.Models;
using S2ITSolution_MVC.ViewModels;
using System.Web.Mvc;

namespace S2ITSolution_MVC.Controllers
{
    public class JogoController : Controller
    {
        RepositorioJogo r = new RepositorioJogo();

        // GET: Jogo
        public ActionResult Index()
        {
            var lst = r.DemonstraTodosJogos();

            return View(lst);
        }
     
        // GET: Jogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogo/Create
        [HttpPost]
        public ActionResult Create(JogoViewModel jogo)
        {
            if (ModelState.IsValid)
            {
                r.CriarJogo(jogo);
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(int id)
        {
            var jogo = r.GetJogoById(id);

            return View(jogo);
        }

        // POST: Jogo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JogoViewModel jogo)
        {
            if (ModelState.IsValid)
            {
                r.UpdateJogo(jogo);
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(int id)
        {
            var jogo = r.GetJogoById(id);

            return View(jogo);
        }

        // POST: Jogo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(JogoViewModel jogo)
        {
            r.DeleteJogo(jogo);

            return RedirectToAction("Index");
        }
    }
}
