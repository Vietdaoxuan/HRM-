using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace HRM.Class
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        public static void GlobalVariable()
        {
            if (WebApiClient.BaseAddress == null)
            {
                WebApiClient.BaseAddress = new Uri("http://localhost:50595/api/");
            }
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static object GetMaritalAsync(string path, object list)
        {
            GlobalVariable();
            var response =  WebApiClient.GetAsync(path);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<object>();
                readTask.Wait();
                list = readTask.Result;
            }
            return list;
        }
    }
}