using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data;
using WebService.BAL;
namespace WebService
{
    /// <summary>
    /// Summary description for CustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<CustomerBAL> GetCustomer(string id)
        {
            List<CustomerBAL> lst = new List<CustomerBAL>();
            CustomerBAL obj = new CustomerBAL();
            lst = obj.GetCustomer(Convert.ToInt64(id));
            if (lst == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return lst;
        }

        //  To Call from Ajax Call
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCustomerByAjax(string id)
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            List<CustomerBAL> lst = new List<CustomerBAL>();
            CustomerBAL obj = new CustomerBAL();
            lst = obj.GetCustomer(Convert.ToInt64(id));
            if (lst == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            Context.Response.Write(JsonConvert.SerializeObject(lst));
        }

        [WebMethod]
        public int InsertUpdateCustomer(CustomerBAL obj)
        {
            CustomerBAL objBAL = new CustomerBAL();
            return objBAL.InsertUpdateCustomer(obj);
        }

        [WebMethod]
        public int DeleteCustomer(string id)
        {
            CustomerBAL obj = new CustomerBAL();
            return obj.DeleteCustomer(Convert.ToInt64(id));
        }
    }
}
