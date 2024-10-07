using Hackaton.shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hackaton.API.Controllers
{
    public class TeamController : Controller
    {
        private static List<Team> teams = new List<Team>();

        // GET: /team/
        public IActionResult Index()
        {
            return View(teams);
        }

        // GET: /Team/Details/5
        public IActionResult Details(int id)
        {
            var team = teams.FirstOrDefault(e => e.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // GET: /Equipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Equipo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                team.Id = teams.Count + 1;
                teams.Add(team);
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: /Team/Edit/5
        public IActionResult Edit(int id)
        {
            var equipo = teams.FirstOrDefault(e => e.Id == id);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams);
        }

        // POST: /Team/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Team team)
        {
            var existingEquipo = teams.FirstOrDefault(e => e.Id == id);
            if (existingEquipo == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingEquipo.Name = team.Name;
                existingEquipo.MentorId = team.MentorId;
                existingEquipo.HackatonId = team.HackatonId;
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: /Teams/Delete/5
        public IActionResult Delete(int id)
        {
            var equipo = teams.FirstOrDefault(e => e.Id == id);
            if (teams == null)
            {
                return NotFound();
            }
            return View(teams);
        }

        // POST: /Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var team = teams.FirstOrDefault(e => e.Id == id);
            if (teams != null)
            {
                teams.Remove(team);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


















{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
