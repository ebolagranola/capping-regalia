<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Visual_Studio_Capping_Project.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 558px;
        }
    </style>
</head>
<body style="height: 427px">
    <form id="form1" runat="server">
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="emailTextBox" runat="server" OnTextChanged="emailTextBox_TextChanged"></asp:TextBox>
        <br />
        Weight&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="weightTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
&nbsp;College City&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
        <br />
&nbsp;Height Inches&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="heightinchesTextBox" runat="server"></asp:TextBox>
        <br />
        Height Feet&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="heightFeetTextBox" runat="server"></asp:TextBox>
        <br />
        Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
        Phone Number:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="phoneNumberTextBox" runat="server"></asp:TextBox>
        <br />
        Department:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="departmentTextBox" runat="server" style="height: 22px"></asp:TextBox>
        <br />
        Cap Size:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="capSizeTextBox" runat="server" Width="121px"></asp:TextBox>
        <br />
        Head Size(Inches):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="headSizeTextBox" runat="server"></asp:TextBox>
        <br />
        Ceremony&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ceremonyDropDownList" runat="server" Height="24px" Width="212px" OnSelectedIndexChanged="collegeDropDownList0_SelectedIndexChanged">
            <asp:ListItem>Saturday (Traditional Bachelors)</asp:ListItem>
            <asp:ListItem>Friday Evening (Adult &amp; Masters)</asp:ListItem>
        </asp:DropDownList>
        <br />
        University:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="collegeDropDownList" runat="server" Height="23px" Width="153px">
            <asp:ListItem>Marist</asp:ListItem>
            <asp:ListItem>SUNY</asp:ListItem>
        </asp:DropDownList>
        <br />
        Degree&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="degreeDropDownList" runat="server" Height="23px" Width="153px">
            <asp:ListItem>Associate degree	</asp:ListItem>
            <asp:ListItem>Bachelor&#39;s degree	</asp:ListItem>
            <asp:ListItem>Master&#39;s degree	</asp:ListItem>
            <asp:ListItem>Doctoral degree	</asp:ListItem>
        </asp:DropDownList>
        <br />
        State:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="stateDropDownList" runat="server" DataSourceID="XmlDataSource1" DataTextField="value" DataValueField="value">
            </asp:DropDownList>
            &nbsp;<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/XMLFile1.xml"></asp:XmlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="XmlDataSource2" DataTextField="value" DataValueField="value">
        </asp:DropDownList>
        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/XMLFile2.xml"></asp:XmlDataSource>
        <p>
        <asp:Button ID="Button1" runat="server" Height="44px" OnClick="Button1_Click" Text="Submit" Width="116px" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
