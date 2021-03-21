using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YelpCamp.Data;
using YelpCamp.Models;

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


    }
}
