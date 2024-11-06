using CYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AForge.Video.DirectShow;
using ZXing;
using System.Drawing;
using System.Threading.Tasks;
using System.Reflection;
using ZXing.QrCode.Internal;
using System.Web.Services;

public partial class Stock_Entry : System.Web.UI.Page
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
                BindVendorList();
                BindProductList();
                BindBrandList();

                BindGrid();

            }

        }
    }
    protected void BindGrid()
    {
        try
        {

            DataTable dt = new DataTable();
            dt = DB.GetDataTableByProc("sp_Get_product_details_info");
            if (dt != null && dt.Rows.Count > 0)
            {
                grdProductDetails.DataSource = dt;
                grdProductDetails.DataBind();

            }
            else
            {
                grdProductDetails.DataSource = null;
                grdProductDetails.DataBind();
            }


        }
        catch
        {
            grdProductDetails.DataSource = null;
            grdProductDetails.DataBind();
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
            DataTable dt = DB.GetDataTableByProc("sp_Get_unit_info");
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
    protected void BindVendorList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_Vendor_info");
            ddlVendorName.Items.Clear();
            ddlVendorName.Items.Add(new ListItem("Select Vendor name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlVendorName.Items.Add(new ListItem(dr["vendor_Name"].ToString(), dr["vendor_id"].ToString()));
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void BindBrandList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_Brand_info");
            ddlBrandName.Items.Clear();
            ddlBrandName.Items.Add(new ListItem("Select Brand Name", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                ddlBrandName.Items.Add((new ListItem(dr["brand_Name"].ToString(), dr["brand_id"].ToString())));
            }
        }
        catch 
        {

        }
    }
    protected void BindProductList()
    {
        try
        {
            DataTable dt = DB.GetDataTableByProc("sp_Get_Product_info");
            ddlProductName.Items.Clear();
            ddlProductName.Items.Add(new ListItem("Select Product Name", "0"));
            foreach(DataRow dr in dt.Rows)
            {
                ddlProductName.Items.Add(new ListItem(dr["product_Name"].ToString(), dr["product_id"].ToString()));
            }
        }
        catch
        {
        
        }
    }

    protected void cmdClear_Click(object sender, EventArgs e)
    {
        ddlCategoryName.SelectedValue = "0";
        ddlSubCategoryName.SelectedValue = "0";
        ddlProductName.SelectedValue="0";
        ddlBrandName.SelectedValue="0";
        ddlVendorName.SelectedValue="0";
        ddlSizeName.SelectedValue = "0";
        ddlUnitName.SelectedValue = "0";
        ddlColorName.SelectedValue = "0";
        txtProductQuantity.Text = "";
        txtPrintedPrice.Text = "";
        txtPurchasePrice.Text = "";
        txtSellingPrice.Text = "";
        txtMaxDiscount.Text = "";
        txtGST.Text = "";
        ddlRemark.Text = "";

        lblmsg.Text = "";
        Clear();
        BindGrid();

    }

    [WebMethod]
    public static string ProcessBarcode(string barcodeValue)
    {
        // Process the barcode (e.g., save it, display on UI, etc.)
        return String.Format("Barcode received: {0}", barcodeValue);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (fileUploadBarcode.HasFile)
        {
            try
            {
                // Convert uploaded file to a Bitmap
                using (var uploadedImage = new Bitmap(fileUploadBarcode.PostedFile.InputStream))
                {
                    // Initialize barcode reader
                    var barcodeReader = new BarcodeReader();
                    var result = barcodeReader.Decode(uploadedImage);

                    if (result != null)
                    {
                        // Set the hidden field value to the scanned barcode
                        hfBarcodeResult.Value = result.Text;
                    }
                    else
                    {
                        hfBarcodeResult.Value = "No barcode detected.";
                    }
                }
            }
            catch (Exception ex)
            {
                hfBarcodeResult.Value = "Error reading barcode: " + ex.Message;
            }
        }
    }
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '1'))
            {
                string select = "Select * from product_details_info Where Status='E' And admin_id=" + Session["AdminID"].ToString() + " and category_id='" + ddlCategoryName.SelectedValue + "' And sub_category_id='" + ddlSubCategoryName.SelectedValue + "'and product_id='"+ddlProductName.SelectedValue+"'and vendor_id='"+ddlVendorName.SelectedValue+"'and brand_id='"+ddlBrandName.SelectedValue+"'and size_id='"+ddlSizeName.SelectedValue+"'and color_id='"+ddlColorName.SelectedValue+"'and unit_id='"+ddlUnitName.SelectedValue+"'and product_quantity='"+txtProductQuantity.Text+"'and purchase_price='"+txtPurchasePrice.Text+"'and printed_price='"+txtPrintedPrice.Text+"'and gst_percentage='"+txtGST.Text+"'and selling_price='"+txtSellingPrice.Text+"'max_discount='"+txtMaxDiscount.Text+"'";
                DataTable dt = DB.GetDataTable(select);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblmsg.Text = "Record Already Exist.";

                }
                else
                {

                    //byte[] bytes;
                    //using (BinaryReader br = new BinaryReader(Barcode.PostedFile.InputStream))
                    //{
                    //    bytes = br.ReadBytes(Barcode.PostedFile.ContentLength);
                    //}
                    Stock a = new Stock();
                        a.product_quantity = txtProductQuantity.Text;
                        a.printed_price = txtPrintedPrice.Text;
                        a.purchase_price = txtPurchasePrice.Text;
                        a.selling_price = txtSellingPrice.Text;
                        a.max_discount = txtMaxDiscount.Text;
                        a.gst_percentage = txtGST.Text;
                        a.remark = ddlRemark.Text;
                        a.category_id = ddlCategoryName.SelectedValue;
                        a.sub_category_id = ddlSubCategoryName.SelectedValue;
                        a.unit_id = ddlUnitName.SelectedValue;
                        a.size_id = ddlSizeName.SelectedValue;
                        a.color_id = ddlColorName.SelectedValue;
                        a.product_id = ddlProductName.SelectedValue;
                        a.brand_id = ddlBrandName.SelectedValue;
                        a.vendor_id = ddlVendorName.SelectedValue;
                        //a.barcode = Convert.ToBase64String(bytes);
                        a.admin_id = Session["AdminID"].ToString();

                        lblmsg.Text = Stock.InsertProductDetailsInfo(a);
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
                //byte[] bytes;
                //using (BinaryReader br = new BinaryReader(Barcode.PostedFile.InputStream))
                //{
                //    bytes = br.ReadBytes(Barcode.PostedFile.ContentLength);
                //}
                Stock a = new Stock();
                a.product_details_id = lblID.Text;
                a.product_quantity = txtProductQuantity.Text;
                a.printed_price = txtPrintedPrice.Text;
                a.purchase_price = txtPurchasePrice.Text;
                a.selling_price = txtSellingPrice.Text;
                a.max_discount = txtMaxDiscount.Text;
                a.gst_percentage = txtGST.Text;
                a.remark = ddlRemark.Text;
                a.category_id = ddlCategoryName.SelectedValue;
                a.sub_category_id = ddlSubCategoryName.SelectedValue;
                a.unit_id = ddlUnitName.SelectedValue;
                a.size_id = ddlSizeName.SelectedValue;
                a.color_id = ddlColorName.SelectedValue;
                a.product_id = ddlProductName.SelectedValue;
                a.brand_id = ddlBrandName.SelectedValue;
                a.vendor_id = ddlVendorName.SelectedValue;
                //a.barcode=bytes.ToString();
                a.admin_id = Session["AdminID"].ToString();

                lblmsg.Text = Stock.UpdateProductDetailsInfo(a);
                BindGrid();
                Clear();
            }
        }
        catch
        {
            lblmsg.Text = "Error";
        }
    }

    protected void Clear()
    {
        ddlCategoryName.SelectedValue = "0";
        ddlSubCategoryName.SelectedValue = "0";
        ddlProductName.SelectedValue = "0";
        ddlBrandName.SelectedValue = "0";
        ddlVendorName.SelectedValue = "0";
        ddlSizeName.SelectedValue = "0";
        ddlUnitName.SelectedValue = "0";
        ddlColorName.SelectedValue = "0";
        txtProductQuantity.Text = "";
        txtPrintedPrice.Text = "";
        txtPurchasePrice.Text = "";
        txtSellingPrice.Text = "";
        txtMaxDiscount.Text = "";
        ddlRemark.Text = "";
        txtGST.Text = "";

        cmdSubmit.Visible = true;
        cmdUpdate.Visible = false;
    }

    protected void UpdatePanel1_DataBinding(object sender, EventArgs e)
    {

    }

    protected void grdProductDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void grdProductDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvrow;
        GridViewRow previousRow;
        if (e.CommandName == "Delete")
        {
            if (DB.CheckForPermission("PermissionInfo", "AdminID", Session["AdminID"].ToString(), "Permission", '3'))
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lblProductDetailsID = (Label)grdProductDetails.Rows[index].FindControl("lblProductDetailsID");

                Stock a = new Stock();
                a.product_details_id = lblProductDetailsID.Text;
                a.admin_id = Session["AdminID"].ToString();

                lblmsg.Text = Stock.DeleteProductDetailsInfo(a);
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
                Label lblProductDetailsID = (Label)grdProductDetails.Rows[index].FindControl("lblProductDetailsID");
                Label lblProductQuantity = (Label)grdProductDetails.Rows[index].FindControl("lblProductQuantity");
                Label lblPrintedPrice = (Label)grdProductDetails.Rows[index].FindControl("lblPurchasePrice");
                Label lblPurchasePrice = (Label)grdProductDetails.Rows[index].FindControl("lblPurchasePrice");
                Label lblSellingPrice = (Label)grdProductDetails.Rows[index].FindControl("lblSellingPrice");
                Label lblMaxDiscount = (Label)grdProductDetails.Rows[index].FindControl("lblMaxDiscount");
                Label lblGST = (Label)grdProductDetails.Rows[index].FindControl("lblGST");
                Label lblRemark = (Label)grdProductDetails.Rows[index].FindControl("lblRemark");
                Label lblCategoryID = (Label)grdProductDetails.Rows[index].FindControl("lblCategoryID");
                Label lblCategoryName = (Label)grdProductDetails.Rows[index].FindControl("lblCategoryName");
                Label lblSubCategoryID = (Label)grdProductDetails.Rows[index].FindControl("lblSubCategoryID");
                Label lblUnitID = (Label)grdProductDetails.Rows[index].FindControl("lblUnitID");
                Label lblSizeID = (Label)grdProductDetails.Rows[index].FindControl("lblSizeID");
                Label lblColorID = (Label)grdProductDetails.Rows[index].FindControl("lblColorID");
                Label lblProductID = (Label)grdProductDetails.Rows[index].FindControl("lblProductID");
                Label lblBrandID = (Label)grdProductDetails.Rows[index].FindControl("lblBrandID");
                Label lblVendorID = (Label)grdProductDetails.Rows[index].FindControl("lblVendorID");
                    
                lblID.Text = lblProductDetailsID.Text;
                txtProductQuantity.Text = lblProductQuantity.Text;
                ddlRemark.Text= lblRemark.Text;
                ddlCategoryName.SelectedValue = lblCategoryID.Text;
                ddlSubCategoryName.SelectedValue = lblSubCategoryID.Text;
                ddlUnitName.SelectedValue = lblUnitID.Text;
                ddlSizeName.SelectedValue = lblSizeID.Text;
                ddlColorName.SelectedValue = lblColorID.Text;
                ddlProductName.SelectedValue = lblProductID.Text;
                ddlVendorName.SelectedValue = lblVendorID.Text;
                ddlBrandName.SelectedValue = lblBrandID.Text;
                txtProductQuantity.Text=lblProductQuantity.Text;
                txtPrintedPrice.Text = lblPrintedPrice.Text;
                txtPurchasePrice.Text = lblPurchasePrice.Text;
                txtSellingPrice.Text= lblSellingPrice.Text;
                txtMaxDiscount.Text = lblMaxDiscount.Text;
                txtGST.Text = lblGST.Text;

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


    protected void grdProductDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdProductDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

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
    
    protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlBrandName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlVendorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlRemark_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void ddlBarcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void grdProductDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();
        grdProductDetails.PageIndex = e.NewPageIndex;
        grdProductDetails.DataBind();

    }
}