using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.BAL;

namespace WebForms
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
                {
                    GetCustomer(Convert.ToInt64(Request.QueryString["Id"]));
                }
            }
        }

        public void GetCustomer(Int64 customerID)
        {
            //List<CustomerBAL> lst = new List<CustomerBAL>();
            DataTable dt = new DataTable();
            CustomerBAL obj = new CustomerBAL();
            dt = obj.GetCustomer(customerID);
            obj = null;
            if (dt.Rows.Count > 0)
            {
                divResult.Attributes.Add("class", "show");
                divNoRecord.Attributes.Add("class", "hide");
                hdnCustomerID.Value = dt.Rows[0]["CustomerID"].ToString();
                lblFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                lblLastName.Text = dt.Rows[0]["LastName"].ToString();
                lblBirthDate.Text = Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToShortDateString();
                lblEmail.Text = dt.Rows[0]["Email"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
            }
            else
            {
                divResult.Attributes.Add("class", "hide");
                divNoRecord.Attributes.Add("class", "show");
            }
        }
    }
}