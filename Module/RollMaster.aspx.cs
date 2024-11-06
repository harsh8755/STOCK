using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;


public partial class Admin_RollMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {
                BindDdlModule();
                BindPages();
                BindGrid();
            }

        }

    }



    protected void BindGrid()
    {
        try
        {
            string select = "Select * from AdminInfo Where Status='E' And UpdateAdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ") and AdminID in (Select AdminID from RollInfo Where Status='E' and AdminID1='" + Session["AdminID"].ToString() + "')";
            select += " order by Name asc";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdRoll.DataSource = dt;
                grdRoll.DataBind();

            }
            else
            {
                grdRoll.DataSource = null;
                grdRoll.DataBind();
            }


        }
        catch
        {
            grdRoll.DataSource = null;
            grdRoll.DataBind();
        }
    }


    protected void BindDdlModule()
    {
        try
        {
            string select = "Select * from AdminInfo Where Status='E' And CompanyID=" + Session["CompanyID"].ToString() + "  order by name asc";
            DataTable dt = DB.GetDataTable(select);
            ddlAdminName.Items.Clear();
            ddlAdminName.Items.Add(new ListItem("Select Admin Name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlAdminName.Items.Add(new ListItem(dr["Name"].ToString(), dr["AdminID"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void BindPages()
    {
        try
        {

            string select;
            select = "Select * from PageInfo Where Status='E' and moduleID  in (select ModuleID from ModuleInfo where Status='E') order by Priority asc";
            DataTable dt = DB.GetDataTable(select);
            lstPages.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lstPages.Items.Add(new ListItem(dr["PageName"].ToString(), dr["PageID"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        ddlAdminName.SelectedValue = "0";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string delete = "Delete RollInfo where AdminID='"+ ddlAdminName.SelectedValue + "' and status='E'";
            string delete1 = " Delete PermissionInfo where AdminID = '" + ddlAdminName.SelectedValue + "' and status = 'E'";
            int p = DB.ExecuteNonQuery(delete);
            int p1 = DB.ExecuteNonQuery(delete1);
            foreach (ListItem listBoxItem in lstPages.Items)
            {
                if (listBoxItem.Selected == true)
                {
                    InsertRolls(listBoxItem.Value, ddlAdminName.SelectedValue);
                }

            }
            foreach (ListItem listBoxItem in lstPermission.Items)
            {
                if (listBoxItem.Selected == true)
                {
                    InserPermission(listBoxItem.Value, ddlAdminName.SelectedValue);
                }

            }
            BindGrid();
            Clear();
            }
            else
            {

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
                string delete = "Delete RollInfo where AdminID='" + ddlAdminName.SelectedValue + "' and status='E'";
            string delete1 = " Delete PermissionInfo where AdminID = '" + ddlAdminName.SelectedValue + "' and status = 'E'";
            int p = DB.ExecuteNonQuery(delete);
            int p1 = DB.ExecuteNonQuery(delete1);
            foreach (ListItem listBoxItem in lstPages.Items)
            {
                if (listBoxItem.Selected == true)
                {
                    InsertRolls(listBoxItem.Value, ddlAdminName.SelectedValue);
                }

            }
            foreach (ListItem listBoxItem in lstPermission.Items)
            {
                if (listBoxItem.Selected == true)
                {
                    InserPermission(listBoxItem.Value, ddlAdminName.SelectedValue);
                }

            }
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
        // txtRollName.Text = "";

        foreach (ListItem listBoxItem in lstPages.Items)
        {
            if (listBoxItem.Selected == true)
            {
                listBoxItem.Selected = false;
            }

        }
        foreach (ListItem listBoxItem in lstPermission.Items)
        {
            if (listBoxItem.Selected == true)
            {
                listBoxItem.Selected = false;
            }

        }
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdRoll_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdRoll_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                 foreach (ListItem listBoxItem in lstPages.Items)
        {
            if (listBoxItem.Selected == true)
            {
                listBoxItem.Selected = false;
            }

        }
        foreach (ListItem listBoxItem in lstPermission.Items)
        {
            if (listBoxItem.Selected == true)
            {
                listBoxItem.Selected = false;
            }

        }
                int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblAdminID = (Label)grdRoll.Rows[index].FindControl("lblAdminID");
            string delete = "Delete RollInfo where AdminID='" + lblAdminID.Text + "' and status='E'";
            string delete1 = " Delete PermissionInfo where AdminID = '" + lblAdminID.Text + "' and status = 'E'";
            int p = DB.ExecuteNonQuery(delete);
            int p1 = DB.ExecuteNonQuery(delete1);
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
                foreach (ListItem listBoxItem in lstPages.Items)
                {
                    if (listBoxItem.Selected == true)
                    {
                        listBoxItem.Selected = false;
                    }

                }
                foreach (ListItem listBoxItem in lstPermission.Items)
                {
                    if (listBoxItem.Selected == true)
                    {
                        listBoxItem.Selected = false;
                    }

                }
                int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblAdminID = (Label)grdRoll.Rows[index].FindControl("lblAdminID");
            ddlAdminName.SelectedValue = lblAdminID.Text;
            string Select1 = "Select * from RollInfo Where Status='E' And AdminID='"+ lblAdminID.Text + "'";
            string Select2 = "Select * from PermissionInfo Where Status='E' And AdminID='" + lblAdminID.Text + "'";

            DataTable dt = DB.GetDataTable(Select1);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    foreach (ListItem listBoxItem in lstPages.Items)
                    {
                        if (listBoxItem.Value == dr["PageID"].ToString())
                        {
                            listBoxItem.Selected = true;
                        }

                    }

                }

            }
            DataTable dt1 = DB.GetDataTable(Select2);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    foreach (ListItem listBoxItem in lstPermission.Items)
                    {
                        if (listBoxItem.Value == dr["Permission"].ToString())
                        {
                            listBoxItem.Selected = true;
                        }

                    }

                }

            }
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


    protected void grdRoll_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdRoll_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlAdminName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }


    protected void InsertRolls(string PageID,string AdminID)
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
    protected void InserPermission(string Permission, string AdminID)
    {
        try
        {
            AdminModule a = new AdminModule();
            a.Permission = Permission;
            if(Permission=="1")
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
            lblmsg.Text = AdminModule.InsertPermission(a);
        }
        catch
        {
        }
    }
}