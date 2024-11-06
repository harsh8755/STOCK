using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;

public partial class State_StateMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {
                //ScriptManager.RegisterStartupScript(Page, GetType(), "ShowWarningMessage", "<script>Alert('Helos');</script>", false);
             
                BindGrid();
            }

        }

    }



    protected void BindGrid()
    {
        try
        {
            string select = "Select * from StateInfo Where Status='E' And AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ") order by name asc";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdState.DataSource = dt;
                grdState.DataBind();

            }
            else
            {
                grdState.DataSource = null;
                grdState.DataBind();
            }


        }
        catch
        {
            grdState.DataSource = null;
            grdState.DataBind();
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
                string select = "Select * from StateInfo Where Status='E' And AdminID=" + Session["AdminID"].ToString() + " and Name='" + txtStateName.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    AdminModule a = new AdminModule();
                    a.Name = txtStateName.Text;
                    a.AdminID = Session["AdminID"].ToString();
                    lblmsg.Text = AdminModule.InsertStateInfo(a);
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
                a.Name = txtStateName.Text;
                a.AdminID = Session["AdminID"].ToString();
                a.StateID = lblID.Text;
                lblmsg.Text = AdminModule.UpdateStateInfo(a);
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
        txtStateName.Text = "";
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdState_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblStateID = (Label)grdState.Rows[index].FindControl("lblStateID");
                AdminModule a = new AdminModule();
                a.StateID = lblStateID.Text;
                a.AdminID = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.DeleteStateInfo(a);
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
            Label lblStateID = (Label)grdState.Rows[index].FindControl("lblStateID");
            Label lblStateName = (Label)grdState.Rows[index].FindControl("lblStateName");
            lblID.Text = lblStateID.Text;
            txtStateName.Text = lblStateName.Text;
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


    protected void grdState_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdState_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}