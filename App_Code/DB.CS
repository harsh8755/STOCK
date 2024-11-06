using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// This CommonData Name have DB Class
/// </summary>
namespace CYS
{
    public partial class DB
    {




        #region connection string
        public static string EncryptWeb(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //// Get the key from config file
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);

            string key = "Hi";
            // string key = System.Configuration.ConfigurationManager.ConnectionStrings["COM"].ConnectionString;
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string DecryptWeb(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            ////Get your key from config file to open the lock!
            //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //string key = System.Configuration.ConfigurationManager.ConnectionStrings["COM"].ConnectionString;
            string key = "Hi";
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        /*-----Function For Return Connection ------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection();
             string key = System.Configuration.ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            cn.ConnectionString = key;
            return cn;

           
        }

        /*-----Function For Close Connection -------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static void CloseConnection()
        {
            SqlConnection cn = GetConnection();
            if (cn.State == ConnectionState.Open)
                cn.Close();
        }

        /*-----Function For Execute Non Query------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int ExecuteNonQuery(string query)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                i = cmd.ExecuteNonQuery();
              //  cn.Close();

                cn.Close();

            }
            return i;
        }

        public static int ExecuteScalar(string query)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                i = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            return i;
        }

        /*-----Function For Open Connection --------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static void OpenConnection()
        {
            SqlConnection cn = GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cn.Close();
        }

        #region stored proc for get data
        //public static SqlParameter[] GetSqlParameters(SqlParameter[] prams) {
        //    SqlParameter[] param ={
        //                         new SqlParameter("@PlanStatus","E"),
        //                         new SqlParameter("@AdminId",12)

        //                    };
        //    return prams;
        //}
        public static DataSet GetDataSetByProc(string DatabaseProcedureName, SqlParameter[] SParameters)
        {
            using (SqlConnection cn = DB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                SqlParameter SParameter = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                if (cmd.Parameters.Count > 0)
                    cmd.Parameters.Clear();
                foreach (SqlParameter parameter in SParameters)
                {
                    SParameter = parameter;
                    cmd.Parameters.Add(SParameter);
                }
                // DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                CloseConnection();
                return ds;
                //using (DataSet ds = new DataSet())
                //{
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);
                //    CloseConnection();
                //    return ds;
                //}
            }
        }

        public static DataTable GetDataByProc(string DatabaseProcedureName, SqlParameter[] SParameters)
        {
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                SqlParameter SParameter = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                if (cmd.Parameters.Count > 0)
                    cmd.Parameters.Clear();
                foreach (SqlParameter parameter in SParameters)
                {
                    SParameter = parameter;
                    cmd.Parameters.Add(SParameter);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                CloseConnection();
                return dt;
            }
        }
        #endregion
        
        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }

        }

        #region return dataset by proc
      
        public static int ExecuteProcedureBySingleParam(string DatabaseProcedureName, string ColumnName1, string ColumnValue1)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                i = cmd.ExecuteNonQuery();
                cn.Close();
                return i;
            }
        }

        //public static int ExecuteProcedureBySingleParam_1(string DatabaseProcedureName, SqlParameter SParameters)
        //{
        //    int i = 0;
        //    using (SqlConnection cn = GetConnection())
        //    {
        //        SqlCommand command = new SqlCommand(DatabaseProcedureName, cn);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(SParameters);
        //         i = command.ExecuteNonQuery();
        //        cn.Close();
        //    }
        //    return i;
        //}

        public static int ExecuteProcedureByParam(string DatabaseProcedureName, SqlParameter[] SParameters)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                SqlParameter SParameter = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                if (cmd.Parameters.Count > 0)
                    cmd.Parameters.Clear();
                foreach (SqlParameter parameter in SParameters)
                {
                    SParameter = parameter;
                    cmd.Parameters.Add(SParameter);
                }
                i = cmd.ExecuteNonQuery();
                cn.Close();
            }
            return i;
        }
        #endregion

        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName, string ColumnName1, string ColumnValue1)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }

        }

        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                cmd.Parameters.AddWithValue(ColumnName2, ColumnValue2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }

        }

        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                cmd.Parameters.AddWithValue(ColumnName2, ColumnValue2);
                cmd.Parameters.AddWithValue(ColumnName3, ColumnValue3);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }
        }

        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3, string ColumnName4, string ColumnValue4)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                cmd.Parameters.AddWithValue(ColumnName2, ColumnValue2);
                cmd.Parameters.AddWithValue(ColumnName3, ColumnValue3);
                cmd.Parameters.AddWithValue(ColumnName4, ColumnValue4);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }
        }

        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3, string ColumnName4, string ColumnValue4, string ColumnName5, string ColumnValue5)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                cmd.Parameters.AddWithValue(ColumnName2, ColumnValue2);
                cmd.Parameters.AddWithValue(ColumnName3, ColumnValue3);
                cmd.Parameters.AddWithValue(ColumnName4, ColumnValue4);
                cmd.Parameters.AddWithValue(ColumnName5, ColumnValue5);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }

        }

        /*-----Function For Execute Query By Procedure----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable ExecuteQueryByProc(string DatabaseProcedureName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3, string ColumnName4, string ColumnValue4, string ColumnName5, string ColumnValue5, string ColumnName6, string ColumnValue6)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                cmd.Parameters.AddWithValue(ColumnName2, ColumnValue2);
                cmd.Parameters.AddWithValue(ColumnName3, ColumnValue3);
                cmd.Parameters.AddWithValue(ColumnName4, ColumnValue4);
                cmd.Parameters.AddWithValue(ColumnName5, ColumnValue5);
                cmd.Parameters.AddWithValue(ColumnName6, ColumnValue6);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
                return dt;
            }

        }

        /*-----Function For Execute Non Query By Procedure------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int ExecuteNonQueryByProc(string DatabaseProcedureName, SqlParameter[] NewParameters)
        {
            int i = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                SqlParameter SParameter = new SqlParameter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = DatabaseProcedureName;
                if (cmd.Parameters.Count > 0)
                    cmd.Parameters.Clear();
                foreach (SqlParameter LoopVarParam in NewParameters)
                {
                    SParameter = LoopVarParam;
                    cmd.Parameters.Add(SParameter);
                }
                i = cmd.ExecuteNonQuery();
                cn.Close();
            }
            return i;
        }
        
        /*-----Function For Execute Reader ---------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static SqlDataReader ExecuteReader(string Query)
        {
            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection cn = GetConnection())
            {
                cn.Open();
                cmd.CommandText = Query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
                cn.Close();
            }
           
            return dr;
        }

        /*-----Function For Return Data Table ------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDataTable(string Query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            using (SqlConnection cn = GetConnection())
            {
                try
                {
                    da = new SqlDataAdapter(Query, cn);
                    da.Fill(dt);
                }
                catch
                {
                    dt = null;
                }
                cn.Close();
                return dt;
            }
        }
        public static DataTable GetDataTableByProc(string procedureName, string[,] Params)
        {
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    DataTable dt = new DataTable();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    for (int i = 0; i < Params.GetLength(0); i++)
                    {
                        cmd.Parameters.AddWithValue(Params[i, 0], Params[i, 1]);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn.Close();
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetDataTableByProc(string procedureName)
        {
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    DataTable dt = new DataTable();
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn.Close();
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }


        /*-----Function For Return Data Table ------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDataTableProcedure(string Procedure)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection cn = GetConnection())
            {
                try
                {
                    cmd = new SqlCommand(Procedure, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                }
                catch
                {
                    dt = null;
                }
                cn.Close();
                return dt;
            }
        }

        /*-----Function For Return Data Table ------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDataTableProcedure(string Procedure, string ColumnName1, string ColumnValue1)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection cn = GetConnection())
            {
                try
                {
                    cmd = new SqlCommand(Procedure, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                }
                catch
                {
                    dt = null;
                }
                cn.Close();
                return dt;
            }
        }

        /*-----Function For Return Data Table ------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDataTableProcedure(string Procedure, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            SqlDataAdapter da = new SqlDataAdapter();
            using (SqlConnection cn = GetConnection())
            {
                try
                {
                    cmd = new SqlCommand(Procedure, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ColumnName1, ColumnValue1);
                    cmd.Parameters.AddWithValue(ColumnName2, ColumnValue2);
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                }
                catch(Exception ex)
                {
                    dt = null;
                }
                cn.Close();
                return dt;
            }
        }
        /*-----Function For Encryption -------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string Encrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i - 2;
                _result += (char)i;
            }
            return _result;
        }

        /*-----Function For Decryption -------------------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string Decrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i + 2;
                _result += (char)i;
            }
            return _result;
        }
        /*-----Function For Return Data Table with 4 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDropdownStatus(string TableName, string TableStatus, char StatusValue, string ColumnOrderby)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + TableStatus + "='" + StatusValue + "' order by case when " + ColumnOrderby + "='Other' then 2 else 1 end , " + ColumnOrderby + "");
            return dt;
        }
        /*-----Function For Return Data Table with 6 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDropdownStatus(string TableName, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2, string ColumnOrderby)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + TableStatus1 + "='" + StatusValue1 + "' AND " + TableStatus2 + "='" + StatusValue2 + "' order by case when " + ColumnOrderby + "='Other' then 2 else 1 end , " + ColumnOrderby + "");
            return dt;
        }
        /*-----Function For Return Data Table with 6 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDropdownStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus, char StatusValue, string ColumnOrderby)
        {
           
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + ColumnName + "='" + ColumnValue + "' AND " + TableStatus + "='" + StatusValue + "' order by case when " + ColumnOrderby + "='Other' then 2 else 1 end," + ColumnOrderby + "");
            return dt;
        }

        /*-----Function For Return Data Table with 8 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDropdownStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2, string ColumnOrderby)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + ColumnName + "='" + ColumnValue + "' AND " + TableStatus1 + "='" + StatusValue1 + "' AND " + TableStatus2 + "='" + StatusValue2 + "' order by case when " + ColumnOrderby + "='Other' then 2 else 1 end," + ColumnOrderby + "");
            return dt;
        }

        /*-----Function For Return Data Table with 8 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetDropdownStatus(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, char StatusValue1, string ColumnOrderby)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + TableStatus1 + "='" + StatusValue1 + "' order by case when " + ColumnOrderby + "='Other' then 2 else 1 end," + ColumnOrderby + "");
            return dt;
        }

        /*-----Function For Return Data Table with 3 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + TableStatus + "=" + "'" + StatusValue + "'");
            return dt;
        }

        /*-----Function For Return Data Table with 5 Argument---------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 4 Argument with Order By-------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string TableStatus, char StatusValue, string OderByColumn)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " ASC");
            return dt;
        }

        /*-----Function For Return Data Table with 5 Argument --------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName + "=" + "'" + ColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }
        /*-----Function For Return Data Table with 7 Argument --------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + ColumnName + "=" + "'" + ColumnValue + "'" + " " + "AND" + " " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + "AND" + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 7 Argument with Order BY------------8-----------the original function is above and this one specifically to restrict the limited ledger viewing--------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus, char StatusValue, string OderByColumn, string adminid, int flg ) // flg just to avoid ovewrloading by kit
        {
            string sql = "select * from " + TableName + " where " + ColumnName + "=" + "'" + ColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + "   and  (  adminid=   " + adminid + "  or  1="+ adminid + ") ORDER BY " + OderByColumn + " ASC";
            DataTable dt = DB.GetDataTable(sql);
            return dt; 
        }

        /*-----Function For Return Data Table with 6 Argument with Order BY------------8-------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + ColumnName + "=" + "'" + ColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + "   ORDER BY " + OderByColumn + " ASC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 7 Argument with Order BY-------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName, string ColumnValue, string TableStatus, char StatusValue, string OderByColumn,string OderByValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName + "=" + "'" + ColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "' ORDER BY " + OderByColumn + " "+OderByValue+"";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 5 Argument with Like-----------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataByLike(string TableName, string ColumnName1, string ColumnValue1, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + " like " + "'" + ColumnValue1 + "%'" + " " + " AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 5 Argument with Between----------- actually 6---------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataByBetween(string TableName, string ColumnName1, string ColumnValue11, string ColumnValue12, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + " Between " + "'" + ColumnValue11 + "'" + "  AND " + "'" + ColumnValue12 + "'" + " AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 7 Argument --------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + "=" + "'" + ColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 7 Argument with Order By-------8------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + "=" + "'" + ColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " ASC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 7 Argument with Like-----------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataByLike(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + " like " + "'" + ColumnValue1 + "%'" + " " + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 7 Argument with Between--------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataByBetween(string TableName, string ColumnName1, string ColumnValue11, string ColumnValue12, string ColumnName2, string ColumnValue21, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + " Between " + "'" + ColumnValue11 + "'" + "  AND " + "'" + ColumnValue12 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue21 + "'" + " " + " AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 9 Argument --------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + "=" + "'" + ColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 9 Argument with Order By-------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataStatus(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + "=" + "'" + ColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'" + " ORDER BY " + OderByColumn + " ASC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with 9 Argument with Like-----------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataByLike(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + " like " + "'" + ColumnValue1 + "%'" + " " + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }
        
        /*-----Function For Return Data Table with 9 Argument with Between--------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataByBetween(string TableName, string ColumnName1, string ColumnValue11, string ColumnValue12, string ColumnName2, string ColumnValue21, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + ColumnName1 + " Between " + "'" + ColumnValue11 + "'" + "  AND " + "'" + ColumnValue12 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue21 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*------------Function For Checking Duplicacy with 3 Argument-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable CheckForDuplicacy(string TableName, string ColumnName1, string ColumnValue1, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            return dt;
        }

        /*------------Function For Checking Duplicacy with 5 Argument-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable CheckForDuplicacy(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            return dt;
        }

        /*------------Function For Checking Duplicacy with 7 Argument-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable CheckForDuplicacy(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select * from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + ColumnName3 + "='" + ColumnValue3 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            return dt;
        }

        /*------------Function For Checking Permission----------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static bool CheckForPermission(string TableName, string ColumnName, string ColumnValue, string PermissionName, char PermissionValue)
        {
            DataTable dt1 = DB.GetDataTable("select * from " + TableName + " where " + ColumnName + "=" + "'" + ColumnValue + "'" + " " + "AND" + " " + PermissionName + "=" + "'" + PermissionValue + "'");
            if (dt1 != null && dt1.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /*------------Function For Checking Roll----------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static bool CheckForRoll(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnStatus, char StatusValue)
        {
            DataTable dt1 = DB.GetDataTable("select * from " + TableName + " where " + ColumnName1 + "=" + "'" + ColumnValue1 + "'" + " " + "AND" + " " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + ColumnStatus + "=" + "'" + StatusValue + "'");
            if (dt1 != null && dt1.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /*------------Function For Checking Roll----------------------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static bool CheckForRoll(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3, string ColumnStatus, char StatusValue)
        {
            DataTable dt1 = DB.GetDataTable("select * from " + TableName + " where " + ColumnName1 + "=" + "'" + ColumnValue1 + "'" + " " + "AND" + " " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + ColumnName3 + "=" + "'" + ColumnValue3 + "'" + " " + "AND" + " " + ColumnStatus + "=" + "'" + StatusValue + "'");
            if (dt1 != null && dt1.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /*------------Function For Fatch Top Record Integer Value-----------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchTopRecord(string TableName, string ReturnColumn, string TableStatus, char StatusValue)
        {
            try
            {
                DataTable dt = DB.GetDataTable("SELECT TOP 1 " + ReturnColumn + " FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
                if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    return 0;
                else
                    return Convert.ToInt32(dt.Rows[0][0].ToString());

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /*------------Function For Fatch MIN Record Integer Value-----------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchMinRecordInt(string TableName, string ReturnColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("SELECT MIN (" + ReturnColumn + ") FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }
        /*------------Function For Fatch MIN Record Double Value------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static double FatchMinRecordDouble(string TableName, string ReturnColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("SELECT MIN (" + ReturnColumn + ") FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0.00;
            else
                return Convert.ToDouble(dt.Rows[0][0].ToString());

        }
    
        /*------------Function For Fatch MAX Record Integer Value-----------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchMaxRecord(string TableName, string ReturnColumn)
        {
            DataTable dt = DB.GetDataTable("SELECT MAX (" + ReturnColumn + ") FROM " + TableName);
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }
        
        public static int FatchMaxRecord(string TableName, string ReturnColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("SELECT MAX (" + ReturnColumn + ") FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }
        /*------------Function For Fatch MAX Record Double Value------------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static double FatchMaxRecordDouble(string TableName, string ReturnColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("SELECT MAX (" + ReturnColumn + ") FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0.00;
            else
                return Convert.ToDouble(dt.Rows[0][0].ToString());

        }
        /*------------Function For Fatching Column Name String Value-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string FatchColumnNameString(string TableName, string ColumnName1, string ColumnValue1, string ReturnColumn)
        {
            try
            {
                string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "'";
                DataTable dt = DB.GetDataTable(sql);
                if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    return "0";
                else
                    return dt.Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                return "None";
            }
        }

        /*------------Function For Fatching Column Name String Value-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string FatchColumnNameString(string TableName, string ColumnName1, string ColumnValue1, string ReturnColumn, string TableStatus, char StatusValue)
        {
            try
            {
                string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
                DataTable dt = DB.GetDataTable(sql);
                if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    return "0";
                else
                    return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        /*------------Function For Fatching Column Name String Value-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string FatchColumnNameString(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            try
            {
                string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
                DataTable dt = DB.GetDataTable(sql);
                if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    return "0";
                else
                    return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        /*------------Function For Fatching Column Name String Value-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string FatchColumnNameString(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string ColumnName3, string ColumnValue3, string TableStatus, char StatusValue)
        {
            try
            {
                string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + ColumnName3 + "='" + ColumnValue3 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
                DataTable dt = DB.GetDataTable(sql);
                if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    return "0";
                else
                    return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        /*------------Function For Fatching Column Name String Value-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static string FatchColumnNameString(string TableName, string ColumnName1, string ColumnValue1, string ReturnColumn, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + " " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + "' AND " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return "0";
            else
                return dt.Rows[0][0].ToString();
        }

        /*------------Function For Fatching Column Name Integer Value-------------------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchColumnName(string TableName, string ColumnName1, string ColumnValue1, string ReturnColumn, string TableStatus, char StatusValue)
        {
            string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        /*------------Function For Fatching SUM of Column Integer Value with 5 Argument-------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchColumnSum(string TableName, string ColumnName1, string ColumnValue1, string SumColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select " + " SUM " + " ( " + SumColumn + " ) " + " from " + TableName + " where  "+ ColumnName1 + "<'" + ColumnValue1 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        /*------------Function For Fatching SUM of Column decimal Value with 5 Argument-------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static decimal FatchColumnDecimalSum(string TableName, string ColumnName1, string ColumnValue1, string SumColumn, string TableStatus, char StatusValue)
        {
            
            DataTable dt = DB.GetDataTable("select " + " SUM " + " ( " + SumColumn + " ) " + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return decimal.Parse(dt.Rows[0][0].ToString());
        }

        /*------------Function For Fatching SUM of Column Integer Value with 7 Argument-------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchColumnSum(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string SumColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select " + " SUM " + " ( " + SumColumn + " ) " + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "<'" + ColumnValue2 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        /*------------Function For Fatching SUM of Column decimal Value with 7 Argument-------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static decimal FatchColumnDecimalSum(string TableName, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string SumColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("select " + " SUM " + " ( " + SumColumn + " ) " + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return decimal.Parse(dt.Rows[0][0].ToString());
        }     
        
        /*-----Function For Return Data Table with Greater Case with 5 Argument---------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreater(string TableName, string GColumnName, string GColumnValue, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + GColumnName + ">" + "'" + GColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Case with 5 Argument with Order BY-------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreater(string TableName, string GColumnName, string GColumnValue, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + GColumnName + ">" + "'" + GColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }


        /*-----Function For Return Data Table with Greater Case with 7 Argument --------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreater(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Case with 7 Argument with Order By-------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreater(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Case with 9 Argument --------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreater(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Case with 9 Argument with Order By-------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreater(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Equal Case with 5 Argument---------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreaterEqual(string TableName, string GColumnName, string GColumnValue, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + GColumnName + ">=" + "'" + GColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Equal Case with 5 Argument with Order BY-------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreaterEqual(string TableName, string GColumnName, string GColumnValue, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + GColumnName + ">=" + "'" + GColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Equal Case with 7 Argument --------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreaterEqual(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">=" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Equal Case with 7 Argument with Order By-------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreaterEqual(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">=" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Equal Case with 9 Argument --------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreaterEqual(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">=" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Greater Equal Case with 9 Argument with Order By-------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataGreaterEqual(string TableName, string GColumnName1, string GColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + GColumnName1 + ">=" + "'" + GColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Less Equal Case with 5 Argument------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataLessEqual(string TableName, string LColumnName, string LColumnValue, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + LColumnName + "<=" + "'" + LColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Less Equal Case with 5 Argument with Order BY----------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataLessEqual(string TableName, string LColumnName, string LColumnValue, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + LColumnName + "<=" + "'" + LColumnValue + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }
        
        /*-----Function For Return Data Table with Less Equal Case with 7 Argument -----------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataLessEqual(string TableName, string LColumnName1, string LColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue)
        {
            string sql = "select * from " + TableName + " where " + LColumnName1 + "<=" + "'" + LColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Less Equal Case with 7 Argument with Order By----------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataLessEqual(string TableName, string LColumnName1, string LColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus, char StatusValue, string OderByColumn)
        {
            string sql = "select * from " + TableName + " where " + LColumnName1 + "<=" + "'" + LColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + "AND" + " " + TableStatus + "=" + "'" + StatusValue + "'" + " ORDER BY " + OderByColumn + " DESC";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }

        /*-----Function For Return Data Table with Less Equal Case with 9 Argument -----------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static DataTable GetTableDataLessEqual(string TableName, string LColumnName1, string LColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, string StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "select * from " + TableName + " where " + LColumnName1 + "<=" + "'" + LColumnValue1 + "'" + " AND " + ColumnName2 + "=" + "'" + ColumnValue2 + "'" + " " + " AND " + TableStatus1 + "=" + "'" + StatusValue1 + "'" + " AND " + " " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            return dt;
        }



        public static int FatchCountRecord(string TableName, string ReturnColumn)
        {
            DataTable dt = DB.GetDataTable("SELECT COUNT (" + ReturnColumn + ") FROM " + TableName);
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }
        /*------------Function For Fatch Count Record Integer Value 4 Argument----------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchCountRecord(string TableName, string ReturnColumn, string TableStatus, char StatusValue)
        {
            DataTable dt = DB.GetDataTable("SELECT COUNT (" + ReturnColumn + ") FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }

        public static int FatchCountRecord(string TableName, string ReturnColumn, string TableStatus, string StatusValue)
        {
            DataTable dt = DB.GetDataTable("SELECT COUNT (" + ReturnColumn + ") FROM " + TableName + " WHERE " + " " + TableStatus + "=" + "'" + StatusValue + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }
        /*------------Function For Fatch Count Record Integer Value 6 Argument----------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchCountRecord(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1, string TableStatus1, char StatusValue1)
        {
            
            DataTable dt = DB.GetDataTable("SELECT COUNT (" + ReturnColumn + ") FROM " + TableName + " WHERE " + ColumnName1 + "='" + ColumnValue1 + "' AND "  + TableStatus1 + "=" + "'" + StatusValue1 + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }

        /*------------Function For Fatch Count Record Integer Value 8 Argument----------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchCountRecord(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, char StatusValue1)
        {
            DataTable dt = DB.GetDataTable("SELECT COUNT (" + ReturnColumn + ") FROM " + TableName + " WHERE " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " +  TableStatus1 + "=" + "'" + StatusValue1 + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }

        /*------------Function For Fatch Count Record Integer Value 8 Argument----------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchCountRecord(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2)
        {
            string sql = "SELECT COUNT (" + ReturnColumn + ") FROM " + TableName + " WHERE " + ColumnName1 + "='" + ColumnValue1 + "' AND " + TableStatus1 + "=" + "'" + StatusValue1 + "' AND " + TableStatus2 + "=" + "'" + StatusValue2 + "'";
            DataTable dt = DB.GetDataTable(sql);
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }

        /*------------Function For Fatch Count Record Integer Value 10 Argument---------------------------*/
        /*------------------------------------------------------------------------------------------------*/
        public static int FatchCountRecord(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1, string ColumnName2, string ColumnValue2, string TableStatus1, char StatusValue1, string TableStatus2, char StatusValue2)
        {
            DataTable dt = DB.GetDataTable("SELECT COUNT (" + ReturnColumn + ") FROM " + TableName + " WHERE " + ColumnName1 + "='" + ColumnValue1 + "' AND " + ColumnName2 + "='" + ColumnValue2 + "' AND " + TableStatus1 + "=" + "'" + StatusValue1 + "' AND " + TableStatus2 + "=" + "'" + StatusValue2 + "'");
            if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0].ToString());

        }
    /*------------Function For Fatching Column Name String Value-------------------------------------*/
    /*------------------------------------------------------------------------------------------------*/
    public static byte[] FatchColumnNameByte(string TableName, string ReturnColumn, string ColumnName1, string ColumnValue1,string TableStatus, char StatusValue)
    {
      try
      {
        byte[] bytesData = null;
        string sql = "select " + ReturnColumn + " from " + TableName + " where  " + ColumnName1 + "='" + ColumnValue1 + "'AND " + " " + TableStatus + "=" + "'" + StatusValue + "'";
        DataTable dt = DB.GetDataTable(sql);
        if (String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
        { bytesData = null; }
        else
        { bytesData = (byte[])dt.Rows[0][0]; }
          return bytesData;
        //else
         // return dt.Rows[0][0].ToString();
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    /*------------Function For Get Month -------------------------------------------------------------*/
    /*------------------------------------------------------------------------------------------------*/
    public static string GetMonth(int month)
        {
            switch (month)
            {
                case 13: return "Fresher";
                    break;
                case 1: return "Jan";
                    break;
                case 2: return "Feb";
                    break;
                case 3: return "Mar";
                    break;
                case 4: return "Aprl";
                    break;
                case 5: return "May";
                    break;
                case 6: return "Jun";
                    break;
                case 7: return "Jul";
                    break;
                case 8: return "Aug";
                    break;
                case 9: return "Sep";
                    break;
                case 10: return "Oct";
                    break;
                case 11: return "Nov";
                    break;
                case 12: return "Dec";
                    break;
                default: return "None";
                    break;

            }
        }
        
    }
}
