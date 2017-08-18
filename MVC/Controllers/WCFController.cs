namespace MVC.Controllers
{
    public class WCFController : Controller
    {
        public ActionResult WCF()
        {
            ////  (1) Consume WebService from WebRequest
            //WebRequest req = WebRequest.Create(@"http://localhost:57840/CustomerService.svc/Customer/0");
            //req.Method = "GET";
            //req.ContentType = @"application/json; charset=utf-8";
            //HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            //string jsonResponse = string.Empty;
            //List<Models.Customer> lst = new List<Models.Customer>();

            //using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            //{
            //    jsonResponse = sr.ReadToEnd();
            //    lst = JsonConvert.DeserializeObject<List<Models.Customer>>(jsonResponse);
            //    //var lst = JsonConvert.DeserializeObject(jsonResponse);
            //    return View(lst);
            //}

            ////  (2) Consume WebService from WebClient
            //WebClient proxy = new WebClient();
            //string serviceURL = string.Format("http://localhost:57840/CustomerService.svc/Customer/0");
            //byte[] data = proxy.DownloadData(serviceURL);
            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(List<Models.Customer>));
            //List<Models.Customer> lst = obj.ReadObject(stream) as List<Models.Customer>;
            //return View(lst);

            return View();
        }
    }
}
