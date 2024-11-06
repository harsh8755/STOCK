<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default1" %>



<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>STOCK</title>
  <link rel="icon" type="image/x-icon" href="../dist/img/favicon.ico">
  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <!-- /.login-logo -->
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
      <a href="#" class="h1"><b>Admin</b>STOCK</a>
    </div>
    <div class="card-body">
      <p class="login-box-msg">Sign in to start your session</p>
 
      <form  runat="server" id="form1">
        <div class="input-group mb-3">
          
          <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="USER ID" TabIndex="1" ></asp:TextBox>
     
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
         
        </div> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="User ID is Required" Display="Dynamic" ValidationGroup="Frm" CssClass="text-red"></asp:RequiredFieldValidator>
        <div class="input-group mb-3">
          
          <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TabIndex="2" TextMode="Password"></asp:TextBox>
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
          </div>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is Required" Display="Dynamic" ValidationGroup="Frm" ControlToValidate="txtPassword" CssClass="text-red"></asp:RequiredFieldValidator> 
        
        <div class="row">
          <div class="col-8">
           
          </div>
          <!-- /.col -->
          <div class="col-4">

            <asp:Button ID="btnlogin" runat="server" Text="Sign In" CssClass="btn btn-primary btn-block" ValidationGroup="Frm" TabIndex="3"/>
          </div>
          <!-- /.col -->
        </div>
      </form>

             

      <%--<p class="mb-1">
        <a href="forgot-password.html">I forgot my password</a>
      </p>
      <p class="mb-0">
        <a href="register.html" class="text-center">Register a new membership</a>
      </p>--%>
    </div>
    <!-- /.card-body -->
  </div>
  <!-- /.card -->
</div>
<!-- /.login-box -->
  <div class="modal modal-danger fade" id="modal-danger">
          <div class="modal-dialog">
            <div class="modal-content" style="background-color:#f13b4d;">
              <div class="modal-header"><h4 class="modal-title">Failed Message</h4>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span></button>
                
              </div>
              <div class="modal-body">
                
              </div>
              <%--<div class="modal-footer">
                <button type="button" class="btn btn-outline pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-outline">Save changes</button>
              </div>--%>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
<!-- jQuery -->
<script src="../../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../../dist/js/adminlte.min.js"></script>
    <script src="https://unpkg.com/@lottiefiles/lottie-player@latest/dist/lottie-player.js"></script>
  <script type="text/javascript">
      $(function () {
         
      $("[id*=btnlogin]").bind("click", function () {
        var user = {};
        user.Username = $("[id*=txtUsername]").val();
        user.Password = $("[id*=txtPassword]").val();
        $.ajax({
          type: "POST",
          url: "Default.aspx/ValidateUser",
          data: '{user: ' + JSON.stringify(user) + '}',
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function (response) {
            if (response.d === 'Success') {
              window.location.replace("Admin/Default.aspx");
              //$('#modal-success').modal('toggle');
              //$('#modal-success').modal('show');
              //$(".modal-body").text(response.d);

            }
            else {
              //alert(response.d);
              $('#modal-danger').modal('toggle');
              $('#modal-danger').modal('show');
                $(".modal-body").html('<center><lottie-player src="https://lottie.host/0745acb5-378a-45a9-a0c8-d158945a480b/26MIyiTzAg.json" background="transparent"  speed="2"  style="width: 300px; height: 300px;" loop autoplay></lottie-player> </br>'+response.d+'</center>');

            }
            //alert(response.d);
          }
        });
        return false;
      });
    });
      
  </script>
</body>
</html>
