using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManager.Models;

namespace LibraryManager.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext _db;

        public GenreController()
        {
            _db = new ApplicationDbContext();
        }
        // GET: Genre
        public ActionResult Index()
        {
            return View(_db.Genres.ToList());
        }

        //GET: Create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}