using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_CategoryMaster : System.Web.UI.Page
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
            dt = DB.GetDataTableByProc("sp_Get_category_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdCategory.DataSource = dt;
                grdCategory.DataBind();

            }
            else
            {
                grdCategory.DataSource = null;
                grdCategory.DataBind();
            }


        }
        catch
        {
            grdCategory.DataSource = null;
            grdCategory.DataBind();
        }
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtCategoryName.Text = "";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from category_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and Category_Name='" + txtCategoryName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.category_Name = txtCategoryName.Text;
                    a.admin_id = Session["AdminID"].ToString();
                    
                    lblmsg.Text = AdminModule.InsertCategoryInfo(a);
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
                a.category_Name = txtCategoryName.Text;
                a.admin_id = Session["AdminID"].ToString();
                a.category_id = lblID.Text;

                lblmsg.Text = AdminModule.UpdateCategoryInfo(a);
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
        txtCategoryName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblCategoryID = (Label)grdCategory.Rows[index].FindControl("lblCategoryID");
                AdminModule a = new AdminModule();
                a.category_id = lblCategoryID.Text;
                a.admin_id = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteCategoryInfo(a);
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
                Label lblCategoryID = (Label)grdCategory.Rows[index].FindControl("lblCategoryID");
                Label lblCategoryName = (Label)grdCategory.Rows[index].FindControl("lblCategoryName");

                lblID.Text = lblCategoryID.Text;
                txtCategoryName.Text = lblCategoryName.Text;

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


    protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdCategory.PageIndex = e.NewPageIndex;
        grdCategory.DataBind();

    }
}