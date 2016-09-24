﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmCategory.aspx.cs" Inherits="AdminTool.frmCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="border: 1px solid #4090fd;">
        <div style="text-align: center; border-bottom: 1px solid #4090fd;">
            <asp:Label ID="lblHeader" runat="server" Text="Choose the Any one Category" Font-Size="18"
                Font-Names="Forum"></asp:Label>
        </div>
        <div>
            <table style="text-align:center;width:100%;margin-top:3%">
                <tr>
                    <td>
                        <asp:Button ID="ImgButtonIAssist" runat="server" Text="i-Assist" CssClass="btn" EnableViewState="false"
                            Width="125" CausesValidation="true" OnClick="ImgButtonIAssist_Click" 
                            BackColor="#3E75CD" ForeColor="White" />
                    </td>
                    <td colspan=3>
                    <td>
                        <asp:Button ID="ImgButtonITest" runat="server" Text="i-Text" CssClass="btn" EnableViewState="false"
                            Width="125" CausesValidation="true" OnClick="ImgButtonITest_Click" 
                            BackColor="#3E75CD" ForeColor="White" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
