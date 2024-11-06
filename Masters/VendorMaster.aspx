<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="VendorMaster.aspx.cs" Inherits="Masters_VendorMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <div class="content-header">
  <div class="container-fluid">
    <div class="row mb-2">
      <div class="col-sm-6">
        <h1 class="m-0">Add Vendor </h1>
      </div><!-- /.col -->
      <div class="col-sm-6">
        <ol class="breadcrumb float-sm-right">
          <li class="breadcrumb-item"><a href="../Admin/Default.aspx">Home</a></li>
          <li class="breadcrumb-item active">Add Vendor </li>
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
                <label for="exampleInputEmail1">Enter Vendor Name</label>
                 <asp:TextBox ID="txtVendorName" runat="server" CssClass="form-control" placeholder="Enter Vendor Name" MaxLength="500" TabIndex="1"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVendorName" ErrorMessage="Please Enter Vendor name" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-red"></asp:RequiredFieldValidator> </div>
                </div>

              <div class="col-md-3">
                    <div class="form-group">
                <label for="exampleInputEmail1">Enter Firm Name</label>
                <asp:TextBox ID="txtFirmName" runat="server" CssClass="form-control" placeholder="Enter Firm Name" MaxLength="500" TabIndex="2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirmName" ErrorMessage="Please Enter Firm name" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-red"></asp:RequiredFieldValidator> </div>
         </div>

              <div class="col-md-3">
      <div class="form-group">
 <label for="exampleInputEmail1">Enter Address Name</label>
  <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" MaxLength="500" TabIndex="3"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-red"></asp:RequiredFieldValidator> </div>
 </div>

            <div class="col-md-3">
              <div class="form-group">
                  <label for="exampleInputEmail1">Select State Name</label>
                <asp:DropDownList ID="ddlStateName" runat="server" TabIndex="4" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlStateName_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Select State Name</asp:ListItem>
                        </asp:DropDownList>              
            </div>
</div>
              </div>
            <!---row---->
              <div class="row">
         <div class="col-md-3">
                 <div class="form-group">
              <label for="exampleInputEmail1">Select City Name</label>
             <asp:DropDownList ID="ddlCityName" runat="server" TabIndex="5" CssClass="form-control select2" style="width: 100%;" OnSelectedIndexChanged="ddlCityName_SelectedIndexChanged" AutoPostBack="true">
               <asp:ListItem Value="0">Select City Name</asp:ListItem>
                   </asp:DropDownList>              
            </div>
              </div>

            <div class="col-md-3">
               <div class="form-group">
                  <label for="exampleInputEmail1">Enter Pincode</label>
               <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" placeholder="Enter Pincode" MaxLength="10" TabIndex="6"></asp:TextBox>
               </div>
            </div>
                  <div class="col-md-3">
    <label for="exampleInputEmail1" class="form-label">Enter Vendor EmailID</label>
         <asp:TextBox ID="txtVendorEmail" runat="server" placeholder="Enter Email ID" CssClass="form-control" MaxLength="50" TabIndex="7"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtVendorEmail" ErrorMessage="Please Enter Vendor EmailID" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="txtVendorEmail" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  </div>

    <div class="col-md-3">
  <label for="exampleInputEmail1" class="form-label">Enter Vendor Mobile Number</label>
       <asp:TextBox ID="txtVendorMobile" runat="server" placeholder="Enter Mobile Number" CssClass="form-control" MaxLength="10" TabIndex="8"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="txtVendorMobile" ErrorMessage="Please Enter Vendor Mobile Number" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Valid Mobile Number" ControlToValidate="txtVendorMobile" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ValidationExpression="^[6-9]\d{9}$"></asp:RegularExpressionValidator>
</div>

          </div>
          <!-- /.row -->
            <!---row--->
            <div class="row">
                                <div class="col-md-3">
  <label for="exampleInputEmail1" class="form-label">Enter Contact Person</label>
       <asp:TextBox ID="txtContactPerson" runat="server" placeholder="Enter Contact Person" CssClass="form-control" MaxLength="50" TabIndex="9"></asp:TextBox>
</div>

                    <div class="col-md-3">
             <label for="exampleInputEmail1" class="form-label">Enter Contact Person EmailID</label>
       <asp:TextBox ID="txtContactEmail" runat="server" placeholder="Enter Email ID" CssClass="form-control" MaxLength="50" TabIndex="10"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="txtContactEmail" ErrorMessage="Please Enter Contact EmialID" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter Valid Email ID" ControlToValidate="txtContactEmail" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
</div>

                    <div class="col-md-3">
  <label for="exampleInputEmail1" class="form-label">Enter Contact Person Mobile No.</label>
       <asp:TextBox ID="txtContactMobile" runat="server" placeholder="Enter Mobile Number" CssClass="form-control" MaxLength="10" TabIndex="11"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  ControlToValidate="txtContactMobile" ErrorMessage="Please Enter Contact Mobile Number" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please Enter Valid Mobile Number" ControlToValidate="txtContactMobile" Display="Dynamic" ValidationGroup="Vendor" CssClass="text-danger" ValidationExpression="^[6-9]\d{9}$"></asp:RegularExpressionValidator>
</div>

                    <div class="col-md-3">
            <label for="exampleInputEmail1" class="form-label">Enter Registration Number</label>
       <asp:TextBox ID="txtRegNo" runat="server" placeholder="Enter Registration Number" CssClass="form-control" MaxLength="50" TabIndex="12"></asp:TextBox>
</div>

            </div>
            
            <!---/row--->
            <!---row--->
            <div class="row">
               <div class="col-md-3">
            <label for="exampleInputEmail1" class="form-label">Enter GST Number</label>
       <asp:TextBox ID="txtGSTNo" runat="server" placeholder="Enter GST Number" CssClass="form-control" MaxLength="15" TabIndex="13"></asp:TextBox>
</div>
            </div>
            <!---/row--->

        </div><br />
        <!-- /.box-body -->
       <div class="box-footer">
               <asp:Button ID="cmdSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="Vendor" TabIndex="14" OnClick="cmdSubmit_Click" />  <asp:Button ID="cmdUpdate" runat="server" Text="Update"  TabIndex="14" CssClass="btn btn-primary" ValidationGroup="Vendor" Visible="false" OnClick="cmdUpdate_Click" /> <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="btn btn-primary"  TabIndex="15" OnClick="cmdClear_Click"/>
             <br />

            <asp:Label ID="lblmsg" runat="server" Text="" CssClass="text-red" ></asp:Label>
            <asp:Label ID="lblID" runat="server" Text="" CssClass="text-red" Visible="false" ></asp:Label>
              </div>
      </div>

 <br />
            <div class="card-body table-responsive p-0" style="height: 300px;">

            <asp:GridView ID="grdVendor" runat="server" AllowPaging="true" PageVendor="10" OnPageIndexChanging="grdVendor_PageIndexChanging" PagerSettings-Mode="NumericFirstLast"
         AutoGenerateColumns="False"  ShowFooter="false"
   CssClass="table table-bordered table-striped"  DataKeyNames="vendor_id" EmptyDataText="No Record Found" OnRowCommand="grdVendor_RowCommand" OnRowDataBound="grdVendor_RowDataBound"  OnRowDeleting="grdVendor_RowDeleting"  OnRowUpdating="grdVendor_RowUpdating"   
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
                <asp:TemplateField  HeaderText="VendorID" Visible="false"  >
                    <EditItemTemplate>
                      

                    </EditItemTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblVendorID" runat="server" Text='<%# Eval("vendor_id")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("vendor_Address")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblStateID" runat="server" Text='<%# Eval("vendor_State")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblStateName" runat="server" Text='<%# Eval("VendorState")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblCityID" runat="server" Text='<%# Eval("vendor_City")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblCityName" runat="server" Text='<%# Eval("CityName")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblPincode" runat="server" Text='<%# Eval("vendor_Pincode")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblVendorEmail" runat="server" Text='<%# Eval("vendor_Email_id")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblVendorMobile" runat="server" Text='<%# Eval("vendor_Mobile")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblContactPerson" runat="server" Text='<%# Eval("Contact_person")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblContactEmail" runat="server" Text='<%# Eval("Contact_Email_id")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblContactMobile" runat="server" Text='<%# Eval("Contact_Mobile")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblRegNo" runat="server" Text='<%# Eval("vendor_Reg_No")%>' Visible="false"></asp:Label>
                     <asp:Label ID="lblGSTNo" runat="server" Text='<%# Eval("vendor_GST_No")%>' Visible="false"></asp:Label>
                    </ItemTemplate>
                  
                    <HeaderStyle  HorizontalAlign="Center"   Width="80px" />
                    <ItemStyle HorizontalAlign="Center"    Width="80px" />
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Vendor Name"  HeaderStyle-HorizontalAlign="Center">
    
                <ItemTemplate>
                 <asp:Label ID="lblVendorName" runat="server" Text='<%# Eval("vendor_Name") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Vendor Firm"  HeaderStyle-HorizontalAlign="Center">
                    
                    <ItemTemplate>
                      <asp:Label ID="lblVendorFirm" runat="server" Text='<%# Eval("vendor_Firm_Name") %>' ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
       <ItemTemplate>
                 <a onclick="ViewVendorDetails('<%# Eval("vendor_Name") %>','<%# Eval("vendor_Firm_Name") %>','<%# Eval("vendor_Address") %>','<%# Eval("VendorState") %>','<%# Eval("CityName") %>','<%# Eval("vendor_Pincode") %>','<%# Eval("vendor_Email_id") %>','<%# Eval("vendor_Mobile") %>','<%# Eval("Contact_person") %>','<%# Eval("Contact_Email_id") %>','<%# Eval("Contact_Mobile") %>','<%# Eval("vendor_Reg_No") %>','<%# Eval("vendor_GST_No") %>')"><i class="fa fa-eye"></i></a>
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

    <div class="modal fade" id="modal-lg">
        <div class="modal-dialog modal-xl">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">User Details</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
              <div id="viewDetails">
                  <h4>User Details</h4>
            <div class="modal-body">
              <div class="row">
                  <div class="col-md-3">
                      Vendor Name: <label id="lbl_Vendor_Name"></label>

                  </div>
                  <div class="col-md-3">
                      Firm Name: <label id="lbl_Firm"></label>
                  </div>
                  <div class="col-md-3">
                       Address: <label id="lbl_Address"></label>
                  </div>
                  <div class="col-md-3">
                       State: <label id="lbl_State"></label>
                  </div>

              </div>
                <div class="row">
                  <div class="col-md-3">
                      City: <label id="lbl_City"></label>

                  </div>
                  <div class="col-md-3">
                      Pincode: <label id="lbl_Pincode"></label>
                  </div>
                  <div class="col-md-3">
                       Vendor EmailID: <label id="lbl_Vendor_EmailID"></label>
                  </div>
                  <div class="col-md-3">
                       Vendor Mobile Number: <label id="lbl_Vendor_MobileNo"></label>
                  </div>
              </div>

          <div class="row">
                <div class="col-md-3">
                     Contact Person Name: <label id="lbl_ContactPerson"></label>
                </div>
                <div class="col-md-3">
                     Contact EmailID: <label id="lbl_Contact_EmailID"></label>
                 </div>
                 <div class="col-md-3">
                      Contact Mobile No: <label id="lbl_Contact_MobileNo"></label>
                 </div>
                 <div class="col-md-3">
                         Registration Number: <label id="lbl_RegNo"></label>
                </div>
          </div>

            <div class="row">
                <div class="col-md-3">
                 GST No: <label id="lbl_GSTNo"></label>
                 </div>
                 
            </div>

            </div>
                  </div>
            <div class="modal-footer justify-content-between">
               <button type="button" class="btn btn-primary" id="downloadBtn" onclick="printData()">Download PDF</button>
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
          <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
      </div>
    
    <script type="text/javascript">
        function ViewVendorDetails(name, firm, address, state, city, pincode, email, mobile, contactPerson, contactEmail, contactMobile, RegNo, GSTNo) {
            // Initialize a variable to check if all fields are empty
            let allFieldsEmpty = true;

            // Check and set Vendor details
            $("#lbl_Vendor_Name").text(name || "N/A");
            if (name) allFieldsEmpty = false;

            $("#lbl_Firm").text(firm || "N/A");
            if (firm) allFieldsEmpty = false;

            $("#lbl_Address").text(address || "N/A");
            if (address) allFieldsEmpty = false;

            $("#lbl_State").text(state || "N/A");
            if (state) allFieldsEmpty = false;

            $("#lbl_City").text(city || "N/A");
            if (city) allFieldsEmpty = false;

            $("#lbl_Pincode").text(pincode || "N/A");
            if (pincode) allFieldsEmpty = false;

            $("#lbl_Vendor_EmailID").text(email || "N/A");
            if (email) allFieldsEmpty = false;

            $("#lbl_Vendor_MobileNo").text(mobile || "N/A");
            if (mobile) allFieldsEmpty = false;

            $("#lbl_ContactPerson").text(contactPerson || "N/A");
            if (contactPerson) allFieldsEmpty = false;

            $("#lbl_Contact_EmailID").text(contactEmail || "N/A");
            if (contactEmail) allFieldsEmpty = false;

            $("#lbl_Contact_MobileNo").text(contactMobile || "N/A");
            if (contactMobile) allFieldsEmpty = false;

            $("#lbl_RegNo").text(RegNo || "N/A");
            if (RegNo) allFieldsEmpty = false;

            $("#lbl_GSTNo").text(GSTNo || "N/A");
            if (GSTNo) allFieldsEmpty = false;

            // Display "No Data Available" if all fields are empty
            if (allFieldsEmpty) {
                $("#viewDetails").text("No Data Available");
                $("#viewDetails").css("text-align", "center"); // Center the text for better visibility
            } else {
                $("#viewDetails").css("text-align", ""); // Reset text alignment if data is available
            }

            // Show the modal
            $('#modal-lg').modal('toggle');
            $('#modal-lg').modal('show');
        }
        function printData() {

            var printContents = document.getElementById('viewDetails').innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            document.body.style.color = "black";
            //originalContents.fontsize = '12px';
            window.print();

            document.body.innerHTML = originalContents;

            $('#modal-lg').modal('toggle');

            $('#modal-lg').on('hidden.bs.modal', function () {
                $('.modal-backdrop').remove();  // Removes the backdrop
                $('body').removeClass('modal-open');  // Removes modal-open class from body
            });

        }
    </script>

</asp:Content>

