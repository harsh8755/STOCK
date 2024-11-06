using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MessageView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null && Session["AdminID"].ToString() != "" && Session["AdminID"].ToString() != null)
            {
               
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
        }
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static string BindViewMSG(string ContactUSID,string ReadStatus,string textmsg)
    {
        try
        {
            string select = "Select * from ContactUsInfo Where Status='E'";
            if (ContactUSID != "" && ContactUSID != "null" && ContactUSID != null)
            {
                select = select + "  and ContactUSID='"+ContactUSID+"'";
            }
            if (ReadStatus != "" && ReadStatus != "null" && ReadStatus != null)
            {
                select = select + "  and ReadStatus='" + ReadStatus + "'";
            }
            if (textmsg != "" && textmsg != "null" && textmsg != null)
            {
                select = select + "  and (Name LIKE '%"+ textmsg + "%' OR Email LIKE '%"+ textmsg + "%' OR Mobile LIKE '%"+ textmsg + "%' OR Message LIKE '%"+ textmsg + "%')";
            }
            select = select + "  Order by ReadStatus asc,CreateDate asc";
            DataSet ds = new DataSet();
            DataTable dt = DB.GetDataTable(select);
            string[] arr4 = new string[dt.Rows.Count];
            if (dt != null && dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt);
            }

            return ds.GetXml();

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static string UnreadMsg(string ContactUSID1,string Reply,string EmailID)
    {
        try
        {
            string result = "";
            AdminModule a = new AdminModule();
            a.AdminID = HttpContext.Current.Session["AdminID"].ToString();
            a.ContactUSID = ContactUSID1;
            a.Reply = Reply;
            result = AdminModule.UpdateMessageReply(a);
           // SentEmail.SendingMail(EmailID, "Reply of your Enquire With www.cashyourskill.com", Reply);
            return result;

        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
