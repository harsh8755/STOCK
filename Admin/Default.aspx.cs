using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null && Session["AdminID"].ToString() != "" && Session["AdminID"].ToString() != null)
            {
                
            }
        }
    }

 
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static string BindMSG()
    {
        try
        {
            string select = "Select * from ContactUsInfo Where Status='E' and ReadStatus='N' Order by CreateDate asc ";
            DataSet ds = new DataSet();
            DataTable dt = DB.GetDataTable(select);
           // string[] arr4 = new string[dt.Rows.Count];
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


}