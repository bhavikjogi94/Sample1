using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class ConsumeAPIController : Controller
    {
        public ActionResult ConsumeAPI()
        {
            //  (1) ConsumeAPI WebService from WebRequest
            //WebRequest req = WebRequest.Create(@"http://localhost:57840/CustomerService.svc/Customer");
            //req.Method = "GET";
            //req.ContentType = @"application/json; charset=utf-8";
            //HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            //string jsonResponse = string.Empty;
            //using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            //{
            //    jsonResponse = sr.ReadToEnd();
            //    List<Models.Customer> lst = JsonConvert.DeserializeObject<List<Models.Customer>>(jsonResponse);
            //}

            //  (2) ConsumeAPI WebService from WebClient
            //WebClient proxy = new WebClient();
            //string serviceURL = string.Format("http://localhost:57840/CustomerService.svc/Customer");
            //byte[] data = proxy.DownloadData(serviceURL);
            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<Models.Customer>));
            //List<Models.Customer> country = obj.ReadObject(stream) as List<Models.Customer>;  

            return View();
        }
    }
}
