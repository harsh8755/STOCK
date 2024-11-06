using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;
using System.Activities.Expressions;

public partial class Page_PageMaster : System.Web.UI.Page
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
            string select = "Select pi.*,mi.Name from PageInfo pi, ModuleInfo mi  Where pi.ModuleID=mi.ModuleID and  pi.Status='E' and mi.Status='E' And pi.AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")";
            if (ddlModuleName.SelectedValue!="0")
            {
                select += " and pi.ModuleID=" + ddlModuleName.SelectedValue;
            }
            select += " order by pi.Priority asc";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdPage.DataSource = dt;
                grdPage.DataBind();
                LinkButton lnkUp = (grdPage.Rows[0].FindControl("lnkUp") as LinkButton);
                LinkButton lnkDown = (grdPage.Rows[grdPage.Rows.Count - 1].FindControl("lnkDown") as LinkButton);
                lnkUp.Enabled = false;
               
                lnkDown.Enabled = false;
            

            }
            else
            {
                grdPage.DataSource = null;
                grdPage.DataBind();
            }


        }
        catch
        {
            grdPage.DataSource = null;
            grdPage.DataBind();
        }
    }

    
    protected void BindDdlModule()
    {
        try
        {
            string select = "Select * from ModuleInfo Where Status='E' And AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")  order by Priority asc";
            DataTable dt = DB.GetDataTable(select);
            ddlModuleName.Items.Clear();
            ddlModuleName.Items.Add(new ListItem("Select Module Name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlModuleName.Items.Add(new ListItem(dr["Name"].ToString(), dr["ModuleID"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        ddlModuleName.SelectedValue = "0";
        Clear();
        BindGrid();
    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from PageInfo Where Status='E' And AdminID=" + Session["AdminID"].ToString() + " and Name='" + txtPageName.Text + "' And ModuleID="+ddlModuleName.SelectedValue;
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblmsg.Text = "Record Already Exist.";

            }
            else
            {
                AdminModule a = new AdminModule();
                a.Name = txtPageName.Text;
                a.ModuleID = ddlModuleName.SelectedValue;
                a.PageLink = txtPageLink.Text;
                a.AdminID = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.InsertPageInfo(a);
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
                a.Name = txtPageName.Text;
                a.ModuleID = ddlModuleName.SelectedValue;
                a.PageLink = txtPageLink.Text;
                a.AdminID = Session["AdminID"].ToString();
                a.PageID = lblID.Text;
                lblmsg.Text = AdminModule.UpdatePageInfo(a);
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
        txtPageName.Text = "";
     
        txtPageLink.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdPage_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdPage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblPageID = (Label)grdPage.Rows[index].FindControl("lblPageID");
            AdminModule a = new AdminModule();
            a.PageID = lblPageID.Text;
            a.AdminID = Session["AdminID"].ToString();
            lblmsg.Text = AdminModule.DeletePageInfo(a);
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
            Label lblPageID = (Label)grdPage.Rows[index].FindControl("lblPageID");
            Label lblPageName = (Label)grdPage.Rows[index].FindControl("lblPageName");
            Label lblModuleID = (Label)grdPage.Rows[index].FindControl("lblModuleID");
            Label lblPageLink = (Label)grdPage.Rows[index].FindControl("lblPageLink");

            lblID.Text = lblPageID.Text;
            txtPageName.Text = lblPageName.Text;
            ddlModuleName.SelectedValue = lblModuleID.Text;
            txtPageLink.Text = lblPageLink.Text;
            cmdSubmit.Visible = false;
            cmdUpdate.Visible = true;
            }
            else
            {
                lblmsg.Text = "You Do not Have Permission for Update Record";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('You Do not Have Permission for Update Record');", true);
            }

        }
        //if (e.CommandName == "Up")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument.ToString());
        //    gvrow = grdPage.Rows[index];
        //    previousRow = grdPage.Rows[index - 1];
        //    int mobilePriority = Convert.ToInt32(grdPage.DataKeys[gvrow.RowIndex].Value.ToString());
        //    int mobileId = Convert.ToInt32(gvrow.Cells[0].Text);
        //    int previousId = Convert.ToInt32(previousRow.Cells[0].Text);

        //    string update = "Update PageInfo set Priority='"+ (mobilePriority - 1) + "' where PageID='"+ mobileId + "'; update pageinfo set Priority='"+ (mobilePriority) + "' where PageID='"+ previousId + "' ";
        //    int i = DB.ExecuteNonQuery(update);
        //    BindGrid();
        //}
        //if (e.CommandName == "Down")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument.ToString());
        //    gvrow = grdPage.Rows[index];
        //    previousRow = grdPage.Rows[index + 1];
        //    int mobilePriority = Convert.ToInt32(grdPage.DataKeys[gvrow.RowIndex].Value.ToString());
        //    int mobileId = Convert.ToInt32(gvrow.Cells[0].Text);
        //    int previousId = Convert.ToInt32(previousRow.Cells[0].Text);
        //    string update = "Update PageInfo set Priority='" + (mobilePriority + 1) + "' where PageID='" + mobileId + "'; update pageinfo set Priority='" + (mobilePriority) + "' where PageID='" + previousId + "' ";
        //    int i = DB.ExecuteNonQuery(update);
        //    BindGrid();
        //}
       
    }


    protected void grdPage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdPage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlModuleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ChangePreference(object sender, EventArgs e)
    {
        if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '2'))
        {
            string commandArgument = (sender as LinkButton).CommandArgument;

        int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
        Label lblPageID = (Label)grdPage.Rows[rowIndex].FindControl("lblPageID");
        Label lblPriority = (Label)grdPage.Rows[rowIndex].FindControl("lblPriority");
        int locationId = Convert.ToInt32(lblPageID.Text);
        int preference = Convert.ToInt32(lblPriority.Text);
        preference = commandArgument == "up" ? preference - 1 : preference + 1;
        this.UpdatePreference(locationId, preference);
        rowIndex = commandArgument == "up" ? rowIndex - 1 : rowIndex + 1;
        Label lblPageID1 = (Label)grdPage.Rows[rowIndex].FindControl("lblPageID");
        Label lblPriority1 = (Label)grdPage.Rows[rowIndex].FindControl("lblPriority");
        locationId = Convert.ToInt32(lblPageID1.Text);
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
        string Update = "Update PageInfo set Priority='"+preference+ "' where Status='E' and PageID="+locationId;
        int i = DB.ExecuteNonQuery(Update);
    }
}