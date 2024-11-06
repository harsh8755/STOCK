using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_ColorMaster : System.Web.UI.Page
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
            dt = DB.GetDataTableByProc("sp_Get_color_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdColor.DataSource = dt;
                grdColor.DataBind();

            }
            else
            {
                grdColor.DataSource = null;
                grdColor.DataBind();
            }


        }
        catch
        {
            grdColor.DataSource = null;
            grdColor.DataBind();
        }
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtColorName.Text = "";
        txtColorShortName.Text = "";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from Color_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and color_Name='" + txtColorName.Text + "' And color_short_name='" + txtColorShortName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.color_Name = txtColorName.Text;
                    a.color_short_name = txtColorShortName.Text;
                    a.admin_id = Session["AdminID"].ToString();

                    lblmsg.Text = AdminModule.InsertColorInfo(a);
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
                a.color_Name = txtColorName.Text;
                a.color_short_name= txtColorShortName.Text;
                a.admin_id = Session["AdminID"].ToString();
                a.color_id = lblID.Text;

                lblmsg.Text = AdminModule.UpdateColorInfo(a);
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
        txtColorName.Text = "";
        txtColorShortName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdColor_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdColor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblColorID = (Label)grdColor.Rows[index].FindControl("lblColorID");
                AdminModule a = new AdminModule();
                a.color_id = lblColorID.Text;
                a.admin_id = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteColorInfo(a);
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
                Label lblColorID = (Label)grdColor.Rows[index].FindControl("lblColorID");
                Label lblColorName = (Label)grdColor.Rows[index].FindControl("lblColorName");
                Label lblColorShortName = (Label)grdColor.Rows[index].FindControl("lblColorShortName");

                lblID.Text = lblColorID.Text;
                txtColorName.Text = lblColorName.Text;
                txtColorShortName.Text = lblColorShortName.Text;

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


    protected void grdColor_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdColor_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grdColor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdColor.PageIndex = e.NewPageIndex;
        grdColor.DataBind();

    }
}