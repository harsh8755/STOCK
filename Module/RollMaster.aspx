<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="RollMaster.aspx.cs" Inherits="Admin_RollMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Add Role </h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
              <li class="breadcrumb-item active">Add Role </li>
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
                  <label for="exampleInputEmail1">Select Admin Name </label>
               <asp:DropDownList ID="ddlAdminName" runat="server" TabIndex="1" CssClass="form-control select2" style="width: 100%;" >
                   <asp:ListItem Value="0">Select Admin Name</asp:ListItem>
               </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAdminName" ErrorMessage="Please select Admin name" InitialValue="0" Display="Dynamic" ValidationGroup="Roll" CssClass="text-red"></asp:RequiredFieldValidator> </div>
             <div class="form-group">
                  <label for="exampleInputEmail1">Select Page</label>
             <br />
                    <asp:ListBox ID="lstPages" runat="server" SelectionMode="Multiple" CssClass="form-control" style="width: 100%;">
    
                     </asp:ListBox><br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstPages" ErrorMessage="Please select Atleast One " InitialValue="" Display="Dynamic" ValidationGroup="Roll" CssClass="text-red"></asp:RequiredFieldValidator> 

             </div>
          
            </div>
            <!-- /.col -->
            <div class="col-md-6">
                 <div class="form-group">
                  <label for="exampleInputEmail1">Select Permission</label>
             <br />
                    <asp:ListBox ID="lstPermission" runat="server" SelectionMode="Multiple" CssClass="form-control" style="width: 100%;">
                          <asp:ListItem Text="Insert" Value="1" />
                          <asp:ListItem Text="Update" Value="2" />
                          <asp:ListItem Text="Delete" Value="3" />
                     </asp:ListBox>
                     <br />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lstPermission" ErrorMessage="Please select Atleast One " InitialValue="" Display="Dynamic" ValidationGroup="Roll" CssClass="text-red"></asp:RequiredFieldValidator> 
             </div>
             
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Roll" TabIndex="2" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="2" CssClass="btn btn-primary" ValidationGroup="Roll" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="3" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>



  
 <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">

            <asp:GridView ID="grdRoll" runat="server" AllowPaging="false" 
         AutoGenerateColumns="False"  ShowFooter="false"
 CssClass="table table-bordered table-striped" DataKeyNames="AdminID" EmptyDataText="No Record Found" OnRowCommand="grdRoll_RowCommand" OnRowDataBound="grdRoll_RowDataBound"  OnRowDeleting="grdRoll_RowDeleting"  OnRowUpdating="grdRoll_RowUpdating"   
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
                <asp:TemplateField HeaderText="Admin Name"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                         <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID") %>'  Visible="false"></asp:Label>
                      <asp:Label ID="lblAdminName" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                
<asp:TemplateField HeaderText="Edit / Delete"   HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                    
                    <ItemTemplate>
                          <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Update" ToolTip="Click To Edit Details"><i class="fa fa-edit"></i></asp:LinkButton> <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete');"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Delete" ToolTip="Click To Delete Record"><i class="fas fa-times"></i></asp:LinkButton>
                        
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
             <asp:PostBackTrigger ControlID="cmdClear" />
               <asp:PostBackTrigger ControlID="grdRoll" />
         </Triggers>
    </asp:UpdatePanel>

   

</asp:Content>




