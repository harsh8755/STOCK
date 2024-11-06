using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace CYS
{
    public class Stock
    {

        public static DataTable AdminLogin(Stock a)
        {
            try
            {

                DataTable dt = DB.GetDataTableProcedure("sp_AdminLogin", "@uname", a.Username, "@pass", a.Password);
                return dt;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string InsertModuleInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),

                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertModule", param);
                return "Thankyou! Module Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertModuleInfo";
            }
        }

        /*------------------------------Function For Insert Module----------------------------------*/
        public static string DeleteModuleInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@ModuleID",a.ModuleID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_DeleteModule", param);
                return "Module Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteModule";
            }
        }
        public static string UpdateModuleInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),
                                 new SqlParameter("@ModuleID",a.ModuleID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdateModule", param);
                return "Thankyou! Module Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateModuleInfo";
            }
        }

        public string PageID { get; set; }
        public string PageLink { get; set; }
        public static string InsertPageInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@PageName",a.Name),
                                 new SqlParameter("@PageLink",a.PageLink),
                                  new SqlParameter("@ModuleID",a.ModuleID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertPage", param);
                return "Thankyou! Page Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertPageInfo";
            }
        }

        /*------------------------------Function For Insert Page----------------------------------*/
        public static string DeletePageInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@PageID",a.PageID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_DeletePage", param);
                return "Page Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeletePage";
            }
        }
        public static string UpdatePageInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                  new SqlParameter("@PageName",a.Name),
                                  new SqlParameter("@PageLink",a.PageLink),
                                  new SqlParameter("@ModuleID",a.ModuleID),
                                   new SqlParameter("@PageID",a.PageID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdatePage", param);
                return "Thankyou! Page Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdatePageInfo";
            }
        }
        public static string InsertCityInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@CityName",a.Name),

                                  new SqlParameter("@StateID",a.StateID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertCity", param);
                return "Thankyou! City Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertCityInfo";
            }
        }

        /*------------------------------Function For Insert City----------------------------------*/
        public static string DeleteCityInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@CityID",a.CityID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_DeleteCity", param);
                return "City Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteCity";
            }
        }
        public static string UpdateCityInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                  new SqlParameter("@CityName",a.Name),

                                  new SqlParameter("@StateID",a.StateID),
                                   new SqlParameter("@CityID",a.CityID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdateCity", param);
                return "Thankyou! City Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateCityInfo";
            }
        }


        /*------------------------------Function For Insert State----------------------------------*/

        public static string InsertStateInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),

                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertState", param);
                return "Thankyou! State Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertStateInfo";
            }
        }

        public static string DeleteStateInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@StateID",a.StateID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_DeleteState", param);
                return "State Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteState";
            }
        }
        public static string UpdateStateInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),
                                 new SqlParameter("@StateID",a.StateID),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdateState", param);
                return "Thankyou! State Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateStateInfo";
            }
        }


        /*------------------------------Function For Insert Admin----------------------------------*/

        public static string InsertAdminInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),
                                new SqlParameter("@EmailID",a.EmailID),
                                new SqlParameter("@Mobile",a.Mobile),
                                new SqlParameter("@LoginID",a.LoginID),
                                new SqlParameter("@Password",a.Password),
                                new SqlParameter("@PicURL",a.PicURl),
                                new SqlParameter("@PicBytes",a.PicBytes),
                                new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertAdmin", param);
                return "Thankyou! Admin Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertAdminInfo";
            }
        }

        public static string DeleteAdminInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@AdminID",a.AdminID),
                                    new SqlParameter("@AdminID1",a.AdminID1),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_DeleteAdmin", param);
                return "Admin Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteAdmin";
            }
        }
        public static string UpdateAdminInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),
                              new SqlParameter("@EmailID",a.EmailID),
                                new SqlParameter("@Mobile",a.Mobile),
                                new SqlParameter("@PicURL",a.PicURL),
                                new SqlParameter("@PicBytes",a.PicBytes),
                                new SqlParameter("@AdminID",a.AdminID),
                                  new SqlParameter("@AdminID1",a.AdminID1),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdateAdmin", param);
                return "Thankyou! Admin Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateAdminInfo";
            }
        }


        /*------------------------------Function For Insert Roll----------------------------------*/
        public static string InsertRoll(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@PageID",a.PageID),
                              new SqlParameter("@AdminID",a.AdminID),
                                new SqlParameter("@AdminID1",a.AdminID1),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertRoll", param);
                return "Thankyou! Role Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:sp_InsertRoll";
            }
        }
        /*------------------------------Function For Insert Permission----------------------------------*/
        public static string InsertPermission(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Permission",a.Permission),
                                new SqlParameter("@Name",a.Name),
                                new SqlParameter("@AdminID",a.AdminID),
                                new SqlParameter("@AdminID1",a.AdminID1),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertPermission", param);
                return "Thankyou! Role Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:sp_InsertPermission";
            }
        }

        /*------------------------------Function For Insert Admin----------------------------------*/

        public static string InsertCompanyInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@Name",a.Name),
                                new SqlParameter("@EmailID",a.EmailID),
                                new SqlParameter("@Mobile",a.Mobile),

                                new SqlParameter("@Address",a.Address),
                                new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_InsertCompany", param);
                return "Thankyou! Company Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:sp_InsertCompany";
            }
        }

        public static string DeleteCompanyInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@AdminID",a.AdminID),
                                    new SqlParameter("@CompanyID",a.CompanyID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_DeleteCompany", param);
                return "Company Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:sp_DeleteCompany";
            }
        }
        public static string UpdateCompanyInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                               new SqlParameter("@Name",a.Name),
                                new SqlParameter("@EmailID",a.EmailID),
                                new SqlParameter("@Mobile",a.Mobile),
                                new SqlParameter("@Address",a.Address),
                                new SqlParameter("@AdminID",a.AdminID),
                                 new SqlParameter("@CompanyID",a.CompanyID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdateCompany", param);
                return "Thankyou! Company Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateAdminInfo";
            }
        }
        public static string UpdateMessageReply(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@ContactUSID ",a.ContactUSID ),
                                 new SqlParameter("@Reply",a.Reply),
                                    new SqlParameter("@AdminID",a.AdminID),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_UpdateContactUsInfo", param);
                return "1";

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        /*------------------------------Function For Insert Unit----------------------------------*/

        public static string InsertUnitInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@unit_Name",a.unit_Name),
                                  new SqlParameter("@unit_short_name",a.unit_short_name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_unit_info", param);
                return "Thankyou! Unit Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertUnitInfo";
            }
        }

        public static string DeleteUnitInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@unit_id",a.unit_id),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_delete_unit_info", param);
                return "Unit Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteUnit";
            }
        }
        public static string UpdateUnitInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                  new SqlParameter("@unit_Name",a.unit_Name),
                                  new SqlParameter("@unit_id",a.unit_id),
                                  new SqlParameter("@unit_short_name",a.unit_short_name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_unit_info", param);
                return "Thankyou! Unit Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateUnitInfo";
            }
        }

        /*------------------------------Function For Insert Size----------------------------------*/

        public static string InsertSizeInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@unit_id",a.unit_id),
                                new SqlParameter("@size_Name",a.size_Name),
                                  new SqlParameter("@size_short_name",a.size_short_name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_size_info", param);
                return "Thankyou! Size Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertSizeInfo";
            }
        }

        public static string DeleteSizeInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@size_id",a.size_id),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_delete_size_info", param);
                return "Size Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteSize";
            }
        }
        public static string UpdateSizeInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                    new SqlParameter("@size_id",a.size_id),
                                  new SqlParameter("@size_Name",a.size_Name),
                                  new SqlParameter("@unit_id",a.unit_id),
                                  new SqlParameter("@size_short_name",a.size_short_name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_size_info", param);
                return "Thankyou! Size Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateSizeInfo";
            }
        }

        /*------------------------------Function For Insert Color----------------------------------*/

        public static string InsertColorInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@color_Name",a.color_Name),
                                  new SqlParameter("@color_short_name",a.color_short_name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_color_info", param);
                return "Thankyou! Color Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertColorInfo";
            }
        }

        public static string DeleteColorInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@color_id",a.color_id),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_delete_color_info", param);
                return "Color Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteColor";
            }
        }
        public static string UpdateColorInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                    new SqlParameter("@color_id",a.color_id),
                                  new SqlParameter("@color_Name",a.color_Name),
                                  new SqlParameter("@color_short_name",a.color_short_name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_color_info", param);
                return "Thankyou! Color Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateColorInfo";
            }


        }

        /*------------------------------Function For Insert Category----------------------------------*/

        public static string InsertCategoryInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@category_Name",a.category_Name),
                                    new SqlParameter("@admin_id",a.admin_id)
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_category_info", param);
                return "Thankyou! Category Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertCategoryInfo";
            }
        }

        public static string DeleteCategoryInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@category_id",a.category_id),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_delete_category_info", param);
                return "category Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteCategory";
            }
        }
        public static string UpdateCategoryInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                    new SqlParameter("@category_id",a.category_id),
                                  new SqlParameter("@category_Name",a.category_Name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_category_info", param);
                return "Thankyou! Category Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateCategoryInfo";
            }


        }

        /*------------------------------Function For Insert SubCategory----------------------------------*/


        public static string InsertSubCategoryInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter ("@category_id",a.category_id),
                                new SqlParameter("@sub_category_Name",a.sub_category_Name),
                                    new SqlParameter("@admin_id",a.admin_id)
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_sub_category_info", param);
                return "Thankyou! SubCategory Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertSubCategoryInfo";
            }
        }

        public static string DeleteSubCategoryInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@sub_category_id",a.sub_category_id),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_delete_sub_category_info", param);
                return "SubCategory Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteSubCategory";
            }
        }
        public static string UpdateSubCategoryInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                    new SqlParameter("@category_id",a.category_id),
                                    new SqlParameter("@sub_category_id",a.sub_category_id),
                                  new SqlParameter("@sub_category_Name",a.sub_category_Name),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_sub_category_info", param);
                return "Thankyou! SubCategory Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateSubCategoryInfo";
            }
        }

        /*------------------------------Function For Insert Vendor----------------------------------*/

        public static string InsertVendorInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@vendor_Name",a.vendor_Name),
                                new SqlParameter("@vendor_Firm_Name",a.vendor_Firm_Name),
                                new SqlParameter("@vendor_State",a.vendor_State),
                                new SqlParameter("@vendor_City",a.vendor_City),
                                new SqlParameter("@vendor_Pincode",a.vendor_Pincode),
                                new SqlParameter("@vendor_Email_id",a.vendor_Email_id),
                                new SqlParameter("@vendor_Mobile",a.vendor_Mobile),
                                new SqlParameter("@Contact_person",a.Contact_person),
                                new SqlParameter("@Contact_Email_id",a.Contact_Email_id),
                                new SqlParameter("@Contact_Mobile",a.Contact_Mobile),
                                new SqlParameter("@vendor_Reg_No",a.vendor_Reg_No),
                                new SqlParameter("@vendor_GST_No",a.vendor_GST_No),
                                new SqlParameter("@vendor_Address",a.vendor_Address),
                                    new SqlParameter("@admin_id",a.admin_id)
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_vendor_info", param);
                return "Thankyou! Vendor Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertVendorInfo";
            }
        }

        public static string DeleteVendorInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@vendor_id",a.vendor_id),
                                    new SqlParameter("@admin_id",a.admin_id),
                            };

                int result = DB.ExecuteNonQueryByProc("sp_delete_vendor_info", param);
                return "Vendor Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteVendor";
            }
        }
        public static string UpdateVendorInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                    new SqlParameter("@vendor_id",a.vendor_id),
                                new SqlParameter("@vendor_Name",a.vendor_Name),
                                new SqlParameter("@vendor_Firm_Name",a.vendor_Firm_Name),
                                new SqlParameter("@vendor_State",a.vendor_State),
                                new SqlParameter("@vendor_City",a.vendor_City),
                                new SqlParameter("@vendor_Pincode",a.vendor_Pincode),
                                new SqlParameter("@vendor_Email_id",a.vendor_Email_id),
                                new SqlParameter("@vendor_Mobile",a.vendor_Mobile),
                                new SqlParameter("@Contact_person",a.Contact_person),
                                new SqlParameter("@Contact_Email_id",a.Contact_Email_id),
                                new SqlParameter("@Contact_Mobile",a.Contact_Mobile),
                                new SqlParameter("@vendor_Reg_No",a.vendor_Reg_No),
                                new SqlParameter("@vendor_GST_No",a.vendor_GST_No),
                                new SqlParameter("@vendor_Address",a.vendor_Address),
                                    new SqlParameter("@admin_id",a.admin_id)
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_vendor_info", param);
                return "Thankyou! Vendor Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateVendorInfo";
            }
        }

        /*------------------------------Function For Insert Brand----------------------------------*/

        public static string InsertBrandInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@brand_Name",a.brand_Name),
                                new SqlParameter("@brand_short_name",a.brand_short_name),
                                new SqlParameter("@Brand_logo_url",a.Brand_logo_url),
                                    new SqlParameter("@admin_id",a.admin_id)
                            };

                int result = DB.ExecuteNonQueryByProc("sp_insert_brand_info", param);
                return "Thankyou! Brand Info Saved Successfully";

            }
            catch (Exception ex)
            {

                return "EC:InsertBrandInfo";
            }
        }

        public static string DeleteBrandInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@brand_id",a.brand_id),
                                new SqlParameter("@admin_id",a.admin_id)
                                };
                int result = DB.ExecuteNonQueryByProc("sp_delete_brand_info", param);
                return "Brand Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteBrand";
            }
        }
        public static string UpdateBrandInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                    new SqlParameter("@brand_id",a.brand_id),
                                  new SqlParameter("@brand_Name",a.brand_Name),
                                  new SqlParameter("@brand_short_name",a.brand_short_name),
                                  new SqlParameter("@Brand_logo_url",a.Brand_logo_url),
                                    new SqlParameter("@admin_id",a.admin_id)
                            };

                int result = DB.ExecuteNonQueryByProc("sp_update_brand_info", param);
                return "Thankyou! Brand Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateBrandInfo";
            }
        }

        /*------------------------------Function For Insert Product----------------------------------*/
        public static string InsertProductInfo(Stock a, DataTable imageUrls)
        {
            try
            {
                // Define the parameters for the stored procedure
                SqlParameter[] param ={
            new SqlParameter("@product_Name",a.product_Name),
            new SqlParameter("@product_Code",a.product_Code),
            new SqlParameter("@category_id",a.category_id),
            new SqlParameter("@sub_category_id",a.sub_category_id),
            new SqlParameter("@unit_id",a.unit_id),
            new SqlParameter("@size_id",a.size_id),
            new SqlParameter("@color_id",a.color_id),
            new SqlParameter("@admin_id",a.admin_id),

            // Add the table-valued parameter for image URLs
            new SqlParameter
            {
                ParameterName = "@ImageUrls",
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.ImageUrlTableType", // Your table type name
                Value = imageUrls
            }
        };

                // Execute the stored procedure with the parameters
                int result = DB.ExecuteNonQueryByProc("sp_insert_Product_info", param);
                return "Thank you! Product Info and images saved successfully.";
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                return "EC:InsertProductInfo";
            }
        }


        public static string DeleteProductInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@product_id",a.product_id),
                                new SqlParameter("@admin_id",a.admin_id)
                                };
                int result = DB.ExecuteNonQueryByProc("sp_delete_Product_info", param);
                return "Product Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteProduct";
            }
        }
        public static string UpdateProductInfo(Stock a, DataTable imageUrls)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@product_id",a.product_id),
                                new SqlParameter("@product_Name",a.product_Name),
                                new SqlParameter("@product_Code",a.product_Code),
                                new SqlParameter("@category_id",a.category_id),
                                new SqlParameter("@sub_category_id",a.sub_category_id),
                                new SqlParameter("@unit_id",a.unit_id),
                                new SqlParameter("@size_id",a.size_id),
                                new SqlParameter("@color_id",a.color_id),
                                new SqlParameter("@admin_id",a.admin_id),
                                new SqlParameter
                                {
                                    ParameterName = "@ImageUrls",
                                    SqlDbType = SqlDbType.Structured,
                                    TypeName = "dbo.ImageUrlTableType", // Your table type name
                                    Value = imageUrls
                                }
                };

                int result = DB.ExecuteNonQueryByProc("sp_update_Product_info", param);
                return "Thankyou! Product Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateProductInfo";
            }
        }

        /*------------------------------Function For Insert ProductDetails----------------------------------*/
        public static string InsertProductDetailsInfo(Stock a)
        {
            try
            {
                // Define the parameters for the stored procedure
                SqlParameter[] param ={
                                        new SqlParameter("@product_quantity",a.product_quantity),
                                        new SqlParameter("@printed_price",a.printed_price),
                                        new SqlParameter("@purchase_price",a.purchase_price),
                                        new SqlParameter("@selling_price",a.selling_price),
                                        new SqlParameter("@max_discount",a.max_discount),
                                        new SqlParameter("@gst_percentage",a.gst_percentage),
                                        new SqlParameter("@remark",a.remark),
                                        new SqlParameter("@category_id",a.category_id),
                                        new SqlParameter("@sub_category_id",a.sub_category_id),
                                        new SqlParameter("@unit_id",a.unit_id),
                                        new SqlParameter("@size_id",a.size_id),
                                        new SqlParameter("@color_id",a.color_id),
                                        new SqlParameter("@product_id",a.product_id),
                                        new SqlParameter("@brand_id",a.brand_id),
                                        new SqlParameter("@vendor_id",a.vendor_id),
                                        new SqlParameter("@barcode",a.barcode),
                                        new SqlParameter("@admin_id",a.admin_id)
                                       };

                // Execute the stored procedure with the parameters
                int result = DB.ExecuteNonQueryByProc("sp_insert_product_details_info", param);
                return "Thank you! Product Details Info saved successfully.";
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                return "EC:InsertProductDetailsInfo";
            }
        }


        public static string DeleteProductDetailsInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@product_details_id",a.product_details_id),
                                new SqlParameter("@admin_id",a.admin_id)
                                };
                int result = DB.ExecuteNonQueryByProc("sp_delete_product_details_info", param);
                return "Product Details Info Deleted Successfully";

            }
            catch (Exception ex)
            {

                return "EC:DeleteProductDetails";
            }
        }
        public static string UpdateProductDetailsInfo(Stock a)
        {
            try
            {
                SqlParameter[] param ={
                                new SqlParameter("@product_details_id",a.product_details_id),
                                new SqlParameter("@product_quantity",a.product_quantity),
                                new SqlParameter("@printed_price",a.printed_price),
                                new SqlParameter("@purchase_price",a.purchase_price),
                                new SqlParameter("@selling_price",a.selling_price),
                                new SqlParameter("@max_discount",a.max_discount),
                                new SqlParameter("@gst_percentage",a.gst_percentage),
                                new SqlParameter("@remark",a.remark),
                                new SqlParameter("@category_id",a.category_id),
                                new SqlParameter("@sub_category_id",a.sub_category_id),
                                new SqlParameter("@unit_id",a.unit_id),
                                new SqlParameter("@size_id",a.size_id),
                                new SqlParameter("@color_id",a.color_id),
                                new SqlParameter("@product_id",a.product_id),
                                new SqlParameter("@brand_id",a.brand_id),
                                new SqlParameter("@vendor_id",a.vendor_id),
                                new SqlParameter("@barcode",a.barcode),
                                new SqlParameter("@admin_id",a.admin_id)
                };

                int result = DB.ExecuteNonQueryByProc("sp_update_product_details_info", param);
                return "Thankyou! Product Details Info Updated Successfully";

            }
            catch (Exception ex)
            {

                return "EC:UpdateProductDetailsInfo";
            }
        }

        public string barcode { get; set; }
        public string product_details_id { get; set; }
        public string product_quantity { get; set; }
        public string printed_price { get; set; }
        public string purchase_price { get; set; }
        public string selling_price { get; set; }
        public string max_discount { get; set; }
        public string gst_percentage { get; set; }
        public string remark { get; set; }

        public string product_id { get; set; }
        public string product_Name { get; set; }
        public string product_Code { get; set; }
        public string image_Url { get; set; }


        public string brand_id { get; set; }
        public string brand_Name { get; set; }
        public string brand_short_name { get; set; }
        public string Brand_logo_url { get; set; }

        public string vendor_id { get; set; }
        public string vendor_Name { get; set; }
        public string vendor_Firm_Name { get; set; }
        public string vendor_Address { get; set; }
        public string vendor_State { get; set; }
        public string vendor_City { get; set; }
        public string vendor_Pincode { get; set; }
        public string vendor_Email_id { get; set; }
        public string vendor_Mobile { get; set; }
        public string Contact_person { get; set; }
        public string Contact_Email_id { get; set; }
        public string Contact_Mobile { get; set; }
        public string vendor_Reg_No { get; set; }
        public string vendor_GST_No { get; set; }

        public string sub_category_id { get; set; }
        public string sub_category_Name { get; set; }

        public string category_id { get; set; }
        public string category_Name { get; set; }

        public string color_short_name { get; set; }
        public string color_Name { get; set; }
        public string color_id { get; set; }
        public string size_id { get; set; }
        public string size_Name { get; set; }
        public string size_short_name { get; set; }

        public string Reply { get; set; }

        public string CompanyID { get; set; }
        public string StateID { get; set; }

        public string ModuleID { get; set; }
        public string Name { get; set; }
        public string AdminID { get; set; }

        public string CityID { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string AdminID1 { get; set; }
        public string Mobile { get; set; }
        public string PicURL { get; set; }
        public byte[] PicBytes { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }

        public string PicURl { get; set; }
        public string Permission { get; set; }
        public string Username { get; set; }
        public string ContactUSID { get; set; }

        public string unit_id { get; set; }
        public string unit_Name { get; set; }

        public string unit_short_name { get; set; }
        public string admin_id { get; set; }

    }



}
