using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CYS;
using System.Web.Services;
using System.Web.Script.Services;

public partial class Default1 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
         Session.Abandon();
       //  List<PrizeInfo> prizeList = CalculatePrize(1011, 100);


    }
  [System.Web.Services.WebMethod]
  [System.Web.Script.Services.ScriptMethod]
  public static string ValidateUser(Users user)
    {
    int userId = 0;
    int r = 0;
    string result = "";
    if (user.Password == "" && user.Username == "")
    {
      r = 1;
      result = "User Id & Password is Required";

    }
    else if (user.Username == "")
    {
      r = 2;
      result = "User Id is Required";
    }
    else if (user.Password == "")
    {
      r = 3;
      result = "Password is Required";
    }

    else
    {
      AdminModule a = new AdminModule();
      a.Username = user.Username;
      a.Password = CryptoEngine.Encrypt(user.Password);
      DataTable dt = AdminModule.AdminLogin(a);
      if (dt != null && dt.Rows.Count > 0)
      {
        if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][0].ToString() != null)
        {
          HttpContext.Current.Session["AdminID"] = dt.Rows[0]["AdminID"].ToString();
          HttpContext.Current.Session["Name"] = dt.Rows[0]["Name"].ToString();
          HttpContext.Current.Session["LastloginDate"] = dt.Rows[0]["LastloginDate"].ToString();
          HttpContext.Current.Session["LastloginTime"] = dt.Rows[0]["LastloginTime"].ToString();
          HttpContext.Current.Session["TotalLogin"] = dt.Rows[0]["TotalLogin"].ToString();
          HttpContext.Current.Session["CompanyID"] = DB.FatchColumnName("AdminInfo", "AdminID", dt.Rows[0]["AdminID"].ToString(), "CompanyID", "Status", 'E');
          result = "Success";

        }
        else
        {
          result = "Invalid Login Credentials";

        }
      }
      else
      {
        result = "Invalid Login Credentials";

      }

    }
    string IsValidate = string.Empty;
    return result;
  }
    static List<PrizeInfo> CalculatePrize(int participants, double fees)
    {
        int X = participants;
        double y = (fees * 30 / 100);
        double multiplier = GetMultiplier(participants.ToString(), fees, 2.0);

        if (X <= 0)
        {
            Console.WriteLine("Invalid number of participants");
            return null;
        }
        List<PrizeInfo> prizeList = new List<PrizeInfo>();

        while (X >= 1)
        {
            prizeList.Insert(0, new PrizeInfo { Rank = X, Prize = Convert.ToInt32(y) });
            float p = (float)X / 2;
            if(p<1)
            {
                p = 0;
            }
            X = (int)Math.Ceiling((double)(p));
            y = (int)Math.Round(y * multiplier);
        }

        return prizeList;
     }
    static double GetMultiplier(string participants, double fees, double multiplier1)
    {
        int X = int.Parse(participants);
        double y = Math.Round(fees * 0.3); // equivalent to parseInt(fees * 30 / 100) in JavaScript
        double totalCollection = X * fees;
        double netCollection = totalCollection * 0.7; // for 70%
        double multiplier = multiplier1;
        int rank = X; // initialize rank to participants
        double prize = 0; // initialize prize to 0
        while (X >= 1 && prize <= netCollection)
        {
            float p = (float)X / 2;
            if (p < 1)
            {
                p = 0;
            }
            int k = (int)Math.Ceiling(p);
            X = Convert.ToInt32(k);
            rank = (rank -X);
            prize += y * rank;
            rank = X;
            y = Math.Round(y) * multiplier;
        }

        // Check if prize is greater than netCollection
        if (prize > netCollection)
        {
            multiplier = Math.Round(multiplier - 0.1, 1);
            multiplier = GetMultiplier(participants, fees, multiplier);
        }

        return multiplier;
    }

    public class Users
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
    class PrizeInfo
    {
        public int Rank { get; set; }
        public int Prize { get; set; }
    }

}
