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
    public partial class Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            //List<CustomerBAL> lst = new List<CustomerBAL>();
            DataTable dt = new DataTable();
            CustomerBAL obj = new CustomerBAL();
            dt = obj.GetCustomer(0);
            obj = null;
            if (dt.Rows.Count > 0)
            {
                divGrid.Visible = true;
                divNoRecords.Visible = false;
                grdCustomer.DataSource = dt;
                grdCustomer.DataBind();
            }
            else
            {
                divGrid.Visible = false;
                divNoRecords.Visible = true;
            }
        }
        
        public void ClearControls()
        {
            hdnCustomerID.Value = "0";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        protected void grdCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EDT")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                grdCustomer.SelectedIndex = rowIndex;
                hdnCustomerID.Value = ((HiddenField)grdCustomer.Rows[rowIndex].FindControl("hdnCustomerID")).Value;
                txtFirstName.Text = ((LinkButton)grdCustomer.Rows[rowIndex].FindControl("lnkFirstName")).Text;
                txtLastName.Text = ((HyperLink)grdCustomer.Rows[rowIndex].FindControl("hypLastName")).Text;
                txtBirthDate.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblBirthDate")).Text;
                txtEmail.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblEmail")).Text;
                txtAddress.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblAddress")).Text;
            }
            else if (e.CommandName == "DLT")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                hdnCustomerID.Value = ((HiddenField)grdCustomer.Rows[rowIndex].FindControl("hdnCustomerID")).Value;
                CustomerBAL obj = new CustomerBAL();
                int retVal = obj.DeleteCustomer(Convert.ToInt64(hdnCustomerID.Value));
                obj = null;
                if (retVal > 0)
                {
                    BindGrid();
                    ClearControls();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Deleted", "<script>alert('Deleted successfully.');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Deleted", "<script>alert('Error while deleting.');</script>");
                }
            }
        }

        protected void grdCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnCustomerID.Value = ((HiddenField)grdCustomer.SelectedRow.FindControl("hdnCustomerID")).Value;
            txtFirstName.Text = ((LinkButton)grdCustomer.SelectedRow.FindControl("lnkFirstName")).Text;
            txtLastName.Text = ((HyperLink)grdCustomer.SelectedRow.FindControl("hypLastName")).Text;
            txtBirthDate.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblBirthDate")).Text;
            txtEmail.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblEmail")).Text;
            txtAddress.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblAddress")).Text;
        }

        protected void grdCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].BackColor = System.Drawing.Color.Black;
                e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                string name = ((LinkButton)e.Row.FindControl("lnkFirstName")).Text + " " + ((HyperLink)e.Row.FindControl("hypLastName")).Text;
                ((LinkButton)e.Row.FindControl("lnkDelete")).Attributes.Add("onclick", String.Format("javascript:return confirm('Are you sure to delete {0} ?');", name));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CustomerBAL obj = new CustomerBAL();
                obj.CustomerID = Convert.ToInt64(hdnCustomerID.Value);
                obj.FirstName = txtFirstName.Text.Trim();
                obj.LastName = txtLastName.Text.Trim();
                obj.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
                obj.Email = txtEmail.Text.Trim();
                obj.Address = txtAddress.Text.Trim();

                int retVal = obj.InsertUpdateCustomer(obj);
                obj = null;
                if (retVal > 0)
                {
                    BindGrid();
                    ClearControls();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Saved", "<script>alert('Saved successfully.');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Saved", "<script>alert('Error while saving.');</script>");
                }
            }
        }
    }
}