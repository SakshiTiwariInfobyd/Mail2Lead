<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmApiReport.aspx.cs" Inherits="AdminTool.frmApiReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style>
        .ListRowGrid {
            border-bottom: 10px #fff solid;
            background-color: #efefef;
            Height: 50px;
            margin-left: 10px;
        }

            .ListRowGrid td {
                padding-left: 15px;
            }

        .ListHeaderGrid {
            background-color: #FFFFFF;
            height: 50px;
        }

            .ListHeaderGrid th {
                padding-left: 15px;
            }
    .style1
    {
        height: 55px;
    }
    </style>
    <script type="text/javascript">

        function onlyAlphabets(e, t) {
            try {
                var msg = document.getElementById("<%= emptyListMsg.ClientID %>");
                msg.style.color = "Red";
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32)) {
                    $(msg).text("");
                    return true;
                }
                else {
                    $(msg).text("Invalid Name>");
                    return false;
                }
            }
            catch (err) {
                alert(err.Description);
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:Label ID="lblHeader" runat="server" Text="User API Status" Font-Size="18" Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">

            <tr>
                    <td colspan="3">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td colspan="2" align="right" class="style1">
                        <div id="DivExport" runat="server">
                            <asp:Button runat="server" ID="UpdateUser" Text="UPDATE" OnClick="UpdateUser_Click1" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                            <asp:Button runat="server" ID="ViewReport" Text="View Report" OnClick="ViewReport_Click" CssClass="btn" EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                           
                        </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="3">
                        <br />
                        <div id="ApiDetails" runat="server" width="100%">
                            <asp:GridView ID="GridView1" runat="server" Width="101%" 
                                AllowPaging="True"  AutoGenerateColumns="False" GridLines="None" DataKeyNames="Id">

                                <HeaderStyle CssClass="ListHeaderGrid" HorizontalAlign="Left" />
                                <RowStyle CssClass="ListRowGrid" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" Height="40" HorizontalAlign="Center" />
                            
                            
                             <Columns>


                                 <asp:TemplateField>
                                  <HeaderTemplate>S No.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server"
                                                Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                  </asp:TemplateField>
                                 <asp:TemplateField>
                                  <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            API Limit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAPILimit" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbAPILimit" runat="server" Text='<%# Eval("Description") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEmailId" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField>
                                 
                                  <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            Total API Count
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalAPICount" runat="server" Text='<%# Eval("APICallCount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbTotalAPICount" runat="server" Text='<%# Eval("APICallCount") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEmailId" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                 
                                 </asp:TemplateField>
                                 <asp:TemplateField>
                                  <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                           Remaining API Count
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemainingAPICount" runat="server" Text='<%# Eval("RemaningAPICount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbRemainingAPICount" runat="server" Text='<%# Eval("RemaningAPICount") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEmailId" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                   </asp:TemplateField>
                                 <asp:TemplateField>
                                  <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            API Submit Into CRM
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblAPISubmitIntoCRM" runat="server" Text='<%# Eval("SubmitToCRMCount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="tbAPISubmitIntoCRM" runat="server" Text='<%# Eval("SubmitToCRMCount") %>' Width="120" CssClass="txtbox" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatortbEmailId" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" Font-Bold="true" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                        </EditItemTemplate>
                                 
                                 
                                 </asp:TemplateField>


                             </Columns>
                            </asp:GridView>
                            </div>
                             <asp:Label ID="emptyListMsg" runat="server" Text="NA"></asp:Label>
                          </asp:Content>