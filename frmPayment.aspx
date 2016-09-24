<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPayment.aspx.cs" Inherits="AdminTool.frmPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
        .ListRowGrid
        {
            border-bottom: 10px #fff solid;
            background-color: #efefef;
            height: 50px;
            margin-left: 10px;
        }
        
        .ListRowGrid td
        {
            padding-left: 15px;
            vertical-align: middle;
        }
        
        .ListHeaderGrid
        {
            background-color: #BDC9D6;
            height: 50px;
        }
        
        .ListHeaderGrid th
        {
            padding-left: 15px;
            vertical-align:middle;
        }
        .style1
        {
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 20px 20px; border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
                        <asp:ImageButton ID="ImageGoBack3" ValidationGroup="text" runat="server" ImageUrl="~/Images/goBack.png"
                            Style="height: 30px; width: 30px; vertical-align: middle; margin:5px;" OnClientClick="if(!ValidateSearch()) return false;"
                            OnClick="ImageGoBack3_Click" align="left" />
            <asp:Label ID="lblHeader" runat="server" Text="PAYMENT" Font-Size="18" Font-Names="Forum"></asp:Label>
        </div>
        <div style="padding: 20px;">
            <table width="100%">
                <tr>
                    <td colspan="3">
                        <div id="GroupDetails" runat="server" width="100%">
                            <asp:GridView ID="GridPaymentDetails" runat="server" Width="101%" AllowPaging="True"
                              AutoGenerateColumns="False" GridLines="None" DataKeyNames="Id"                              >
                                <HeaderStyle CssClass="ListHeaderGrid" HorizontalAlign="Left" BorderColor="#bbd3e9"  BackColor="#e5eef6" />
                                <RowStyle CssClass="ListRowGrid" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" Height="40" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            S No.</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hiddenUserId" runat="server" Value='<%# Eval("id") %>' />
                                            <asp:HiddenField ID="hiddenPaymentAmout" runat="server" Value='<%# Eval("paymentAmount") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle CssClass="minWidth" />
                                        <HeaderTemplate>
                                            API Description
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                
                                
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Action
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                           <asp:Button runat="server" ID="imgButtonUpgrade" Text="Buy" CssClass="btn" CommandArgument='<%# Eval("id") %>' OnClick="imgBtnUserpayment_Click"  EnableViewState="false" Width="125" CausesValidation="true" ValidationGroup="Group1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <asp:Label ID="emptyListMsg" runat="server" Text="NA"></asp:Label>
</asp:Content>
