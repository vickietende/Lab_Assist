<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab_Assist.Home" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajax"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
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
       <h4>Home</h4>
          </div>
         <div class="container">
                <div class="row mt-5">
                    <div  class="col-md-6">
                    <asp:RadioButtonList ID="rdblClientType" RepeatDirection="Horizontal"  runat="server" >
                        <asp:ListItem Value="Online">Online</asp:ListItem>
                        <asp:ListItem Value="New">New</asp:ListItem>
                    </asp:RadioButtonList>
                        </div>
                    </div>
             </div>
           <div class="container">
                <div class="row mt-1">
                    <div  class="col-md-6">
                        <asp:TextBox   ID="txtSearchCustomer" autocomplete="off"   runat="server" Width="550px" ></asp:TextBox>
                   
                        </div>
                    <div  class="col-md-6">
                      <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnSearchCustomer" runat="server"  Text="🔍" UseSubmitBehavior="false" Onclick="btnSearchCustomer_Click" />
                        </div>
                    </div>
             </div>
         <div class="container">
              <div class="row mt-1">
                    <div class="col-md-12 center-block" >
                    <asp:ListBox ID="lstCustomers" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block" OnSelectedIndexChanged="lstCustomers_SelectedIndexChanged"></asp:ListBox>
                </div>
                  </div>
              </div>
          <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label2" runat="server" Text="Date" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtDateCreated" autocomplete="off" CssClass="form-control"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label3" runat="server" Text="Lab No." CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtlabNo" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ForeColor="Red" Font-Bold="true" ></asp:TextBox>
                       
                    </div>
                    <div class="col-md-1">
                       <asp:Label ID="Label11" runat="server" Text="Current Time" CssClass="control-label" ></asp:Label> 
                        
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
                       <asp:Label ID="Label4" runat="server" Text="Email" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtemail" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" TextMode="Email"></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label5" runat="server" Text="Phone No." CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtphone" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                  </div>
         </div>
              <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label9" runat="server" Text="D.O.B" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtDOB" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                         <asp:Image ID="Image1" runat="server" ImageUrl="assets/img/calendar.jpg"  Height="24px" Width="23px" Align="Top"/>
                          <ajax:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image1" runat="server" TargetControlID="txtDOB"  
                        Format="dd/MM/yyyy">  
                    </ajax:CalendarExtender> 
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label10" runat="server" Text="Gender" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                 <asp:DropDownList ID="ddl_Gender" CssClass="form-control" data-toggle="dropdown" runat="server">
                        <asp:ListItem Value="0">Select Option</asp:ListItem>
                         <asp:ListItem Value="M">Male</asp:ListItem>
                         <asp:ListItem Value="F">Female</asp:ListItem>
                     </asp:DropDownList>
                       
                    </div>
                        <div class="col-md-1">
                       <asp:Label ID="Label6" runat="server" Text="ID Number" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtIDNO" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                  </div>
         </div>
           <div class="container">
              <div class="row  mt-1">
                 
                     <div class="col-md-1">
                       <asp:Label ID="Label7" runat="server" Text="Location" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                 <asp:DropDownList ID="ddl_Cities" CssClass="form-control" data-toggle="dropdown" runat="server">
                      
                     </asp:DropDownList>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label8" runat="server" Text="Physical Address" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtaddress" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" TextMode="MultiLine" ></asp:TextBox>
                       
                    </div>
                  </div>
         </div>
         <div class="container">
              <div class="row  mt-1">
                 
                     <div class="col-md-10">
                  <asp:CheckBoxList ID="chkSelectedServices" RepeatColumns="3" Visible="false" RepeatDirection="Vertical" runat="server"  CellPadding="5">

                    </asp:CheckBoxList>
             </div>
                  </div>
                </div>
           <%-- <div class="container">
              <div class="row  mt-1">
                 
                     <div class="col-md-10">
                  <asp:CheckBoxList ID="chkServices" RepeatColumns="3" Visible="false" RepeatDirection="Vertical" runat="server"  CellPadding="5">

                    </asp:CheckBoxList>
             </div>
                  </div>
                </div>--%>
          <div class="container">
              <div class="row  mt-1">
              <div class="col-md-1">
                  <asp:Label ID="lblOther" runat="server" Visible="false" Text="Other"></asp:Label>
                  </div>
         <div class="col-md-3">
                  <asp:TextBox ID="txtOther" class="form-control" Width="600px" runat="server" Visible="false"  TextMode="MultiLine"></asp:TextBox>
                  
              </div>
                  </div>
              </div>
              <div class="container">
          <div class="row  mt-5">
          <div  class="nav nav-tabs alert-success">
                <h4>Services</h4>
          </div>
            </div>
              </div>
          <div class="container">
                <div class="row mt-1">
                     <div  class="col-md-1">
                         <asp:Label ID="Label15" runat="server" Text="Category"></asp:Label>
                        </div>
                    <div  class="col-md-3">
                    <asp:DropDownList ID="ddl_Category" runat="server" CssClass="form-control" AutoPostBack="true" style="width:200px;" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-1">
                       <asp:Label ID="Label13" runat="server" Text="Service" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                 <asp:DropDownList ID="ddl_Products" CssClass="form-control" data-toggle="dropdown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_Products_SelectedIndexChanged" Width="200px">
                       
                     </asp:DropDownList>
                       
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
                    <div class="col-md-1">
                       <asp:Label ID="Label12" runat="server" Text="Test Code" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtTestCode" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
           
                  </div>
         </div>
             <div class="container">
              <div class="row mt-1">
                    <div class="col-md-12 center-block" >
                    <asp:ListBox ID="lstTests" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block" OnSelectedIndexChanged="lstTests_SelectedIndexChanged" ></asp:ListBox>
                </div>
                  </div>
              </div>
         <hr/>
          <div class="container">
              <div class="row  mt-1">
                 
                     <div  style="padding-left:450px;">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" Text="Send Test" Onclick="btnSave_Click"/>
                <asp:Button ID="btnCreate" runat="server" CssClass="btn btn-primary btn-sm" Text="Create Profile" Onclick="btnCreate_Click"/>
             </div>
               
                  </div>
                </div>

          <div class="container">
              <div class="row  mt-1">
                 
                     <div class="col-md-10">
                     <asp:LinkButton ID="lnkRefresh" ForeColor="Blue" runat="server" OnClick="lnkRefresh_Click">Refresh Page</asp:LinkButton>
                       <asp:Label ID="lblError" runat="server" Text="" CssClass="control-label" ></asp:Label>    
             </div>
               
                  </div>
                </div>
             
           
             
             
         </asp:Panel>
        <ajax:RoundedCornersExtender ID="Panel1_RoundedCornersExtender"
        runat="server" Enabled="True" TargetControlID="pnlContent" Radius="15">
    </ajax:RoundedCornersExtender>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-2.0.0.min.js"></script>
    
</asp:Content>
