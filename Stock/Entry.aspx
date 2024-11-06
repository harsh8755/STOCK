<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Entry.aspx.cs" Inherits="Stock_Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <div class="content-header">
  <div class="container-fluid">
    <div class="row mb-2">
      <div class="col-sm-6">
        <h1 class="m-0">Add Product Details </h1>
      </div><!-- /.col -->
      <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
          <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
          <li class="breadcrumb-item active">Add Product Details </li>
        </ol>
      </div><!-- /.col -->
    </div><!-- /.row -->
  </div><!-- /.container-fluid -->
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnDataBinding="UpdatePanel1_DataBinding">
        <ContentTemplate>


                <div class="box box-primary">
        
        <!-- /.box-header -->
        <div class="box-body">
          <div class="row">

           <div class="col-md-3">
              <div class="form-group">
                  <label for="exampleInputEmail1">Select Category</label>
                <asp:DropDownList ID="ddlCategoryName" runat="server" TabIndex="1" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlCategoryName_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Select Category Name</asp:ListItem>
                        </asp:DropDownList>     
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" ControlToValidate="ddlCategoryName" ErrorMessage="Please Select Category" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

                      </div>
                </div>

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Sub Category</label>
                 <asp:DropDownList ID="ddlSubCategoryName" runat="server" TabIndex="2" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlSubCategoryName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Sub Category Name</asp:ListItem>
                   </asp:DropDownList>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0" ControlToValidate="ddlSubCategoryName" ErrorMessage="Please Select Sub Category" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Product</label>
                 <asp:DropDownList ID="ddlProductName" runat="server" TabIndex="3" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Product Name</asp:ListItem>
                   </asp:DropDownList>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" InitialValue="0" ControlToValidate="ddlProductName" ErrorMessage="Please Select Product Name" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Brand</label>
                 <asp:DropDownList ID="ddlBrandName" runat="server" TabIndex="4" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlBrandName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Brand Name</asp:ListItem>
                   </asp:DropDownList>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" InitialValue="0" ControlToValidate="ddlBrandName" ErrorMessage="Please Select Brand Name" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>
    </div>
            <div class="row">

  <div class="col-md-3">
     <div class="form-group">
     <label for="exampleInputEmail1">Select Vendor</label>
     <asp:DropDownList ID="ddlVendorName" runat="server" TabIndex="5" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlVendorName_SelectedIndexChanged" AutoPostBack="true">
          <asp:ListItem Value="0">Select vendor Name</asp:ListItem>
       </asp:DropDownList>  
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" InitialValue="0" ControlToValidate="ddlVendorName" ErrorMessage="Please Select vendor Name" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

         </div>
     </div>

   <div class="col-md-3">
     <div class="form-group">
     <label for="exampleInputEmail1">Select Unit</label>
     <asp:DropDownList ID="ddlUnitName" runat="server" TabIndex="6" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlUnitName_SelectedIndexChanged" AutoPostBack="true">
          <asp:ListItem Value="0">Select Unit Name</asp:ListItem>
       </asp:DropDownList> 
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ControlToValidate="ddlUnitName" ErrorMessage="Please Select Unit" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

         </div>
     </div>

   <div class="col-md-3">
     <div class="form-group">
     <label for="exampleInputEmail1">Select Size</label>
     <asp:DropDownList ID="ddlSizeName" runat="server" TabIndex="7" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlSizeName_SelectedIndexChanged" AutoPostBack="true">
          <asp:ListItem Value="0">Select Size Name</asp:ListItem>
       </asp:DropDownList>   
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0" ControlToValidate="ddlSizeName" ErrorMessage="Please Select Size" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

         </div>
     </div>

   <div class="col-md-3">
     <div class="form-group">
     <label for="exampleInputEmail1">Select Color</label>
     <asp:DropDownList ID="ddlColorName" runat="server" TabIndex="8" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlColorName_SelectedIndexChanged" AutoPostBack="true">
          <asp:ListItem Value="0">Select Color Name</asp:ListItem>
       </asp:DropDownList>  
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="0" ControlToValidate="ddlColorName" ErrorMessage="Please Select color" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>

         </div>
     </div>

            </div>
             <div class="row">

                  <div class="col-md-3">
                    <div class="form-group">
                 <label for="exampleInputEmail1">Enter Product Quantity</label>
                 <asp:TextBox ID="txtProductQuantity" runat="server" CssClass="form-control" placeholder="Enter Product Quantity" MaxLength="50" TabIndex="9"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProductQuantity" ErrorMessage="Please Enter Product Quantity" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                </div>

             <div class="col-md-3">
             <div class="form-group">
             <label for="exampleInputEmail1">Enter Printed Price</label>
                <asp:TextBox ID="txtPrintedPrice" runat="server" CssClass="form-control" placeholder="Enter Printed Price" MaxLength="50" TabIndex="10"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrintedPrice" ErrorMessage="Please Enter Printed Price" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
        </div>

             <div class="col-md-3">
             <div class="form-group">
             <label for="exampleInputEmail1">Enter Purchase Price</label>
                <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="form-control" placeholder="Enter Purchase Price" MaxLength="50" TabIndex="11"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPurchasePrice" ErrorMessage="Please Enter Purchase Price" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
        </div>

             <div class="col-md-3">
             <div class="form-group">
             <label for="exampleInputEmail1">Enter selling Price</label>
                <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="form-control" placeholder="Enter Selling Price" MaxLength="50" TabIndex="12"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSellingPrice" ErrorMessage="Please Enter Selling Price" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
        </div>

            </div>    

            <div class="row">

             <div class="col-md-3">
             <div class="form-group">
             <label for="exampleInputEmail1">Enter Max Discount in percentage</label>
                <asp:TextBox ID="txtMaxDiscount" runat="server" CssClass="form-control" placeholder="Enter Maximum Discount" MaxLength="50" TabIndex="13"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMaxDiscount" ErrorMessage="Please Enter Discount in Percentage" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
        </div>

             <div class="col-md-3">
             <div class="form-group">
             <label for="exampleInputEmail1">Enter GST Percentage</label>
                <asp:TextBox ID="txtGST" runat="server" CssClass="form-control" placeholder="Enter GST Percent" MaxLength="50" TabIndex="14"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtGST" ErrorMessage="Please Enter GST Percentage" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
        </div>

        <div class="col-md-3">
     <div class="form-group">
     <label for="exampleInputEmail1">Enter Remark</label>
        <asp:TextBox ID="ddlRemark" runat="server" CssClass="form-control" placeholder="Enter Remark" MaxLength="100" TabIndex="15"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlRemark" ErrorMessage="Please Enter Remark" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator> </div>
</div>

            <div class="col-md-3">
  <div class="form-group">
    <label>Barcode:</label>
    <select id="barcodeOption" class="form-control" onchange="toggleBarcodeInput()">
      <option value="upload">Upload Barcode Image</option>
      <option value="camera">Scan from Camera</option>
    </select>
    </div>
                <!-- Hidden field to store the barcode result -->
            <asp:HiddenField ID="hfBarcodeResult" runat="server" />
                </div>
                </div>

    <div class="row">

        <div class="col-md-3">
            <div class="form-group">
                <!-- Upload Barcode Image -->
<div id="barcodeUploadDiv" class="mt-2">
  <asp:FileUpload ID="fileUploadBarcode" runat="server" CssClass="form-control" /><br />
    <asp:Button ID="btnUpload" runat="server" Text="Scan Uploaded Image" OnClick="btnUpload_Click" style="display:block;" />
  <asp:RequiredFieldValidator ID="rfvFileUploadBarcode" runat="server" ControlToValidate="fileUploadBarcode" ErrorMessage="Please upload a barcode image" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>
</div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="form-group">
                <!-- Camera Scan -->
<div id="barcodeCameraDiv" class="mt-2" style="display: none;">
    <!-- Video element for camera scanning (shown but not active initially) -->
  <button type="button" class="btn btn-primary" onclick="startCamera()">Start</button>
  <button type="button" class="btn btn-secondary" onclick="stopCamera()">Stop</button>
  <video id="cameraFeed" width="300" height="300" autoplay style="border:2px solid green"></video>
  <label id="scannedBarcodeLabel" class="d-block mt-2"></label>
  <%--<asp:RequiredFieldValidator ID="rfvCameraScan" runat="server" ControlToValidate="cameraFeed" ErrorMessage="Please scan the barcode" Display="Dynamic" ValidationGroup="ProductDetails" CssClass="text-red"></asp:RequiredFieldValidator>--%>
</div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
            <label>Scanned Barcode: </label>
                <label id="barcodeResult">No barcode detected</label>
            </div>
    </div>

</div>
     
            </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="ProductDetails" TabIndex="9" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="9" CssClass="btn btn-primary" ValidationGroup="ProductDetails" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="10" OnClick="cmdClear_Click"/>
             <br />
            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>
 <br />

            <div class="card-body table-responsive p-0" style="height: 300px;">
            <asp:GridView ID="grdProductDetails" runat="server" AllowPaging="true" PageProductDetails="10" OnPageIndexChanging="grdProductDetails_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
         AutoGenerateColumns="False"  ShowFooter="false"
   CssClass="table table-bordered table-striped"  DataKeyNames="product_details_id" EmptyDataText="No Record Found" OnRowCommand="grdProductDetails_RowCommand" OnRowDataBound="grdProductDetails_RowDataBound"  OnRowDeleting="grdProductDetails_RowDeleting"  OnRowUpdating="grdProductDetails_RowUpdating">
            <EmptyDataRowStyle CssClass="fnt_val" />
           
           <Columns>
                <asp:TemplateField  HeaderText="S.No" Visible="True" >
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSerialNo" runat="server" MaxLength="20" 
                                                            Text="<%# Container.DataItemIndex + 1 %>"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" runat="server" 
                                                            Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="25px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                                </asp:TemplateField>
                <asp:TemplateField  HeaderText="ProductDetailsID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblProductDetailsID" runat="server" Text='<%# Eval("product_details_id")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblPrintedPrice" runat="server" Text='<%# Eval("printed_price")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblPurchasePrice" runat="server" Text='<%# Eval("purchase_price")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblSellingPrice" runat="server" Text='<%# Eval("selling_price")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblMaxDiscount" runat="server" Text='<%# Eval("max_discount")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblGST" runat="server" Text='<%# Eval("gst_percentage")%>' Visible="false"></asp:Label>
                           
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"   Width="80px" />
                    <ItemStyle HorizontalAlign="Center"    Width="80px" />
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Category"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                    <asp:Label ID="lblCategoryID" runat="server" Text='<%#Eval("category_id") %>' Visible="false"></asp:Label>
                 <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("category_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Sub Category"  HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <asp:Label ID="lblSubCategoryID" runat="server" Text='<%#Eval("sub_category_id") %>' Visible="false"></asp:Label>
                 <asp:Label ID="lblSubCategoryName" runat="server" Text='<%# Eval("sub_category_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

              <asp:TemplateField HeaderText="Product"  HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                    <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("product_id") %>' Visible="false"></asp:Label>
                   <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("product_Name") %>' ></asp:Label>
              </ItemTemplate>
             <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
             </asp:TemplateField>

              <asp:TemplateField HeaderText="Brand"  HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
                    <asp:Label ID="lblBrandID" runat="server" Text='<%#Eval("brand_id") %>' Visible="false"></asp:Label>
                   <asp:Label ID="lblBrandName" runat="server" Text='<%# Eval("brand_Name") %>' ></asp:Label>
              </ItemTemplate>
             <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
             </asp:TemplateField>

               <asp:TemplateField HeaderText="Vendor"  HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <asp:Label ID="lblVendorID" runat="server" Text='<%#Eval("vendor_id") %>' Visible="false"></asp:Label>
                 <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("vendor_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Size"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                    <asp:Label ID="lblSizeID" runat="server" Text='<%#Eval("size_id") %>' Visible="false"></asp:Label>
                 <asp:Label ID="lblSizeName" runat="server" Text='<%# Eval("size_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Unit"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                    <asp:Label ID="lblUnitID" runat="server" Text='<%#Eval("unit_id") %>' Visible="false"></asp:Label>
                 <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("unit_short_name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Color"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                    <asp:Label ID="lblColorID" runat="server" Text='<%#Eval("color_id") %>' Visible="false"></asp:Label>
                 <asp:Label ID="lblColorName" runat="server" Text='<%# Eval("color_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Product Quantity"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                 <asp:Label ID="lblProductQuantity" runat="server" Text='<%# Eval("product_quantity") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Remark" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("remark") %>' ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

             <asp:TemplateField HeaderText="view" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                    <ItemTemplate>
                 <a onclick="ViewProductDetails('<%# Eval("product_Name") %>','<%# Eval("product_Code") %>','<%# Eval("vendor_Name") %>','<%# Eval("category_Name") %>','<%# Eval("sub_category_Name") %>','<%# Eval("brand_Name") %>','<%# Eval("unit_short_name") %>','<%# Eval("size_Name") %>','<%# Eval("color_Name") %>','<%# Eval("product_quantity") %>','<%# Eval("printed_price") %>','<%# Eval("purchase_price") %>','<%# Eval("selling_price") %>','<%# Eval("max_discount") %>','<%# Eval("gst_percentage") %>','<%# Eval("remark") %>','<%# Eval("barcode") %>')"><i class="fa fa-eye"></i></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

             <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                    <ItemTemplate>
                          <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Update" ToolTip="Click To Edit Details"><i class="fa fa-edit"></i></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                    <ItemTemplate>
              <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete');"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Delete" ToolTip="Click To Delete Record " ><i class="fas fa-times"></i></asp:LinkButton>
                    </ItemTemplate>
             <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
                </div>

        </ContentTemplate>
          <Triggers>
              <asp:PostBackTrigger ControlID="cmdSubmit" />
              <asp:PostBackTrigger ControlID="cmdUpdate" />
              <asp:PostBackTrigger ControlID="btnUpload" />
          </Triggers>
    </asp:UpdatePanel>

     <div class="modal fade" id="modal-lg">
     <div class="modal-dialog modal-xl">
       <div class="modal-content">
         <div class="modal-header">
           <h4 class="modal-title">Product Details</h4>
           <button type="button" class="close" data-dismiss="modal" aria-label="Close">
             <span aria-hidden="true">&times;</span>
           </button>
         </div>
           <div id="viewDetails">
         <div class="modal-body">
           <div class="row">
               <div class="col-md-3">
                   Product Name: <label id="lbl_Product_Name"></label>

               </div>
               <div class="col-md-3">
                   Product Code: <label id="lbl_Product_Code"></label>
               </div>
               <div class="col-md-3">
                    Vendor Name: <label id="lbl_Vendor_Name"></label>
               </div>
               <div class="col-md-3">
                    Category Name: <label id="lbl_Category_Name"></label>
               </div>

           </div>
             <div class="row">
               <div class="col-md-3">
                   Sub Category Name: <label id="lbl_SubCategory_Name"></label>

               </div>
               <div class="col-md-3">
                   Unit Name: <label id="lbl_Unit_Name"></label>
               </div>
               <div class="col-md-3">
                    Size Name: <label id="lbl_Size_Name"></label>
               </div>
               <div class="col-md-3">
                    Color Name: <label id="lbl_Color_Name"></label>
               </div>
           </div>

       <div class="row">
             <div class="col-md-3">
                  Product Quantity: <label id="lbl_Product_Quantity"></label>
             </div>
             <div class="col-md-3">
                  Printed Price: &#8377;<label id="lbl_Printed_Price"></label>
              </div>
              <div class="col-md-3">
                   Purchase Price: &#8377;<label id="lbl_Purchase_Price"></label>
              </div>
              <div class="col-md-3">
                      Maximum Discount:<label id="lbl_Max_Discount"></label>%
             </div>
       </div>

         <div class="row">
             <div class="col-md-3">
              GST Percent: <label id="lbl_GST_Percent"></label>%
              </div>

             <div class="col-md-3">
              Remark: <label id="lbl_Remark"></label>
              </div>
             
             <div class="col-md-3">
              Barcode: <%--<asp:Image ID="lbl_barcode" runat="server" style="height:100px; width:100px" />--%><label id="lbl_barcode"></label>
              </div>

         </div>

         </div>
               </div>
         <div class="modal-footer justify-content-between">
            <button type="button" class="btn btn-primary" id="downloadBtn" onclick="printData()">Download PDF</button>
           <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
         </div>
       </div>
       <!-- /.modal-content -->
     </div>
     <!-- /.modal-dialog -->
   </div>
 
<script src="https://unpkg.com/@zxing/library@latest"></script>

 <script type="text/javascript">
     debugger;
     function ViewProductDetails(ProductName,ProductCode,VendorName,CategoryName,SubCategoryName,BrandName,UnitName,SizeName,ColorName,Quantity,PrintedPrice,PurchasePrice,SellingPrice,MaxDiscount,GST,Remark,Barcode) {
         // Initialize a variable to check if all fields are empty
         let allFieldsEmpty = true;

         // Check and set Vendor details
         $("#lbl_Product_Name").text(ProductName || "N/A");
         if (ProductName) allFieldsEmpty = false;

         $("#lbl_Product_Code").text(ProductCode || "N/A");
         if (ProductCode) allFieldsEmpty = false;

         $("#lbl_Vendor_Name").text(VendorName || "N/A");
         if (VendorName) allFieldsEmpty = false;

         $("#lbl_Category_Name").text(CategoryName || "N/A");
         if (CategoryName) allFieldsEmpty = false;

         $("#lbl_SubCategory_Name").text(SubCategoryName || "N/A");
         if (SubCategoryName) allFieldsEmpty = false;

         $("#lbl_Unit_Name").text(UnitName || "N/A");
         if (UnitName) allFieldsEmpty = false;

         $("#lbl_Size_Name").text(SizeName || "N/A");
         if (SizeName) allFieldsEmpty = false;

         $("#lbl_Color_Name").text(ColorName || "N/A");
         if (ColorName) allFieldsEmpty = false;

         $("#lbl_Product_Quantity").text(Quantity || "N/A");
         if (Quantity) allFieldsEmpty = false;

         $("#lbl_Printed_Price").text(parseFloat(PrintedPrice).toFixed(2) || "N/A");
         
         if (PrintedPrice) allFieldsEmpty = false;

         $("#lbl_Purchase_Price").text(parseFloat(PurchasePrice).toFixed(2) || "N/A");
         if (PurchasePrice) allFieldsEmpty = false;

         $("#lbl_Max_Discount").text(MaxDiscount || "N/A");
         if (MaxDiscount) allFieldsEmpty = false;

         $("#lbl_GST_Percent").text(GST || "N/A");
         if (GST) allFieldsEmpty = false;

         $("#lbl_Remark").text(Remark || "N/A");
         if (Remark) allFieldsEmpty = false;

         $("#lbl_barcode").text(Barcode || "N/A");
         if (Barcode) allFieldsEmpty = false;

         ////document.getElementById('ContentPlaceHolder2_lbl_barcode').setAttribute('src', Barcode || "defaultLogo.png"); // Set a default image if logo is empty

         //// Set the barcode image
         //const barcodeImg = Barcode ? `data:image/png;base64,${Barcode}` : "defaultLogo.png"; // Default image
         //$('#ContentPlaceHolder2_lbl_barcode').attr('src', barcodeImg);
         //if (Barcode) allFieldsEmpty = false;

         // Display "No Data Available" if all fields are empty
         if (allFieldsEmpty) {
             $("#viewDetails").text("No Data Available");
             $("#viewDetails").css("text-align", "center"); // Center the text for better visibility
         } else {
             $("#viewDetails").css("text-align", ""); // Reset text alignment if data is available
         }

         // Show the modal
         $('#modal-lg').modal('toggle');
         $('#modal-lg').modal('show');
     }
     function printData() {

         var printContents = document.getElementById('viewDetails').innerHTML;
         var originalContents = document.body.innerHTML;

         document.body.innerHTML = printContents;
         document.body.style.color = "black";
         //originalContents.fontsize = '12px';
         window.print();

         document.body.innerHTML = originalContents;

         $('#modal-lg').modal('toggle');

         $('#modal-lg').on('hidden.bs.modal', function () {
             $('.modal-backdrop').remove();  // Removes the backdrop
             $('body').removeClass('modal-open');  // Removes modal-open class from body
         });

     }

     function toggleBarcodeInput() {
         const selectedOption = document.getElementById("barcodeOption").value;
         document.getElementById("barcodeUploadDiv").style.display = selectedOption === "upload" ? "block" : "none";
         document.getElementById("barcodeCameraDiv").style.display = selectedOption === "camera" ? "block" : "none";
     }

     function startCamera() {
         //Logic to start the camera feed and scan barcode
         //document.getElementById("cameraFeed").style.display = "block";
         //added part
         const videoElement = document.getElementById("cameraFeed");
         const barcodeLabel = document.getElementById("scannedBarcodeLabel");
          //Attempt to start the camera feed
             navigator.mediaDevices.getUserMedia({ video: { facingMode: "environment" } })
                 .then(function (stream) {
                     videoElement.srcObject = stream; // Connect camera feed to video element
                     barcodeLabel.textContent = "Scanning..."; // Update the label text
                 })
                 .catch(function (err) {
                     console.error("Error starting camera: ", err);
                     alert('Error accessing the camera.');
                 });
     }

     function stopCamera() {
         //Logic to stop the camera feed 
          //added const 
         const videoElement = document.getElementById("cameraFeed").style.display = "none";
         //added part
         // Stop the video stream
             const stream = videoElement.srcObject;
             if (stream) {
                 const tracks = stream.getTracks();
                 tracks.forEach(track => track.stop()); // Stop all tracks
             }
             videoElement.srcObject = null; // Disconnect the video feed
     }
     const video = document.getElementById('video');
     const barcodeResult = document.getElementById('barcodeResult');
     const btnScan = document.getElementById('btnScan');
     let codeReader;
     let isScanning = false;
     let stream;

      //Toggle between camera and file upload based on dropdown selection
     function toggleInputMethod() {
         const scanOption = document.getElementById('scanOption').value;
        const fileUpload = document.getElementById('<%= fileUploadBarcode.ClientID %>');
         //const btnUpload = document.getElementById('<%= rfvFileUploadBarcode.ClientID %>');

                 if (scanOption === 'camera') {
                     fileUpload.style.display = 'none';
                     btnUpload.style.display = 'none';
                     video.style.display = 'block';
                     btnScan.style.display = 'block';
                 } else if (scanOption === 'upload') {
                     fileUpload.style.display = 'block';
                     btnUpload.style.display = 'block';
                     video.style.display = 'none';
                     btnScan.style.display = 'none';
                     stopScanning();
                     barcodeResult.textContent = 'No barcode detected';
                 }
             }

             function toggleScanning() {
                 if (isScanning) {
                     stopScanning();
                     btnScan.textContent = 'Start Scanning';
                 } else {
                     startScanning();
                     btnScan.textContent = 'Stop Scanning';
                 }
             }

             function startScanning() {
                 if (!codeReader) {
                     codeReader = new ZXing.BrowserBarcodeReader();
                 }

                 navigator.mediaDevices.getUserMedia({ video: { facingMode: "environment" } })
      .then(camStream => {
       stream = camStream;
       video.srcObject = stream;
       video.classList.add('playing');

       codeReader.decodeFromVideoDevice(null, 'video', (result, err) => {
       if (result) {
           barcodeResult.textContent = result.text;
           sendBarcodeToServer(result.text);
       }
       if (err && !(err instanceof ZXing.NotFoundException)) {
                     console.error(err);
                 }
             });
      })
      .catch(err => {
        console.error(err);
        alert('Error accessing the camera: ' + err);
     });
     isScanning = true;
  }

  function stopScanning() {
         if (codeReader) codeReader.reset();
         if (stream) {
             let tracks = stream.getTracks();
             tracks.forEach(track => track.stop());
         }
         video.classList.remove('playing');
         isScanning = false;
     }

     //Function to send barcode to server via AJAX
     function sendBarcodeToServer(barcode) {

         fetch('Entry.aspx/ProcessBarcode', {
         method: 'POST',
      headers: {
                 'Content-Type': 'application/json'
      },
      body: JSON.stringify({ barcodeValue: barcode })
    })
    .then(response => response.json())
    .then(data => console.log('Barcode sent to server:', data))
    .catch(console.error);
  }

   //Update the label with the hidden field value after page load
  window.onload = function () {
         const hiddenField = document.getElementById('<%= hfBarcodeResult.ClientID %>');
      if (hiddenField.value) {
          barcodeResult.textContent = hiddenField.value;
      } else {
          barcodeResult.textContent = 'No barcode detected';
      }
     };


     //function toggleBarcodeInput() {
     //    const selectedOption = document.getElementById("barcodeOption").value;
     //    // Show/hide sections based on dropdown selection
     //    document.getElementById("barcodeUploadDiv").style.display = selectedOption === "upload" ? "block" : "none";
     //    document.getElementById("barcodeCameraDiv").style.display = selectedOption === "camera" ? "block" : "none";

     //    if (selectedOption === 'camera') {
     //        // Start camera when camera option is selected
     //        startCamera();
     //    } else {
     //        // Stop camera when upload option is selected
     //        stopCamera();
     //    }
     //}
     //function startCamera() {
     //    const videoElement = document.getElementById("cameraFeed");
     //    const barcodeLabel = document.getElementById("scannedBarcodeLabel");

     //    // Attempt to start the camera feed
     //    navigator.mediaDevices.getUserMedia({ video: { facingMode: "environment" } })
     //        .then(function (stream) {
     //            videoElement.srcObject = stream; // Connect camera feed to video element
     //            barcodeLabel.textContent = "Scanning..."; // Update the label text
     //        })
     //        .catch(function (err) {
     //            console.error("Error starting camera: ", err);
     //            alert('Error accessing the camera.');
     //        });
     //}

     //function stopCamera() {
     //    const videoElement = document.getElementById("cameraFeed");

     //    // Stop the video stream
     //    const stream = videoElement.srcObject;
     //    if (stream) {
     //        const tracks = stream.getTracks();
     //        tracks.forEach(track => track.stop()); // Stop all tracks
     //    }
     //    videoElement.srcObject = null; // Disconnect the video feed
     //}
     //let codeReader;
     //let isScanning = false;

     //function startScanning() {
     //    if (!codeReader) {
     //        codeReader = new ZXing.BrowserBarcodeReader();
     //    }

     //    navigator.mediaDevices.getUserMedia({ video: { facingMode: "environment" } })
     //        .then(camStream => {
     //            stream = camStream;
     //            video.srcObject = stream;
     //            video.classList.add('playing');

     //            codeReader.decodeFromVideoDevice(null, 'cameraFeed', (result, err) => {
     //                if (result) {
     //                    barcodeResult.textContent = result.text;
     //                    sendBarcodeToServer(result.text);
     //                }
     //                if (err && !(err instanceof ZXing.NotFoundException)) {
     //                    console.error("Scanning error:", err);
     //                }
     //            });
     //        })
     //        .catch(err => {
     //            console.error("Camera access error:", err);
     //            alert('Error accessing the camera: ' + err);
     //        });
     //    isScanning = true;
     //}


     //function stopScanning() {
     //    if (codeReader) codeReader.reset();
     //    isScanning = false;
     //}

     //function sendBarcodeToServer(barcode) {
     //    fetch('Entry.aspx/ProcessBarcode', {
     //        method: 'POST',
     //        headers: { 'Content-Type': 'application/json' },
     //        body: JSON.stringify({ barcodeValue: barcode })
     //    })
     //        .then(response => response.json())
     //        .then(data => console.log('Barcode sent to server:', data))
     //        .catch(console.error);
     //}



 </script>

</asp:Content>

