using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Visual_Studio_Capping_Project
{

    public partial class Homepage : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
           // con.ConnectionString = "Data Source=DESKTOP-AUSRECR;User ID=sa;Password=alpaca;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog=Capping";
            con.ConnectionString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Regalia" + "(Email, Name, PhoneNumber, Department, CapSize, HeadSize, University, Degree, State ) VALUES (@email, @name, @phonenumber, @department, @capsize, @headsize, @school, @degree, @state)", con);
            cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
            cmd.Parameters.AddWithValue("@name", nameTextBox.Text);

            cmd.Parameters.AddWithValue("@phonenumber", phoneNumberTextBox.Text);
            cmd.Parameters.AddWithValue("@department", departmentTextBox.Text);
            cmd.Parameters.AddWithValue("@capsize", capSizeTextBox.Text);
            cmd.Parameters.AddWithValue("@headsize", headSizeTextBox.Text);

            cmd.Parameters.AddWithValue("@school", collegeDropDownList.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@degree", degreeDropDownList.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@state", stateDropDownList.SelectedItem.Value);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void emailTextBox0_TextChanged(object sender, EventArgs e)
        {

        }
    }
}