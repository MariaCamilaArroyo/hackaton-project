using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.API.Controllers
{
    public class MentorController : Controller
    {
        private static List<Mentor> mentors = new List<Mentor>();

        // GET: /Mentor/
        public IActionResult Index()
        {
            return View(mentors);
        }

        // GET: /Mentor/Details/5
        public IActionResult Details(int id)
        {
            var mentor = mentors.FirstOrDefault(m => m.Id == id);
            if (mentor == null)
            {
                return NotFound();
            }
            return View(mentor);
        }

        // GET: /Mentor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Mentor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                mentor.Id = mentors.Count + 1;
                mentors.Add(mentor);
                return RedirectToAction(nameof(Index));
            }
            return View(mentor);
        }

        // GET: /Mentor/Edit/5
        public IActionResult Edit(int id)
        {
            var mentor = mentors.FirstOrDefault(m => m.Id == id);
            if (mentor == null)
            {
                return NotFound();
            }
            return View(mentor);
        }

        // POST: /Mentor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Mentor mentor)
        {
            var existingMentor = mentors.FirstOrDefault(m => m.Id == id);
            if (existingMentor == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingMentor.expertise = mentor.expertise;
                existingMentor.Name = mentor.Name;
                existingMentor.identificationNumber = mentor.identificationNumber;
                return RedirectToAction(nameof(Index));
            }
            return View(mentor);
        }

        // GET: /Mentor/Delete/5
        public IActionResult Delete(int id)
        {
            var mentor = mentors.FirstOrDefault(m => m.Id == id);
            if (mentor == null)
            {
                return NotFound();
            }
            return View(mentor);
        }

        // POST: /Mentor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var mentor = mentors.FirstOrDefault(m => m.Id == id);
            if (mentor != null)
            {
                mentors.Remove(mentor);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
