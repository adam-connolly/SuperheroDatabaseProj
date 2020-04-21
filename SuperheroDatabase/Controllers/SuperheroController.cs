using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroDatabase.Data;
using SuperheroDatabase.Models;

namespace SuperheroDatabase.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superhero
        public IActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: Superhero/Details/5
        public IActionResult Details(int id)
        {
            var superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // GET: Superhero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Superhero/Edit/5
        public IActionResult Edit(int id)
        {
            var superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public IActionResult Delete(int id)
        {
            var superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Superhero superhero)
        {
            try
            {
                _context.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}