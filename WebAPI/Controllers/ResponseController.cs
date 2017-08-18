using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ResponseController : ApiController
    {
        private WebAPIEntities context = new WebAPIEntities();

        [HttpGet]
        public HttpResponseMessage GetCustomer()
        {
            IEnumerable<Customer> obj = context.Customers.OrderBy(o => o.FirstName).ThenBy(p => p.LastName);
            if (obj == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCustomerByID(Int64 id)
        {
            Customer customer = context.Customers.Where(t => t.CustomerID == id).SingleOrDefault();
            if (customer == null)
            {
                return Content(HttpStatusCode.NotFound, "No record(s) found.");
            }
            else
            {
                return Ok(customer);
            }
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}