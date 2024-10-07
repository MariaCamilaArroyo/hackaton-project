using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.API.Controllers
{
    public class EvaluationController : Controller
    {
        private static List<Evaluation> evaluations = new List<Evaluation>();

        // GET: /Evaluation/
        public IActionResult Index()
        {
            return View(evaluations);
        }

        // GET: /Evaluation/Details/5
        public IActionResult Details(int id)
        {
            var evaluation = evaluations.FirstOrDefault(e => e.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        // GET: /Evaluation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Evaluation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                evaluation.Id = evaluations.Count + 1;
                evaluations.Add(evaluation);
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
        }

        // GET: /Evaluation/Edit/5
        public IActionResult Edit(int id)
        {
            var evaluation = evaluations.FirstOrDefault(e => e.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        // POST: /Evaluation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Evaluation evaluation)
        {
            var existingEvaluation = evaluations.FirstOrDefault(e => e.Id == id);
            if (existingEvaluation == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingEvaluation.Id = evaluation.Id;
                existingEvaluation.ProjectId = evaluation.ProjectId;
                existingEvaluation.value = evaluation.value;
                existingEvaluation.comments = evaluation.comments;
                return RedirectToAction(nameof(Index));
            }
            return View(evaluation);
        }

        // GET: /Evaluation/Delete/5
        public IActionResult Delete(int id)
        {
            var evaluation = evaluations.FirstOrDefault(e => e.Id == id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return View(evaluation);
        }

        // POST: /Evaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var evaluation = evaluations.FirstOrDefault(e => e.Id == id);
            if (evaluation != null)
            {
                evaluations.Remove(evaluation);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

