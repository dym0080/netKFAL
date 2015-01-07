<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetExamination.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="background-image:url(image/总登陆页面.jpg);width:456px;height:296px" align="center">
        <tr>
            <td align="right" style="width:443px;height:132px"></td>
            <td style="width:123px;height:132px"></td>
            <td align="left" style="width: 114px; height: 132px"></td>
        </tr>
        <tr>
            <td align="right" style="width:443px">
                <asp:Label ID="lblUserName" runat="server" Font-Size="9pt" Text="用户名"></asp:Label>
            </td>
            <td style="width:123px;font-size:12pt">
                <asp:TextBox ID="txtUserName" runat="server" Width="120px"></asp:TextBox>
            </td>
            <td align="left" style="width:114px;font-size:12pt">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ErrorMessage="请输入用户名"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" runat="server" ControlToValidate="txtPWD" ErrorMessage="请输入密码"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:443px;height:37px">
                <asp:Label ID="lblPWD" runat="server" Font-Size="9pt" Text="密码"></asp:Label>
            </td>
            <td style="width:123px;font-size:12pt;height:37px">
                <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" Width="120px"></asp:TextBox>
            </td>
            <td align="left" style="width: 114px; height: 37px">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 443px; height: 19px">
                    <asp:Label ID="Label4" runat="server" Font-Size="9pt" Text="验证码"></asp:Label></td>
            <td align="right" style="height:19px;width:123px">
                <asp:TextBox ID="txtValiDate" runat="server" Width="76px"></asp:TextBox>
                <asp:Label ID="lblValiDate" runat="server" BackColor="#C0C0FF" ForeColor="Red" Text="Label"></asp:Label>
            </td>
            <td align="left" style="width: 114px; height: 19px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtValiDate" ErrorMessage="请输入验证码"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:443px;height:47px">
                <asp:CheckBoxList ID="cbAdminLogin" runat="server" Font-Size="9pt">
                    <asp:ListItem>管理员登陆</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td style="width: 123px; height: 47px">
                <asp:Button ID="btnLogin" runat="server" Text="登陆" OnClick="btnLogin_Click" />
                <asp:Button ID="btnZC" runat="server" CausesValidation="false" Text="注册" OnClick="btnZC_Click" />
                <asp:Button ID="btnFindPWD" runat="server" CausesValidation="false" Text="忘码" OnClick="btnFindPWD_Click" />
            </td>
            <td rowspan="1" style="width: 114px; height: 47px">
                <asp:ValidationSummary ID="ValidationSummary1" Font-Size="9pt" Height="24px" Width="112px" ShowMessageBox="true" ShowSummary="false" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
