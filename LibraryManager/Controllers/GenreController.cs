using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            } 
            return View(genre);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(genre).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = _db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Genre genre = _db.Genres.Find(id);
            _db.Genres.Remove(genre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}