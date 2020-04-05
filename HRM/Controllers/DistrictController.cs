using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {
            DataAccessLayer act = new DataAccessLayer();
            ViewBag.Province = act.ToSelectList("LSProvinceID", "Name", "select * from tbl_LSProvince");
            return View();
        }
    }
}