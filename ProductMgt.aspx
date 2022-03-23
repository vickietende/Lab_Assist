<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductMgt.aspx.cs" Inherits="Lab_Assist.ProductMgt" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajax"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
     <asp:Panel ID="pnlContent" runat="server" BorderColor="SkyBlue" BorderWidth="1px"  CssClass="alert-dark">
    
      <div  class="nav nav-tabs alert-success">
       <h4>Product Management</h4>
          </div>
        
          <div class="container">
               
                <div class="row mt-5">
                    
                     <div  class="col-md-1">
                         <asp:Label ID="Label1" runat="server" Text="Products"></asp:Label>
                        </div>
                   
                    <div  class="col-md-10">
                    <asp:DropDownList ID="ddl_Products" CssClass="form-control" runat="server" AutoPostBack="true" style="width:400px;" OnSelectedIndexChanged="ddl_Products_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                    </div>
                   
             </div>
      
           <div class="container">
                <div class="row mt-1">
                     <div  class="col-md-1">
                         <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                        </div>
                    <div  class="col-md-5">
                    <asp:DropDownList ID="ddl_Category" runat="server" CssClass="form-control" AutoPostBack="true" style="width:400px;" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                     <div  class="col-md-1">
                         <asp:Label ID="Label3" runat="server" Text="Specimen Type"></asp:Label>
                        </div>
                    <div  class="col-md-5">
                    <asp:DropDownList ID="ddl_SpecimenTypes" CssClass="form-control" runat="server" style="width:400px;"></asp:DropDownList>
                        </div>
                    </div>
             </div>
           <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label4" runat="server" Text="Test" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-5">
                <asp:TextBox   ID="txtTest" autocomplete="off" CssClass="form-group"  runat="server" Width="400px" ></asp:TextBox>
                       
                    </div>
                     <div class="col-md-1">
                       <asp:Label ID="Label5" runat="server" Text="Test Code" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-5">
                <asp:TextBox   ID="txtTestCode" autocomplete="off" CssClass="form-group"  runat="server" Width="200px" ></asp:TextBox>
                       
                    </div>
                   
                
                  </div>
         </div>
          <div class="container">
              <div class="row  mt-1">
                    <div class="col-md-1">
                       <asp:Label ID="Label6" runat="server" Text="Price(USD)" CssClass="control-label" ></asp:Label> 
                        
                    </div>
                    <div class="col-md-5">
                <asp:TextBox   ID="txtPrice" autocomplete="off" CssClass="form-group"  runat="server" Width="400px" ></asp:TextBox>
                       
                    </div>
             
                  </div>
         </div>
         <hr/>
          <div class="container">
              <div class="row  mt-1">
                       <div  style="padding-left:350px;">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-sm" Text="Update" OnClick="btnUpdate_Click" />
                             <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary btn-sm" Text="Clear" OnClick="btnClear_Click" />
                   
                    
                    
                    </div>
                  <div class="col-xs-2" style="padding-left:20px;color:blueviolet;">
                    <a data-bs-target="#showCategoryModal" role="button" class="" data-bs-toggle="modal" id="launchCategoryModal">New Category</a>
                  </div>
                   <div class="col-xs-2" style="padding-left:20px;color:blueviolet;">
                    <a data-bs-target="#showSpecimenModal" role="button" class="" data-bs-toggle="modal" id="launchSpecimenModal">New Specimen Type</a>
                  </div>
             
                  </div>
         </div>
         <hr/>
         <div class="container">
              <div class="row mt-3">
                  <div  class="col-md-12">
                      <asp:GridView ID="grdProducts" AutoGenerateColumns="False" horizontalalign="Center"  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Caption="Products" CaptionAlign="Top"   AllowPaging="True" PageSize="20" OnSelectedIndexChanged="grdProducts_SelectedIndexChanged" OnPageIndexChanging="grdProducts_PageIndexChanging" OnRowEditing="grdProducts_RowEditing" OnRowCancelingEdit="grdProducts_RowCancelingEdit" >
                          <AlternatingRowStyle BackColor="White" />
                          <columns>
                              <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                   
                                    <asp:LinkButton ID="lnkBtnCan" runat="server" CausesValidation="true"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    &nbsp; <asp:LinkButton ID="lnkBtnSel" runat="server" CausesValidation="true"
                                        CommandName="Select"  Text="Select" ></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnEdt" runat="server" CausesValidation="true"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                              
                                 <asp:TemplateField HeaderText="#">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDEdit" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Test">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTest" runat="server" Text='<%# Bind("Test") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                          
                              <asp:TemplateField HeaderText="Category">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Specimen Type">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSpecimen" runat="server" Text='<%# Bind("Specimen_Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Test Code">
                                             
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTestCode" runat="server" Text='<%# Bind("TestCode") %>'></asp:Label>
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

         <br/>
          
         </asp:Panel>
      <ajax:RoundedCornersExtender ID="Panel1_RoundedCornersExtender"
        runat="server" Enabled="True" TargetControlID="pnlContent" Radius="15">
    </ajax:RoundedCornersExtender>

    <script src="../Scripts/select2.min.js"></script>

    
   
   <%--  <script>
         $("#<%=ddl_Products.ClientID%>").select2({
           /*  placeholder: "*** Select Option ***",*/
             allowClear: true
         });
     </script>--%>
    <%--  <script>
          $("#<%=ddl_SpecimenTypes.ClientID%>").select2({
              /*  placeholder: "*** Select Option ***",*/
              allowClear: true
          });
      </script>--%>
     <div id="showCategoryModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
              
                <div class="modal-header">
                      <div>
                         <h4 class="modal-title">Add Category</h4>
                    </div>
                    <button type="button" class="close" data-bs-dismiss="modal">&times;</button>
               
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:label class="col-xs-2 control-label"  runat="server" Font-Size="Large">
                                Category
                            </asp:label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox  ID="txtAddCategory" runat="server" Width="400px" Font-Size="Medium"></asp:TextBox>
                           
                        </div>
                    </div>
                <br>
                    <div class="row">
                        <div class="col-xs-12 text-center" style="padding-left:200px;">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddCategory" runat="server" Text="Add"  UseSubmitBehavior="false" OnClick="btnAddCategory_Click"/>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

     <div id="showSpecimenModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
              
                <div class="modal-header">
                      <div>
                         <h4 class="modal-title">Add Specimen Type</h4>
                    </div>
                    <button type="button" class="close" data-bs-dismiss="modal">&times;</button>
               
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:label class="col-xs-2 control-label"  runat="server" Font-Size="Large">
                                Specimen Type
                            </asp:label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox  ID="txtAddSpecimen" runat="server" Width="400px" Font-Size="Medium"></asp:TextBox>
                           
                        </div>
                    </div>
                <br>
                    <div class="row">
                        <div class="col-xs-12 text-center" style="padding-left:200px;">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddSpecimen" runat="server" Text="Add"  UseSubmitBehavior="false" OnClick="btnAddSpecimen_Click"/>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
