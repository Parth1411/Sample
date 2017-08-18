using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebService.DAL;
using System.Data;

namespace WebService.BAL
{
    [Serializable]
    public class CustomerBAL
    {
        public Int64 CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public CustomerBAL GetCustomerByName(string name)
        {
            CustomerDAL obj = new CustomerDAL();
            return obj.GetCustomerByName(name);
        }

        public List<CustomerBAL> GetCustomer(Int64 customerID)
        {
            CustomerDAL obj = new CustomerDAL();
            return obj.GetCustomer(customerID);
        }

        public int InsertUpdateCustomer(CustomerBAL obj)
        {
            CustomerDAL objDAL = new CustomerDAL();
            return objDAL.InsertUpdateCustomer(obj);
        }

        public int DeleteCustomer(Int64 customerID)
        {
            CustomerDAL objDAL = new CustomerDAL();
            return objDAL.DeleteCustomer(customerID);
        }
    }
}
