<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Visual_Studio_Capping_Project.Homepage" %>
<!DOCTYPE html>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<link rel="icon" href="../images/marist.ico">
<script src="../js/addAuthor.js"></script>
<script src="../js/submit.js"></script>
<script src="../../models/Register.js"></script>
<style media="screen">
   .card-columns {
   column-count: 1;
   }
   table {
   font-size: 14px;
   }
</style>
<!--<html xmlns="http://www.w3.org/1999/xhtml"> -->
<head runat="server">
   <title></title>
   <style type="text/css">
      #form1 {
      height: 558px;
      }
   </style>
</head>



<body>
<form id="form1" runat="server">

   
  

<nav class="navbar navbar-dark" style="background-color: #b31b1b;">
    <div class="container">
        <span style="width: 70%;">
            <!-- <img id="marist_logo" src="./marist_logo.png"> -->
            <img src="https://www.marist.edu/marist-theme/images/marist-header-logo.png" alt="Marist College logo">
        </span>
        <span class="text-white ml-auto" style="font-size: 24px;">
            <div>
                Faculty/Administrator
            </div>
            <div>
                Rented Regalia Request
            </div>
        </span>
    </div>
</nav>
   <div class="container" style="padding-top: 25px;">
      <div class="row">
         <div class="mx-auto col-lg-10 col-sm-*">
            <!--<div class="card-columns">
               <div id="mainCard" class="card">
                  <div class="card-header text-white bg-danger">
                     <div class="container">
                        <div class="row d-flex">
                           <h1 style="font-size: 70px;">
                              Marist College
                           </h1>
                           <span class="ml-auto float-right" style="margin: auto 0 auto auto; font-size: 24px;">
                              <div>
                                 Faculty/Administrator
                              </div>
                              <div>
                                 Rented Regalia Request
                              </div>
                           </span>
                        </div>
                     </div>
                  </div>-->
                  <div class="card-body">
                     <div class="container">
                        <div class="row">
                           <div class="container-fluid col-4">
                              <div class="card">
                                 <div class="card-header text-white bg-warning" style="height: 50px;">
                                    <h5>
                                       Cap Size
                                    </h5>
                                 </div>
                                 <div class="card-body">
                                    <table class="table table-striped table-sm table-bordered">
                                       <thead>
                                          <tr>
                                             <th scope="col" style="width: 40%;">Size</th>
                                             <th scope="col" style="width: 60%;">Inches</th>
                                          </tr>
                                       </thead>
                                       <tbody>
                                          <tr>
                                             <td>5 &frac78;</td>
                                             <td>18 &frac12; - 18 &frac58;</td>
                                          </tr>
                                          <tr>
                                             <td>6</td>
                                             <td>18 &frac34; - 19</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac18;</td>
                                             <td>19 &frac18; - 19 &frac38;</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac14;</td>
                                             <td>19 &frac12; - 19 &frac34;</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac38;</td>
                                             <td>19 &frac78; - 20 &frac18;</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac12;</td>
                                             <td>20 &frac14; - 20 &frac12;</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac58;</td>
                                             <td>20 &frac58; - 20 &frac78;</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac34;</td>
                                             <td>21 - 21 &frac38;</td>
                                          </tr>
                                          <tr>
                                             <td>6 &frac78;</td>
                                             <td>21 &frac12; - 21 &frac34;</td>
                                          </tr>
                                          <tr>
                                             <td>7</td>
                                             <td>21 &frac78; - 22 &frac18;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac18;</td>
                                             <td>22 &frac14; - 22 &frac12;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac14;</td>
                                             <td>22 &frac58; - 22 &frac78;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac38;</td>
                                             <td>23 - 23 &frac14;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac12;</td>
                                             <td>23 &frac38; - 23 &frac58;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac58;</td>
                                             <td>23 &frac34; - 24 &frac18;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac34;</td>
                                             <td>24 &frac14; - 24 &frac12;</td>
                                          </tr>
                                          <tr>
                                             <td>7 &frac78;</td>
                                             <td>24 &frac58; - 24 &frac78;</td>
                                          </tr>
                                          <tr>
                                             <td>8</td>
                                             <td>25 - 25 &frac14;</td>
                                          </tr>
                                       </tbody>
                                    </table>
                                 </div>
                              </div>
                           </div>
                           <div class="container col-8">
                              <div class="card">
                                 <!-- <div class="container"> -->
                                 <div class="card-header">
                                    <div class="d-flex justify-content-between" style="margin-top: 15px;">
                                       <div class="form-group">
                                          <button type="button" class="btn text-white btn-lg" style="height: 55px; background-color: #006e7a;">Place a New Order</button>
                                       </div>
                                       <div class="form-group">
                                          <button type="button" class="btn text-white btn-lg" style="height: 55px; background-color: #006e7a;">Load Last Years Order</button>
                                       </div>
                                    </div>
                                 </div>
                                 <div class="card-body">
                                    <p>
                                       <span class="font-weight-bold" style="font-size: 22px;">1. </span>
                                       <span class="font-weight-bold">Which Ceremony are you attending? </span>
                                       <span class="text-danger"> *</span>
                                       <span>(Check one or both):</span>
                                    </p> 
                                    <div class="form-check">
                                       <input type="checkbox" class="form-check-input" id="fridayCheckBox" runat="server" value="1">
                                       <label class="form-check-label" for="exampleCheck1">Friday Evening (Adult & Masters)</label>
                                    </div>
                                    <div class="form-check">
                                       <input type="checkbox" class="form-check-input" id="saturdayCheckBox" runat="server" value="1">
                                       <label class="form-check-label" for="exampleCheck1">Saturday (Traditional Bachelors)</label>
                                    </div>
                                    <hr>
                                    <p>
                                       <span class="font-weight-bold" style="font-size: 22px;">2. </span>
                                       <span class="font-weight-bold">Please Enter the Following Information:</span>
                                    </p>
                                    <!--         <body style="height: 5000px">
                                       -->    
                                    <div class="form-group">
                                       <label for="name" class="font-weight-bold">
                                       <span>Name</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <input class="form-control" id="nameTextBox" type="Text" aria-describedby="department" runat="server" onkeydown="__doPostBack(this.name,'OnKeyPress');">
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="email" class="font-weight-bold">
                                       <span>Email</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       
                                        
                                        
                                        <input class="form-control" id="emailTextBox" type="Text" aria-describedby="department" runat="server" AutoPostBack="true" OnKeyDown="CallingServerSideFunction()" ClientMode="Static" EnablePageMethods="true">
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                 

                                     <asp:textbox id="MyTextBox" runat="server" onkeydown="__doPostBack(this.name,'OnKeyPress');" ></asp:textbox>

                                    <script type="text/javascript">


                                        function hello() {

    alert("hi")

    }

</script>
                                    <div class="form-group">
                                       <label for="department" class="font-weight-bold">
                                       <span>Department</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <input class="form-control" id="departmentTextBox" type="Text" aria-describedby="department" runat="server">
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="phone_number" class="font-weight-bold">
                                       <span>Phone Number</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <input class="form-control" id="phoneNumberTextBox" type="Text" aria-describedby="phoneNumber" runat="server">
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="height" class="font-weight-bold">
                                       <span>Height</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <div class="container row">
                                          <input style="width: 75px;" class="form-control" id="heightFeetTextBox" type="Text" runat="server">
                                          <label style="padding: 8 16px 0 8px;">feet</label>
                                          <input style="width: 75px;" class="form-control" id="heightInchesTextBox" type="Text" runat="server">
                                          <label style="padding: 8 16px 0 8px">inches</label>
                                       </div>
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="weight" class="font-weight-bold">
                                       <span>Weight</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <div class="container row">
                                          <input style="width: 75px;" class="form-control" id="weightTextBox" type="Text" runat="server">
                                          <label style="padding: 8 16px 0 8px;">lbs</label>
                                       </div>
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="capSize" class="font-weight-bold">
                                       <span>Cap Size</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <div class="container row">
                                          <input style="width: 75px;" class="form-control" id="capSizeTextBox" type="text" runat="server">
                                          <label style="padding: 8 16px 0 8px;"> Enter cap size or inches</label>
                                       </div>
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="degree" class="font-weight-bold">
                                       <span>Degree</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <select class="form-control" id="degreeDropDownList" placeholder="Select One" runat="server">
                                          <option value="" selected disabled>-- Select One --</option>
                                          <option value="Associate Degree">Associate Degree</option>
                                          <option value="Bachelor Degree">Bachelor Degree</option>
                                          <option value="Master Degree">Master Degree</option>
                                          <option value="Doctoral Degree">Doctoral Degree</option>
                                       </select>
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="city" class="font-weight-bold">
                                       <span>College City</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <input class="form-control" id="cityTextBox" type="Text" aria-describedby="city" runat="server">
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="state" class="font-weight-bold">
                                       <span>State</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <select class="form-control" id="stateDropDownList" placeholder="Select One" runat="server" data-source="~/XMLFile1.xml" data-valuekey="value">
                                          <option value="" selected disabled>-- Select One --</option>
                                       </select>
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <label for="state" class="font-weight-bold">
                                       <span>University</span>
                                       <span class="text-danger"> *</span>
                                       </label>
                                       <select class="form-control" id="collegeDropDownList" placeholder="Select One" runat="server" data-source="~/XMLFile1.xml" data-valuekey="value">
                                          <option value="" selected disabled>-- Select One --</option>
                                       </select>
                                       <div class="invalid-feedback">Sorry, you missed this one!</div>
                                    </div>
                                    <div class="form-group">
                                       <div class="text-right">
                                          <button ID="Button1" onServerClick="Button1_Click" type="button" class="btn text-white text-right" style="background-color: #006e7a;" runat="server">Submit</button>
                                       </div>
                                    </div>
</form>

</body>
</div>
<!-- </div> -->
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div class="container-fluid text-white" id="footer-bottom-wrapper" style="background-color: #404040; height: 219px; bottom: ">
    <div class="container-fluid" id="footer-bottom">
        <div id="marist-info" style="margin-top: 60px;">
            <img src="https://www.marist.edu/marist-theme/images/marist-header-logo.png" alt="Marist College logo">
            <p>Marist College, 3399 North Road, Poughkeepsie, NY 12601 | 845-575-3000<br>
            © Copyright
            2019 Marist College. All Rights Reserved. <a href="https://www.marist.edu/disclaimers">Disclaimers</a> | <a href="https://www.marist.edu/privacy-policy">Privacy Policy</a> | <a href="https://www.marist.edu/web-accessibility-policy">Accessibility Policy</a></p>
        </div>
    </div>
</div>
</div>
</div>
