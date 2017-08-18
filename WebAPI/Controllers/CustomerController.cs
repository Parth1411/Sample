using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private WebAPIEntities context = new WebAPIEntities();
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> obj = context.Customers.OrderBy(o => o.FirstName).ThenBy(p => p.LastName);
            if (obj == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return obj;
            }
        }

        [HttpGet]
        [ActionName("Single")]
        public Customer GetCustomersByID(Int64 customersID)
        {
            Int64 customerID = Convert.ToInt64(customersID);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID).SingleOrDefault();
            if (customers == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return customers;
            }
        }

        [HttpPost]
        [ActionName("Single")]
        public string AddCustomersByID(Int64 id)
        {
            return "Saved Successfully";
        }

        [HttpGet]
        public Customer GetByID(Int64 id)
        {
            Int64 customerID = Convert.ToInt64(id);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID).SingleOrDefault();
            if (customers == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return customers;
            }
        }
        
        [HttpGet]
        [NonAction]
        public string GetNonAction(Int64 id)
        {
            return "Non Action Method";
        }

        [HttpPost]
        public string SaveCustomer(Customer obj)
        {
            if (obj.CustomerID > 0)
            {
                context.Customers.Attach(obj);
                context.Configuration.ValidateOnSaveEnabled = false;

                context.Entry(obj).Property(u => u.FirstName).IsModified = true;
                context.Entry(obj).Property(u => u.LastName).IsModified = true;
                context.Entry(obj).Property(u => u.BirthDate).IsModified = true;
                context.Entry(obj).Property(u => u.Email).IsModified = true;
                context.Entry(obj).Property(u => u.Address).IsModified = true;

                try
                {
                    if (context.SaveChanges() > 0)
                    {
                        context.Configuration.ValidateOnSaveEnabled = true;
                        return "Updated Successfully.";
                    }
                    else
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while updating."));
                    }
                }
                catch
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while updating."));
                }
            }
            else
            {
                context.Customers.Add(obj);
                try
                {
                    if (context.SaveChanges() > 0)
                    {

                        var customerID = obj.CustomerID;
                        return customerID.ToString() + " " + "Saved Successfully.";
                    }
                    else
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while saving."));
                    }
                }
                catch
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while saving."));
                }
            }
        }

        [HttpPost]
        public string DeleteCustomer(Int64 id)
        {
            Int64 customerID = Convert.ToInt64(id);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID).SingleOrDefault();
            context.Customers.Remove(customers);
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return "Deleted Successfully.";
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while deleting."));
                }
            }
            catch
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while deleting."));
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