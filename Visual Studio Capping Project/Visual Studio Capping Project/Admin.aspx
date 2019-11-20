<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Visual_Studio_Capping_Project.Admin" %>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

<style>

</style>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script> 
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="padding-top: 25px; min-width: 90%">
          <div class="row">
            <div class="mx-auto col-lg-12 col-xs-*">
              <div class="card">
                <div class="card-header text-white" style="background-color: #b31b1b;">
                  <h2>
                    Regalia Entries
                  </h2>
                </div>
                <div class="card-body">
                    <div class="d-flex justify-content-around">
                        <button onClick="showFaculty()" type="button" class="btn text-white text-right" style="background-color: #006e7a;">Display Faculty Table</button>
                        <button onClick="showOrders()" type="button" class="btn text-white text-right" style="background-color: #006e7a;">Display Faculty Table</button>
                        <button onClick="exportFacultyTable()" type="button" class="btn text-white text-right bg-success">Export Faculty Table to Excel</button>
                        <button onClick="exportUserData()" type="button" class="btn text-white text-right bg-success">Export Orders table to Excel</button>
                        <button onClick="exportUserData()" type="button" class="btn text-white text-right bg-success">Export All to Excel</button>
                    </div>


                    <div id="facultyTable" class="container" style="padding-top: 25px; min-width: 100%; display: none;">
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
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Email" DataSourceID="SqlDataSource1" CssClass="small table table-bordered table-striped table-sm table-hover">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="CapSize" HeaderText="CapSize" SortExpression="CapSize" />
                                        <asp:BoundField DataField="HeadSize" HeaderText="HeadSize" SortExpression="HeadSize" />
                                        <asp:BoundField DataField="University" HeaderText="University" SortExpression="University" />
                                        <asp:BoundField DataField="Degree" HeaderText="Degree" SortExpression="Degree" />
                                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />

                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteRow" CssClass="btn-danger btn"></asp:Button>                    
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnEdit" Text="Edit" CommandName="EditRow" CssClass="btn-warning btn"></asp:Button>                    
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div id="ordersTable" class="container" style="padding-top: 25px; min-width: 100%; display: none;">
                        <div class="row">
                            <div class="mx-auto col-lg-12 col-xs-*">
                                <div class="card">
                                    <div class="card-header">
                                        <h2>
                                            Orders Table
                                        </h2>
                                    </div>
                                    <div class="card-body">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="SqlDataSource2" CssClass="small table table-bordered table-striped table-sm table-hover">
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
                                                <asp:BoundField HeaderText="Delete" />
                                                <asp:BoundField HeaderText="Edit" />
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

<script>

    function showFaculty() {
        document.getElementById("facultyTable").style.display = "initial";
        document.getElementById("ordersTable").style.display = "none";

        //var deleteRow = $('#facultyTable th:contains("Delete")').index();
        //var editRow = $('#facultyTable th:contains("Edit")').index();

        //var rowNums = document.getElementById("facultyTable").querySelectorAll("tr");

        //for (var i = 1; i < rowNums.length; i++) {
        //    console.log(document.getElementById("facultyTable").querySelectorAll("tr")[i].querySelectorAll("td")[deleteRow]);
        //    document.getElementById("facultyTable").querySelectorAll("tr")[i].querySelectorAll("td")[deleteRow].innerHTML = "<button style='font-size: 12px;' type='button' class='btn btn-danger btn-block'>" +
        //        "<svg id='i-trash' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32' width='15' height='15' fill='none' stroke='currentcolor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'>" +
        //        "<path d='M28 6 L6 6 8 30 24 30 26 6 4 6 M16 12 L16 24 M21 12 L20 24 M11 12 L12 24 M12 6 L13 2 19 2 20 6' />" +
        //        "</svg>" +
        //        "</button>";
        //    document.getElementById("facultyTable").querySelectorAll("tr")[i].querySelectorAll("td")[editRow].innerHTML = "<button style='font-size: 12px;' type='button' class='btn btn-warning btn-block'>" +
        //        "<svg id='i-compose' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32' width='15' height='15' fill='none' stroke='currentcolor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'>" +
        //        "<path d='M27 15 L27 30 2 30 2 5 17 5 M30 6 L26 2 9 19 7 25 13 23 Z M22 6 L26 10 Z M9 19 L13 23 Z' />" +
        //        "</svg>" +
        //        "</button>";
        //}
    }

    function showOrders() {
        document.getElementById("facultyTable").style.display = "none";
        document.getElementById("ordersTable").style.display = "initial";

        //var deleteRow = $('#ordersTable th:contains("Delete")').index();
        //var editRow = $('#ordersTable th:contains("Edit")').index();

        //var rowNums = document.getElementById("ordersTable").querySelectorAll("tr");

        //for (var i = 1; i < rowNums.length; i++) {
        //    document.getElementById("ordersTable").querySelectorAll("tr")[i].querySelectorAll("td")[deleteRow].innerHTML = "<button style='font-size: 12px;' type='button' class='btn btn-danger btn-block'>" +
        //        "<svg id='i-trash' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32' width='15' height='15' fill='none' stroke='currentcolor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'>" +
        //        "<path d='M28 6 L6 6 8 30 24 30 26 6 4 6 M16 12 L16 24 M21 12 L20 24 M11 12 L12 24 M12 6 L13 2 19 2 20 6' />" +
        //        "</svg>" +
        //        "</button>";
        //    document.getElementById("ordersTable").querySelectorAll("tr")[i].querySelectorAll("td")[editRow].innerHTML = "<button style='font-size: 12px;' type='button' class='btn btn-warning btn-block'>" +
        //        "<svg id='i-compose' xmlns='http://www.w3.org/2000/svg' viewBox='0 0 32 32' width='15' height='15' fill='none' stroke='currentcolor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'>" +
        //        "<path d='M27 15 L27 30 2 30 2 5 17 5 M30 6 L26 2 9 19 7 25 13 23 Z M22 6 L26 10 Z M9 19 L13 23 Z' />" +
        //        "</svg>" +
        //        "</button>";
        //}
    }
</script>
