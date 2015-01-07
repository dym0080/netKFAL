<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoPwd.aspx.cs" Inherits="NetExamination.InfoPwd" %>

<%--<!DOCTYPE html>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>找回密码1</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">&nbsp;</div>
        <table style="width: 800px; height: 216px; text-align: center; background-image: url('igm/找回密码.jpg');" align="center">
            <tr>
                <td colspan="1" style="width: 54px; height: 246px"></td>
                <td colspan="2" style="width: 664px; height: 246px"></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 54px; height: 32px"></td>
                <td colspan="2" style="width: 664px; height: 32px">&nbsp;<asp:Label ID="Label1" Font-Size="9pt" ForeColor="Red" runat="server" Text="填写以下注册资料找回密码！"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="2" style="width: 54px; height: 275px; vertical-align: top"></td>
                <td colspan="2" rowspan="2" style="width: 664px; height: 275px; vertical-align: top">
                    <table>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="Label2" runat="server" Font-Size="9pt" Text="学生证号"></asp:Label>
                            </td>
                            <td style="width: 122px">
                                <asp:TextBox ID="txtStuID" runat="server" Width="130px"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 96px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStuID" ErrorMessage="请输入学生证号！"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtStuID" ValidationExpression="^[0-9]*$" ErrorMessage="请输入数字"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStuID" ValidationExpression="^.{16}$" ErrorMessage="学生编号为16位有效数字"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px"></td>
                            <td style="width: 122px">&nbsp;<asp:Button ID="btnSubmit" runat="server" Font-Size="9pt" Text="确定" OnClick="btnSubmit_Click" />
                            </td>
                            <td rowspan="3" style="width: 96px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="9pt" ShowMessageBox="true" ShowSummary="false" Width="112px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:100px"></td>
                            <td style="width:122px"></td>
                        </tr>
                        <tr>
                            <td style="width:100px"></td>
                            <td style="width:122px"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
