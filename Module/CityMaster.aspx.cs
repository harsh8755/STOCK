using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;

public partial class State_CityMaster : System.Web.UI.Page
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
            string select = "Select pi.*,mi.Name as Sname from CityInfo pi, StateInfo mi  Where pi.StateID=mi.StateID and  pi.Status='E' and mi.Status='E' And pi.AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")";
            if (ddlStateName.SelectedValue != "0")
            {
                select += " and pi.StateID=" + ddlStateName.SelectedValue;
            }
            select += " order by pi.Name asc";
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                grdCity.DataSource = dt;
                grdCity.DataBind();

            }
            else
            {
                grdCity.DataSource = null;
                grdCity.DataBind();
            }


        }
        catch
        {
            grdCity.DataSource = null;
            grdCity.DataBind();
        }
    }


    protected void BindDdlModule()
    {
        try
        {
            string select = "Select * from StateInfo Where Status='E' And AdminID in (Select AdminID from AdminInfo Where Status='E' and CompanyID=" + Session["CompanyID"].ToString() + ")  order by name asc";
            DataTable dt = DB.GetDataTable(select);
            ddlStateName.Items.Clear();
            ddlStateName.Items.Add(new ListItem("Select State Name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlStateName.Items.Add(new ListItem(dr["Name"].ToString(), dr["StateID"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        ddlStateName.SelectedValue = "0";
        Clear();
        BindGrid();

    }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from CityInfo Where Status='E' And AdminID=" + Session["AdminID"].ToString() + " and Name='" + txtCityName.Text + "' And StateID=" + ddlStateName.SelectedValue;
            DataTable dt = DB.GetDataTable(select);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblmsg.Text = "Record Already Exist.";

            }
            else
            {
                AdminModule a = new AdminModule();
                a.Name = txtCityName.Text;
                a.StateID = ddlStateName.SelectedValue;
               
                a.AdminID = Session["AdminID"].ToString();
                lblmsg.Text = AdminModule.InsertCityInfo(a);
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
                a.Name = txtCityName.Text;
                a.StateID = ddlStateName.SelectedValue;

                a.AdminID = Session["AdminID"].ToString();
                a.CityID = lblID.Text;
                lblmsg.Text = AdminModule.UpdateCityInfo(a);
                BindGrid();
                Clear();
            }
            else {
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
        txtCityName.Text = "";
   
 
        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdCity_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblCityID = (Label)grdCity.Rows[index].FindControl("lblCityID");
            AdminModule a = new AdminModule();
            a.CityID = lblCityID.Text;
            a.AdminID = Session["AdminID"].ToString();
            lblmsg.Text = AdminModule.DeleteCityInfo(a);
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
            Label lblCityID = (Label)grdCity.Rows[index].FindControl("lblCityID");
            Label lblCityName = (Label)grdCity.Rows[index].FindControl("lblCityName");
            Label lblStateID = (Label)grdCity.Rows[index].FindControl("lblStateID");
          
            lblID.Text = lblCityID.Text;
            txtCityName.Text = lblCityName.Text;
            ddlStateName.SelectedValue = lblStateID.Text;
          
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


    protected void grdCity_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdCity_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}