using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_BrandMaster : System.Web.UI.Page
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

            DataTable dt = new DataTable();
            dt = DB.GetDataTableByProc("sp_Get_brand_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdBrand.DataSource = dt;
                grdBrand.DataBind();

            }
            else
            {
                grdBrand.DataSource = null;
                grdBrand.DataBind();
            }


        }
        catch
        {
            grdBrand.DataSource = null;
            grdBrand.DataBind();
        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtBrandName.Text = "";
        txtBrandShortName.Text = "";
        BrandLogo.Dispose();
        Clear();
        BindGrid();

    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from Brand_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and brand_Name='" + txtBrandName.Text + "' And brand_short_name='" + txtBrandShortName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    if (BrandLogo != null && BrandLogo.HasFile)
                    {
                        string fileUrl = "";
                        int maxFileSize = 1 * 1024 * 1024; // Maximum file size in bytes (e.g., 5MB)
                        int fileSize = BrandLogo.PostedFile.ContentLength;
                        if (fileSize <= maxFileSize)
                        {
                            string ext = Path.GetExtension(BrandLogo.FileName);
                            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                            BrandLogo.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/img/") + filename);
                            fileUrl = "img/" + filename;

                            AdminModule a = new AdminModule();
                            a.brand_Name = txtBrandName.Text;
                            a.brand_short_name = txtBrandShortName.Text;
                            a.Brand_logo_url= fileUrl;
                            a.admin_id = Session["AdminID"].ToString();

                            lblmsg.Text = AdminModule.InsertBrandInfo(a);
                            BindGrid();
                            Clear();
                        }
                        else
                        {
                            lblmsg.Text = "Please Select an image less then 1 MB.";
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Please Select a valid file.";
                    }

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
                if (BrandLogo != null && BrandLogo.HasFile)
                {
                    string fileUrl = "";
                    int maxFileSize = 1 * 1024 * 1024; // Maximum file size in bytes (e.g., 5MB)
                    int fileSize = BrandLogo.PostedFile.ContentLength;
                    if (fileSize <= maxFileSize)
                    {
                        string ext = Path.GetExtension(BrandLogo.FileName);
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                        BrandLogo.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/img/") + filename);
                        fileUrl = "img/" + filename;

                        AdminModule a = new AdminModule();
                        a.brand_id = lblID.Text;
                        a.brand_Name = txtBrandName.Text;
                        a.brand_short_name = txtBrandShortName.Text;
                        a.Brand_logo_url = fileUrl != "" ? fileUrl : null;
                        a.admin_id = Session["AdminID"].ToString();

                        lblmsg.Text = AdminModule.UpdateBrandInfo(a);
                        BindGrid();
                        Clear();
                    }
                    else
                    {
                        lblmsg.Text = "Please Select an image less then 1 MB.";
                    }
                }
                else if (BrandLogo == null || !BrandLogo.HasFile)
                {
                    string fileUrl1 = "";
                    AdminModule a = new AdminModule();
                    a.brand_id = lblID.Text;
                    a.brand_Name = txtBrandName.Text;
                    a.brand_short_name = txtBrandShortName.Text;
                    a.Brand_logo_url = fileUrl1;
                    a.admin_id = Session["AdminID"].ToString();

                    lblmsg.Text = AdminModule.UpdateBrandInfo(a);
                    BindGrid();
                    Clear();
                }
                else
                {
                    lblmsg.Text = "Please Select a valid file.";
                }

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
        txtBrandName.Text = "";
        txtBrandShortName.Text = "";
        BrandLogo.Dispose();

        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdBrand_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdBrand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblBrandID = (Label)grdBrand.Rows[index].FindControl("lblBrandID");
                AdminModule a = new AdminModule();
                a.brand_id = lblBrandID.Text;
                a.admin_id = Session["AdminID"].ToString();

                lblmsg.Text = AdminModule.DeleteBrandInfo(a);
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
                Label lblBrandID = (Label)grdBrand.Rows[index].FindControl("lblBrandID");
                Label lblBrandName = (Label)grdBrand.Rows[index].FindControl("lblBrandName");
                Label lblBrandShortName = (Label)grdBrand.Rows[index].FindControl("lblBrandShortName");
                lblID.Text = lblBrandID.Text;
                txtBrandName.Text = lblBrandName.Text;
                txtBrandShortName.Text = lblBrandShortName.Text;

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


    protected void grdBrand_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdBrand_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlBrandName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grdBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdBrand.PageIndex = e.NewPageIndex;
        grdBrand.DataBind();

    }
}