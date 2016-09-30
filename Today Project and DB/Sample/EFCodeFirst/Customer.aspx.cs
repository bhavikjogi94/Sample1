using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EFCodeFirst
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
            using (BAL.EFContext context = new BAL.EFContext())
            {
                //  Using Syntax Based Query
                var customers = from c in context.Customers
                                join cn1 in context.Countries on c.CountryID equals cn1.CountryID into con
                                from cn1 in con.DefaultIfEmpty()
                                join cn2 in context.Provinces on c.ProvinceID equals cn2.ProvinceID into pro
                                from cn2 in pro.DefaultIfEmpty()
                                orderby c.FirstName, c.LastName
                                select new
                {
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    BirthDate = c.BirthDate,
                    Phone = c.Phone,
                    Email = c.Email,
                    Address = c.Address,
                    ProvinceID = c.ProvinceID,
                    CountryID = c.CountryID,
                    IsActive = c.IsActive,
                    Country = c.Country.CountryName,
                    Province = c.Province.ProvinceName
                };

                //  Using Method Based Query
                //var customers = context.Customers.GroupJoin(context.Countries, m => m.CountryID, n => n.CountryID, (m, n) => new { m, n })
                //.GroupJoin(context.Provinces, j => j.m.ProvinceID, k => k.ProvinceID, (j, k) => new { j, k })
                //.Select(l => new
                //{
                //    CustomerID = l.j.m.CustomerID,
                //    FirstName = l.j.m.FirstName,
                //    LastName = l.j.m.LastName,
                //    BirthDate = l.j.m.BirthDate,
                //    Phone = l.j.m.Phone,
                //    Email = l.j.m.Email,
                //    Address = l.j.m.Address,
                //    ProvinceID = l.j.m.ProvinceID,
                //    CountryID = l.j.m.CountryID,
                //    IsActive = l.j.m.IsActive,
                //    Country = l.j.m.Country.CountryName,
                //    Province = l.j.m.Province.ProvinceName
                //});

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

        public void BindCountry()
        {
            using (BAL.EFContext context = new BAL.EFContext())
            {
                //  Using Syntax Based Query
                var countries = from c in context.Countries
                                orderby c.CountryName
                                select new { CountryID = c.CountryID, Country = c.CountryName };
                //  Using Method based query
                //var countries = context.Countries.Select(t => new { CountryID = t.CountryID, Country = t.CountryName });
                if (countries != null)
                {
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "Country";
                    ddlCountry.DataSource = countries.ToList();
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
        }

        public void BindProvince(int countryID)
        {
            ddlProvince.Items.Clear();
            using (BAL.EFContext context = new BAL.EFContext())
            {
                //  Using Syntax Based Query
                var provinces = from p in context.Provinces
                                where p.CountryID == countryID
                                orderby p.ProvinceName
                                select new { ProvinceID = p.ProvinceID, Province = p.ProvinceName };

                //  Using Method based query
                //var provinces = context.Provinces.Where(m => m.CountryID == countryID).Select(t => new { ProvinceID = t.ProvinceID, Province = t.ProvinceName });
                if (provinces != null)
                {
                    ddlProvince.DataValueField = "ProvinceID";
                    ddlProvince.DataTextField = "Province";
                    ddlProvince.DataSource = provinces.ToList();
                    ddlProvince.DataBind();
                    ddlProvince.Items.Insert(0, new ListItem("Select", "0"));
                }
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
                using (BAL.EFContext context = new BAL.EFContext())
                {
                    Int64 customerID = Convert.ToInt64(hdnCustomerID.Value);
                    //  Using Syntax Based Query
                    BAL.Customer customer = (from c in context.Customers
                                    where c.CustomerID == customerID
                                    select c).FirstOrDefault();
                    context.Customers.Remove(customer);

                    //  Using Method based query
                    //BAL.Customer customers = context.Customers.Where(m => m.CustomerID == customerID).FirstOrDefault();
                    //context.Customers.Remove(customers);

                    if (context.SaveChanges() > 0)
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
                using (BAL.EFContext context = new BAL.EFContext())
                {
                    BAL.Customer obj = new BAL.Customer();
                    obj.CustomerID = Convert.ToInt64(hdnCustomerID.Value);
                    obj.FirstName = txtFirstName.Text.Trim();
                    obj.LastName = txtLastName.Text.Trim();
                    obj.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
                    obj.Phone = txtPhone.Text.Trim();
                    obj.Email = txtEmail.Text.Trim();
                    obj.Address = txtAddress.Text.Trim();
                    obj.ProvinceID = Convert.ToInt32(ddlProvince.SelectedValue);
                    obj.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                    obj.IsActive = chkIsActive.Checked;

                    if (Convert.ToInt64(hdnCustomerID.Value) > 0)
                    {
                        obj.ModifiedDate = DateTime.Now;

                        context.Customers.Attach(obj);
                        var entry = context.Entry(obj);
                        context.Configuration.ValidateOnSaveEnabled = false;

                        context.Entry(obj).Property(u => u.FirstName).IsModified = true;
                        context.Entry(obj).Property(u => u.LastName).IsModified = true;
                        context.Entry(obj).Property(u => u.BirthDate).IsModified = true;
                        context.Entry(obj).Property(u => u.Phone).IsModified = true;
                        context.Entry(obj).Property(u => u.Email).IsModified = true;
                        context.Entry(obj).Property(u => u.Address).IsModified = true;
                        context.Entry(obj).Property(u => u.CountryID).IsModified = true;
                        context.Entry(obj).Property(u => u.ProvinceID).IsModified = true;
                        context.Entry(obj).Property(u => u.ModifiedDate).IsModified = true;
                        context.Entry(obj).Property(u => u.IsActive).IsModified = true;

                        if (context.SaveChanges() > 0)
                        {
                            context.Configuration.ValidateOnSaveEnabled = true;
                            grdCustomer.SelectedIndex = -1;
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
                        obj.CreatedDate = DateTime.Now;
                        obj.CreatedByID = 1;
                        obj.ModifiedDate = DateTime.Now;
                        obj.ModifiedByID = 1;
                        obj.IsDeleted = false;

                        context.Customers.Add(obj);
                        if (context.SaveChanges() > 0)
                        {
                            var customerID = obj.CustomerID;
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
    }
}