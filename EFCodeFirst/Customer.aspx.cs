using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EFCodeFirst.Model;

namespace EFCodeFirst
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
            using (EFContext context = new EFContext())
            {
                //  Using Syntax Based Query
                var customers = from c in context.Customers
                                orderby c.FirstName, c.LastName
                                select new
                {
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    BirthDate = c.BirthDate,
                    Email = c.Email,
                    Address = c.Address
                };

                //  Using Method Based Query
                //var customers = context.Customers;
                //.Select(l => new
                //{
                //    CustomerID = l.CustomerID,
                //    FirstName = l.FirstName,
                //    LastName = l.LastName,
                //    BirthDate = l.BirthDate,
                //    Email = l.Email,
                //    Address = l.Address
                //});

                //var customers = context.Customers.OrderBy(o => o.FirstName).ThenBy(p => p.LastName).ToList();

                if (customers != null)
                {
                    divGrid.Visible = true;
                    divNoRecords.Visible = false;
                    grdCustomer.DataSource = customers.ToList();
                    grdCustomer.DataBind();
                }
                else
                {
                    divGrid.Visible = false;
                    divNoRecords.Visible = true;
                }
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
                txtLastName.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblLastName")).Text;
                txtBirthDate.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblBirthDate")).Text;
                txtEmail.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblEmail")).Text;
                txtAddress.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblAddress")).Text;
            }
            else if (e.CommandName == "DLT")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                hdnCustomerID.Value = ((HiddenField)grdCustomer.Rows[rowIndex].FindControl("hdnCustomerID")).Value;
                using (EFContext context = new EFContext())
                {
                    Int64 customerID = Convert.ToInt64(hdnCustomerID.Value);
                    //  Using Syntax Based Query
                   
                    Model.Customer customer = (from c in context.Customers
                                    where c.CustomerID == customerID
                                    select c).SingleOrDefault();
                    context.Customers.Remove(customer);

                    //  Using Method based query
                    //Customer customers = context.Customers.Where(m => m.CustomerID == customerID).SingleOrDefault();
                    //context.Customers.Remove(customers);

                    if (context.SaveChanges() > 0)
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
        }

        protected void grdCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnCustomerID.Value = ((HiddenField)grdCustomer.SelectedRow.FindControl("hdnCustomerID")).Value;
            txtFirstName.Text = ((LinkButton)grdCustomer.SelectedRow.FindControl("lnkFirstName")).Text;
            txtLastName.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblLastName")).Text;
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
                string name = ((LinkButton)e.Row.FindControl("lnkFirstName")).Text + " " + ((Label)e.Row.FindControl("lblLastName")).Text;
                ((LinkButton)e.Row.FindControl("lnkDelete")).Attributes.Add("onclick", String.Format("javascript:return confirm('Are you sure to delete {0} ?');", name));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (EFContext context = new EFContext())
                {
                    Model.Customer obj = new Model.Customer();
                    obj.CustomerID = Convert.ToInt64(hdnCustomerID.Value);
                    obj.FirstName = txtFirstName.Text.Trim();
                    obj.LastName = txtLastName.Text.Trim();
                    obj.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
                    obj.Email = txtEmail.Text.Trim();
                    obj.Address = txtAddress.Text.Trim();

                    if (Convert.ToInt64(hdnCustomerID.Value) > 0)
                    {
                        context.Customers.Attach(obj);
                        context.Configuration.ValidateOnSaveEnabled = false;

                        context.Entry(obj).Property(u => u.FirstName).IsModified = true;
                        context.Entry(obj).Property(u => u.LastName).IsModified = true;
                        context.Entry(obj).Property(u => u.BirthDate).IsModified = true;
                        context.Entry(obj).Property(u => u.Email).IsModified = true;
                        context.Entry(obj).Property(u => u.Address).IsModified = true;

                        if (context.SaveChanges() > 0)
                        {
                            context.Configuration.ValidateOnSaveEnabled = true;
                            BindGrid();
                            ClearControls();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Saved", "<script>alert('Updated successfully.');</script>");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Saved", "<script>alert('Error while updating.');</script>");
                        }
                    }
                    else
                    {
                        context.Customers.Add(obj);
                        if (context.SaveChanges() > 0)
                        {
                            var customerID = obj.CustomerID;
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
    }
}