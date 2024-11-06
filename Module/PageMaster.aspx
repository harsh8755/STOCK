<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PageMaster.aspx.cs" Inherits="Page_PageMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Add Page </h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
              <li class="breadcrumb-item active">Add Page </li>
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
                  <label for="exampleInputEmail1">Select Module Name</label>
               <asp:DropDownList ID="ddlModuleName" runat="server" TabIndex="1" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlModuleName_SelectedIndexChanged" AutoPostBack="true">
                   <asp:ListItem Value="0">Select Module Name</asp:ListItem>
               </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlModuleName" ErrorMessage="Please select module name" InitialValue="0" Display="Dynamic" ValidationGroup="Page" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                <div class="form-group">
                  <label for="exampleInputEmail1">Page Link</label>
               <asp:TextBox ID="txtPageLink" runat="server" CssClass="form-control" placeholder="Enter Page Name" MaxLength="50" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPageLink" ErrorMessage="Enter Page Link" Display="Dynamic" ValidationGroup="Page" CssClass="text-red"></asp:RequiredFieldValidator> </div>
             
            </div>
            <!-- /.col -->
            <div class="col-md-6">
              <div class="form-group">
                  <label for="exampleInputEmail1">Page Name</label>
               <asp:TextBox ID="txtPageName" runat="server" CssClass="form-control" placeholder="Enter Page Name" MaxLength="50" TabIndex="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPageName" ErrorMessage="Enter Page Name" Display="Dynamic" ValidationGroup="Page" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                
             
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Page" TabIndex="4" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="5" CssClass="btn btn-primary" ValidationGroup="Page" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="6" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>
            
             <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">


            <asp:GridView ID="grdPage" runat="server" AllowPaging="false"
         AutoGenerateColumns="False" ShowFooter="false"
 CssClass="table table-bordered table-striped" DataKeyNames="PageID" EmptyDataText="No Record Found" OnRowCommand="grdPage_RowCommand" OnRowDataBound="grdPage_RowDataBound"  OnRowDeleting="grdPage_RowDeleting"  OnRowUpdating="grdPage_RowUpdating"   
         >
       
            <EmptyDataRowStyle CssClass="fnt_val" />
           
           <Columns>
                <asp:TemplateField  HeaderText="S.No" Visible="True"  >
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
                <asp:TemplateField  HeaderText="PageID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblPageID" runat="server" Text='<%# Eval("PageID")%>' Visible="false"></asp:Label>
                           
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"   Width="80px" />
                    <ItemStyle HorizontalAlign="Center"    Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Module Name"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                         <asp:Label ID="lblModuleID" runat="server" Text='<%# Eval("ModuleID") %>'  Visible="false"></asp:Label>
                      <asp:Label ID="lblModuleName" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Page Name"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        
                      <asp:Label ID="lblPageName" runat="server" Text='<%# Eval("PageName") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Page Link"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        
                      <asp:Label ID="lblPageLink" runat="server" Text='<%# Eval("PageLink") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Priority"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                           <asp:Label ID="lblPriority" runat="server" Text='<%# Eval("Priority") %>' Visible="false"></asp:Label>
                <asp:LinkButton ID="lnkUp" CssClass="button" CommandArgument = "up" runat="server" OnClick="ChangePreference" ToolTip="Click To Up Record"> <i class="fas fa-arrow-up"></i></asp:LinkButton>
                <asp:LinkButton ID="lnkDown" CssClass="button" CommandArgument = "down" runat="server"  OnClick="ChangePreference" ToolTip="Click To Down Record"><i class="fas fa-arrow-down"></i> </asp:LinkButton>

                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
<asp:TemplateField HeaderText="Edit / Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                    
                    <ItemTemplate>
                        
                        
                          <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Update" ToolTip="Click To Edit Details"><i class="fa fa-edit"></i></asp:LinkButton> <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete');"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Delete" ToolTip="Click To Delete Record"><i class="fas fa-times"></i></asp:LinkButton>
                        
                        
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


