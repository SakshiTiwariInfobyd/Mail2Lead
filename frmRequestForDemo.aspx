<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRequestForDemo.aspx.cs" Inherits="AdminTool.frmRequestForDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Note :
   - You can modify the font style and form style to suit your website. 
   - Code lines with comments “Do not remove this code”  are required for the form to work properly, make sure that you do not remove these lines of code. 
   - The Mandatory check script can modified as to suit your business needs. 
   - It is important that you test the modified form before going live.-->
    <div id='crmWebToEntityForm' style='width: 600px; margin: auto;'>
        <meta http-equiv='content-type' content='text/html;charset=UTF-8'>
        <form action='https://crm.zoho.com/crm/WebToLeadForm' name="WebToLeads1969077000000184001" method='POST' onsubmit='javascript:document.charset="UTF-8"; return checkMandatory()' accept-charset='UTF-8'>

            <!-- Do not remove this code. -->
            <input type='text' style='display: none;' name='xnQsjsdp' value='503b1277ce765935cad00b408569539d664b47120f48e2939f823fc19530195f' />
            <input type='hidden' name='zc_gad' id='zc_gad' value='' />
            <input type='text' style='display: none;' name='xmIwtLD' value='0a566b3b44c3c2a7a75c31fd52b82ddd34f04d68c6700ad97f460c0e670ead26' />
            <input type='text' style='display: none;' name='actionType' value='TGVhZHM=' />

            <input type='text' style='display: none;' name='returnURL' value='https&#x3a;&#x2f;&#x2f;www.infobyd.com' />
            <!-- Do not remove this code. -->
            <input type='text' style='display: none;' id='ldeskuid' name='ldeskuid'></input>
            <input type='text' style='display: none;' id='LDTuvid' name='LDTuvid'></input>
            <!-- Do not remove this code. -->
            <style>
                tr, td {
                    padding: 6px;
                    border-spacing: 0px;
                    border-width: 0px;
                }
            </style>
            <div style="text-align: center; border-bottom: 1px solid #4090fd;">
                <asp:Label ID="lblHeader" runat="server" Text="Request for Demo" Font-Size="18" Font-Names="Forum"></asp:Label>
            </div>
            <table style='width: 100%; background-color: white; color: black'>
                <tr>
                    <br />
                </tr>
                <tr>
                    <td style='nowrap: nowrap; text-align: left;' class="col-md-4 control-label">Company<span style='color: red;'>*</span></td>
                    <td style='width: 250px;'>
                        <input type='text' style='width: 250px;' maxlength='40' name='Company' class="form-control" /></td>
                </tr>

                <tr>
                    <td style='nowrap: nowrap; text-align: left;' class="col-md-4 control-label">First Name<span style='color: red;'>*</span></td>
                    <td style='width: 250px;'>
                        <input type='text' style='width: 250px;' maxlength='40' name='First Name' class="form-control" /></td>
                </tr>

                <tr>
                    <td style='nowrap: nowrap; text-align: left;' class="col-md-4 control-label">Last Name<span style='color: red;'>*</span></td>
                    <td style='width: 250px;'>
                        <input type='text' style='width: 250px;' maxlength='80' name='Last Name' class="form-control" /></td>
                </tr>

                <tr>
                    <td style='nowrap: nowrap; text-align: left;' class="col-md-4 control-label">Email<span style='color: red;'>*</span></td>
                    <td style='width: 250px;'>
                        <input type='text' style='width: 250px;' maxlength='100' name='Email' class="form-control" /></td>
                </tr>

                <tr>
                    <td style='nowrap: nowrap; text-align: left;' class="col-md-4 control-label">Description</td>
                    <td>
                        <textarea name='Description' maxlength='1000' style='width: 250px;' class="form-control">&nbsp;</textarea></td>
                </tr>

                <tr>
                    <td colspan='2' style='text-align: center; padding-top: 15px;'>
                        <input style='font-size: 12px; color: #131307' type='submit' value='Submit' class="btn btn-default" />
                        <input type='reset' style='font-size: 12px; color: #131307' value='Reset' class="btn btn-default" />
                    </td>
                </tr>
            </table>
            <script>
                var mndFileds = new Array('Company', 'Last Name');
                var fldLangVal = new Array('Company', 'Last Name');
                var name = '';
                var email = '';

                function checkMandatory() {
                    for (i = 0; i < mndFileds.length; i++) {
                        var fieldObj = document.forms['WebToLeads1969077000000184001'][mndFileds[i]];
                        if (fieldObj) {
                            if (((fieldObj.value).replace(/^\s+|\s+$/g, '')).length == 0) {
                                if (fieldObj.type == 'file') {
                                    alert('Please select a file to upload.');
                                    fieldObj.focus();
                                    return false;
                                }
                                alert(fldLangVal[i] + ' cannot be empty.');
                                fieldObj.focus();
                                return false;
                            } else if (fieldObj.nodeName == 'SELECT') {
                                if (fieldObj.options[fieldObj.selectedIndex].value == '-None-') {
                                    alert(fldLangVal[i] + ' cannot be none.');
                                    fieldObj.focus();
                                    return false;
                                }
                            } else if (fieldObj.type == 'checkbox') {
                                if (fieldObj.checked == false) {
                                    alert('Please accept  ' + fldLangVal[i]);
                                    fieldObj.focus();
                                    return false;
                                }
                            }
                            try {
                                if (fieldObj.name == 'Last Name') {
                                    name = fieldObj.value;
                                }
                            } catch (e) { }
                        }
                    }
                    trackVisitor();
                }
            </script>
            <script type='text/javascript' id='VisitorTracking'>var $zoho = $zoho || { salesiq: { values: {}, ready: function () { $zoho.salesiq.floatbutton.visible('hide'); } } }; var d = document; s = d.createElement('script'); s.type = 'text/javascript'; s.defer = true; s.src = 'https://salesiq.zoho.com/infobyd1/float.ls?embedname=infobyd'; t = d.getElementsByTagName('script')[0]; t.parentNode.insertBefore(s, t); function trackVisitor() { try { if ($zoho) { var LDTuvidObj = document.forms['WebToLeads1969077000000184001']['LDTuvid']; if (LDTuvidObj) { LDTuvidObj.value = $zoho.salesiq.visitor.uniqueid(); } var firstnameObj = document.forms['WebToLeads1969077000000184001']['First Name']; if (firstnameObj) { name = firstnameObj.value + ' ' + name; } $zoho.salesiq.visitor.name(name); var emailObj = document.forms['WebToLeads1969077000000184001']['Email']; if (emailObj) { email = emailObj.value; $zoho.salesiq.visitor.email(email); } } } catch (e) { } }</script>
        </form>
    </div>
</asp:Content>
