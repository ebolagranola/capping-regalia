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
            con.ConnectionString = "Data Source=DESKTOP-AUSRECR;User ID=sa;Password=alpaca;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Initial Catalog=Capping";
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Regalia" + "(Email, School) VALUES (@email, @school)", con);
            cmd.Parameters.AddWithValue("@email", TextBox1.Text);
            cmd.Parameters.AddWithValue("@school", DropDownList1.SelectedItem.Value);
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}