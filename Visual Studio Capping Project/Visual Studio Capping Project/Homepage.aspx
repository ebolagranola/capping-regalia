<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Visual_Studio_Capping_Project.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 427px">
    <form id="form1" runat="server">
        Email<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
&nbsp;<p>
            <asp:Button ID="Button1" runat="server" Height="44px" OnClick="Button1_Click" Text="Button" Width="116px" />
        </p>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Marist</asp:ListItem>
            <asp:ListItem>SUNY</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
