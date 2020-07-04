using HRM.Class;
using HRM.Models;
using Microsoft.Build.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRM.Controllers
{
    public class MaritalController : Controller
    {
        
        static HttpClient client = new HttpClient();

        public ActionResult Index()
        
        {
            //var response = GlobalVariables.WebApiClient.GetAsync("MaritalAPI/GetData");
            //response.Wait();
            //var result = response.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<List<LSMaritalModel>>().Result;
            //    //readTask.Wait();
            //    //listMarital = readTask.Result;
            //}
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("MaritalAPI/GetData").Result;
            //listMarital = response.Content.ReadAsAsync<List<LSMaritalModel>>().Result;
            
            return View();
        }

        public JsonResult GetListApi()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("http://localhost:50595/api/");
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GlobalVariables gv = new GlobalVariables();
            //GlobalVariables.GlobalVariable();
            List<LSMaritalModel> listMarital = null;
            //listMarital = await GetMaritalAsync("MaritalAPI/GetData", listMarital);
            var response = client.GetAsync("MaritalAPI/GetData");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<LSMaritalModel>>();
                readTask.Wait();
                listMarital = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            //GlobalVariables.GetMaritalAsync("MaritalAPI/GetData", listMarital);
            return Json(listMarital, JsonRequestBehavior.AllowGet);
        }

        static async Task<List<LSMaritalModel>> GetMaritalAsync(string path,List<LSMaritalModel> list = null)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost:50595/api/");
            
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<List<LSMaritalModel>>();
            }
            return list;
        }
    }
}