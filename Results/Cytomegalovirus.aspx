<%@ Page Title="" Language="C#" MasterPageFile="~/Results/Site2.Master" AutoEventWireup="true" CodeBehind="Cytomegalovirus.aspx.cs" Inherits="Lab_Assist.Results.Cytomegalovirus" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajax"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script type="text/javascript">

    function ShowTime() {

        var dt = new Date();

        document.getElementById("<%= txtTime.ClientID %>").value = dt.toLocaleTimeString();

        window.setTimeout("ShowTime()", 1000);

    } 

     </script>
    <script type="text/javascript">

        window.setTimeout("ShowTime()", 1000);

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
     <asp:Panel ID="pnlContent" runat="server" BorderColor="SkyBlue" BorderWidth="1px"  CssClass="alert-dark">
    
     
          <div  class="nav nav-tabs alert-success">
       <h4>Cytomegalovirus Results</h4>
          </div>
               
   <div class="container">
                <div class="row mt-5">
                    
                    <div  class="col-md-6">
                        <asp:TextBox   ID="txtSearchCustomer" autocomplete="off"   runat="server" Width="550px" ></asp:TextBox>
                   
                        </div>
                    <div  class="col-md-2">
                      <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnSearchCustomer" runat="server"  Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchCustomer_Click" />
                        </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label19" runat="server" Text="Customer No." CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtCustomerNo" autocomplete="off" CssClass="form-control"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                    </div>
             </div>
         <div class="container">
              <div class="row mt-1">
                    <div class="col-md-12 center-block" >
                    <asp:ListBox ID="lstCustomers" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block" OnSelectedIndexChanged="lstCustomers_SelectedIndexChanged" ></asp:ListBox>
                </div>
                  </div>
              </div>
             <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label2" runat="server" Text="Date" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtDateCreated" autocomplete="off" CssClass="form-control" ReadOnly="true"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label3" runat="server" Text="Lab No." CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtlabNo" autocomplete="off" CssClass="form-group" ReadOnly="true"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                    <div class="col-md-1">
                       <asp:Label ID="Label11" runat="server" Text="Current Time"  CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtTime" autocomplete="off" CssClass="form-control"   runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                  
                  </div>
         </div>
            <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label1" runat="server" Text="Full Name" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtFullName" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label4" runat="server" Text="IDNO" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtIDNO" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                    <div class="col-md-1">
                       <asp:Label ID="Label12" runat="server" Text="D.O.B" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtDOB" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                     
                  </div>
         </div>
           <div class="container">
              <div class="row  mt-1">
                     <div class="col-md-1">
                       <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                 <asp:DropDownList ID="ddl_Gender" CssClass="form-control" data-toggle="dropdown" runat="server" Width="200px">
                        <asp:ListItem Value="0">Select Option</asp:ListItem>
                         <asp:ListItem Value="M">Male</asp:ListItem>
                         <asp:ListItem Value="F">Female</asp:ListItem>
                     </asp:DropDownList>
                       
                    </div>
                    <div class="col-md-1">
                       <asp:Label ID="Label5" runat="server" Text="Doctor" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtDoctor" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label6" runat="server" Text="Hospital/Clinic" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtHospital" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                  
                  </div>
         </div>
          <div class="container">
          <div class="row  mt-3">
          <div  class="nav nav-tabs alert-success">
       <h4>Results</h4>
          </div>
            </div>
              </div>
          <div class="container">
                <div class="row mt-1">
                     <div  class="col-md-1">
                         <asp:Label ID="Label15" runat="server" Text="Category"></asp:Label>
                        </div>
                    <div  class="col-md-5">
                    <asp:DropDownList ID="ddl_Category" runat="server" CssClass="form-control" AutoPostBack="true" style="width:200px;" ></asp:DropDownList>
                        </div>
                       <div  class="col-md-6">
                           <asp:CheckBox ID="ChkIsPaid" CssClass="form-group" runat="server" Text="IsPaid?" />
                        </div>
                   
                    </div>
             </div>
            <div class="container">
              <div class="row  mt-3">
                     <div class="col-md-1">
                       <asp:Label ID="Label13" runat="server" Text="Service" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                 <asp:DropDownList ID="ddl_Products" CssClass="form-control" data-toggle="dropdown" AutoPostBack="true" runat="server"  Width="200px">
                       
                     </asp:DropDownList>
                       
                    </div>
                    <div class="col-md-1">
                       <asp:Label ID="Label14" runat="server" Text="Test Code" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtTestCode" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                    <div  class="col-md-1">
                         <asp:Label ID="Label16" runat="server" Text="Specimen Type"></asp:Label>
                        </div>
                    <div  class="col-md-3">
                    <asp:DropDownList ID="ddl_SpecimenTypes" CssClass="form-control" runat="server" style="width:200px;"></asp:DropDownList>
                        </div>
                  
                  </div>
         </div>
            <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-6">
                       <asp:Label ID="Label17" runat="server" Text="Cytomegalovirus IgM and IgG"  Font-Bold="true" Font-Size="Larger" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                  
                  </div>
         </div>
          <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label7" runat="server" Text="IgM" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtCytoIgM" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label8" runat="server" Text="IgG" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtCytoIgG" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                
                  
                  </div>
         </div>
             <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label18" runat="server" Text="Comment" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-10">
                <asp:TextBox   ID="txtComment" autocomplete="off" CssClass="form-control"  runat="server" Width="600px" TextMode="MultiLine"></asp:TextBox>
                       
                    </div>
                
                 
                  </div>
         </div>
          <div class="container">
              <div class="row  mt-3">
                 
                     <div class="col-md-5" style="padding-left:300px;">
                            <asp:Image ID="imgQRCode" Width="100px" Height="100px" runat="server" Visible="true" />
                        </div>
             
                  </div>
                </div>
          <div class="container">
              <div class="row  mt-3">
                 
                     <div class="col-md-5" style="padding-left:300px;">
                         <asp:Literal ID="litQRCode" runat="server" Text="QRCode info here"></asp:Literal>
                        </div>
                    
              
                  </div>
                </div>
         <hr/>
           <div class="container">
              <div class="row  mt-1">
                 
                     <div style="padding-left:200px;">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" Text="Process Result" OnClick="btnSave_Click"/>
                             <%--   <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary btn-sm" Text="Print Result" OnClick="btnPrint_Click"/>--%>
                          <asp:Button ID="btnReadQR" runat="server" CssClass="btn btn-primary btn-sm" Text="Read QRCode" OnClick="btnReadQR_Click"/>
                         <%--<asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary btn-sm" Text="Edit" OnClick="btnEdit_Click"/>--%>
                          <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary btn-sm" Text="Clear" OnClick="btnClear_Click"/>
                        </div>
              
                  </div>
                </div>
         <br/>
         </asp:Panel>
          <ajax:RoundedCornersExtender ID="Panel1_RoundedCornersExtender"
        runat="server" Enabled="True" TargetControlID="pnlContent" Radius="15">
    </ajax:RoundedCornersExtender>
</asp:Content>
