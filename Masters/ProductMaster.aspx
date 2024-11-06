<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ProductMaster.aspx.cs" Inherits="Masters_ProductMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <div class="content-header">
  <div class="container-fluid">
    <div class="row mb-2">
      <div class="col-sm-6">
        <h1 class="m-0">Add Product </h1>
      </div><!-- /.col -->
      <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
          <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
          <li class="breadcrumb-item active">Add Product </li>
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="0" ControlToValidate="ddlCategoryName" ErrorMessage="Please Select Category" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator>

                      </div>
                </div>

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Sub Category</label>
                 <asp:DropDownList ID="ddlSubCategoryName" runat="server" TabIndex="2" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlSubCategoryName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Sub Category Name</asp:ListItem>
                   </asp:DropDownList>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0" ControlToValidate="ddlSubCategoryName" ErrorMessage="Please Select Sub Category" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Unit</label>
                 <asp:DropDownList ID="ddlUnitName" runat="server" TabIndex="3" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlUnitName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Unit Name</asp:ListItem>
                   </asp:DropDownList> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ControlToValidate="ddlUnitName" ErrorMessage="Please Select Unit" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Size</label>
                 <asp:DropDownList ID="ddlSizeName" runat="server" TabIndex="4" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlSizeName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Size Name</asp:ListItem>
                   </asp:DropDownList>   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0" ControlToValidate="ddlSizeName" ErrorMessage="Please Select Size" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>
        </div>

            <div class="row">

               <div class="col-md-3">
                 <div class="form-group">
                 <label for="exampleInputEmail1">Select Color</label>
                 <asp:DropDownList ID="ddlColorName" runat="server" TabIndex="5" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlColorName_SelectedIndexChanged" AutoPostBack="true">
                      <asp:ListItem Value="0">Select Color Name</asp:ListItem>
                   </asp:DropDownList>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" InitialValue="0" ControlToValidate="ddlColorName" ErrorMessage="Please Select color" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator>

                     </div>
                 </div>

                 <div class="col-md-3">
                    <div class="form-group">
                 <label for="exampleInputEmail1">Enter Product Name</label>
                 <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Enter Product Name" MaxLength="50" TabIndex="6"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProductName" ErrorMessage="Please Enter Product Name" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                </div>

             <div class="col-md-3">
             <div class="form-group">
             <label for="exampleInputEmail1">Enter Product Code</label>
                <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control" placeholder="Enter Product Code" MaxLength="50" TabIndex="7"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductCode" ErrorMessage="Please Enter Product Name" Display="Dynamic" ValidationGroup="Product" CssClass="text-red"></asp:RequiredFieldValidator> </div>
        </div>

             <div class="col-md-3">
                  <div class="form-group">
               <label for="exampleInputEmail1">Product Image</label>
                 <asp:FileUpload ID="ProductImage" runat="server" TabIndex="8" AllowMultiple="true"/>
                  <asp:RegularExpressionValidator ID="eventregex" runat="server" ErrorMessage="Please Select Only Jpeg / PNG /JPG files" ControlToValidate="ProductImage" Display="Dynamic" ValidationGroup="Product" CssClass="text-danger" ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)"></asp:RegularExpressionValidator>
            </div>
  <!-- /.col -->
</div>

            </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Product" TabIndex="9" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="9" CssClass="btn btn-primary" ValidationGroup="Product" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="10" OnClick="cmdClear_Click"/>
             <br />
            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>
 <br />

            <div class="card-body table-responsive p-0" style="height: 300px;">
            <asp:GridView ID="grdProduct" runat="server" AllowPaging="true" PageProduct="10" OnPageIndexChanging="grdProduct_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
         AutoGenerateColumns="False"  ShowFooter="false"
   CssClass="table table-bordered table-striped"  DataKeyNames="product_id" EmptyDataText="No Record Found" OnRowCommand="grdProduct_RowCommand" OnRowDataBound="grdProduct_RowDataBound"  OnRowDeleting="grdProduct_RowDeleting"  OnRowUpdating="grdProduct_RowUpdating">
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
                <asp:TemplateField  HeaderText="ProductID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("product_id")%>' Visible="false"></asp:Label>
                           
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

               <asp:TemplateField HeaderText="Product Name"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                 <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("product_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Product Code" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="lblProductCode" runat="server" Text='<%# Eval("product_Code") %>' ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                 <ItemTemplate>
                  <a onclick="ViewProductImages('<%# Eval("image_URLs").ToString().Replace("\\\"", "\"").Replace("\\/", "/") %>')"><i class="fa fa-eye"></i></a>
                 <%--<a onclick="ViewProductImages('<%# Eval("image_URLs").ToString().Replace("\"", "\\\"")%>')"><i class="fa fa-eye"></i></a>--%>
                <%--<a onclick="ViewProductImages('<%# Newtonsoft.Json.JsonConvert.SerializeObject(Eval("image_URLs")) %>')"><i class="fa fa-eye"></i></a>--%>


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
           </Triggers>
    </asp:UpdatePanel>

    <%-- <div class="modal fade" id="modal-lg">
     <div class="modal-dialog modal-lg">
       <div class="modal-content">
         <div class="modal-header">
           <h4 class="modal-title">Product Images</h4>
           <button type="button" class="close" data-dismiss="modal" aria-label="Close">
             <span aria-hidden="true">&times;</span>
           </button>
         </div>
           <div class="modal-body">
  <div class="row">
      <div class="col-md-4">
                     <asp:Image ID="lbl_ProductImage" runat="server" style="height:240px; width:180px" />
             </div>
      </div>
              </div>
            </div>
      <div class="modal-footer justify-content-between">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
    <!-- /.modal-content -->
  </div>--%>

    <!-- Modal Structure -->

<!-- Bootstrap Modal -->
<div class="modal fade" id="imageModal" tabindex="-1" aria-labelledby="imageModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="imageModalLabel">Product Images</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div id="imageGallery" class="row"></div>
            </div>
        </div>
    </div>
</div>


    <script type="text/javascript">
        //function ViewProductImages(logo) {
        //    document.getElementById('ContentPlaceHolder2_lbl_ProductImage').setAttribute('src','../'+ logo || "defaultLogo.png"); // Set a default image if image gallery is empty

        //    // Show the modal
        //    $('#modal-lg').modal('toggle');
        //    $('#modal-lg').modal('show');
        //}

        //function ViewProductImages(jsonString) {
        //    // Parse the JSON string into a JavaScript object
        //    var imageArray = JSON.parse(jsonString);

        //    // Get the modal body element where the images will be displayed
        //    var modalBody = document.getElementById("modal-body-content");

        //    // Clear any existing content in the modal body
        //    modalBody.innerHTML = "";

        //    // Loop through the image URLs and add them to the modal body
        //    imageArray.forEach(function (image) {
        //        // Create an image element
        //        var imgElement = document.createElement("img");
        //        imgElement.src = image.image_Url.replace("~", ""); // Adjust the image path if needed
        //        imgElement.classList.add("img-fluid", "m-2"); // Add Bootstrap classes for styling
        //        imgElement.style.maxWidth = "150px"; // Set image size

        //        // Append the image to the modal body
        //        modalBody.appendChild(imgElement);
        //    });

        //    // Show the modal (Bootstrap modal trigger)
        //    //var myModal = new bootstrap.Modal(document.getElementById('imageModal'));
        //    //myModal.show();

        //    $('#modal-lg').modal('toggle');
        //    $('#modal-lg').modal('show');
       
        function ViewProductImages(imageURLs) {
            debugger;
            // Parse the JSON string into an object
            let images = JSON.parse(imageURLs);
            // Clear the existing images in the gallery
            const gallery = document.getElementById('imageGallery');
            gallery.innerHTML = '';

            // Loop through the images and create image elements
            images.forEach(imageObj => {
                const colDiv = document.createElement('div');
                colDiv.className = 'col-4'; // Change to desired column size (e.g., col-4 for 3 columns)
                colDiv.innerHTML = `<img src="${imageObj.image_Url}" class="img-fluid" alt="Product Image" />`;
                gallery.appendChild(colDiv);
            });

            // Show the modal
            //var modal = new bootstrap.Modal(document.getElementById('imageModal'));
            //modal.show();
            $('#imageMoal').modal('toggle');
            $('#imageModal').modal('show');
        }


    </script>

</asp:Content>

