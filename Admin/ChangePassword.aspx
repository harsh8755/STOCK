<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Settings </h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
              <li class="breadcrumb-item active">Update Profile </li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <div class="box box-primary">
        <!-- /.box-header -->
        <div class="box-body">
          <div class="row">
            <div class="col-md-6">
              <div class="form-group">
                  <label for="exampleInputEmail1">Admin Name</label>
               <asp:TextBox ID="txtAdminName" runat="server" CssClass="form-control" placeholder="Enter Admin Name" MaxLength="50" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminName" ErrorMessage="Enter Admin Name" Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RequiredFieldValidator>

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
                  <label for="exampleInputEmail1">Photo (Size Less Then 5 MB)</label> <br />
               <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="4" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression=".*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG]|[bB][mM][pP])$" ControlToValidate="FileUpload1"  ErrorMessage="Upload Only jpeg,gif,png Pics" Display="Dynamic" ValidationGroup="Admin" CssClass="text-red"></asp:RegularExpressionValidator>
                    <asp:Label ID="lblPath" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <!-- /.col -->
          </div>
            
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
                <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="5" CssClass="btn btn-primary" ValidationGroup="Admin" Visible="true" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear2" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="6" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg1" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>

 <div class="box box-primary">
        <br />
          <h3 class="m-0">Change Password</h3>

       
        <!-- /.box-header -->
        <div class="box-body">
          <div class="row">
            <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">Old Password</label>
               <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" placeholder="Enter Old Password" TextMode="Password" MaxLength="50" TabIndex="7"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword" ErrorMessage="Enter Old Password" Display="Dynamic" ValidationGroup="module" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                <div class="form-group">
                  <label for="exampleInputEmail1">Confirm New Password</label>
               <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="form-control" placeholder="Enter New Password" TextMode="Password" MaxLength="50" TabIndex="9"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmNewPassword" ErrorMessage="Enter again New Password" Display="Dynamic" ValidationGroup="module" CssClass="text-red"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Matched" Display="Dynamic" ValidationGroup="module" CssClass="text-red" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword"></asp:CompareValidator>


         </div>
            </div>
            <!-- /.col -->
            <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">New Password</label>
               <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter New Password" TextMode="Password" MaxLength="50" TabIndex="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="Enter New Password" Display="Dynamic" ValidationGroup="module" CssClass="text-red"></asp:RequiredFieldValidator> </div>
    
             
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
      
              <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Change Password" CssClass="btn btn-primary" ValidationGroup="module" TabIndex="10" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="11" OnClick="cmdClear_Click1"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>

            </ContentTemplate>
           <Triggers>
               <asp:PostBackTrigger ControlID="cmdUpdate" />
           </Triggers>
           </asp:UpdatePanel>
</asp:Content>

