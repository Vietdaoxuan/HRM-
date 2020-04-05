using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HRM.Class;
using HRM.Models;
using Newtonsoft.Json;

namespace HRM.Controllers
{  
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            DataAccessLayer act = new DataAccessLayer();
            ViewBag.comID = act.ToSelectList("LSCompanyID", "Name", "select * from tbl_Company");
            ViewBag.BankID = act.ToSelectList("LSBankID", "Name", "select * from tbl_LSBank");
            ViewBag.CulLevel = act.ToSelectList("LSCultureLevelID", "Name", "select * from tbl_LSCultureLevel");
            ViewBag.Province = act.ToSelectList("LSProvinceID", "Name", "select * from tbl_LSProvince");
            ViewBag.District = act.ToSelectList("LSDistrictID", "Name", "select * from tbl_LSDistrict");
            ViewBag.Marital = act.ToSelectList("LSMaritalID", "Name", "select * from tbl_LSMarital");
            return View();
        }
    }
}