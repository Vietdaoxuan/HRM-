﻿using HRM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRM.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}