<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="SubCategoryMaster.aspx.cs" Inherits="Masters_SubCategoryMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="content-header">
  <div class="container-fluid">
    <div class="row mb-2">
      <div class="col-sm-6">
        <h1 class="m-0">Add SubCategory </h1>
      </div><!-- /.col -->
      <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
          <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
          <li class="breadcrumb-item active">Add SubCategory </li>
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
            <div class="col-md-6">
              <div class="form-group">
                  <label for="exampleInputEmail1">Select Category Name</label>
                <asp:DropDownList ID="ddlCategoryName" runat="server" TabIndex="1" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlCategoryName_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Select Category Name</asp:ListItem>
                        </asp:DropDownList>              
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategoryName" InitialValue="0" ErrorMessage="Please select Unit name" Display="Dynamic" ValidationGroup="SubCategory" CssClass="text-red"></asp:RequiredFieldValidator> </div>
             
            </div>

              <div class="col-md-6">
  <div class="form-group">
      <label for="exampleInputEmail1">Enter Sub Category Name</label>
            <asp:TextBox ID="txtSubCategoryName" runat="server" CssClass="form-control" placeholder="Enter Sub Category Name" MaxLength="50" TabIndex="2"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubCategoryName" ErrorMessage="Please Enter Sub Category name" Display="Dynamic" ValidationGroup="SubCategory" CssClass="text-red"></asp:RequiredFieldValidator> </div>
 
</div>

            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="SubCategory" TabIndex="3" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="3" CssClass="btn btn-primary" ValidationGroup="SubCategory" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="4" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>



  
 <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">

            <asp:GridView ID="grdSubCategory" runat="server" AllowPaging="true" PageSubCategory="10" OnPageIndexChanging="grdSubCategory_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
         AutoGenerateColumns="False"  ShowFooter="false"
   CssClass="table table-bordered table-striped"  DataKeyNames="sub_category_id " EmptyDataText="No Record Found" OnRowCommand="grdSubCategory_RowCommand" OnRowDataBound="grdSubCategory_RowDataBound"  OnRowDeleting="grdSubCategory_RowDeleting"  OnRowUpdating="grdSubCategory_RowUpdating"   
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
                <asp:TemplateField  HeaderText="SubcategoryID " Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblSubCategoryID" runat="server" Text='<%# Eval("sub_category_id ")%>' Visible="false"></asp:Label>
                           
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"   Width="80px" />
                    <ItemStyle HorizontalAlign="Center"    Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                      <asp:Label ID="lblCategoryID" runat="server" Text='<%# Eval("category_id")%>' Visible="false"></asp:Label>
                      <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("category_Name") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Sub Category Name"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                 <asp:Label ID="lblSubCategoryName" runat="server" Text='<%# Eval("sub_category_Name") %>' ></asp:Label>
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
           
    </asp:UpdatePanel>
    

</asp:Content>

