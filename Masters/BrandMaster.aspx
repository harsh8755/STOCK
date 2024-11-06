<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BrandMaster.aspx.cs" Inherits="Masters_BrandMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="content-header">
  <div class="container-fluid">
    <div class="row mb-2">
      <div class="col-sm-6">
        <h1 class="m-0">Add Brand </h1>
      </div><!-- /.col -->
      <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
          <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
          <li class="breadcrumb-item active">Add Brand </li>
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
              <div class="col-md-4">
  <div class="form-group">
      <label for="exampleInputEmail1">Enter Brand Name</label>
            <asp:TextBox ID="txtBrandName" runat="server" CssClass="form-control" placeholder="Enter Brand Name" MaxLength="50" TabIndex="1"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBrandName" ErrorMessage="Please Enter Brand name" Display="Dynamic" ValidationGroup="Brand" CssClass="text-red"></asp:RequiredFieldValidator> </div>
 
</div>
            <div class="col-md-4">
               <div class="form-group">
                  <label for="exampleInputEmail1">Enter Brand Short Name</label>
               <asp:TextBox ID="txtBrandShortName" runat="server" CssClass="form-control" placeholder="Enter Brand Short Name" MaxLength="50" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrandShortName" ErrorMessage="Please Enter Short Brand Name" Display="Dynamic" ValidationGroup="Brand" CssClass="text-red"></asp:RequiredFieldValidator> </div>   
            </div>
              
              <div class="col-md-4">
               <div class="form-group">
                  <label for="exampleInputEmail1">Upload Logo</label>
               <asp:FileUpload ID="BrandLogo" runat="server" TabIndex="3"/>
                <asp:RegularExpressionValidator ID="eventregex" runat="server" ErrorMessage="Please Select Only Jpeg / PNG /JPG files" ControlToValidate="BrandLogo" Display="Dynamic" ValidationGroup="Brand" CssClass="text-danger" ValidationExpression="(.*png$)|(.*jpg$)|(.*jpeg$)"></asp:RegularExpressionValidator>
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Brand" TabIndex="4" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="4" CssClass="btn btn-primary" ValidationGroup="Brand" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="5" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>



  
 <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">

            <asp:GridView ID="grdBrand" runat="server" AllowPaging="true" PageBrand="10" OnPageIndexChanging="grdBrand_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
         AutoGenerateColumns="False"  ShowFooter="false"
   CssClass="table table-bordered table-striped"  DataKeyNames="brand_id" EmptyDataText="No Record Found" OnRowCommand="grdBrand_RowCommand" OnRowDataBound="grdBrand_RowDataBound"  OnRowDeleting="grdBrand_RowDeleting"  OnRowUpdating="grdBrand_RowUpdating"   
         >
       
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
                <asp:TemplateField  HeaderText="BrandID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblBrandID" runat="server" Text='<%# Eval("brand_id")%>' Visible="false"></asp:Label>
                           
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"   Width="80px" />
                    <ItemStyle HorizontalAlign="Center"    Width="80px" />
                </asp:TemplateField>
                
               <asp:TemplateField HeaderText="Brand Name"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                 <asp:Label ID="lblBrandName" runat="server" Text='<%# Eval("brand_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Brand Short Name"  HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="lblBrandShortName" runat="server" Text='<%# Eval("brand_short_name") %>' ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="View Logo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                 <ItemTemplate>
              <a onclick="ViewBrandLogo('<%# Eval("Brand_logo_url") %>')"><i class="fa fa-eye"></i></a>
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

     <div class="modal fade" id="modal-lg">
     <div class="modal-dialog modal-sm">
       <div class="modal-content">
         <div class="modal-header">
           <h4 class="modal-title">Brand Logo</h4>
           <button type="button" class="close" data-dismiss="modal" aria-label="Close">
             <span aria-hidden="true">&times;</span>
           </button>
         </div>
           <div class="modal-body">
  <div class="row">
      <div class="col-md-12">
                     <asp:Image ID="lbl_BrandImage" runat="server" style="height:240px; width:180px" />
             </div>
      </div>
              </div>
            </div>
      <div class="modal-footer justify-content-between">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
    <!-- /.modal-content -->
  </div>

    <script type="text/javascript">
        function ViewBrandLogo(logo) {
            document.getElementById('ContentPlaceHolder2_lbl_BrandImage').setAttribute('src', '../'+logo || "defaultLogo.png"); // Set a default image if logo is empty

            // Show the modal
            $('#modal-lg').modal('toggle');
            $('#modal-lg').modal('show');
        }
    </script>

</asp:Content>

