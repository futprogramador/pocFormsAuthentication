using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAutenticacao.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="admin")]
        public ActionResult Admin()
        {
            return View();
        }        
    }
}