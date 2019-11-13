<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Visual_Studio_Capping_Project.Admin" %>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="padding-top: 25px; min-width: 90%">
          <div class="row">
            <div class="mx-auto col-lg-12 col-xs-*">
              <div class="card">
                <div class="card-header bg-danger text-white">
                  <h2>
                    Regalia Entries
                  </h2>
                </div>
                <div class="card-body">
                  <div class="d-flex justify-content-around">
                    <button onClick="exportFacultyTable()" type="button" class="btn btn-primary text-right">Export Faculty Table to Excel</button>
                    <button onClick="exportUserData()" type="button" class="btn btn-primary text-right">Export Orders table to Excel</button>
                    <button onClick="exportUserData()" type="button" class="btn btn-primary text-right">Export All to Excel</button>
                  </div>


                    <div class="container" style="padding-top: 25px; min-width: 100%">
                      <div class="row">
                        <div class="mx-auto col-lg-12 col-xs-*">
                          <div class="card">
                            <div class="card-header">
                              <h2>
                                Faculty Table
                              </h2>
                            </div>
                            <div class="card-body">                
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CappingConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Faculty]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CappingConnectionString %>" SelectCommand="SELECT * FROM [Orders]"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Email" DataSourceID="SqlDataSource1">
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
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                        <div class="container" style="padding-top: 25px; min-width: 100%">
                          <div class="row">
                            <div class="mx-auto col-lg-12 col-xs-*">
                              <div class="card">
                                <div class="card-header">
                                  <h2>
                                    Orders Table
                                  </h2>
                                </div>
                                    <div class="card-body">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="SqlDataSource2">
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
            </div>
          </div>
        </div>
    </form>
</body>
</html>
