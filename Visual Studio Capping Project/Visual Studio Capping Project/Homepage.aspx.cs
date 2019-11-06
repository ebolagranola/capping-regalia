using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Configuration;
using System.Net.Mail;

namespace Visual_Studio_Capping_Project
{

    public partial class Homepage : System.Web.UI.Page
    {
        //Construct all the SQL commands we will be using

        SqlCommand faculty = new SqlCommand();
        SqlCommand orders = new SqlCommand();
        SqlCommand generateordernum = new SqlCommand();
        SqlCommand findemail = new SqlCommand();
        SqlConnection con = new SqlConnection();
     


        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Connection strings for various databases, the commended ones are old and outdated
            
            //con.ConnectionString = "Data Source=DESKTOP-AUSRECR;User ID=sa;Password=alpaca;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog=Capping";
            //con.ConnectionString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
            con.ConnectionString = "Data Source = 72.76.93.24; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";


            con.Open();

            //These funtions populate the two drop down lists on the website by reading the database 

            PopulateStates();

            PopulateColleges();



        }


        //This function reads the States table in the database and addes each value to the drop down list for selecting a state
        public void PopulateStates() {
            if (!IsPostBack)
            {

                string ConnectString = "Data Source = 72.76.93.24; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
                // string ConnectString = "Data Source = 72.76.93.24; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
                string QueryString = "select * from States";

                SqlConnection myConnection = new SqlConnection(ConnectString);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();

                myCommand.Fill(ds, "Value");

                stateDropDownList.DataSource = ds;
                stateDropDownList.DataTextField = "Value";
                stateDropDownList.DataValueField = "Value";
                stateDropDownList.DataBind();
            }

        }

        //This function reads the table that has every college and adds them to the drop down list for colleges, in the future this fucntion will be updated to query the DB on demand to reduce load times
        //This is currently commented out because the ECRL is not working and we need to rebuild the DB
        public void PopulateColleges() {
            if (!IsPostBack)
            {
                string ConnectString = "Data Source = 72.76.93.24; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
                string QueryString = "select LocationName from InstitutionCampus$";

                SqlConnection myConnection = new SqlConnection(ConnectString);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "LocationName");

                collegeDropDownList.DataSource = ds;
                collegeDropDownList.DataTextField = "LocationName";
                collegeDropDownList.DataValueField = "LocationName";
                collegeDropDownList.DataBind();
            }


        }

        //This funciton takes in SQL commands for each table and assignes variables based on the information present in the website
        public void WriteDB(SqlCommand faculty, SqlCommand orders) {

            faculty.Parameters.AddWithValue("@email", Request.Form["emailTextBox"]);
            faculty.Parameters.AddWithValue("@name", Request.Form["nameTextBox"]);
            faculty.Parameters.AddWithValue("@phonenumber", Request.Form["phoneNumberTextBox"]);
            faculty.Parameters.AddWithValue("@department", Request.Form["departmentTextBox"]);
            faculty.Parameters.AddWithValue("@capsize", Request.Form["capSizeTextBox"]);
            faculty.Parameters.AddWithValue("@headsize", 0);
            faculty.Parameters.AddWithValue("@school", Request.Form["collegeDropDownList"]);
            faculty.Parameters.AddWithValue("@degree", degreeDropDownList.Items[degreeDropDownList.SelectedIndex].Text);
            faculty.Parameters.AddWithValue("@state", Request.Form["stateDropDownList"]);

            faculty.ExecuteNonQuery();

            orders.Parameters.AddWithValue("@ordernumber", Ordernumber());
            orders.Parameters.AddWithValue("@email", Request.Form["emailTextBox"]);
            orders.Parameters.AddWithValue("@capsize", Request.Form["capSizeTextBox"]);
            orders.Parameters.AddWithValue("@headsize", 0);
            orders.Parameters.AddWithValue("@weight", Request.Form["weightTextBox"]);
            orders.Parameters.AddWithValue("@heightfeet", Request.Form["heightFeetTextBox"]);
            orders.Parameters.AddWithValue("@heightinches", Request.Form["heightInchesTextBox"]);
            orders.Parameters.AddWithValue("@city", Request.Form["cityTextBox"]);
            orders.Parameters.AddWithValue("@school", Request.Form["collegeDropDownList"]);
            orders.Parameters.AddWithValue("@degree", degreeDropDownList.Items[degreeDropDownList.SelectedIndex].Text);
            orders.Parameters.AddWithValue("@state", Request.Form["stateDropDownList"]);
            orders.Parameters.AddWithValue("@ceremonytype", Ceremony());

            orders.ExecuteNonQuery();
        }

        //This function is used to generate ordernumbers, it reads the DB for the largest number then adds one 
        public int Ordernumber() {
            int ordernumber;
            
            SqlCommand generateordernum = new SqlCommand("SELECT MAX(OrderID) FROM Orders", con);


            if (generateordernum.ExecuteScalar() is DBNull)
            {

                ordernumber = 1;

            }

            else {
                ordernumber = (Convert.ToInt32(generateordernum.ExecuteScalar())) + 1;
            }

            return ordernumber;
        }

        //This function is used to query the DB to find if an email has already been entered and returns a boolean
        public Boolean EmailAlreadyExists() {
            SqlCommand findemail = new SqlCommand("SELECT 1 FROM Faculty WHERE Email = @email", con);

            findemail.Parameters.AddWithValue("@email", Request.Form["emailTextBox"]);

            if (Convert.ToInt32(findemail.ExecuteScalar()) == 1)
            {
                return true;
            }

            else {
                return false;

          }

        }

        //This function is used to check the values of the checkboxes at the top of the webpage to find the different combinations of ceremony attendance
        public String Ceremony() {

            String ceremony;

            if (Request.Form["fridayCheckBox"] == "1" && Request.Form["saturdayCheckBox"] != "1")
            {
                ceremony = "Friday";
            }
            else if (Request.Form["saturdayCheckBox"] == "1" && Request.Form["fridayCheckBox"] != "1")
            {
                ceremony = "Saturday";
            }
            else if (Request.Form["fridayCheckBox"] == "1" && Request.Form["saturdayCheckBox"] == "1")
            {
                ceremony = "Friday and Saturday";
            }
            else {
                ceremony = "Not Attending";
            }

            return ceremony;

        }

        public static void SendEmail(String email, String name) {
            MailMessage mailMessage = new MailMessage("maristregalia@gmail.com", email);
            mailMessage.Subject = "Your order on MaristRegalia.site";
            mailMessage.Body = "Hey " + name + ", we have recived your order and put the information in our database";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "maristregalia@gmail.com",
                Password = "vkojywyjcjgwsziy"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

        }

        //This function is run on click of the submit button
        protected void Button1_Click(object sender, EventArgs e)
        {

            Debug.WriteLine(Request.Form["emailTextBox"]);

            SendEmail(Request.Form["emailTextBox"], Request.Form["nameTextBox"]);

            Debug.WriteLine(Ceremony());

            //If the email exits used the UPDATE SQL command to change the information
            if (EmailAlreadyExists() == true){

                Debug.WriteLine("Found this email");

                SqlCommand faculty = new SqlCommand("UPDATE Faculty SET Name = @name, PhoneNumber = @phonenumber, Department = @department, CapSize = @capsize, HeadSize = @headsize, University = @school, Degree = @degree, State = @state WHERE Email = @email", con);
                SqlCommand orders = new SqlCommand("UPDATE Orders SET CeremonyType = @ceremonytype, CapSize = @capsize, HeadSize = @headsize, Weight = @weight, HeightFeet = @heightfeet, HeightInches = @heightinches, Degree = @degree, College = @school, CollegeCity = @city, CollegeState = @state WHERE Email = @email", con);

                WriteDB(faculty, orders);

                Server.Transfer("UpdateUserPage.html");
                
            }

            //If the email does not exist use the INSERT command to add the new data to the DB
            else if(EmailAlreadyExists() == false){

                Debug.WriteLine("Did not find this email");

                SqlCommand faculty = new SqlCommand("INSERT INTO Faculty" + "(Email, Name, PhoneNumber, Department, CapSize, HeadSize, University, Degree, State) VALUES (@email, @name, @phonenumber, @department, @capsize, @headsize, @school, @degree, @state)", con);
                SqlCommand orders = new SqlCommand("INSERT INTO Orders" + "(OrderID, Email, CeremonyType, CapSize, HeadSize, Weight, HeightFeet, HeightInches, Degree, College, CollegeCity, CollegeState) VALUES (@ordernumber, @email, @ceremonytype, @capsize, @headsize, @weight, @heightfeet, @heightinches, @degree, @school, @city, @state )", con);

                WriteDB(faculty, orders);

                Server.Transfer("NewUserPage.html");
                
            }
            con.Close();

        }


        public void Text_Changed(Object sender, EventArgs e)
        {
            TextBox t = (TextBox)(sender);
            //use t as the current textbox that raised the event.
            Debug.WriteLine(Request.Form["emailTextBox"]);
        }

        public void test() {
            Debug.WriteLine("This is working");

        }

        protected void emailTextBox0_TextChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("text changed");
        }

        protected void emailTextBox0_TextChanged1(object sender, EventArgs e)
        {
            Debug.WriteLine(Request.Form["emailTextBox"]);
        }

        protected void collegeDropDownList0_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(Request.Form["emailTextBox"]);
        }

        protected void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(Request.Form["emailTextBox"]);
        }

        protected void collegeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(Request.Form["emailTextBox"]);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(Request.Form["emailTextBox"]);
        }
    }
}