<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminMaster.aspx.cs" Inherits="Module_AdminMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Add Admin </h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
              <li class="breadcrumb-item active">Add Admin </li>
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
        <div class="box-header with-border">

          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
            <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
          </div>
        </div>
        <!-- /.box-header -->
        <div class="box-body">
          <div class="row">
            <div class="col-md-6">
              <div class="form-group">
                  <label for="exampleInputEmail1">Admin Name</label>
               <asp:TextBox ID="txtAdminName" runat="server" CssClass="form-control" placeholder="Enter Admin Name" MaxLength="50" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Enter Admin Name" Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RequiredFieldValidator>

                </div>
             <div class="form-group">
                  <label for="exampleInputEmail1">Email ID</label>
               <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control" placeholder="Enter Email ID (If Any)" MaxLength="50" TabIndex="3"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" ControlToValidate="txtEmailID"  ErrorMessage="Enter Valid Email ID" Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <!-- /.col -->
            <div class="col-md-6">
              <div class="form-group">
                  <label for="exampleInputEmail1">Mobile No.</label>
               <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile No. (If Any)" MaxLength="10" TabIndex="2"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[6-9]\d{9}$" ControlToValidate="txtMobile"  ErrorMessage="Enter Valid Mobile No." Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RegularExpressionValidator>
                </div>
              <div class="form-group">
                  <label for="exampleInputEmail1">Photo(Size Less Then 5 MB)</label> <br />
               <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="4" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression=".*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG]|[bB][mM][pP])$" ControlToValidate="FileUpload1"  ErrorMessage="Upload Only jpeg,gif,png Pics" Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RegularExpressionValidator>
                    <asp:Label ID="lblPath" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <!-- /.col -->
          </div>
            <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                  <label for="exampleInputEmail1">Login ID</label>
               <asp:TextBox ID="txtLoginID" runat="server" CssClass="form-control" placeholder="Enter Login ID of 20 Characters only" MaxLength="20" TabIndex="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginID" ErrorMessage="Enter Login ID " Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RequiredFieldValidator>

                </div>
                  
                </div>
                   <div class="col-md-6"><div class="form-group">
                  <label for="exampleInputEmail1">Password</label>
               <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Create Password " MaxLength="15" TabIndex="6"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password " Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RequiredFieldValidator>

                </div>
                       </div>
                </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Admin" TabIndex="7" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="8" CssClass="btn btn-primary" ValidationGroup="Admin" Visible="false" OnClick="cmdUpdate_Click"  /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="9" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>
            <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">
            <asp:GridView ID="grdAdmin" runat="server" AllowPaging="false" 
         AutoGenerateColumns="False" ShowFooter="false"
    CssClass="table table-bordered table-striped" DataKeyNames="AdminID" EmptyDataText="No Record Found" OnRowCommand="grdAdmin_RowCommand" OnRowDataBound="grdAdmin_RowDataBound"  OnRowDeleting="grdAdmin_RowDeleting"  OnRowUpdating="grdAdmin_RowUpdating"   
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
                <asp:TemplateField  HeaderText="AdminID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblAdminID" runat="server" Text='<%# Eval("AdminID")%>' Visible="false"></asp:Label>
                           
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"    />
                    <ItemStyle HorizontalAlign="Center"   />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Admin Name"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        
                      <asp:Label ID="lblAdminName" runat="server" Text='<%# Eval("Name") %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Email ID"   HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        
                      <asp:Label ID="lblEmailID" runat="server"  Text='<%# Eval("EmailID").ToString() == "" ? "N/A" : Eval("EmailID").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile No." HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        
                      <asp:Label ID="lblMobile" runat="server"  Text='<%# Eval("Mobile").ToString() == "" ? "N/A" : Eval("Mobile").ToString() %>' ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Login ID"  HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                        
                      <asp:Label ID="LblLoginID" runat="server" Text='<%# Eval("LoginID") %>' ></asp:Label>
                         <asp:Label ID="LblPassword" runat="server" Text='<%# Eval("Password") %>' Visible="false" ></asp:Label>
                         <asp:Label ID="lblPath" runat="server" Text='<%# Eval("PicURL") %>' Visible="false" ></asp:Label>
                    </ItemTemplate>
                  
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                    
                </asp:TemplateField>
               
<asp:TemplateField HeaderText="Edit / Block / Delete"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                    
                    <ItemTemplate>
                        
                        
                         <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Update"  ToolTip="Click For Edit"><i class="fa fa-edit"></i></asp:LinkButton> <asp:LinkButton ID="lnkBlock" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Block" OnClientClick="return confirm('Are you sure you want Block this Account');" Visible='<%# DataBinder.Eval(Container.DataItem, "BlockStatus").ToString() == "N" %>' ToolTip="Click For Block Account"><i class="fa fa-fw fa-unlock"></i></asp:LinkButton> <asp:LinkButton ID="LnkUnblock" runat="server" OnClientClick="return confirm('Are you sure you want Unblock this Account');"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Unblock" Visible='<%# DataBinder.Eval(Container.DataItem, "BlockStatus").ToString() == "Y" %>' ToolTip="Click For Unblock Account" ><i class="fa fa-fw fa-lock"></i></asp:LinkButton>  <asp:LinkButton ID="lnkDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete');"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Delete"   ToolTip="Click For Delete ">  <i class="fas fa-times"></i></asp:LinkButton>
                        
                        
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
</asp:Content>
