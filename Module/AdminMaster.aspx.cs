using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;
using System.IO;
using System.EnterpriseServices;
using System.Text;

public partial class Module_AdminMaster : System.Web.UI.Page
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
            string select = "Select * from AdminInfo Where Status='E' and AdminType!='S' And AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ") and  AdminID not in ('" + Session["AdminID"].ToString() + "') order by name asc";
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

                string select = "Select * from AdminInfo Where Status='E' And AdminID=" + Session["AdminID"].ToString() + " and Name='" + txtAdminName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    FileUpload fileUploader = FileUpload1;

                    int maxFileSize = 5 * 1024 * 1024; // Maximum file size in bytes (e.g., 5MB)
                    int fileSize = fileUploader.PostedFile.ContentLength;
                    if (fileSize <= maxFileSize)
                    {
                        if (fileUploader.HasFile)
                        {
                            ImageConverter1 imageConverter = new ImageConverter1();
                            byte[] imageBytes = imageConverter.ConvertFileUploaderToByteArray(fileUploader);

                            if (imageBytes != null)
                            {
                                a.PicBytes = imageBytes;
                            }
                            else
                            {
                                a.PicBytes = null;
                            }
                        }
                        else
                        {
                            a.PicBytes = DB.FatchColumnNameByte("AdminPicInfo", "ImageBytes", "AdminID", "1", "Status", 'D'); ; ;
                        }
                        



                        a.Name = txtAdminName.Text;
                        a.EmailID = txtEmailID.Text;
                        a.Mobile = txtMobile.Text;
                        a.LoginID = txtLoginID.Text;
                        a.Password = CryptoEngine.Encrypt(txtPassword.Text);
                        a.PicURl = lblPath.Text;
                        a.AdminID = Session["AdminID"].ToString();
                        lblmsg.Text = AdminModule.InsertAdminInfo(a);

                        string AdminID = "";
                        string Select1 = "Select Max(AdminID) as AdminID from AdminInfo where Status='E' and Name='" + txtAdminName.Text + "' and LoginID='" + txtLoginID.Text + "'";
                        DataTable dt1 = DB.GetDataTable(Select1);
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            AdminID = dt1.Rows[0]["AdminID"].ToString();
                            string Update = "Update AdminInfo set CompanyID='" + Session["CompanyID"].ToString() + "' where AdminID=" + AdminID;
                            int i = DB.ExecuteNonQuery(Update);
                            InsertRolls("3", AdminID);

                        }
                    }
                    else 
                    {
                        lblmsg.Text = "File size exceeds the allowed limit.5 MB";
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('File size exceeds the allowed limit.5 MB');", true);
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
                AdminModule a = new AdminModule();
                FileUpload fileUploader = FileUpload1;

                int maxFileSize = 5 * 1024 * 1024; // Maximum file size in bytes (e.g., 5MB)
                int fileSize = fileUploader.PostedFile.ContentLength;
                if (fileSize <= maxFileSize)
                {
                    if (fileUploader.HasFile)
                    {
                        ImageConverter1 imageConverter = new ImageConverter1();
                        byte[] imageBytes = imageConverter.ConvertFileUploaderToByteArray(fileUploader);

                        if (imageBytes != null)
                        {
                            a.PicBytes = imageBytes;
                        }
                        else
                        {
                            a.PicBytes = null;
                        }
                    }
                    else
                    {
                        a.PicBytes = DB.FatchColumnNameByte("AdminPicInfo", "ImageBytes", "AdminID", lblID.Text, "Status", 'E'); ; ;

                    }

                    a.Name = txtAdminName.Text;
                    a.EmailID = txtEmailID.Text;
                    a.Mobile = txtMobile.Text;
                    a.PicURL = lblPath.Text;
                    a.AdminID1 = Session["AdminID"].ToString();
                    a.AdminID = lblID.Text;
                    lblmsg.Text = AdminModule.UpdateAdminInfo(a);
                    BindGrid();
                    Clear();

                }
                else
                {
                    lblmsg.Text = "File size exceeds the allowed limit.5 MB";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('File size exceeds the allowed limit.5 MB');", true);
                }
                //clear();
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
                Label lblAdminID = (Label)grdAdmin.Rows[index].FindControl("lblAdminID");

                AdminModule a = new AdminModule();
                a.AdminID = lblAdminID.Text;
                a.AdminID1 = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteAdminInfo(a);
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
                Label lblAdminID = (Label)grdAdmin.Rows[index].FindControl("lblAdminID");

                Label lblAdminName = (Label)grdAdmin.Rows[index].FindControl("lblAdminName");
                Label lblEmailID = (Label)grdAdmin.Rows[index].FindControl("lblEmailID");
                Label lblMobile = (Label)grdAdmin.Rows[index].FindControl("lblMobile");
                Label LblLoginID = (Label)grdAdmin.Rows[index].FindControl("LblLoginID");
                Label LblPassword = (Label)grdAdmin.Rows[index].FindControl("LblPassword");
                Label lblPath1 = (Label)grdAdmin.Rows[index].FindControl("lblPath");

                lblID.Text = lblAdminID.Text;
                txtEmailID.Text = lblEmailID.Text;
                txtMobile.Text = lblMobile.Text;
                txtLoginID.Text = LblLoginID.Text;
                txtPassword.Text = CryptoEngine.Decrypt(LblPassword.Text);
                lblPath.Text = lblPath1.Text;
                txtAdminName.Text = lblAdminName.Text;
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
        if (e.CommandName == "Block")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblAdminID = (Label)grdAdmin.Rows[index].FindControl("lblAdminID");

                string Update = "Update AdminInfo Set BlockStatus='Y' Where AdminID='" + lblAdminID.Text + "'";
                int i = DB.ExecuteNonQuery(Update);
                if (i > 0)
                {
                    BindGrid();
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Update Record');", true);
            }

        }
        if (e.CommandName == "Unblock")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblAdminID = (Label)grdAdmin.Rows[index].FindControl("lblAdminID");

                string Update = "Update AdminInfo Set BlockStatus='N' Where AdminID='" + lblAdminID.Text + "'";
                int i = DB.ExecuteNonQuery(Update);
                if (i > 0)
                {
                    BindGrid();
                }
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
            lblmsg.Text = AdminModule.InsertRoll(a);
        }
        catch
        {
        }
    }
}