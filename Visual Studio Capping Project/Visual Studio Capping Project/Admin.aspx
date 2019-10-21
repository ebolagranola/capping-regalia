<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Visual_Studio_Capping_Project.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Here is the database</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CappingConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Faculty]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CappingConnectionString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>
        <br />
        <br />
        Faculty Table:<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Email" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                <asp:BoundField DataField="CapSize" HeaderText="CapSize" SortExpression="CapSize" />
                <asp:BoundField DataField="HeadSize" HeaderText="HeadSize" SortExpression="HeadSize" />
                <asp:BoundField DataField="University" HeaderText="University" SortExpression="University" />
                <asp:BoundField DataField="Degree" HeaderText="Degree" SortExpression="Degree" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        Orders Table:<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="OrderID" ReadOnly="True" SortExpression="OrderID" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="DateandTime" HeaderText="DateandTime" SortExpression="DateandTime" />
                <asp:BoundField DataField="CeremonyType" HeaderText="CeremonyType" SortExpression="CeremonyType" />
                <asp:BoundField DataField="CapSize" HeaderText="CapSize" SortExpression="CapSize" />
                <asp:BoundField DataField="HeadSize" HeaderText="HeadSize" SortExpression="HeadSize" />
                <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                <asp:BoundField DataField="HeightFeet" HeaderText="HeightFeet" SortExpression="HeightFeet" />
                <asp:BoundField DataField="HeightInches" HeaderText="HeightInches" SortExpression="HeightInches" />
                <asp:BoundField DataField="Degree" HeaderText="Degree" SortExpression="Degree" />
                <asp:BoundField DataField="College" HeaderText="College" SortExpression="College" />
                <asp:BoundField DataField="CollegeCity" HeaderText="CollegeCity" SortExpression="CollegeCity" />
                <asp:BoundField DataField="CollegeState" HeaderText="CollegeState" SortExpression="CollegeState" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
