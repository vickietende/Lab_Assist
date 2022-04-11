<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserRoleMgt.aspx.cs" Inherits="Lab_Assist.UserRoleMgt" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajax"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:Panel ID="pnlMain" runat="server" BorderColor="SkyBlue" BorderWidth="1px" style="padding-top:4em;"  CssClass="alert-dark">
      <div id="tabs" style="height:100%">
        <asp:HiddenField ID="hdnSelectedTab" runat="server" Value="0" />
            <ul>
                <li><a href="#tabs-1">User Management</a></li>
                <li><a href="#tabs-2">Role Management</a></li>
                <li><a href="#tabs-3">Add Departments</a></li>
            </ul>
            <div id="tabs-1">
               <asp:Panel ID="pnlContent" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark">
      
    <div  class="nav nav-tabs alert-success">
       
    <h4>Manage Users</h4>
          
         </div>
         <div class="container">
             <div class="row mt-1">
              <div class="col-md-1">
                  Date

              </div>
  <div class="col-md-2">
      <asp:TextBox   ID="txtDateCreated" autocomplete="off"   runat="server" Width="200px" ></asp:TextBox>

  </div>
 
  
                 </div>
             </div>

         <div class="container">
              <div class="row mt-1">
                                       <div class="col-md-1">
                                  <asp:Label ID="Label15" runat="server" Text="User" CssClass="badge-default" ></asp:Label>          
                                      </div>
                  <div class="col-md-5">
                    <asp:TextBox   ID="txtSearchSurname" autocomplete="off"   runat="server" Width="400px" ></asp:TextBox>
                       </div>
              
                <div class="col-md-1">
                    <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnSearchSurname" runat="server" Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchSurname_Click"/>
                </div>
               <div class="col-md-2">
            <asp:Label ID="Label16" runat="server" Text="UserID"></asp:Label>
               </div>
                   <div class="col-md-3">
                    <asp:TextBox ID="txtUserID" runat="server" style="width:200px;"></asp:TextBox>
                    </div>
        
         </div>
             </div>
        
          <div class="container">
              <div class="row mt-1">
                    <div class="col-md-12 center-block" >
                    <asp:ListBox ID="lstSurnames" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block" OnSelectedIndexChanged="lstSurnames_SelectedIndexChanged" ></asp:ListBox>
                </div>
                  </div>
              </div>
           <div class="container">
              <div class="row mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label1" runat="server" Text="Surname" CssClass="control-label" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtuserSurname" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                           <asp:RegularExpressionValidator ID="revSurname" ControlToValidate="txtuserSurname" runat="server"  ValidationExpression="^[A-Za-z\s]+$" ErrorMessage="Text field only" ValidationGroup="myUser" Font-Italic="true" Font-Size="XX-Small" ForeColor="Red"  EnableClientScript="true"></asp:RegularExpressionValidator>
                    </div>
                  <div class="col-md-1">
                       <asp:Label ID="Label2" runat="server" Text="First Name" CssClass="badge-default" ></asp:Label>  
                      
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtuserfname" autocomplete="off"   runat="server" Width="200px"  ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revFname" ControlToValidate="txtuserfname" runat="server"  ValidationExpression="^[A-Za-z\s]+$" ErrorMessage="Text field only" ValidationGroup="myUser" Font-Italic="true" Font-Size="XX-Small" ForeColor="Red"  EnableClientScript="true"></asp:RegularExpressionValidator>
                    </div>
                   <div class="col-md-1">
                       <asp:Label ID="Label3" runat="server" Text="Gender" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                   <asp:DropDownList ID="ddl_userGender" CssClass="dropdown-toggle" data-toggle="dropdown" runat="server" RepeatDirection="Horizontal" Width="200px">
                            <asp:ListItem Text="--select Gender--" Value="-1"></asp:ListItem>
                            <asp:ListItem  Value="M">Male</asp:ListItem>
                            <asp:ListItem  Value="F">Female</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
        </div>

           <div class="container">
              <div class="row mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label10" runat="server" Text="IDNO." CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox   ID="txtuserIDNO" autocomplete="off"   runat="server" Width="200px"></asp:TextBox>
                          <asp:RegularExpressionValidator Display="dynamic" ID="revidno" runat="server" ControlToValidate="txtuserIDNO" ValidationGroup="myUser" ForeColor="Red"
                            Font-Italic="true" Font-Size="XX-Small" ValidationExpression="\d{8,9}[a-zA-Z]\d{2}" ErrorMessage="Enter a valid ID Number"></asp:RegularExpressionValidator>
                    </div>
                  <div class="col-md-1">
                       <asp:Label ID="Label11" runat="server" Text="Email" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                     <asp:TextBox   ID="txtuserEmail" autocomplete="off"   runat="server" Width="200px"  ></asp:TextBox>
                         <asp:RegularExpressionValidator ID="Revmail" Enabled="true" ForeColor="Red"
                            Font-Italic="true" EnableClientScript="true" Font-Size="XX-Small" runat="server"  ControlToValidate="txtuserEmail" ErrorMessage="Invalid Email" ValidationGroup="myUser"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                   <div class="col-md-1">
                       <asp:Label ID="Label12" runat="server" Text="Phone" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox   ID="txtuserPhone" autocomplete="off"   runat="server" Width="200px"  ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revphone" Enabled="true" ForeColor="Red"
                            Font-Italic="true" EnableClientScript="true" Font-Size="XX-Small" runat="server"  ControlToValidate="txtuserPhone" ErrorMessage="Invalid Number" ValidationGroup="myUser"  ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </div>
                </div>
        </div>

          <div class="container">
              <div class="row mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label4" runat="server" Text="Dept." CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddl_userDept" CssClass="dropdown-toggle" data-toggle="dropdown" runat="server" RepeatDirection="Horizontal" Width="200px">
                            <asp:ListItem Text="--select department--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                  <div class="col-md-1">
                       <asp:Label ID="Label5" runat="server" Text="Occupation" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                     <asp:DropDownList ID="ddl_userOccupation" CssClass="dropdown-toggle" data-toggle="dropdown" runat="server" RepeatDirection="Horizontal" Width="200px">
                      
                        </asp:DropDownList>

                    </div>
                   <div class="col-md-1">
                       <asp:Label ID="Label6" runat="server" Text="Role" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                      <asp:DropDownList ID="ddl_userRole" CssClass="dropdown-toggle" data-toggle="dropdown" runat="server" RepeatDirection="Horizontal" Width="200px">
                            <asp:ListItem Text="--select role--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
        </div>
         <div class="container">
              <div class="row mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label7" runat="server" Text="Username" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox   ID="txtusername" autocomplete="off"   runat="server" Width="200px"></asp:TextBox>
                    </div>
                  <div class="col-md-1">
                       <asp:Label ID="Label8" runat="server" Text="Password" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                     <asp:TextBox   ID="txtpwd" autocomplete="off"   runat="server" Width="200px"></asp:TextBox>

                    </div>
                  <div class="col-md-1">
                       <asp:Label ID="Label25" runat="server" Text="Branch" CssClass="badge-default" ></asp:Label>  
                    </div>
                   <div class="col-md-3">
                      <asp:DropDownList ID="ddl_Branches" CssClass="dropdown-toggle" data-toggle="dropdown" runat="server" RepeatDirection="Horizontal" Width="200px">
                         
                        </asp:DropDownList>

                    </div>
                  
                </div>
        </div>
           <br/>
      <hr/>
      <div class="container">
              <div class="row mt-3">
                  
                  
                  <div  style="padding-left:300px;">
                      <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary btn-sm" Text="Update" OnClick="btnEdit_Click" />
                      <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" Text="Save"   CausesValidation="true" ValidationGroup="myUser" OnClick="btnSave_Click"/>
                        <asp:Button ID="btnLock" runat="server" CssClass="btn btn-primary btn-sm" Text="Lock User" OnClick="btnLock_Click"/>
                        <asp:Button ID="btnUnlockUser" runat="server" CssClass="btn btn-primary btn-sm" Text="Unlock User" OnClick="btnUnlockUser_Click"/>
                      <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-primary btn-sm" Text="Clear" OnClick="btnRefresh_Click"/>
                    </div>
                    <div  style="padding-left:10px;">
                        

                    </div>
                 
                    <div  style="padding-left:10px;">
                      

                    </div>
                  <div  style="padding-left:10px;">
                      

                    </div>
                    <div  style="padding-left:10px;">
                        

                    </div>
                  
                </div>
        </div>
     
      <br/>
        </asp:Panel>
            </div>
            <div id="tabs-2">
                 <asp:Panel ID="pnlRoles" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark">
      
                <div  class="nav nav-tabs alert-success">
       
                <h4>Manage Roles</h4>
          
                    </div>
                       <div class="container">
              <div class="row mt-1">
                                       <div class="col-md-1">
                                  <asp:Label ID="Label9" runat="server" Text="Role" CssClass="badge-default" ></asp:Label>          
                                      </div>
                  <div class="col-md-5">
                    <asp:TextBox   ID="txtNewRole" autocomplete="off"   runat="server" Width="400px" ></asp:TextBox>
                       </div>
              
                <div class="col-md-1">
                    <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnAddRole" runat="server" Text="Add" UseSubmitBehavior="false" OnClick="btnAddRole_Click"/>
                </div>
               <div class="col-md-2">
            <asp:Label ID="Label13" runat="server" Text="Role ID"></asp:Label>
               </div>
                   <div class="col-md-3">
                    <asp:TextBox ID="txtRoleID" runat="server" style="width:200px;"></asp:TextBox>
                    </div>
        
         </div>
             </div>
                      <div class="container">
              <div class="row mt-1">
                                       <div class="col-md-1">
                                  <asp:Label ID="Label19" runat="server" Text="Users" CssClass="badge-default" ></asp:Label>          
                                      </div>
                  <div class="col-md-5">
                    <asp:TextBox   ID="txtSearchUsers" autocomplete="off"   runat="server" Width="400px" ></asp:TextBox>
                       </div>
              
                <div class="col-md-1">
                    <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnSearchUserforRoles" runat="server" Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchUserforRoles_Click" />
                </div>
               <div class="col-md-2">
            <asp:Label ID="Label20" runat="server" Text="UserID"></asp:Label>
               </div>
                   <div class="col-md-3">
                    <asp:TextBox ID="txtUserIDonRoles" runat="server" style="width:200px;"></asp:TextBox>
                    </div>
        
         </div>
             </div>
        
          <div class="container">
              <div class="row mt-1">
                    <div class="col-md-12 center-block" >
                    <asp:ListBox ID="lstUsersOnRoles" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block" OnSelectedIndexChanged="lstUsersOnRoles_SelectedIndexChanged" ></asp:ListBox>
                </div>
                  </div>
              </div>
                       <div class="container">
              <div class="row mt-1">
                   <div class="col-md-1">
                       <asp:Label ID="Label14" runat="server" Text="Username" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox   ID="txtUsernameOnRoles" autocomplete="off"   runat="server" Width="200px"></asp:TextBox>
                    </div>

                  <div class="col-md-1">
                       <asp:Label ID="Label17" runat="server" Text="IDNO" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                <asp:TextBox   ID="txtUserIDNOonRoles" autocomplete="off"   runat="server" Width="200px"  ></asp:TextBox>
                    
                    </div>
                   <div class="col-md-1">
                       <asp:Label ID="Label18" runat="server" Text="Roles" CssClass="badge-default" ></asp:Label>  
                    </div>
                    <div class="col-md-3">
                   <asp:DropDownList ID="ddl_AvailableRoles" CssClass="dropdown-toggle" data-toggle="dropdown" runat="server" AutoPostBack="true"  RepeatDirection="Horizontal"  Width="200px" OnSelectedIndexChanged="ddl_AvailableRoles_SelectedIndexChanged">
                          

                        </asp:DropDownList>

                    </div>
                </div>
        </div>
                     <br/>
                     <hr/>
       <div class="container">
              <div class="row mt-3">
                  
                    <div  style="padding-left:450px;">
                        <asp:Button ID="btnAssignRole" runat="server" CssClass="btn btn-primary  btn-sm" Text="Assign Role" OnClick="btnAssignRole_Click"/>
                    </div>
                 
                   
                </div>
        </div>
                     <br/><br/>
                     </asp:Panel>
            </div>

            <div id="tabs-3">
            <asp:Panel ID="pnlDepts" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark">
      
                <div  class="nav nav-tabs alert-success">
       
                <h4>Manage Departments</h4>
          
                    </div>
                <div class="container">
              <div class="row mt-1">
                                       <div class="col-md-1">
                                  <asp:Label ID="Label21" runat="server" Text="Dept" CssClass="badge-default" ></asp:Label>          
                                      </div>
                  <div class="col-md-5">
                    <asp:TextBox   ID="txtDept" autocomplete="off"   runat="server" Width="400px" ></asp:TextBox>
                       </div>
              
                <div class="col-md-1">
                    <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnAddDept" runat="server" Text="Add"  UseSubmitBehavior="false" OnClick="btnAddDept_Click"/>
                </div>
               <div class="col-md-2">
            <asp:Label ID="Label22" runat="server" Text="Dept. ID"></asp:Label>
               </div>
                   <div class="col-md-3">
                    <asp:TextBox ID="txtDeptID" runat="server" style="width:200px;"></asp:TextBox>
                    </div>
        
         </div>
             </div>

        <div class="container">
              <div class="row mt-1">
                                       <div class="col-md-1">
                                  <asp:Label ID="Label23" runat="server" Text="Occupation" CssClass="badge-default" ></asp:Label>          
                                      </div>
                  <div class="col-md-5">
                    <asp:TextBox   ID="txtOccupation" autocomplete="off"   runat="server" Width="400px" ></asp:TextBox>
                       </div>
              
                <div class="col-md-1">
                    <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnAddOccupation" runat="server" Text="Add" UseSubmitBehavior="false" OnClick="btnAddOccupation_Click"/>
                </div>
               <div class="col-md-2">
            <asp:Label ID="Label24" runat="server" Text="Depts."></asp:Label>
               </div>
                   <div class="col-md-3">
                      <asp:DropDownList ID="ddl_AvailableDepts" CssClass="dropdown-toggle" data-toggle="dropdown" AutoPostBack="true"  runat="server" RepeatDirection="Horizontal" Width="200px" OnSelectedIndexChanged="ddl_AvailableDepts_SelectedIndexChanged">
                          

                        </asp:DropDownList>
                    </div>
        
         </div>
             </div>
                 <div class="container">
              <div class="row mt-1">
                                       <div class="col-md-1">
                                  <asp:Label ID="Label26" runat="server" Text="Branch" CssClass="badge-default" ></asp:Label>          
                                      </div>
                  <div class="col-md-5">
                    <asp:TextBox   ID="txtNewBranch" autocomplete="off"   runat="server" Width="400px" ></asp:TextBox>
                       </div>
              
                <div class="col-md-1">
                    <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnAddBranch" Enabled="true" runat="server" Text="Add" UseSubmitBehavior="false" OnClick="btnAddBranch_Click" />
                </div>
               
                   
        
         </div>
             </div>

                <br/>
            </asp:Panel>
                 
                </div>
            </div> 
 <ajax:RoundedCornersExtender ID="RoundedCornersExtender3"
        runat="server" Enabled="True" TargetControlID="pnlMain" Radius="15">
    </ajax:RoundedCornersExtender>
         <ajax:RoundedCornersExtender ID="RoundedCornersExtender1"
        runat="server" Enabled="True" TargetControlID="pnlContent" Radius="15">
    </ajax:RoundedCornersExtender>
             <ajax:RoundedCornersExtender ID="RoundedCornersExtender2"
        runat="server" Enabled="True" TargetControlID="pnlRoles" Radius="15">
    </ajax:RoundedCornersExtender>
             <ajax:RoundedCornersExtender ID="RoundedCornersExtender4"
        runat="server" Enabled="True" TargetControlID="pnlDepts" Radius="15">
    </ajax:RoundedCornersExtender>
     <link href="../jquerytabs/styles/jquery-ui.css" rel="stylesheet" />
    <script src="../jquerytabs/scripts/jquery-1.11.3.min.js"></script>
    <script src="../jquerytabs/scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs({
                activate: function () {
                    var selectedTab = $('#tabs').tabs('option', 'active');
                    $("#<%= hdnSelectedTab.ClientID %>").val(selectedTab);
        },
        active: document.getElementById('<%= hdnSelectedTab.ClientID %>').value
            });
        });

    </script>
    </asp:Panel>  
</asp:Content>
