using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Visual_Studio_Capping_Project
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String connectionString = "Data Source = 10.10.9.100; User ID = sa; Password = Passw0rd12; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog=Capping";

            SqlConnection con = new SqlConnection(connectionString); 
            if (e.CommandName == "EditRow") {
                GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                int index = gr.RowIndex;
                System.Diagnostics.Debug.WriteLine(index);
                //hiddenfield.Value = index.ToString();
                //Textid.Text = gr.Cells[1].Text;
                //Textusername.Text = gr.Cells[2].Text;
                //Textclass.Text = gr.Cells[3].Text;
                //Textsection.Text = gr.Cells[4].Text;
                //Textaddress.Text = gr.Cells[5].Text;
            }
            else if (e.CommandName == "Deleterow") {
                //GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                //SqlCommand com = new SqlCommand("StoredProcedure4", con);
                //com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@ID", gr.Cells[0].Text);
                //var id = Int32.Parse(e.CommandArgument.ToString());
                //GridView1.Rows[id].Visible = false;
                //com.ExecuteNonQuery();
                //Response.Redirect("studententry.aspx");

            }
        }
    }
}