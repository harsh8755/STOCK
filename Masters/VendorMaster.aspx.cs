using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_VendorMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {

                BindStateList();
                BindGrid();
            }

        }

    }



    protected void BindGrid()
    {
        try
        {

            DataTable dt = new DataTable();
            dt = DB.GetDataTableByProc("sp_Get_vendor_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdVendor.DataSource = dt;
                grdVendor.DataBind();

            }
            else
            {
                grdVendor.DataSource = null;
                grdVendor.DataBind();
            }


        }
        catch
        {
            grdVendor.DataSource = null;
            grdVendor.DataBind();
        }
    }


    protected void BindStateList()
    {
        try
        {
            string select = "Select * from stateInfo Where Status='E' And adminId in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")  order by name asc";
            DataTable dt = DB.GetDataTable(select);
            ddlStateName.Items.Clear();
            ddlStateName.Items.Add(new ListItem("Select state name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlStateName.Items.Add(new ListItem(dr["Name"].ToString(), dr["StateID"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void BindCityList()
    {
        try
        {
            string select = "Select * from cityInfo Where Status='E' and stateId='" + ddlStateName.SelectedValue + "' And adminId in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")  order by Name asc";
            DataTable dt = DB.GetDataTable(select);
            ddlCityName.Items.Clear();
            ddlCityName.Items.Add(new ListItem("Select city name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlCityName.Items.Add(new ListItem(dr["Name"].ToString(), dr["cityID"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtVendorName.Text = "";
        txtFirmName.Text = "";
        txtAddress.Text = "";
        ddlCityName.SelectedValue = "0";
        ddlStateName.SelectedValue = "0";
        txtPincode.Text = "";
        txtVendorEmail.Text = "";
        txtVendorMobile.Text = "";
        txtContactPerson.Text = "";
        txtContactEmail.Text = "";
        txtContactMobile.Text = "";
        txtRegNo.Text = "";
        txtGSTNo.Text = "";
        lblmsg.Text = "";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from Vendor_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and vendor_Name='" + txtVendorName.Text + "' And vendror_Firm_Name='" + txtFirmName.Text + "' and vendor_Address='"+txtAddress.Text+ "' and vendor_State='"+ddlStateName.SelectedValue+ "' and vendor_City='"+ddlCityName.SelectedValue+ "' and vendor_Pincode='"+txtPincode.Text+ "' and  vendor_Email_id='"+txtVendorEmail.Text+ "'and vendor_Mobile='"+txtVendorMobile.Text+ "' and Contact_person='"+txtContactPerson.Text+ "' and Contact_Email_id='"+txtContactEmail.Text+"'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.vendor_Name=txtVendorName.Text;
                    a.vendor_Firm_Name=txtFirmName.Text;
                    a.vendor_Address=txtAddress.Text;
                    a.vendor_State=ddlStateName.SelectedValue;
                    a.vendor_City=ddlCityName.SelectedValue;
                    a.vendor_Pincode=txtPincode.Text;
                    a.vendor_Email_id=txtVendorEmail.Text;
                    a.vendor_Mobile=txtVendorMobile.Text;
                    a.Contact_person=txtContactPerson.Text;
                    a.Contact_Email_id=txtContactEmail.Text;
                    a.Contact_Mobile=txtContactMobile.Text;
                    a.vendor_Reg_No=txtRegNo.Text;
                    a.vendor_GST_No=txtGSTNo.Text;
                    a.admin_id = Session["AdminID"].ToString();

                    lblmsg.Text = AdminModule.InsertVendorInfo(a);
                    BindGrid();
                    Clear();
                }
            }
            else
            {
                lblmsg.Text = "You Do not Have Permission for Insert Record";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Insert Record');", true);

            }
        }
        catch (Exception ex)

        {
            lblmsg.Text = ex.ToString();
        }



    }

    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
            {
                AdminModule a = new AdminModule();
                a.vendor_id=lblID.Text;
                a.vendor_Name = txtVendorName.Text;
                a.vendor_Firm_Name = txtFirmName.Text;
                a.vendor_Address = txtAddress.Text;
                a.vendor_State = ddlStateName.SelectedValue;
                a.vendor_City = ddlCityName.SelectedValue;
                a.vendor_Pincode = txtPincode.Text;
                a.vendor_Email_id = txtVendorEmail.Text;
                a.vendor_Mobile = txtVendorMobile.Text;
                a.Contact_person = txtContactPerson.Text;
                a.Contact_Email_id = txtContactEmail.Text;
                a.Contact_Mobile = txtContactMobile.Text;
                a.vendor_Reg_No = txtRegNo.Text;
                a.vendor_GST_No = txtGSTNo.Text;
                a.admin_id = Session["AdminID"].ToString();

                lblmsg.Text = AdminModule.UpdateVendorInfo(a);
                BindGrid();
                Clear();
            }
            else
            {
                lblmsg.Text = "You Do not Have Permission for Update Record";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Update Record');", true);
            }

        }
        catch
        {
            lblmsg.Text = "Error";
        }
    }

    protected void Clear()
    {
        txtVendorName.Text = "";
        txtFirmName.Text = "";
        txtAddress.Text = "";
        ddlCityName.SelectedValue = "0";
        ddlStateName.SelectedValue = "0";
        txtPincode.Text = "";
        txtVendorEmail.Text = "";
        txtVendorMobile.Text = "";
        txtContactPerson.Text = "";
        txtContactEmail.Text = "";
        txtContactMobile.Text = "";
        txtRegNo.Text = "";
        txtGSTNo.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdVendor_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdVendor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblVendorID = (Label)grdVendor.Rows[index].FindControl("lblVendorID");
                AdminModule a = new AdminModule();
                a.vendor_id = lblVendorID.Text;
                a.admin_id = Session["AdminID"].ToString();

                lblmsg.Text = AdminModule.DeleteVendorInfo(a);
                BindGrid();
                Clear();
            }
            else
            {
                lblmsg.Text = "You Do not Have Permission for Delete Record";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Delete Record');", true);
            }
        }
        if (e.CommandName == "Update")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblVendorID = (Label)grdVendor.Rows[index].FindControl("lblVendorID");
                Label lblVendorName = (Label)grdVendor.Rows[index].FindControl("lblVendorName");
                Label lblVendorFirm = (Label)grdVendor.Rows[index].FindControl("lblVendorFirm");
                Label lblAddress = (Label)grdVendor.Rows[index].FindControl("lblAddress");
                Label lblStateID = (Label)grdVendor.Rows[index].FindControl("lblStateID");
                Label lblStateName = (Label)grdVendor.Rows[index].FindControl("lblStateName");
                Label lblCityID = (Label)grdVendor.Rows[index].FindControl("lblCityID");
                Label lblCityName = (Label)grdVendor.Rows[index].FindControl("lblCityName");
                Label lblPincode = (Label)grdVendor.Rows[index].FindControl("lblPincode");
                Label lblVendorEmail = (Label)grdVendor.Rows[index].FindControl("lblVendorEmail");
                Label lblVendorMobile = (Label)grdVendor.Rows[index].FindControl("lblVendorMobile");
                Label lblContactPerson = (Label)grdVendor.Rows[index].FindControl("lblContactPerson");
                Label lblContactEmail = (Label)grdVendor.Rows[index].FindControl("lblContactEmail");
                Label lblContactMobile = (Label)grdVendor.Rows[index].FindControl("lblContactMobile");
                Label lblRegNo = (Label)grdVendor.Rows[index].FindControl("lblRegNo");
                Label lblGSTNo = (Label)grdVendor.Rows[index].FindControl("lblGSTNo");
                
                lblID.Text = lblVendorID.Text;
                txtVendorName.Text = lblVendorName.Text;
                txtFirmName.Text = lblVendorFirm.Text;
                txtAddress.Text = lblAddress.Text;
                ddlStateName.SelectedValue = lblStateID.Text;
                BindCityList();
                ddlCityName.SelectedValue = lblCityID.Text;
                txtPincode.Text=lblPincode.Text;
                txtVendorEmail.Text=lblVendorEmail.Text;
                txtVendorMobile.Text = lblVendorMobile.Text;
                txtContactPerson.Text=lblContactPerson.Text;
                txtContactEmail.Text=lblContactEmail.Text;
                txtContactMobile.Text=lblContactMobile.Text;
                txtRegNo.Text=lblRegNo.Text;
                txtGSTNo.Text=lblGSTNo.Text;

                cmdSubmit.Visible = false;
                cmdUpdate.Visible = true;
            }
            else
            {
                lblmsg.Text = "You Do not Have Permission for Update Record";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Update Record');", true);
            }

        }

    }


    protected void grdVendor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdVendor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCityList();
        BindGrid();
    }
    protected void ddlCityName_SelectedIndexChanged(object sender,EventArgs e)
    {
        BindGrid();
    }

    protected void grdVendor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdVendor.PageIndex = e.NewPageIndex;
        grdVendor.DataBind();

    }
}