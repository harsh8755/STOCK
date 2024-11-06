using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_UnitMaster : System.Web.UI.Page
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
            dt = DB.GetDataTableByProc("sp_get_unit_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdUnit.DataSource = dt;
                grdUnit.DataBind();

            }
            else
            {
                grdUnit.DataSource = null;
                grdUnit.DataBind();
            }


        }
        catch
        {
            grdUnit.DataSource = null;
            grdUnit.DataBind();
        }
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtUnitName.Text = "";
        txtUnitShortName.Text = "";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from Unit_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and unit_Name='" + txtUnitName.Text + "' And unit_short_name='"+txtUnitShortName.Text+"'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.unit_Name = txtUnitName.Text;
                    a.unit_short_name = txtUnitShortName.Text; 

                    a.admin_id = Session["AdminID"].ToString();
                    lblmsg.Text = AdminModule.InsertUnitInfo(a);
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
                a.unit_Name = txtUnitName.Text;
                a.unit_short_name = txtUnitShortName.Text;

                a.admin_id = Session["AdminID"].ToString();
                a.unit_id= lblID.Text;
                lblmsg.Text = AdminModule.UpdateUnitInfo(a);
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
        txtUnitName.Text = "";
        txtUnitShortName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdUnit_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdUnit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblUnitID = (Label)grdUnit.Rows[index].FindControl("lblUnitID");
                AdminModule a = new AdminModule();
                a.unit_id= lblUnitID.Text;
                a.admin_id = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteUnitInfo(a);
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
                Label lblUnitID = (Label)grdUnit.Rows[index].FindControl("lblUnitID");
                Label lblUnitName = (Label)grdUnit.Rows[index].FindControl("lblUnitName");
                Label lblUnitShortName = (Label)grdUnit.Rows[index].FindControl("lblUnitShortName");

                lblID.Text = lblUnitID.Text;
                txtUnitName.Text = lblUnitName.Text;
                txtUnitShortName.Text = lblUnitShortName.Text;

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


    protected void grdUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdUnit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void grdUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdUnit.PageIndex = e.NewPageIndex;
        grdUnit.DataBind();

    }
}