using System;
using System.Collections.Generic;
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
                BindCountry();
                BindGrid();                
            }
        }

        public void BindGrid()
        {
            List<CustomerBAL> lst = new List<CustomerBAL>();
            CustomerBAL obj = new CustomerBAL();
            lst = obj.GetCustomer(0);
            obj = null;
            if (lst.Count > 0)
            {
                divGrid.Visible = true;
                divNoRecords.Visible = false;
                grdCustomer.DataSource = lst;
                grdCustomer.DataBind();
            }
            else
            {
                divGrid.Visible = false;
                divNoRecords.Visible = true;
            }
        }

        public void BindCountry()
        {
            List<CountryBAL> lst = new List<CountryBAL>();
            CountryBAL obj = new CountryBAL();
            lst = obj.GetCountry();
            obj = null;
            if (lst.Count > 0)
            {
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "Country";
                ddlCountry.DataSource = lst;
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        public void BindProvince(int countryID)
        {
            ddlProvince.Items.Clear();
            List<ProvinceBAL> lst = new List<ProvinceBAL>();
            ProvinceBAL obj = new ProvinceBAL();
            lst = obj.GetProvince(countryID);
            obj = null;
            if (lst.Count > 0)
            {
                ddlProvince.DataValueField = "ProvinceID";
                ddlProvince.DataTextField = "Province";
                ddlProvince.DataSource = lst;
                ddlProvince.DataBind();
                ddlProvince.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        public void ClearControls()
        {
            hdnCustomerID.Value = "0";
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlProvince.SelectedIndex = -1;
            ddlCountry.SelectedIndex = -1;
            chkIsActive.Checked = false;
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
                txtPhone.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblPhone")).Text;
                txtEmail.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblEmail")).Text;
                txtAddress.Text = ((Label)grdCustomer.Rows[rowIndex].FindControl("lblAddress")).Text;
                ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(((HiddenField)grdCustomer.SelectedRow.FindControl("hdnCountryID")).Value));
                BindProvince(Convert.ToInt32(ddlCountry.SelectedValue));
                ddlProvince.SelectedIndex = ddlProvince.Items.IndexOf(ddlProvince.Items.FindByValue(((HiddenField)grdCustomer.SelectedRow.FindControl("hdnProvinceID")).Value));
                chkIsActive.Checked = Convert.ToBoolean(((Label)grdCustomer.Rows[rowIndex].FindControl("lblIsActive")).Text);
            }
            else if (e.CommandName == "DLT")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                hdnCustomerID.Value = ((HiddenField)grdCustomer.Rows[rowIndex].FindControl("hdnCustomerID")).Value;
                BAL.CustomerBAL obj = new BAL.CustomerBAL();
                int retVal = obj.DeleteCustomer(Convert.ToInt64(hdnCustomerID.Value));
                obj = null;
                if (retVal > 0)
                {
                    grdCustomer.SelectedIndex = -1;
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
            txtLastName.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblLastName")).Text;
            txtBirthDate.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblBirthDate")).Text;
            txtPhone.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblPhone")).Text;
            txtEmail.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblEmail")).Text;
            txtAddress.Text = ((Label)grdCustomer.SelectedRow.FindControl("lblAddress")).Text;
            ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(((HiddenField)grdCustomer.SelectedRow.FindControl("hdnCountryID")).Value));
            BindProvince(Convert.ToInt32(ddlCountry.SelectedValue));
            ddlProvince.SelectedIndex = ddlProvince.Items.IndexOf(ddlProvince.Items.FindByValue(((HiddenField)grdCustomer.SelectedRow.FindControl("hdnProvinceID")).Value));
            chkIsActive.Checked = Convert.ToBoolean(((Label)grdCustomer.SelectedRow.FindControl("lblIsActive")).Text);
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

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProvince.Items.Clear();
            if (ddlCountry.SelectedIndex > 0)
            {
                BindProvince(Convert.ToInt32(ddlCountry.SelectedValue));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BAL.CustomerBAL obj = new BAL.CustomerBAL();
                obj.CustomerID = Convert.ToInt64(hdnCustomerID.Value);
                obj.FirstName = txtFirstName.Text.Trim();
                obj.LastName = txtLastName.Text.Trim();
                obj.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
                obj.Phone = txtPhone.Text.Trim();
                obj.Email = txtEmail.Text.Trim();
                obj.Address = txtAddress.Text.Trim();
                obj.ProvinceID = Convert.ToInt32(ddlProvince.SelectedValue);
                obj.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                obj.CreatedByID = 1;
                obj.ModifiedByID = 1;
                obj.IsActive = chkIsActive.Checked;

                int retVal = obj.InsertUpdateCustomer(obj);
                obj = null;
                if (retVal > 0)
                {
                    grdCustomer.SelectedIndex = -1;
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