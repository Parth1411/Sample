using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetCustomer(string id)
        {
            DAL.CustomerDAL obj = new DAL.CustomerDAL();
            List<Customer> lst = obj.GetCustomer(Convert.ToInt64(id));
            if (lst == null)
            {
                throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return lst;
        }

        public Customer GetCustomerByName(string name)
        {
            Customer obj = new Customer();
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            obj = objDAL.GetCustomerByName(name);
            if (obj == null)
            {
                throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return obj;
        }

        public string InsertUpdateCustomer(Customer obj)
        {
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            try
            {
                Int64 retVal = objDAL.InsertUpdateCustomer(obj);
                if (retVal > 0)
                {
                    if (obj.CustomerID > 0)
                    {
                        return "Updated Successfully";
                    }
                    else
                    {
                        return "Saved Successfully.";
                    }
                }
                else
                {
                    throw new WebFaultException<string>("Error while saving.", HttpStatusCode.InternalServerError);
                }
            }
            catch
            {
                throw new WebFaultException<string>("Error while saving.", HttpStatusCode.InternalServerError);
            }
        }

        public string DeleteCustomer(string id)
        {
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            try
            {
                Int64 retVal = objDAL.DeleteCustomer(Convert.ToInt64(id));
                if (retVal > 0)
                {
                    return "Deleted Successfully.";
                }
                else
                {
                    throw new WebFaultException<string>("Error while deleting.", HttpStatusCode.InternalServerError);
                }
            }
            catch
            {
                throw new WebFaultException<string>("Error while deleting.", HttpStatusCode.InternalServerError);
            }
        }
    }
}
