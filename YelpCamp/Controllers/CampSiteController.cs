using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YelpCamp.Controllers
{
    public class CampSiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
