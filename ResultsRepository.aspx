<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ResultsRepository.aspx.cs" Inherits="Lab_Assist.ResultsRepository" %>
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
                        <li><a href="#tabs-1">Worklist</a></li>
                        <li><a href="#tabs-2">Results Archive</a></li>
                 
                    </ul>
                <div id="tabs-1">
                    <asp:Panel ID="pnlContent" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark">
                        <div  class="nav nav-tabs alert-success">
                                  <h4>Pending Results</h4>

                        </div>
                           <div class="container">
                <div class="row mt-5">
                    <div  class="col-md-6">
                        <asp:TextBox   ID="txtSearchCustomer" autocomplete="off"   runat="server" Width="550px" ></asp:TextBox>
                        </div>
                     <div  class="col-md-2">
                       <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnSearchCustomer" runat="server"  Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchCustomer_Click"  />
                        </div>
                      
                    </div>
             </div>
           <div class="container">
              <div class="row mt-1">
                    <div class="col-md-12 center-block" >
                    <asp:ListBox ID="lstCustomers" runat="server" AutoPostBack="True" Visible="false" CssClass="col-md-12 center-block" ></asp:ListBox>
                </div>
                  </div>
              </div>
                           <div class="container">
                <div class="row mt-1">
                    <div  class="col-md-12">
                        <asp:Label ID="lblNotification" CssClass="alert-danger" runat="server" Visible="false" Text=""></asp:Label>
                    </div>
                    </div>
              </div>
                                 <div class="container">
                <div class="row mt-1">
                    <div  class="col-md-12">

               <asp:GridView ID="grdWorklist" AutoGenerateColumns="False" horizontalalign="Center"  runat="server" CellPadding="3" GridLines="Horizontal" Caption="Worklist" CaptionAlign="Top"   AllowPaging="True" PageSize="50"   OnPageIndexChanging="grdWorklist_PageIndexChanging" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                          <AlternatingRowStyle BackColor="#F7F7F7" />
                          <columns>
                                <asp:TemplateField HeaderText="#">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDEdit" runat="server" Text='<%# Bind("TestID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="LabNumber">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLabNumber" runat="server" Text='<%# Bind("LabNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                              
                               <asp:TemplateField HeaderText="Name">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("Full_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Test">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTest" runat="server" Text='<%# Bind("Test") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="IDNO">
                                      
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDNO" runat="server" Text='<%# Bind("IDNO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sex">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                              
                                 <asp:TemplateField HeaderText="Phone">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("Phone_Number") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               
                              
                               <asp:TemplateField HeaderText="Date">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Test_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Time">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Test_Time") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                              
                         
                              </columns>
                          <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                          <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                          <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                          <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                          <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                          <SortedAscendingCellStyle BackColor="#F4F4FD" />
                          <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                          <SortedDescendingCellStyle BackColor="#D8D8F0" />
                          <SortedDescendingHeaderStyle BackColor="#3E3277" />
                      </asp:GridView>
                        </div>
                    </div>
                  </div>
                        <%-- ListView Rejected by client  --%>
                     <%--   <div class="container">
                <div class="row mt-5">
                    <div  class="col-md-12">
                        <asp:ListView ID="lvPendingResults" runat="server"  GroupItemCount="3" GroupPlaceholderID="groupPlaceholder1" ItemPlaceholderID="itemPlaceholder1">
                             <LayoutTemplate>
                                    <div>
                                    <div ID="groupPlaceholder1" runat="server">
                                    </div>
                                    </div>
                                </table>
                            </LayoutTemplate>
                              <GroupTemplate>
                                    <div style="clear:both">
                                    <div ID="itemPlaceholder1" runat="server">
                                    </div>
                                    </div>
                            </GroupTemplate>
                            <ItemTemplate>
                                      <div style="float:left; padding: 30px;">                  

                                              <b>ID:</b> <asp:Label ID="lblIDSearch" runat="server" Text='<%# Eval("TestID") %>' /><br />
                                              <b>Lab No:</b> <asp:Label ID="lblLabNo" runat="server" Text='<%# Eval("LabNumber") %>' /><br />
                                              <b>Full Name:</b> <asp:Label ID="lblFullName" runat="server" Text='<%# Eval("Full_Name") %>' /><br />
                                              <b>IDNO:</b> <asp:Label ID="lblIDNO" runat="server" Text='<%# Eval("IDNO") %>' /><br />
                                              <b>Phone Number:</b> <asp:Label ID="lblphoneNumber" runat="server" Text='<%# Eval("Phone_Number") %>' /><br />
                                              <b>Gender:</b> <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>' /><br />
                                              <b>Date Tested:</b> <asp:Label ID="lblContactSearch" runat="server" Text='<%# Eval("Test_Date") %>' /><br />
                                              <b>Time:</b> <asp:Label ID="lblTime" runat="server" Text='<%# Eval("Test_Time") %>' /><br />
                                              <b>Test:</b><asp:Label ID="lblTest" runat="server" Text='<%# Eval("Test") %>' /> <br />
                                              <b>Status:</b><asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' /> <br />
                                         
                                     </div> 

                            </ItemTemplate>
                             
                             <GroupSeparatorTemplate>
                                    <div runat="server">
                                    <div style="clear:both"><hr /></div>
                                    </div>
                            </GroupSeparatorTemplate>
                        </asp:ListView>

                        </div>
                    </div>
                </div>--%>
                        <br/><br/>
                    </asp:Panel>
                    </div>
               <div id="tabs-2">
                    <asp:Panel ID="pnlArchive" runat="server" BorderColor="SkyBlue" BorderWidth="1px" CssClass="alert-dark">
                        <div  class="nav nav-tabs alert-success">
                                  <h4>Results Archive</h4>
                        </div>
                                <div class="container">
                <div class="row mt-5">
                    <div  class="col-md-6">
                        <asp:TextBox   ID="txtSearchArchive" autocomplete="off"   runat="server" Width="550px" ></asp:TextBox>
                        </div>
                     <div  class="col-md-2">
                       <asp:Button  CssClass="btn btn-primary btn-sm" ID="btnSearchArchive" runat="server"  Text="🔍" UseSubmitBehavior="false" OnClick="btnSearchArchive_Click" />
                        </div>
                    
                    
                    </div>
             </div>
                                   <div class="container">
                <div class="row mt-1">
                    <div  class="col-md-12">
                        <asp:Label ID="lblArchiveNotification" CssClass="alert-danger" runat="server" Visible="false" Text=""></asp:Label>
                    </div>
                    </div>
              </div>
         
                               <div class="container">
                <div class="row mt-1">
                    <div  class="col-md-12">

               <asp:GridView ID="grdArchive" AutoGenerateColumns="False" horizontalalign="Center"  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Caption="Archived Results..." CaptionAlign="Top"   AllowPaging="True" PageSize="20"   OnPageIndexChanging="grdArchive_PageIndexChanging" OnRowEditing="grdArchive_RowEditing" OnRowCancelingEdit="grdArchive_RowCancelingEdit" OnSelectedIndexchanged="grdArchive_SelectedIndexChanged">
                          <AlternatingRowStyle BackColor="White" />
                          <columns>
                                <asp:TemplateField HeaderText="#">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDEdit" runat="server" Text='<%# Bind("TestID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="LabNumber">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLabNumber" runat="server" Text='<%# Bind("LabNumber") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                              
                              
                               <asp:TemplateField HeaderText="Name">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("Full_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="IDNO">
                                      
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDNO" runat="server" Text='<%# Bind("IDNO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sex">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                              
                                 <asp:TemplateField HeaderText="Phone">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("Phone_Number") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Test">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTest" runat="server" Text='<%# Bind("Test") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                               
                              
                               <asp:TemplateField HeaderText="Date">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Test_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                              
                         
                              
                                
                                  <asp:TemplateField ShowHeader="False">
                                     
                                <EditItemTemplate>
                                      <asp:LinkButton ID="lnkBtnCan" runat="server" CausesValidation="true"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                   <asp:LinkButton ID="lnkView" CommandArgument='<%# Eval("LabNumber") %>' CommandName="Select" runat="server"> <img src="assets/img/word.png" style="height:20px;width:30px;" /></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" CausesValidation="true"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>   
                            
                              </columns>
                          <EditRowStyle BackColor="#7C6F57" />
                          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#E3EAEB" />
                          <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F8FAFA" />
                          <SortedAscendingHeaderStyle BackColor="#246B61" />
                          <SortedDescendingCellStyle BackColor="#D4DFE1" />
                          <SortedDescendingHeaderStyle BackColor="#15524A" />
                      </asp:GridView>
                        </div>
                    </div>
                  </div>
                        <br/><br/>
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
        runat="server" Enabled="True" TargetControlID="pnlArchive" Radius="15">
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
