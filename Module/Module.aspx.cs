using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;






 

public partial class Module_Module : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
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
            string select = "Select * from ModuleInfo Where Status='E' And AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ") order by Priority asc";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdModule.DataSource = dt;
                grdModule.DataBind();

            }
            else
            {
                grdModule.DataSource = null;
                grdModule.DataBind();
            }


        }
        catch
        {
            grdModule.DataSource = null;
            grdModule.DataBind();
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
                string select = "Select * from ModuleInfo Where Status='E' And AdminID=" + Session["AdminID"].ToString()+" and Name='"+txtModuleName.Text+"'";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblmsg.Text = "Record Already Exist.";

            }
            else
            {
                AdminModule a = new AdminModule();
                a.Name = txtModuleName.Text;
                a.AdminID = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.InsertModuleInfo(a);
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
                a.Name = txtModuleName.Text;
                a.AdminID = Session["AdminID"].ToString();
                a.ModuleID = lblID.Text;
                lblmsg.Text = AdminModule.UpdateModuleInfo(a);
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
        txtModuleName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdModule_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

   
    protected void grdModule_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblModuleID = (Label)grdModule.Rows[index].FindControl("lblModuleID");
            AdminModule a = new AdminModule();
            a.ModuleID = lblModuleID.Text;
            a.AdminID = Session["AdminID"].ToString();
            lblmsg.Text = AdminModule.DeleteModuleInfo(a);
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
            Label lblModuleID = (Label)grdModule.Rows[index].FindControl("lblModuleID");
            Label lblModuleName = (Label)grdModule.Rows[index].FindControl("lblModuleName");
            lblID.Text = lblModuleID.Text;
            txtModuleName.Text = lblModuleName.Text;
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


    protected void grdModule_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdModule_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void ChangePreference(object sender, EventArgs e)
    {
        if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
        {
            string commandArgument = (sender as LinkButton).CommandArgument;

            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            Label lblModuleID = (Label)grdModule.Rows[rowIndex].FindControl("lblModuleID");
            Label lblPriority = (Label)grdModule.Rows[rowIndex].FindControl("lblPriority");
            int locationId = Convert.ToInt32(lblModuleID.Text);
            int preference = Convert.ToInt32(lblPriority.Text);
            preference = commandArgument == "up" ? preference - 1 : preference + 1;
            this.UpdatePreference(locationId, preference);
            rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
            Label lblModuleID1 = (Label)grdModule.Rows[rowIndex].FindControl("lblModuleID");
            Label lblPriority1 = (Label)grdModule.Rows[rowIndex].FindControl("lblPriority");
            locationId = Convert.ToInt32(lblModuleID1.Text);
            preference = Convert.ToInt32(lblPriority1.Text);
            preference = commandArgument == "up" ? preference + 1 : preference - 1;
            this.UpdatePreference(locationId, preference);
            BindGrid();
        }
        else
        {
            lblmsg.Text = "You Do not Have Permission for Update Record";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Update Record');", true);
        }
    }
    private void UpdatePreference(int locationId, int preference)
    {
        string Update = "Update ModuleInfo set Priority='" + preference + "' where Status='E' and ModuleID=" + locationId;
        int i = DB.ExecuteNonQuery(Update);
    }
}