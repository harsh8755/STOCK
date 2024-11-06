using CYS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_SizeMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {

                BindDdlModule();
                BindGrid();
            }

        }

    }



    protected void BindGrid()
    {
        try
        {
            
            DataTable dt = new DataTable();
            dt = DB.GetDataTableByProc("sp_Get_size_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdSize.DataSource = dt;
                grdSize.DataBind();

            }
            else
            {
                grdSize.DataSource = null;
                grdSize.DataBind();
            }


        }
        catch
        {
            grdSize.DataSource = null;
            grdSize.DataBind();
        }
    }


    protected void BindDdlModule()
    {
        try
        {
            string select = "Select unit_id,unit_Name from Unit_info Where Status='E' And admin_id in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")  order by Unit_Name asc";
            DataTable dt = DB.GetDataTable(select);
            ddlUnitName.Items.Clear();
            ddlUnitName.Items.Add(new ListItem("Select Unit Name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlUnitName.Items.Add(new ListItem(dr["Unit_Name"].ToString(), dr["Unit_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
        protected void cmdClear_Click(object sender, EventArgs e)
    {
        ddlUnitName.SelectedValue = "0";
        txtSizeName.Text = "";
        txtSizeShortName.Text = "";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from Size_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and size_Name='" + txtSizeName.Text + "' and  And size_short_name='" + txtSizeShortName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.unit_id= ddlUnitName.SelectedValue;
                    a.size_Name = txtSizeName.Text;
                    a.size_short_name = txtSizeShortName.Text;
                    a.admin_id = Session["AdminID"].ToString();

                    lblmsg.Text = AdminModule.InsertSizeInfo(a);
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
                a.size_Name = txtSizeName.Text;
                a.size_short_name = txtSizeShortName.Text;
                a.size_id= lblID.Text;
                a.admin_id = Session["AdminID"].ToString();
                a.unit_id = lblID.Text;
                lblmsg.Text = AdminModule.UpdateSizeInfo(a);
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
        ddlUnitName.SelectedValue = "0";
        txtSizeName.Text = "";
        txtSizeShortName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdSize_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdSize_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblSizeID = (Label)grdSize.Rows[index].FindControl("lblSizeID");
                AdminModule a = new AdminModule();
                a.size_id = lblSizeID.Text;
                a.admin_id = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteSizeInfo(a);
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
                Label lblUnitID = (Label)grdSize.Rows[index].FindControl("lblUnitID");
                Label lblSizeID = (Label)grdSize.Rows[index].FindControl("lblSizeID");
                Label lblSizeName = (Label)grdSize.Rows[index].FindControl("lblSizeName");
                Label lblSizeShortName = (Label)grdSize.Rows[index].FindControl("lblSizeShortName");
                Label lblUnitName = (Label)grdSize.Rows[index].FindControl("lblUnitName");
                lblID.Text = lblSizeID.Text;
                ddlUnitName.SelectedValue = lblUnitID.Text;
                txtSizeName.Text = lblSizeName.Text;
                txtSizeShortName.Text = lblSizeShortName.Text;

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


    protected void grdSize_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdSize_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void ddlUnitName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void grdSize_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdSize.PageIndex = e.NewPageIndex;
        grdSize.DataBind();

    }
}