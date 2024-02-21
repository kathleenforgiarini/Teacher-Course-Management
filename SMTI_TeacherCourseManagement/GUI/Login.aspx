<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMTI_TeacherCourseManagement.GUI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 44%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 148px;
        }
        .auto-style4 {
            width: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="4">Login Form</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Login As</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:RadioButtonList ID="radioBtnLoginAs" runat="server">
                        <asp:ListItem Selected="True">Coordinator</asp:ListItem>
                        <asp:ListItem>Teacher</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">ID</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" Width="165px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Password</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" Width="135px" BackColor="#000099" BorderColor="#3333FF" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="True" ForeColor="White" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
