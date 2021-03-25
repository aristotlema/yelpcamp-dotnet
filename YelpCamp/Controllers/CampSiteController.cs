using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YelpCamp.Data;
using YelpCamp.Models;
using YelpCamp.Models.ViewModels;

namespace YelpCamp.Controllers
{
    public class CampSiteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CampSiteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<CampSite> objList = _db.Campsite;
            return View(objList);
        }

        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CampSite obj)
        {
            if(ModelState.IsValid)
            {
                _db.Campsite.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var obj = _db.Campsite.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CampSite obj)
        {
            if(ModelState.IsValid)
            {
                _db.Campsite.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - SHOW
        public IActionResult Show(int id)
        {
            CampSiteVM campSiteVM = new CampSiteVM()
            {
                CampSite = new CampSite(),
                CommentList = _db.Comment.Select(i => new Comment
                {
                    Id = i.Id,
                    Author = i.Author,
                    CommentBody = i.CommentBody
                })
            };

            campSiteVM.CampSite = _db.Campsite.Find(id);
            if(campSiteVM.CampSite == null)
            {
                return NotFound();
            }
            return View(campSiteVM);
        }

        // POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Campsite.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Campsite.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
