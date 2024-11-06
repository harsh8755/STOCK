using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_ProductMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {
                BindCategoryList();
                BindSubCategoryList();
                BindColorList();
                BindSizeList();
                BindUnitList();

                BindGrid();
            }
        }
    }
    protected void BindGrid()
    {
        try
        {

            DataTable dt = new DataTable();
            dt = DB.GetDataTableByProc("sp_Get_product_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdProduct.DataSource = dt;
                grdProduct.DataBind();

            }
            else
            {
                grdProduct.DataSource = null;
                grdProduct.DataBind();
            }


        }
        catch
        {
            grdProduct.DataSource = null;
            grdProduct.DataBind();
        }
    }
    protected void BindCategoryList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_category_info");
            ddlCategoryName.Items.Clear();
            ddlCategoryName.Items.Add(new ListItem("Select Category name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlCategoryName.Items.Add(new ListItem(dr["category_Name"].ToString(), dr["category_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void BindSubCategoryList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_sub_category_info");
            ddlSubCategoryName.Items.Clear();
            ddlSubCategoryName.Items.Add(new ListItem("Select Sub Category name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlSubCategoryName.Items.Add(new ListItem(dr["sub_category_Name"].ToString(), dr["sub_category_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void BindUnitList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_Unit_info");
            ddlUnitName.Items.Clear();
            ddlUnitName.Items.Add(new ListItem("Select Unit name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlUnitName.Items.Add(new ListItem(dr["unit_Name"].ToString(), dr["unit_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void BindColorList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_color_info");
            ddlColorName.Items.Clear();
            ddlColorName.Items.Add(new ListItem("Select color name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlColorName.Items.Add(new ListItem(dr["color_Name"].ToString(), dr["color_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void BindSizeList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_size_info");
            ddlSizeName.Items.Clear();
            ddlSizeName.Items.Add(new ListItem("Select Size name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlSizeName.Items.Add(new ListItem(dr["size_Name"].ToString(), dr["size_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void cmdClear_Click(object sender, EventArgs e)
    {
        txtProductName.Text = "";
        ddlCategoryName.SelectedValue = "0";
        ddlSubCategoryName.SelectedValue="0";
        ddlUnitName.SelectedValue = "0";
        ddlSizeName.SelectedValue = "0";
        ddlColorName.SelectedValue = "0";
        txtProductCode.Text = "";
        lblmsg.Text = "";
        Clear();
        BindGrid();

    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from product_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and product_Name='" + txtProductName.Text + "' And product_Code='" + txtProductCode.Text + "'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {
                    //AdminModule a = new AdminModule();
                    //a.unit_id = ddlUnitName.SelectedValue;
                    //a.Product_Name = txtProductName.Text;
                    //a.Product_short_name = txtProductShortName.Text;
                    //a.admin_id = Session["AdminID"].ToString();

                    //lblmsg.Text = AdminModule.InsertProductInfo(a);
                    //BindGrid();
                    //Clear();

                    //if (ProductImage != null && ProductImage.HasFile)
                    //{
                    //    string fileUrl = "";
                    //    int maxFileSize = 1 * 1024 * 1024; // Maximum file size in bytes (e.g., 5MB)
                    //    int fileSize = ProductImage.PostedFile.ContentLength;
                    //    if (fileSize <= maxFileSize)
                    //    {
                    //        string ext = Path.GetExtension(ProductImage.FileName);
                    //        string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                    //        ProductImage.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/img/") + filename);
                    //        fileUrl = "~/img/" + filename;

                    //        AdminModule a = new AdminModule();
                    //        a.product_Name = txtProductName.Text;
                    //        a.product_Code = txtProductCode.Text;
                    //        a.category_id=ddlCategoryName.SelectedValue;
                    //        a.sub_category_id=ddlSubCategoryName.SelectedValue;
                    //        a.unit_id=ddlUnitName.SelectedValue;
                    //        a.size_id=ddlSizeName.SelectedValue;
                    //        a.color_id=ddlColorName.SelectedValue;
                    //        a.image_Url = fileUrl;
                    //        a.admin_id = Session["AdminID"].ToString();

                    //        lblmsg.Text = AdminModule.InsertProductInfo(a);
                    //        BindGrid();
                    //        Clear();
                    //    }
                    //    else
                    //    {
                    //        lblmsg.Text = "Please Select images less then 1 MB.";
                    //    }
                    //}
                    //else
                    //{
                    //    lblmsg.Text = "Please Select a valid file.";
                    //}

                    if (ProductImage != null && ProductImage.HasFiles)
                    {
                        List<string> fileUrls = new List<string>();
                        int maxFileSize = 1 * 1024 * 1024; // Maximum file size (1MB)

                        foreach (HttpPostedFile uploadedFile in ProductImage.PostedFiles)
                        {
                            int fileSize = uploadedFile.ContentLength;
                            if (fileSize <= maxFileSize)
                            {
                                string ext = Path.GetExtension(uploadedFile.FileName);
                                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                                string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/img/") + filename;
                                uploadedFile.SaveAs(filePath);

                                fileUrls.Add("img/" + filename); // Store the relative URL
                            }
                            else
                            {
                                lblmsg.Text = "Please ensure each file is less than 1 MB.";
                                return;
                            }
                        }

                        if (fileUrls.Count > 0)
                        {
                            // Prepare data for the stored procedure
                            AdminModule a = new AdminModule();
                            a.product_Name = txtProductName.Text;
                            a.product_Code = txtProductCode.Text;
                            a.category_id = ddlCategoryName.SelectedValue;
                            a.sub_category_id = ddlSubCategoryName.SelectedValue;
                            a.unit_id = ddlUnitName.SelectedValue;
                            a.size_id = ddlSizeName.SelectedValue;
                            a.color_id = ddlColorName.SelectedValue;
                            a.admin_id = Session["AdminID"].ToString();

                            // Prepare the ImageUrlTableType table for the stored procedure
                            DataTable dtImages = new DataTable();
                            dtImages.Columns.Add("ImageUrl", typeof(string));
                            foreach (var url in fileUrls)
                            {
                                dtImages.Rows.Add(url); // Add each file URL to the table
                            }

                            // Call the stored procedure
                            lblmsg.Text = AdminModule.InsertProductInfo(a, dtImages);
                            BindGrid();
                            Clear();
                        }
                        else
                        {
                            lblmsg.Text = "Please Insert atleast 1 Image.";
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Please select a valid file.";
                    }


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
                if (ProductImage != null && ProductImage.HasFiles)
                {
                    List<string> fileUrls = new List<string>();
                    int maxFileSize = 1 * 1024 * 1024; // Maximum file size (1MB)

                    foreach (HttpPostedFile uploadedFile in ProductImage.PostedFiles)
                    {
                        int fileSize = uploadedFile.ContentLength;
                        if (fileSize <= maxFileSize)
                        {
                            string ext = Path.GetExtension(uploadedFile.FileName);
                            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                            string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/img/") + filename;
                            uploadedFile.SaveAs(filePath);

                            fileUrls.Add("img/" + filename); // Store the relative URL
                        }
                        else
                        {
                            lblmsg.Text = "Please ensure each file is less than 1 MB.";
                            return;
                        }
                    }

                    if (fileUrls.Count > 0)
                    {
                        // Prepare data for the stored procedure
                        AdminModule a = new AdminModule();
                        a.product_Name = txtProductName.Text;
                        a.product_Code = txtProductCode.Text;
                        a.category_id = ddlCategoryName.SelectedValue;
                        a.sub_category_id = ddlSubCategoryName.SelectedValue;
                        a.unit_id = ddlUnitName.SelectedValue;
                        a.size_id = ddlSizeName.SelectedValue;
                        a.color_id = ddlColorName.SelectedValue;
                        a.admin_id = Session["AdminID"].ToString();

                        // Prepare the ImageUrlTableType table for the stored procedure
                        DataTable dtImages = new DataTable();
                        dtImages.Columns.Add("ImageUrl", typeof(string));
                        foreach (var url in fileUrls)
                        {
                            dtImages.Rows.Add(url); // Add each file URL to the table
                        }

                        // Call the stored procedure
                        lblmsg.Text = AdminModule.UpdateProductInfo(a, dtImages);
                        BindGrid();
                        Clear();
                    }
                    else
                    {
                        lblmsg.Text = "Please Insert atleast 1 Image.";
                    }
                }
                else if (ProductImage == null || !ProductImage.HasFiles)
                {
                    //List<string> fileUrls = new List<string>();
                    //fileUrls.Clear();

                    //int maxFileSize = 1 * 1024 * 1024; // Maximum file size (1MB)

                    //foreach (HttpPostedFile uploadedFile in ProductImage.PostedFiles)
                    //{
                    //    int fileSize = uploadedFile.ContentLength;
                    //    if (fileSize <= maxFileSize)
                    //    {
                    //        string ext = Path.GetExtension(uploadedFile.FileName);
                    //        string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                    //        string filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/img/") + filename;
                    //        uploadedFile.SaveAs(filePath);

                    //        fileUrls.Add("img/" + filename); // Store the relative URL
                    //    }
                    //    else
                    //    {
                    //        lblmsg.Text = "Please ensure each file is less than 1 MB.";
                    //        return;
                    //    }
                    //}

                    //if (fileUrls.Count >= 0)
                    //{
                        // Prepare data for the stored procedure
                        AdminModule a = new AdminModule();
                        a.product_id = lblID.Text;
                        a.product_Name = txtProductName.Text;
                        a.product_Code = txtProductCode.Text;
                        a.category_id = ddlCategoryName.SelectedValue;
                        a.sub_category_id = ddlSubCategoryName.SelectedValue;
                        a.unit_id = ddlUnitName.SelectedValue;
                        a.size_id = ddlSizeName.SelectedValue;
                        a.color_id = ddlColorName.SelectedValue;
                        a.admin_id = Session["AdminID"].ToString();

                        // Prepare the ImageUrlTableType table for the stored procedure
                        DataTable dtImages = new DataTable();
                        dtImages.Columns.Add("ImageUrl", typeof(string));
                        //dtImages.Rows.Add(fileUrls);
                        //foreach (var url in fileUrls)
                        //{
                        //    dtImages.Rows.Add(url); // Add each file URL to the table
                        //}

                        // Call the stored procedure
                        lblmsg.Text = AdminModule.UpdateProductInfo(a, dtImages);
                        BindGrid();
                        Clear();
                    //}
                    //else
                    //{
                    //    lblmsg.Text = "Please Insert atleast 1 Image.";
                    //}
                }
                else
                {
                    lblmsg.Text = "Please Select a valid file.";
                }

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
        txtProductName.Text = "";
        ddlCategoryName.SelectedValue = "0";
        ddlSubCategoryName.SelectedValue = "0";
        ddlUnitName.SelectedValue = "0";
        ddlSizeName.SelectedValue = "0";
        ddlColorName.SelectedValue = "0";
        txtProductCode.Text = "";

        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblProductID = (Label)grdProduct.Rows[index].FindControl("lblProductID");
                AdminModule a = new AdminModule();
                a.product_id = lblProductID.Text;
                a.admin_id = Session["AdminID"].ToString();

                lblmsg.Text = AdminModule.DeleteProductInfo(a);
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
                Label lblProductID = (Label)grdProduct.Rows[index].FindControl("lblProductID");
                Label lblProductName = (Label)grdProduct.Rows[index].FindControl("lblProductName");
                Label lblProductCode = (Label)grdProduct.Rows[index].FindControl("lblProductCode");
                Label lblCategoryID = (Label)grdProduct.Rows[index].FindControl("lblCategoryID");
                Label lblCategoryName = (Label)grdProduct.Rows[index].FindControl("lblCategoryName");
                Label lblSubCategoryID = (Label)grdProduct.Rows[index].FindControl("lblSubCategoryID");
                Label lblSubCategoryName = (Label)grdProduct.Rows[index].FindControl("lblSubCategoryName");
                Label lblSizeID = (Label)grdProduct.Rows[index].FindControl("lblSizeID");
                Label lblSizeName = (Label)grdProduct.Rows[index].FindControl("lblSizeName");
                Label lblUnitID = (Label)grdProduct.Rows[index].FindControl("lblUnitID");
                Label lblUnitName = (Label)grdProduct.Rows[index].FindControl("lblUnitName");
                Label lblColorID = (Label)grdProduct.Rows[index].FindControl("lblColorID");
                Label lblColorName = (Label)grdProduct.Rows[index].FindControl("lblColorName");
                lblID.Text = lblProductID.Text;
                txtProductName.Text = lblProductName.Text;
                txtProductCode.Text = lblProductCode.Text;
                ddlCategoryName.SelectedValue=lblCategoryID.Text;
                ddlSubCategoryName.SelectedValue = lblSubCategoryID.Text;
                ddlUnitName.SelectedValue = lblUnitID.Text;
                ddlSizeName.SelectedValue = lblSizeID.Text;
                ddlColorName.SelectedValue = lblColorID.Text;

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


    protected void grdProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlSizeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlUnitName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlColorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grdProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdProduct.PageIndex = e.NewPageIndex;
        grdProduct.DataBind();

    }
}