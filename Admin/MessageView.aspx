<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageView.aspx.cs" Inherits="Admin_MessageView" %>


<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>CYS | Contacts US</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
      <link rel="stylesheet" href="../../plugins/summernote/summernote-bs4.min.css">
     <link rel="stylesheet" href="../../plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css">
  <!-- Toastr -->
  <link rel="stylesheet" href="../../plugins/toastr/toastr.min.css">
</head>
<body>


 
  
  
  <div>
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>Enquire With Us</h1>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
              <li class="breadcrumb-item active">Enquire With Us</li>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">
        
      <!-- Default box -->
      <div class="card card-solid">
        <div class="card-body pb-0">
            <div class="row" id="Search_Row">
             
          
                
                    <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">Search By Text</label>
              <input type="text" class="form-control" placeholder="Enter Text,Name,EmailID,Mobile No." id="txt_text" onchange="ViewMSG();">
                   </div>
                  </div>
             <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">Search By Status</label>
               <select class="form-control select2" style="width: 100%;" id="ddlMsgStatus" onchange="ViewMSG();">
                   <option value="" >All </option> 
                   <option  value="Y">Read</option>
                    <option value="N" selected="selected">Unread</option>

                  </select>
               </div>
            </div>
           
               

        Results( <label id="Result_count"></label> )
         
            
           
          </div>
            
          <div class="row" id="DLMSG">
            
           
          </div>
        </div>
      </div>
    </section>

       <div class="modal fade" id="modal-lg">
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Enquire With Us<Label ID="lblContactUsID" style="color:white"></Label></h4>
                <br />
                

              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <div class="row">
               <!-- /.col -->
            <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">Name</label>
                    : <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
               </div>
            </div>
 <div class="col-md-6">
               <div class="form-group">
                 <label for="exampleInputEmail1">Email ID</label>
                    : <asp:Label ID="lblEmailID" runat="server" Text=""></asp:Label>  
               </div>
            </div>
            </div>
                <div class="row">
               <!-- /.col -->
            <div class="col-md-6">
               <div class="form-group">
                  <label for="exampleInputEmail1">Phone </label>
                    : <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
               </div>
            </div>
 <div class="col-md-6">
               <div class="form-group">
                 <label for="exampleInputEmail1">Recieve @</label>
                    : <asp:Label ID="lblCreateDate" runat="server" Text=""></asp:Label>  
               </div>
            </div>
            </div>
                <div class="row">
               <div class="form-group">
                  <label for="exampleInputEmail1">Message </label>
                    : <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
               </div>
          
 
            </div>
                <div class="row" id="Reply_Row">
               <!-- /.col -->

               <div class="form-group">
                 <label for="exampleInputEmail1">Response</label>
                    : <asp:Label ID="lblReply" runat="server" Text=""></asp:Label>  
                  <label for="exampleInputEmail1">Response @ </label>
                    : <asp:Label ID="lbl_Reply_at" runat="server" Text=""></asp:Label>
               </div>
           
            </div>
                 <div class="row" id="Submit_Row">
               <!-- /.col -->
           
               <div class="form-group">
                  <label for="exampleInputEmail1">Response  </label>
                    : <textarea id="summernote"> </textarea>
               </div>
          
 
            </div>
                <div class="row" id="Submit_Button">
               <!-- /.col -->
           
               <div class="form-group">
                   <a href="#" class="btn btn-sm btn-primary" onclick="UnreadMsg()">  Submit</a>
                  
               </div>
          
 
            </div>
            </div>
            <div class="modal-footer justify-content-between">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                

            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>

  </div>
  




<!-- jQuery -->
<script src="../../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../../dist/js/adminlte.min.js"></script>
    <!-- Summernote -->
<script src="../../../plugins/summernote/summernote-bs4.min.js"></script>
    <script src="../../../plugins/sweetalert2/sweetalert2.min.js"></script>
    <script src="../../../plugins/toastr/toastr.min.js"></script>
    
    <script>
        $(function () {
            var Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            });

            $('.swalDefaultSuccess').click(function () {
                Toast.fire({
                    icon: 'success',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultInfo').click(function () {
                Toast.fire({
                    icon: 'info',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultError').click(function () {
                Toast.fire({
                    icon: 'error',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultWarning').click(function () {
                Toast.fire({
                    icon: 'warning',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.swalDefaultQuestion').click(function () {
                Toast.fire({
                    icon: 'question',
                    title: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });

            $('.toastrDefaultSuccess').click(function () {
                toastr.success('Lorem ipsum dolor sit amet, consetetur sadipscing elitr.')
            });
            $('.toastrDefaultInfo').click(function () {
                toastr.info('Lorem ipsum dolor sit amet, consetetur sadipscing elitr.')
            });
            $('.toastrDefaultError').click(function () {
                toastr.error('This iS Error Message')
            });
            $('.toastrDefaultWarning').click(function () {
                toastr.warning('Lorem ipsum dolor sit amet, consetetur sadipscing elitr.')
            });

            $('.toastsDefaultDefault').click(function () {
                $(document).Toasts('create', {
                    title: 'Toast Title',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultTopLeft').click(function () {
                $(document).Toasts('create', {
                    title: 'Toast Title',
                    position: 'topLeft',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultBottomRight').click(function () {
                $(document).Toasts('create', {
                    title: 'Toast Title',
                    position: 'bottomRight',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultBottomLeft').click(function () {
                $(document).Toasts('create', {
                    title: 'Toast Title',
                    position: 'bottomLeft',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultAutohide').click(function () {
                $(document).Toasts('create', {
                    title: 'Toast Title',
                    autohide: true,
                    delay: 750,
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultNotFixed').click(function () {
                $(document).Toasts('create', {
                    title: 'Toast Title',
                    fixed: false,
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultFull').click(function () {
                $(document).Toasts('create', {
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    icon: 'fas fa-envelope fa-lg',
                })
            });
            $('.toastsDefaultFullImage').click(function () {
                $(document).Toasts('create', {
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    image: '../../dist/img/user3-128x128.jpg',
                    imageAlt: 'User Picture',
                })
            });
            $('.toastsDefaultSuccess').click(function () {
                $(document).Toasts('create', {
                    class: 'bg-success',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultInfo').click(function () {
                $(document).Toasts('create', {
                    class: 'bg-info',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultWarning').click(function () {
                $(document).Toasts('create', {
                    class: 'bg-warning',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultDanger').click(function () {
                $(document).Toasts('create', {
                    class: 'bg-danger',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
            $('.toastsDefaultMaroon').click(function () {
                $(document).Toasts('create', {
                    class: 'bg-maroon',
                    title: 'Toast Title',
                    subtitle: 'Subtitle',
                    body: 'Lorem ipsum dolor sit amet, consetetur sadipscing elitr.'
                })
            });
        });
        
</script>
    <script>
        $(function () {
            ViewMSG();
            // Summernote
            $('#summernote').summernote();
            var Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 3000
            });

        });
        function ViewMSG() {
            var DLMSG = $("#DLMSG");
            DLMSG.html('');
            var HTML_FOR = '';
            var sno = 1;
            let url = new URL(document.location);
            let USID1 = url.searchParams.get("ContactUSID");
            var ContactUSID1 = USID1;
            var ddlMsgStatus = $("#ddlMsgStatus").val();
            var txt_text = $("#txt_text").val();
            if (ContactUSID1 === null) {
                $("#Search_Row").show();
            } else {
                $("#Search_Row").hide();
            }
            $.ajax({
                type: "POST",
                url: "MessageView.aspx/BindViewMSG",
                data: '{ContactUSID: \'' + ContactUSID1 + '\',ReadStatus: \'' + ddlMsgStatus + '\',textmsg: \'' + txt_text + '\'}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $(response.d).find('Table1').each(function (index) {
                        var Name = $(this).find('Name').text();
                        var Mobile = $(this).find('Mobile').text();
                        var Email = $(this).find('Email').text();
                        var Message = $(this).find('Message').text();
                        var CreateDate = $(this).find('CreateDate').text();
                        var ContactUSID = $(this).find('ContactUSID').text();
                        var Reply = $(this).find('Reply').text();
                        var ReadStatus = $(this).find('ReadStatus').text();
                        var ReadDate = $(this).find('ReadDate').text();
                        var Parameter = Name + ',' + Mobile + ', ' + Email + ', ' + Message + ', ' + CreateDate + ', ' + ContactUSID + ', ' + Reply + ', ' + ReadStatus + ', ' + ReadDate;
                        //alert(Parameter)
                        HTML_FOR = HTML_FOR + ' <div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">';
                        HTML_FOR = HTML_FOR + ' <div class="card bg-light d-flex flex-fill">';
                        HTML_FOR = HTML_FOR + ' <div class="card-header text-muted border-bottom-0">';
                        HTML_FOR = HTML_FOR + timeAgo(CreateDate);
                        if (ReadStatus === 'N') {
                            HTML_FOR = HTML_FOR + '   <span class="float-right text-sm text-danger"><i class="fas fa-star"></i></span>';
                        }
                        HTML_FOR = HTML_FOR + ' </div>';
                        HTML_FOR = HTML_FOR + '   <div class="card-body pt-0">';
                        HTML_FOR = HTML_FOR + '<div class="row">';
                        HTML_FOR = HTML_FOR + '<div class="col-7">';
                        HTML_FOR = HTML_FOR + ' <h2 class="lead"><b>' + Name + '</b></h2>';
                        HTML_FOR = HTML_FOR + '<p class="text-muted text-sm"><b>Message: </b>' + truncateText(Message,100) + '</p>';
                        HTML_FOR = HTML_FOR + '<ul class="ml-4 mb-0 fa-ul text-muted">';
                        HTML_FOR = HTML_FOR + ' <li class="small"><span class="fa-li"><i class="fas fa-lg fa-building"></i></span> Email: ' + Email + '</li>';
                        HTML_FOR = HTML_FOR + '<li class="small"><span class="fa-li"><i class="fas fa-lg fa-phone"></i></span> Phone #: + '+Mobile+'</li>';
                        HTML_FOR = HTML_FOR + ' </ul>';
                        HTML_FOR = HTML_FOR + '</div >';
                        HTML_FOR = HTML_FOR + '<div class="col-5 text-center">';
                        HTML_FOR = HTML_FOR + ' <span class="img-circle img-fluid" Style="Font-Size:40px; border:1px solid #6c757d; padding:10px;"> ' + getChars(Name) + '</span>';
                        HTML_FOR = HTML_FOR + ' </div>';
                        HTML_FOR = HTML_FOR + '</div>';
                        HTML_FOR = HTML_FOR + ' </div>';
                        HTML_FOR = HTML_FOR + ' <div class="card-footer">';
                        HTML_FOR = HTML_FOR + '<div class="text-right">';
                        if (ReadStatus === 'N') {
                            HTML_FOR = HTML_FOR + `<a href="#" class="btn btn-sm bg-teal" title="Click To Submit Response." onclick="ShowEnquirePopup('${Name}', '${Mobile}', '${Email}',  '${encodeURIComponent(Message)}', '${CreateDate}', '${ContactUSID}', '${Reply}', '${ReadStatus}', '${ReadDate}')">`;
                            HTML_FOR = HTML_FOR + ' <i class="fas fa-comments"></i></a>  ';
                        }
                        else {
                            HTML_FOR = HTML_FOR + `<a href="#" class="btn btn-sm bg-teal" title="Click To View Details." onclick="ShowEnquirePopup('${Name}', '${Mobile}', '${Email}',  '${encodeURIComponent(Message)}', '${CreateDate}', '${ContactUSID}', '${encodeURIComponent(Reply)}', '${ReadStatus}', '${ReadDate}')">`;
                            HTML_FOR = HTML_FOR + '<i class="fa fa-eye"></i></a>  ';
                        }
                        HTML_FOR = HTML_FOR + '</div> </div></div></div>';
                        sno++;

                    });
                    if (sno === 1) { DLMSG.html('<span style="Color:Red;">NO Enquire Available....</span>'); }
                    else { DLMSG.html(HTML_FOR); }
                    $("#Result_count").html(sno-1);

                }
            });

        }
        function timeAgo(input) {
            const date = (input instanceof Date) ? input : new Date(input);
            const formatter = new Intl.RelativeTimeFormat('en');
            const ranges = {
                years: 3600 * 24 * 365,
                months: 3600 * 24 * 30,
                weeks: 3600 * 24 * 7,
                days: 3600 * 24,
                hours: 3600,
                minutes: 60,
                seconds: 1
            };
            const secondsElapsed = (date.getTime() - Date.now()) / 1000;
            for (let key in ranges) {
                if (ranges[key] < Math.abs(secondsElapsed)) {
                    const delta = secondsElapsed / ranges[key];
                    return formatter.format(Math.round(delta), key);
                }
            }
        }
        function getChars(s) {
            var str = "";
            var temp = "";
            for (var i = s.length - 1; i > 0; i--) {
                if (s[i].match(/[a-zA-Z]/) && s[i - 1] === ' ') {
                    temp += s[i];
                }
            }
            str += s[0];
            for (var i = temp.length - 1; i >= 0; i--) {
                str += temp[i];
            }
            return str;
        }
        function truncateText(inputString, maxLength) {
            var truncatedText = inputString;
            if (truncatedText.length > maxLength) {
                truncatedText = truncatedText.substring(0, maxLength) + "...";
            }
            return truncatedText;
        }
        function UnreadMsg() {

            var EmailID = $("[id*='lblEmailID']").text();
            var msgID = $("#lblContactUsID").text();
            var Reply = $("#summernote").val();
            if (Reply.trim() === '' || Reply.trim()=== null) {
                toastr.error('The Reply content is required.');
                $("#summernote").focus();
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "../Admin/MessageView.aspx/UnreadMsg",
                    data: '{ContactUSID1: \'' + msgID + '\',Reply: \'' + Reply + '\',EmailID: \'' + EmailID + '\'}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d == '1') {
                            toastr.success('Reply email was sent successfully.');
                            var now = new Date();
                            $("[id*=lbl_Reply_at]").text(formatDate(now));
                            $("[id*=lblReply]").html(decodeURIComponent(Reply));
                            $("#Reply_Row").show();
                            $("#Submit_Row").hide();
                            $("#Submit_Button").hide();

                            ViewMSG();
                        }
                        else {
                            toastr.error('The Reply content is Not Sent There is Some Error.');
                        }
                    }
                });

            }
          
           

        }
        function ShowEnquirePopup(Name, Mobile, Email, Message, CreateDate, ContactUSID, Reply, ReadStatus, ReadDate) {
           
            $('#modal-lg').modal('toggle');
            $('#modal-lg').modal('show');
            if (ReadStatus == 'N') {
                $("#Reply_Row").hide();
                $("#Submit_Row").show();
                $("#Submit_Button").show();
             
            }
            else {
               
                $("#Reply_Row").show();
                $("#Submit_Row").hide();
                $("#Submit_Button").hide();
            }
            
            $("#lblContactUsID").text(ContactUSID);
            $("[id*=lblName]").text(Name);
            $("[id*=lblEmailID]").text(Email);
            $("[id*=lblPhone]").text(Mobile);
            $("[id*=lblCreateDate]").text(formatDate(CreateDate));
            $("[id*=lblMessage]").html(decodeURIComponent(Message));
            $("[id*=lbl_Reply_at]").text(formatDate(ReadDate));
            $("[id*=lblReply]").html(decodeURIComponent(Reply));
            
            
}

        function formatDate(dateString) {
            const date = new Date(dateString);

            const day = String(date.getDate()).padStart(2, '0');
            const month = String(date.getMonth() + 1).padStart(2, '0');
            const year = date.getFullYear();

            const hours = String(date.getHours()).padStart(2, '0');
            const minutes = String(date.getMinutes()).padStart(2, '0');

            const formattedDate = `${day}/${month}/${year} ${hours}:${minutes}`;

            return formattedDate;
        }
            </script>

</body>
</html>