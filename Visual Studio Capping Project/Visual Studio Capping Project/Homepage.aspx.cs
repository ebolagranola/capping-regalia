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
        SqlConnection con = new SqlConnection();
        int ordernumber; 


        protected void Page_Load(object sender, EventArgs e)
        {
           // con.ConnectionString = "Data Source=DESKTOP-AUSRECR;User ID=sa;Password=alpaca;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog=Capping";
            con.ConnectionString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();

            //   SqlCommand cmd = new SqlCommand("INSERT INTO Regalia" + "(Email, Name, PhoneNumber, Department, CapSize, HeadSize, University, Degree, State ) VALUES (@email, @name, @phonenumber, @department, @capsize, @headsize, @school, @degree, @state)", con);
            SqlCommand generateordernum = new SqlCommand("SELECT MAX(OrderID) FROM Orders", con);

            ordernumber = Convert.ToInt32(generateordernum.ExecuteScalar());
            //ordernumber = 1;

            Debug.WriteLine("Ordernumber" + ordernumber);
            Debug.WriteLine("Ordernumber1" + generateordernum.ExecuteNonQuery());

            ordernumber = ordernumber + 1;

            Debug.WriteLine("Ordernumber" + ordernumber);

            SqlCommand faculty = new SqlCommand("INSERT INTO Faculty" + "(Email, Name, PhoneNumber, Department, CapSize, HeadSize, University, Degree, State) VALUES (@email, @name, @phonenumber, @department, @capsize, @headsize, @school, @degree, @state)", con);
            SqlCommand orders = new SqlCommand("INSERT INTO Orders" + "(OrderID, Email, CeremonyType, CapSize, HeadSize, Weight, HeightFeet, HeightInches, Degree, College, CollegeCity, CollegeState) VALUES (@ordernumber, @email, @ceremonytype, @capsize, @headsize, @weight, @heightfeet, @heightinches, @degree, @school, @city, @state )", con);




            faculty.Parameters.AddWithValue("@email", emailTextBox.Text);
            faculty.Parameters.AddWithValue("@name", nameTextBox.Text);

            faculty.Parameters.AddWithValue("@phonenumber", phoneNumberTextBox.Text);
            faculty.Parameters.AddWithValue("@department", departmentTextBox.Text);
            faculty.Parameters.AddWithValue("@capsize", capSizeTextBox.Text);
            faculty.Parameters.AddWithValue("@headsize", headSizeTextBox.Text);
            faculty.Parameters.AddWithValue("@weight", weightTextBox.Text);
            faculty.Parameters.AddWithValue("@heightfeet", heightFeetTextBox.Text);
            faculty.Parameters.AddWithValue("@heightinches", heightinchesTextBox.Text);
            faculty.Parameters.AddWithValue("@city", cityTextBox.Text);

            faculty.Parameters.AddWithValue("@school", collegeDropDownList.SelectedItem.Value);
            faculty.Parameters.AddWithValue("@degree", degreeDropDownList.SelectedItem.Value);
            faculty.Parameters.AddWithValue("@state", stateDropDownList.SelectedItem.Value);
            faculty.Parameters.AddWithValue("@ceremonytype", ceremonyDropDownList.SelectedItem.Value);



            faculty.ExecuteNonQuery();

            orders.Parameters.AddWithValue("@ordernumber", ordernumber);
            orders.Parameters.AddWithValue("@email", emailTextBox.Text);
            orders.Parameters.AddWithValue("@name", nameTextBox.Text);

            orders.Parameters.AddWithValue("@phonenumber", phoneNumberTextBox.Text);
            orders.Parameters.AddWithValue("@department", departmentTextBox.Text);
            orders.Parameters.AddWithValue("@capsize", capSizeTextBox.Text);
            orders.Parameters.AddWithValue("@headsize", headSizeTextBox.Text);
            orders.Parameters.AddWithValue("@weight", weightTextBox.Text);
            orders.Parameters.AddWithValue("@heightfeet", heightFeetTextBox.Text);
            orders.Parameters.AddWithValue("@heightinches", heightinchesTextBox.Text);
            orders.Parameters.AddWithValue("@city", cityTextBox.Text);

            orders.Parameters.AddWithValue("@school", collegeDropDownList.SelectedItem.Value);
            orders.Parameters.AddWithValue("@degree", degreeDropDownList.SelectedItem.Value);
            orders.Parameters.AddWithValue("@state", stateDropDownList.SelectedItem.Value);
            orders.Parameters.AddWithValue("@ceremonytype", ceremonyDropDownList.SelectedItem.Value);
            orders.ExecuteNonQuery();
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