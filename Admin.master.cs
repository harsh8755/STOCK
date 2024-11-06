using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;
  public partial class Admin : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        if (Session["AdminID"] != null && Session["AdminID"].ToString() != "" && Session["AdminID"].ToString() != null)
        {
                lbladminName1.Text = Session["Name"].ToString();
                //lblAdminName2.Text = Session["Name"].ToString();
                //lblAdminName3.Text = Session["Name"].ToString();
                LblLastLogin.Text = Convert.ToDateTime(Session["LastloginDate"].ToString()).ToString("dd-MMM-yyyy h:mm tt");
                //lblLastLoginTime.Text = Session["LastloginTime"].ToString();
                LblTotalLogin.Text = Session["TotalLogin"].ToString();
                LoadProfile();
          LoadMenu();

          string path = HttpContext.Current.Request.Url.AbsolutePath;
          string[] tokens = path.Split('/');
          if (tokens[2] == "Default.aspx" || tokens[2] == "Search.aspx" || tokens[2] == "ChangePassword.aspx")
          {
          }
          else
          {

            if (Request["PageID"] != null && Request["PageID"].ToString() != "")
            {
              try
              {
                if (CheckRoll(CryptoEngine.Decrypt(Request["PageID"].ToString()), Session["AdminID"].ToString()))
                {
                }
                else
                {
                  Response.Redirect("../Default.aspx");
                }
              }
              catch
              {
                Response.Redirect("../Default.aspx");
              }

            }
            else
            {
              Response.Redirect("../Default.aspx");
            }
          }
        }
        else
        {

          Response.Redirect("../Default.aspx");
        }

      }

    }
    protected void LoadMenu()
    {
      try
      {
        string str = "";
        str = str + "<li class='nav-item menu-open'>";
        str = str + " <a href='#' class='nav-link active'>";
        str = str + " <i class='nav-icon fas fa-tachometer-alt'></i>";
        str = str + "<p>";
        str = str + " Dashboard";
        str = str + "    <i class='right fas fa-angle-left'></i>";
        str = str + "   </p>";
        str = str + " </a>";
        str = str + "  <ul class='nav nav-treeview'>";
        str = str + "   <li class='nav-item'>";
        str = str + "   <a href='../Admin/Default.aspx' class='nav-link'>";
        str = str + "     <i class='far fa-circle nav-icon'></i>";
        str = str + "    <p>Dashboard</p>";
        str = str + "   </a>";
        str = str + " </li>   ";
        str = str + " </ul>";
        str = str + " </li>";
        string select = "Select * , (select count(*) from PageInfo where ModuleID=ModuleInfo.ModuleID and PageInfo.Status='E' and PageID in (Select PageID From RollInfo Where Status='E' and AdminId="+ Session["AdminID"].ToString() + " OR PageID=3))  as Pages  from ModuleInfo Where Status='E' and ModuleID in (Select ModuleID from PageInfo where Status='E'  and (PageID in (Select PageID from RollInfo where Status='E' and AdminID=" + Session["AdminID"].ToString() + ") ) OR PageID=3) order by Priority Asc";
        DataTable dt = DB.GetDataTable(select);
        if (dt != null && dt.Rows.Count > 0)
        {
          foreach (DataRow dr in dt.Rows)
          {
            str = str + "<li class='nav-item'>";
            str = str + "<a href='#' class='nav-link'>";
            str = str + "<i class='nav-icon fas fa-th'></i><p>" + dr["Name"].ToString() + "<i class='fas fa-angle-left right'></i><span class='badge badge-info right'>" + dr["Pages"].ToString() + "</span></p></a>";
            str = str + "<ul class='nav nav-treeview'>";
            string select1 = "Select * from PageInfo where Status='E' and ModuleID='" + dr["ModuleID"].ToString() + "' and (PageID in (Select PageID from RollInfo where Status='E' and AdminID='" + Session["AdminID"].ToString() + "') OR  PageID=3) order by Priority asc";
            DataTable dt1 = DB.GetDataTable(select1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
              foreach (DataRow dr1 in dt1.Rows)
              {
                //if (dr["Name"].ToString() == "Settings")
                //{
                //  str = str + "<li class='nav-item'><a href = '../Admin/ChangePassword.aspx' ><i class='fa fa-circle-o'></i>" + dr1["PageName"].ToString() + "</a></li>";
                // // a1.HRef = "~/Admin/ChangePassword.aspx";
                //}
                //else
                //{
                string pagelink = dr1["PageLink"].ToString() + "?PageID=" + CryptoEngine.Encrypt(dr1["PageID"].ToString());
                str = str + "<li class='nav-item'><a href=' " + pagelink + "' class='nav-link'><i class='far fa-circle nav-icon'></i><p>" + dr1["PageName"].ToString() + "</p></a></li>";
                //  if (dr1["PageName"].ToString() == "Update Profile")
                //  {
                //    string output = pagelink.Replace("../", "~/");
                //    //a1.HRef = "../Admin/ChangePassword.aspx";
                //  }

                //}
              }
            }
            str = str + "</ul>";
          }
        }

        //str = str + "<li class='nav-item'>";
        //str = str + " <a href='../logout.aspx' class='nav-link active'>";
        //str = str + " <i class='nav-icon fas fa-copy'></i>";
        //str = str + "<p>";
        //str = str + " LOG OUT";
        //str = str + "    <i class='right fas fa-angle-left'></i>";
        //str = str + "   </p>";
        //str = str + " </a>";
        //str = str + " </li>";
        //str = str + "</li>";
       // str = str + " <br /><br /><br /><br /><a style='Font-Size:12px;' ><i class='nav-icon far fa-circle text-info'></i> Last Login : " + Convert.ToDateTime(Session["LastloginDate"].ToString()).ToString("dd-MMM-yyyy h:mm tt") + "</a>";
       // str = str + " <br /><a style='Font-Size:12px;'><i class='nav-icon far fa-circle text-info'></i> Total Login : " + Session["TotalLogin"].ToString() + "</a>";
        menuitem.InnerHtml = str;

      }
      catch
      {

      }
    }


    protected void LoadProfile()
    {
      try
      {
        byte[] PicBytes = null;
        PicBytes = DB.FatchColumnNameByte("AdminPicInfo", "ImageBytes", "AdminID", Session["AdminID"].ToString(), "Status", 'E');
        if (PicBytes != null)
        {
          ImageAdmin1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(PicBytes);
          ;
        }
        else
        {
          ImageAdmin1.ImageUrl = "~/dist/img/user2-160x160.jpg";
        }

      }
      catch (Exception ex)
      {
      }
    }

    protected bool CheckRoll(string PageID, string AdminID)
    {
      try
      {
        string path = ".." + HttpContext.Current.Request.Url.AbsolutePath;
        string Select = "Select * from RollInfo Where AdminID='" + AdminID + "' And PageID in (Select PageID from PageInfo Where PageID='" + PageID + "' and Status='E' And PageLink='" + path + "' ) And Status='E'";
        DataTable dt = DB.GetDataTable(Select);
        if (dt != null && dt.Rows.Count > 0)
        {
          if (dt.Rows[0]["RollID"].ToString() != "")
          {
            return true;
          }
          else
          { return false; }
        }
        else
        {
          return false;
        }
      }
      catch
      {
        return false;
      }
    }
    
}

