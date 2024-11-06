using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;


public partial class Admin_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
        {
            if (Session["AdminID"] != null && Session["AdminID"].ToString() != "" && Session["AdminID"].ToString() != null)
            {
                LoadAdminDetails(Session["AdminID"].ToString());
            }
        }
        }

    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
         {

            if (Session["AdminID"].ToString() != "")
            {
                string select = "Select * from AdminInfo Where AdminID='"+ Session["AdminID"].ToString() + "' and Status='E' and Password='"+CryptoEngine.Encrypt(txtOldPassword.Text)+"'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string update = "update AdminInfo set Password='"+ CryptoEngine.Encrypt(txtConfirmNewPassword.Text)+"' where AdminID="+ Session["AdminID"].ToString();
                    int i = DB.ExecuteNonQuery(update);
                    if(i>0)
                    {
                        clear1();
                        lblmsg.Text = "Password Changed Successfully.";
                    }

                }
                else
                {
                    lblmsg.Text = "Old Password is incorrect.";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('Old Password is incorrect.');", true);
                }
            }

        }
        catch
        {
        }


    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        txtAdminName.Text = "";
        txtEmailID.Text = "";
        txtMobile.Text = "";
        lblPath.Text = "";

    }
    protected void cmdClear_Click1(object sender, EventArgs e)
    {
        clear1();
    }

    protected void clear1()
    {
        txtConfirmNewPassword.Text = "";
        txtNewPassword.Text = "";
        txtOldPassword.Text = "";

    }

    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        try
        {
      
    
      
        AdminModule a = new AdminModule();
        FileUpload fileUploader = FileUpload1;

        int maxFileSize = 5 * 1024 * 1024; // Maximum file size in bytes (e.g., 5MB)
        int fileSize = fileUploader.PostedFile.ContentLength;
        if (fileSize <= maxFileSize)
        {
          if (fileUploader.HasFile)
        {
            ImageConverter1 imageConverter = new ImageConverter1();
            byte[] imageBytes = imageConverter.ConvertFileUploaderToByteArray(fileUploader);

            if (imageBytes != null)
            {
              a.PicBytes = imageBytes;
            }
            else
            {
              a.PicBytes = null;
            }
          }
          else
          {
            a.PicBytes = DB.FatchColumnNameByte("AdminPicInfo", "ImageBytes", "AdminID", Session["AdminID"].ToString(), "Status", 'E'); ; ;

          }

          a.Name = txtAdminName.Text;
          a.EmailID = txtEmailID.Text;
          a.Mobile = txtMobile.Text;
          a.PicURL = lblPath.Text;
          //.PicBytes = imageBytes;
          a.AdminID1 = Session["AdminID"].ToString();
          a.AdminID = Session["AdminID"].ToString();
          lblmsg1.Text = AdminModule.UpdateAdminInfo(a);
          LoadAdminDetails(Session["AdminID"].ToString());
        }
        else
        {
                lblmsg1.Text = "File size exceeds the allowed limit.5 MB";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "ShowWarningMessage", "ShowWarningMessage('File size exceeds the allowed limit.5 MB');", true);
            }
        //clear();
     
        }
        catch
        {
            lblmsg1.Text = "Error";
        }

    }


    protected void LoadAdminDetails(string AdminID)
    {
        try
        {
            string select = "Select * from AdminInfo Where Status='E' And AdminID='"+AdminID+"'";
            DataTable dt = DB.GetDataTable(select);
            if(dt!=null&&dt.Rows.Count>0)
            {
                txtAdminName.Text = dt.Rows[0]["Name"].ToString();
                txtEmailID.Text = dt.Rows[0]["EmailID"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                //lblPath.Text = dt.Rows[0]["PicURL"].ToString();
            }
      MasterPage masterPage = Page.Master;
      if (masterPage != null)
      {
        System.Web.UI.WebControls.Image imgLogo = masterPage.FindControl("ImageAdmin1") as System.Web.UI.WebControls.Image;
        if (imgLogo != null)
        {
          byte[] PicBytes = null;
          PicBytes = DB.FatchColumnNameByte("AdminPicInfo", "ImageBytes", "AdminID",AdminID, "Status", 'E');
          if (PicBytes != null)
          {
            imgLogo.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(PicBytes);
            ;
          }
          else
          {
            imgLogo.ImageUrl = "~/dist/img/user2-160x160.jpg";
          }
        }
      }



    }
    catch
        { }
    }
}
