using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;
using System.IO;

public partial class Module_CompanyMaster : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {
                BindGrid();
            }

        }

    }



    protected void BindGrid()
    {
        try
        {
            string select = "Select ci.* from CompanyInfo ci Where ci.Status='E' and  ci.AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ") order by Companyname asc";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdAdmin.DataSource = dt;
                grdAdmin.DataBind();

            }
            else
            {
                grdAdmin.DataSource = null;
                grdAdmin.DataBind();
            }


        }
        catch
        {
            grdAdmin.DataSource = null;
            grdAdmin.DataBind();
        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        Clear();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {

                string select = "Select * from CompanyInfo Where Status='E' And AdminID=" + Session["AdminID"].ToString() + " and CompanyName='" + txtAdminName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {


                    AdminModule a = new AdminModule();
                    a.Name = txtAdminName.Text;
                    a.EmailID = txtEmailID.Text;
                    a.Mobile = txtMobile.Text;
                    a.LoginID = txtLoginID.Text;
                    a.Address = txtAddress.Text;
                    a.Password = CryptoEngine.Encrypt(txtPassword.Text);
                    a.PicURl = lblPath.Text;
                    a.AdminID = Session["AdminID"].ToString();
                    lblmsg.Text = AdminModule.InsertCompanyInfo(a);
                    AdminModule.InsertAdminInfo(a);
                    string AdminID = "";
                    string Select1 = "Select Max(AdminID) as AdminID from AdminInfo where Status='E' and Name='" + txtAdminName.Text + "' and LoginID='" + txtLoginID.Text + "'";
                    DataTable dt1 = DB.GetDataTable(Select1);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        AdminID = dt1.Rows[0]["AdminID"].ToString();
                        string CompanyID = "";
                        string Select2 = "Select Max(CompanyID) as CompanyID from CompanyInfo where Status='E' and CompanyName='" + txtAdminName.Text + "' and Email='" + txtEmailID.Text + "'";
                        DataTable dt2 = DB.GetDataTable(Select2);
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            CompanyID = dt2.Rows[0]["CompanyID"].ToString();
                            string Update = "Update AdminInfo set CompanyID='" + CompanyID + "' where AdminID=" + AdminID;
                            int i = DB.ExecuteNonQuery(Update);
                            string PageID = "3,1011";
                            string[] page = PageID.Split(',');
                            foreach (string st in page)
                            {
                                InsertRolls(st, AdminID);
                                InserPermission("1", AdminID);
                                InserPermission("2", AdminID);
                                InserPermission("3", AdminID);
                            }
                        }
                    }
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
                if (FileUpload1.HasFile)
                {
                    string fileName = System.DateTime.Now.Ticks.ToString() + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    lblPath.Text = fileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/") + fileName);
                }
                AdminModule a = new AdminModule();
                a.Name = txtAdminName.Text;
                a.EmailID = txtEmailID.Text;
                a.Mobile = txtMobile.Text;
                a.PicURL = lblPath.Text;
                a.AdminID = Session["AdminID"].ToString();
                a.CompanyID = lblID.Text;
                a.Address = txtAddress.Text;
                lblmsg.Text = AdminModule.UpdateCompanyInfo(a);
                BindGrid();
                Clear();
            }
            else
            {
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
        txtAdminName.Text = "";
        txtEmailID.Text = "";
        txtLoginID.Text = "";
        txtMobile.Text = "";
        txtPassword.Text = "";
        lblPath.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
        txtLoginID.Enabled = true;
        txtPassword.Enabled = true;
        RequiredFieldValidator3.Enabled = true;

    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblCompanyID = (Label)grdAdmin.Rows[index].FindControl("lblCompanyID");

                AdminModule a = new AdminModule();
                a.CompanyID = lblCompanyID.Text;
                a.AdminID = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteCompanyInfo(a);
                BindGrid();
                Clear();
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Delete Record');", true);
            }
        }
        if (e.CommandName == "Update")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblCompanyID = (Label)grdAdmin.Rows[index].FindControl("lblCompanyID");

                Label lblAdminName = (Label)grdAdmin.Rows[index].FindControl("lblAdminName");
                Label lblEmailID = (Label)grdAdmin.Rows[index].FindControl("lblEmailID");
                Label lblMobile = (Label)grdAdmin.Rows[index].FindControl("lblMobile");
                Label lblAddress = (Label)grdAdmin.Rows[index].FindControl("lblAddress");
               

                lblID.Text = lblCompanyID.Text;
                txtEmailID.Text = lblEmailID.Text;
                txtMobile.Text = lblMobile.Text;

                txtPassword.Text = "*****";
               
                txtAdminName.Text = lblAdminName.Text;
                txtAddress.Text = lblAddress.Text;

                string select = "Select * from AdminInfo where CompanyID='" + lblCompanyID.Text + "' and Status='E' order by AdminID Asc";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtLoginID.Text = dt.Rows[0]["LoginID"].ToString();
                }

                txtLoginID.Enabled = false;
                txtPassword.Enabled = false;
                RequiredFieldValidator3.Enabled = false;
                cmdSubmit.Visible = false;
                cmdUpdate.Visible = true;
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Update Record');", true);
            }


        }
      
    }


    protected void grdAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void InsertRolls(string PageID, string AdminID)
    {
        try
        {
            AdminModule a = new AdminModule();
            a.PageID = PageID;
            a.AdminID = AdminID;
            a.AdminID1 = Session["AdminID"].ToString();
            AdminModule.InsertRoll(a);
        }
        catch
        {
        }
    }
    protected void InserPermission(string Permission, string AdminID)
    {
        try
        {
            AdminModule a = new AdminModule();
            a.Permission = Permission;
            if (Permission == "1")
            {
                a.Name = "Insert";
            }
            else if (Permission == "2")
            {
                a.Name = "Update";
            }
            else if (Permission == "3")
            {
                a.Name = "Delete";
            }
            a.AdminID = AdminID;
            a.AdminID1 = Session["AdminID"].ToString();
            AdminModule.InsertPermission(a);
        }
        catch
        {
        }
    }
}