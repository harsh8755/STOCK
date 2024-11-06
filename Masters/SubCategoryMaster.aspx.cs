using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_SubCategoryMaster : System.Web.UI.Page
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
            dt = DB.GetDataTableByProc("sp_Get_sub_category_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdSubCategory.DataSource = dt;
                grdSubCategory.DataBind();

            }
            else
            {
                grdSubCategory.DataSource = null;
                grdSubCategory.DataBind();
            }


        }
        catch
        {
            grdSubCategory.DataSource = null;
            grdSubCategory.DataBind();
        }
    }


    protected void BindDdlModule()
    {
        try
        {
            string select = "Select category_id,category_Name from category_info Where Status='E' And admin_id in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")  order by category_Name asc";
            DataTable dt = DB.GetDataTable(select);
            ddlCategoryName.Items.Clear();
            ddlCategoryName.Items.Add(new ListItem("Select Category Name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlCategoryName.Items.Add(new ListItem(dr["category_Name"].ToString(), dr["category_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        ddlCategoryName.SelectedValue = "0";
        txtSubCategoryName.Text = "";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from sub_category_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and SubCategory_Name='" + txtSubCategoryName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.category_id = ddlCategoryName.SelectedValue;
                    a.sub_category_Name = txtSubCategoryName.Text;
                    a.admin_id = Session["AdminID"].ToString();

                    lblmsg.Text = AdminModule.InsertSubCategoryInfo(a);
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
                a.sub_category_Name = txtSubCategoryName.Text;
                a.sub_category_id = lblID.Text;
                a.admin_id = Session["AdminID"].ToString();
                a.category_id = lblID.Text;
                lblmsg.Text = AdminModule.UpdateSubCategoryInfo(a);
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
        ddlCategoryName.SelectedValue = "0";
        txtSubCategoryName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdSubCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdSubCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblSubCategoryID = (Label)grdSubCategory.Rows[index].FindControl("lblSubCategoryID");
                AdminModule a = new AdminModule();
                a.sub_category_id = lblSubCategoryID.Text;
                a.admin_id = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteSubCategoryInfo(a);
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
                Label lblCategoryID = (Label)grdSubCategory.Rows[index].FindControl("lblCategoryID");
                Label lblSubCategoryID = (Label)grdSubCategory.Rows[index].FindControl("lblSubCategoryID");
                Label lblSubCategoryName = (Label)grdSubCategory.Rows[index].FindControl("lblSubCategoryName");
                Label lblCategoryName = (Label)grdSubCategory.Rows[index].FindControl("lblCategoryName");
                lblID.Text = lblSubCategoryID.Text;
                ddlCategoryName.SelectedValue = lblCategoryID.Text;
                txtSubCategoryName.Text = lblSubCategoryName.Text;

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


    protected void grdSubCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdSubCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grdSubCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdSubCategory.PageIndex = e.NewPageIndex;
        grdSubCategory.DataBind();

    }
}