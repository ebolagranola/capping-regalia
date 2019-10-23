using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace Visual_Studio_Capping_Project
{

    public partial class Homepage : System.Web.UI.Page
    {
        SqlCommand faculty = new SqlCommand();
        SqlCommand orders = new SqlCommand();
        SqlCommand generateordernum = new SqlCommand();
        SqlCommand findemail = new SqlCommand();
        SqlConnection con = new SqlConnection();
     


        protected void Page_Load(object sender, EventArgs e)
        {
           // con.ConnectionString = "Data Source=DESKTOP-AUSRECR;User ID=sa;Password=alpaca;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog=Capping";
            con.ConnectionString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";


            con.Open();


            PopulateStates();

            PopulateColleges();



        }

        public void PopulateStates() {
            if (!IsPostBack)
            {
                string ConnectString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
                string QueryString = "select * from States";

                SqlConnection myConnection = new SqlConnection(ConnectString);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "value");

                stateDropDownList.DataSource = ds;
                stateDropDownList.DataTextField = "value";
                stateDropDownList.DataValueField = "value";
                stateDropDownList.DataBind();
            }

        }

        public void PopulateColleges() {
            if (!IsPostBack)
            {
                string ConnectString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
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


        public void UpdateInfo(SqlCommand faculty, SqlCommand orders) {

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

        public int Ordernumber() {
            int ordernumber;
            
            SqlCommand generateordernum = new SqlCommand("SELECT MAX(OrderID) FROM Orders", con);
           // Debug.WriteLine(Convert.ToInt32(generateordernum.ExecuteScalar()));


            if (generateordernum.ExecuteScalar() is DBNull)
            {

                ordernumber = 1;

            }

            else {
                ordernumber = (Convert.ToInt32(generateordernum.ExecuteScalar())) + 1;
            }

            return ordernumber;
        }

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


        protected void Button1_Click(object sender, EventArgs e)
        {

            Debug.WriteLine(Ceremony());

            if (EmailAlreadyExists() == true){

                Debug.WriteLine("Found this email");

                SqlCommand faculty = new SqlCommand("UPDATE Faculty SET Name = @name, PhoneNumber = @phonenumber, Department = @department, CapSize = @capsize, HeadSize = @headsize, University = @school, Degree = @degree, State = @state WHERE Email = @email", con);
                SqlCommand orders = new SqlCommand("UPDATE Orders SET CeremonyType = @ceremonytype, CapSize = @capsize, HeadSize = @headsize, Weight = @weight, HeightFeet = @heightfeet, HeightInches = @heightinches, Degree = @degree, College = @school, CollegeCity = @city, CollegeState = @state WHERE Email = @email", con);

                UpdateInfo(faculty, orders);

                Server.Transfer("UpdateUserPage.html");
                
            }

            else if(EmailAlreadyExists() == false){

                Debug.WriteLine("Did not find this email");

                SqlCommand faculty = new SqlCommand("INSERT INTO Faculty" + "(Email, Name, PhoneNumber, Department, CapSize, HeadSize, University, Degree, State) VALUES (@email, @name, @phonenumber, @department, @capsize, @headsize, @school, @degree, @state)", con);
                SqlCommand orders = new SqlCommand("INSERT INTO Orders" + "(OrderID, Email, CeremonyType, CapSize, HeadSize, Weight, HeightFeet, HeightInches, Degree, College, CollegeCity, CollegeState) VALUES (@ordernumber, @email, @ceremonytype, @capsize, @headsize, @weight, @heightfeet, @heightinches, @degree, @school, @city, @state )", con);

                UpdateInfo(faculty, orders);

                Server.Transfer("NewUserPage.html");
                
            }
            con.Close();

        }

        protected void emailTextBox0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void emailTextBox0_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void collegeDropDownList0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void emailTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void collegeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}