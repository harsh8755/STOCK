using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Module_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    [System.Web.Script.Services.ScriptMethod]
    public static string SubmitAdvertisement()
    {
        try
        {
            HttpPostedFile fuImgPath = HttpContext.Current.Request.Files[0];
            string adName = HttpContext.Current.Request.Form["adName"];
            string adTime = HttpContext.Current.Request.Form["adTime"];
            string adLinkType = HttpContext.Current.Request.Form["adLinkType"];
            string adLinkValue = HttpContext.Current.Request.Form["AdLinkValue"];
            string adURL = "";

            // Rest of your code for file processing and data handling

            return "Success"; // Or whatever response you want to send back
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}