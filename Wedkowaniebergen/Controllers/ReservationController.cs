using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wedkowaniebergen.Controllers
{
    public class ReservationController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}