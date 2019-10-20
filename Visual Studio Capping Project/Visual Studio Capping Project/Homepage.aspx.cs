using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

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
        }


        public void UpdateInfo(SqlCommand faculty, SqlCommand orders) {

            faculty.Parameters.AddWithValue("@email", Request.Form["emailTextBox"]);
            faculty.Parameters.AddWithValue("@name", Request.Form["nameTextBox"]);
            faculty.Parameters.AddWithValue("@phonenumber", Request.Form["phoneNumberTextBox"]);
            faculty.Parameters.AddWithValue("@department", Request.Form["departmentTextBox"]);
            faculty.Parameters.AddWithValue("@capsize", Request.Form["capSizeTextBox"]);
            faculty.Parameters.AddWithValue("@headsize", headSizeTextBox.Text);
            faculty.Parameters.AddWithValue("@school", collegeDropDownList.SelectedItem.Value);
            faculty.Parameters.AddWithValue("@degree", degreeDropDownList.Items[degreeDropDownList.SelectedIndex].Text);
            faculty.Parameters.AddWithValue("@state", stateDropDownList.SelectedItem.Value);

            faculty.ExecuteNonQuery();

            orders.Parameters.AddWithValue("@ordernumber", Ordernumber());
            orders.Parameters.AddWithValue("@email", Request.Form["emailTextBox"]);
            orders.Parameters.AddWithValue("@capsize", Request.Form["capSizeTextBox"]);
            orders.Parameters.AddWithValue("@headsize", headSizeTextBox.Text);
            orders.Parameters.AddWithValue("@weight", Request.Form["weightTextBox"]);
            orders.Parameters.AddWithValue("@heightfeet", Request.Form["heightFeetTextBox"]);
            orders.Parameters.AddWithValue("@heightinches", Request.Form["heightInchesTextBox"]);
            orders.Parameters.AddWithValue("@city", Request.Form["cityTextBox"]);
            orders.Parameters.AddWithValue("@school", collegeDropDownList.SelectedItem.Value);
            orders.Parameters.AddWithValue("@degree", degreeDropDownList.Items[degreeDropDownList.SelectedIndex].Text);
            orders.Parameters.AddWithValue("@state", stateDropDownList.SelectedItem.Value);
            orders.Parameters.AddWithValue("@ceremonytype", ceremonyDropDownList.SelectedItem.Value);

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


        protected void Button1_Click(object sender, EventArgs e)
        {

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