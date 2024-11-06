<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="UnitMaster.aspx.cs" Inherits="Masters_UnitMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
  <div class="container-fluid">
    <div class="row mb-2">
      <div class="col-sm-6">
        <h1 class="m-0">Add Units </h1>
      </div><!-- /.col -->
      <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
          <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
          <li class="breadcrumb-item active">Add Units </li>
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
                  <label for="exampleInputEmail1">Enter Unit Name</label>
                        <asp:TextBox ID="txtUnitName" runat="server" CssClass="form-control" placeholder="Enter Unit Name" MaxLength="50" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnitName" ErrorMessage="Please Enter Unit name" Display="Dynamic" ValidationGroup="Unit" CssClass="text-red"></asp:RequiredFieldValidator> </div>
             
            </div>
            <!-- /.col -->
            <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">Enter Unit Short Name</label>
               <asp:TextBox ID="txtUnitShortName" runat="server" CssClass="form-control" placeholder="Enter Short Unit Name" MaxLength="50" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUnitShortName" ErrorMessage="Please Enter Short Unit Name" Display="Dynamic" ValidationGroup="Unit" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                  
             
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Unit" TabIndex="3" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="3" CssClass="btn btn-primary" ValidationGroup="Unit" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="4" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>



  
 <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">

            <asp:GridView ID="grdUnit" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdUnit_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
         AutoGenerateColumns="False"  ShowFooter="false"
   CssClass="table table-bordered table-striped"  DataKeyNames="unit_id" EmptyDataText="No Record Found" OnRowCommand="grdUnit_RowCommand" OnRowDataBound="grdUnit_RowDataBound"  OnRowDeleting="grdUnit_RowDeleting"  OnRowUpdating="grdUnit_RowUpdating"   
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
                <asp:TemplateField  HeaderText="UnitID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblUnitID" runat="server" Text='<%# Eval("unit_id")%>' Visible="false"></asp:Label>
                           
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"   Width="80px" />
                    <ItemStyle HorizontalAlign="Center"    Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Name"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                      <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("unit_Name") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit Short Name"  HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                      <asp:Label ID="lblUnitShortName" runat="server" Text='<%# Eval("unit_short_name") %>' ></asp:Label>
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

