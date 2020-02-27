using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using Regalia.Models;

namespace Regalia.Controllers
{

    //This line right here protects everything below behind CAS authentication
    [Authorize]

    public class WebController : Controller
    {

        //Define several of the SQL commands used in later functions 
        SqlConnection con = new SqlConnection();
        SqlCommand faculty = new SqlCommand();
        SqlCommand orders = new SqlCommand();
        SqlCommand generateordernum = new SqlCommand();
        SqlCommand findemail = new SqlCommand();

        //This string reads the text file containing the connection string, this was done to make the software more portable
        string connectionstring = System.IO.File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(),@"ConnectionString.txt"));

      

        //This function gets all of the data from the webpage when the submit button is clicked and creates the appropriate SQL command to write the information
        //To the database or update the existing information
        public ActionResult GetData(bool fridayCheckBox, bool saturdayCheckBox, String Name, String PhoneNumber, String Department, int HeightFeet, int HeightInches, int Weight, String CapSize, String Degree, String Discipline, String GrantingInstitution, String InstitutionState, String InstitutionCity)
        {

            Debug.WriteLine("IS THIS WORKING");

            String facultystring;
            String ordersstring;

            if (EmailAlreadyExists(User.Identity.Name) == true)
            {

                con.ConnectionString = connectionstring;
                facultystring = "UPDATE Faculty SET Name = @name, PhoneNumber = @phonenumber, Department = @department, CapSize = @capsize, College = @college, Degree = @degree, Discipline = @discipline, HeightFeet = @heightfeet, HeightInches = @heightinches, Weight = @weight WHERE Email = @email";

                //If the order already exists then update it rather than add a new one
                if (OrderAlreadyExists(User.Identity.Name) == true)
                {

                    ordersstring = "UPDATE Orders SET Name = @name, DateandTime = @dateandtime, CeremonyType = @ceremonytype, CapSize = @capsize, HeightFeet = @heightfeet, HeightInches = @heightinches, Weight = @weight, Degree = @degree, Discipline = @discipline, College = @college, CollegeCity = @collegecity, CollegeState = @collegestate WHERE Email = @email";

                    WriteDB(facultystring, ordersstring, User.Identity.Name, Ceremony(fridayCheckBox, saturdayCheckBox), Name, PhoneNumber, Department, HeightFeet, HeightInches, Weight, CapSize, Degree, Discipline, GrantingInstitution, InstitutionState, InstitutionCity);

                }

                else if (OrderAlreadyExists(User.Identity.Name) == false)
                {

                    ordersstring = "INSERT INTO Orders" + "(OrderID, Email, Name, DateandTime, CeremonyType, CapSize, HeightFeet, HeightInches, Weight, Degree, Discipline, College, CollegeCity, CollegeState) VALUES (@ordernumber, @email, @name, @dateandtime, @ceremonytype, @capsize, @heightfeet, @heightinches, @weight, @degree, @discipline, @college, @collegecity, @collegestate )";

                    WriteDB(facultystring, ordersstring, User.Identity.Name, Ceremony(fridayCheckBox, saturdayCheckBox), Name, PhoneNumber, Department, HeightFeet, HeightInches, Weight, CapSize, Degree, Discipline, GrantingInstitution, InstitutionState, InstitutionCity);

                }

            }

            //If the email does not exist use the INSERT command to add the new data to the DB
            else if (EmailAlreadyExists(User.Identity.Name) == false)
            {

                Debug.WriteLine(HeightFeet);
                OrderAlreadyExists(User.Identity.Name);

                facultystring = "INSERT INTO Faculty" + "(Email, Name, PhoneNumber, Department, CapSize, College, Degree, Discipline, HeightFeet, HeightInches, Weight, IsAdmin, IsFaculty, AuthDate) VALUES (@email, @name, @phonenumber, @department, @capsize, @college, @degree, @discipline, @heightfeet, @heightinches, @weight, @isadmin, @isfaculty, @authdate)";
                ordersstring = "INSERT INTO Orders" + "(OrderID, Email, Name, DateandTime, CeremonyType, CapSize, HeightFeet, HeightInches, Weight, Degree, Discipline, College, CollegeCity, CollegeState) VALUES (@ordernumber, @email, @name, @dateandtime, @ceremonytype, @capsize, @heightfeet, @heightinches, @weight, @degree, @discipline, @college, @collegecity, @collegestate)";

                WriteDB(facultystring, ordersstring, User.Identity.Name, Ceremony(fridayCheckBox, saturdayCheckBox), Name, PhoneNumber, Department, HeightFeet, HeightInches, Weight, CapSize, Degree, Discipline, GrantingInstitution, InstitutionState, InstitutionCity);

            }


            SendEmail(User.Identity.Name, Name, PhoneNumber, Department, HeightFeet, HeightInches, Weight, CapSize, Degree, GrantingInstitution, InstitutionState, InstitutionCity);


            return View("CompleteRedirect");

        }

        //This fucntion is called when the active database is written to the historic, it first copies the exact active database into the 
        //historic table then clears the active table in preparation for the next ceremony
        public ActionResult WriteHistoric()
        {

            if (isAdmin())
            {

                con.ConnectionString = connectionstring;

                con.Open();


                SqlCommand writehistoric = new SqlCommand("INSERT INTO HistoricOrders SELECT * FROM Orders", con);
                SqlCommand clearorders = new SqlCommand("TRUNCATE TABLE Orders", con);



                writehistoric.ExecuteScalar();
                clearorders.ExecuteScalar();

                con.Close();

                return View("AdminRedirect");
            }

            else {

                return (View("NotAdminRedirect"));

            }

        }

        //This is the function that executes the SQL commands from above by taking in all of the values as well as the SQL command generated in the
        //Get data fucntion
        public void WriteDB(String facultystring, String ordersstring, String Email, String Ceremony, String Name, String PhoneNumber, String Department, int HeightFeet, int HeightInches, int Weight, String CapSize, String Degree, String Discipline, String GrantingInstitution, String InstitiutionState, String InstitutionCity)
        {

            con.ConnectionString = connectionstring;

            con.Open();

            faculty.CommandText = facultystring;
            faculty.Connection = con;

            faculty.Parameters.AddWithValue("@email", Email);
            faculty.Parameters.AddWithValue("@name", Name);
            faculty.Parameters.AddWithValue("@phonenumber", PhoneNumber);
            faculty.Parameters.AddWithValue("@department", Department);
            faculty.Parameters.AddWithValue("@capsize", CapSize);
            faculty.Parameters.AddWithValue("@college", GrantingInstitution);
            faculty.Parameters.AddWithValue("@degree", Degree);
            faculty.Parameters.AddWithValue("@discipline", Discipline);
            faculty.Parameters.AddWithValue("@heightfeet", HeightFeet);
            faculty.Parameters.AddWithValue("@heightinches", HeightInches);
            faculty.Parameters.AddWithValue("@weight", Weight);
            faculty.Parameters.AddWithValue("@isadmin", false);
            faculty.Parameters.AddWithValue("@isfaculty", true);
            faculty.Parameters.AddWithValue("@authdate", DateTime.Now);

            faculty.ExecuteNonQuery();


            orders.CommandText = ordersstring;
            orders.Connection = con;

            orders.Parameters.AddWithValue("@ordernumber", Ordernumber());
            orders.Parameters.AddWithValue("@email", Email);
            orders.Parameters.AddWithValue("@name", Name);
            orders.Parameters.AddWithValue("@dateandtime", DateTime.Now);
            orders.Parameters.AddWithValue("@ceremonytype", Ceremony);
            orders.Parameters.AddWithValue("@capsize", CapSize);
            orders.Parameters.AddWithValue("@heightfeet", HeightFeet);
            orders.Parameters.AddWithValue("@heightinches", HeightInches);
            orders.Parameters.AddWithValue("@weight", Weight);
            orders.Parameters.AddWithValue("@degree", Degree);
            orders.Parameters.AddWithValue("@discipline", Discipline);
            orders.Parameters.AddWithValue("@college", GrantingInstitution);
            orders.Parameters.AddWithValue("@collegecity", InstitutionCity);
            orders.Parameters.AddWithValue("@collegestate", InstitiutionState);


            orders.ExecuteNonQuery();


            con.Close();

        }

        //This fucntion is used to delete orders from the orders database, since it is an admin fucntion it first checks to see if the 
        //User is authorized to execute the command before running
        public ActionResult DeleteOrder(String id)
        {

            if (isAdmin())
            {

                con.ConnectionString = connectionstring;

                con.Open();

                SqlCommand deleteorder = new SqlCommand("DELETE FROM Orders WHERE OrderID = @id", con);

                deleteorder.Parameters.AddWithValue("@id", id);


                deleteorder.ExecuteScalar();

                con.Close();

                return (View("AdminRedirect"));
            }

            else {

                return (View("NotAdminRedirect"));

            }

        }

        //This is the fucntion used to delete faculty from the faculty table,  it first deletes the orders in the active table associated with 
        //the faculty because they are forign keys to the faulty table.  THen it 
        public ActionResult DeleteFaculty(String id)
        {

            if (isAdmin())
            {

                String email = id + "@marist.edu";


                if (email != User.Identity.Name)
                {

                    con.ConnectionString = connectionstring;

                    con.Open();

                    SqlCommand deleteorder = new SqlCommand("DELETE FROM Orders WHERE Email = @email", con);

                    SqlCommand deletefaculty = new SqlCommand("DELETE FROM Faculty WHERE Email = @email", con);


                    deletefaculty.Parameters.AddWithValue("@email", email);
                    
                    deleteorder.Parameters.AddWithValue("@email", email);


                    deleteorder.ExecuteScalar();

                    deletefaculty.ExecuteScalar();

                    con.Close();

                    return (View("AdminRedirect"));

                }

                else
                {
                    return (View("AdminRedirect"));


                }

            }

            else {

                return (View("NotAdminRedirect"));

            }

        }

        public ActionResult RevokeAdmin(String id) {

            if (isAdmin())
            {

                String email = id + "@marist.edu";


                if (email != User.Identity.Name)
                {

                    con.ConnectionString = connectionstring;

                    con.Open();

                    SqlCommand removeadmin = new SqlCommand("UPDATE Faculty SET IsAdmin = 'False' WHERE Email = @email", con);


                    removeadmin.Parameters.AddWithValue("@email", email);

                    removeadmin.ExecuteScalar();

                    con.Close();

                    return (View("AdminRedirect"));

                }

                else
                {
                    return (View("AdminRedirect"));


                }

            }

            else
            {

                return (View("NotAdminRedirect"));

            }

        }
        
        //Function for adding new admins, checks if the current user is an admin and changes the database of the faculty member whos ID was entered
        public ActionResult NewAdmin(String id)
        {

            if (isAdmin())
            {

                con.ConnectionString = connectionstring;

                if (EmailAlreadyExists(id + "@marist.edu"))
                {

                    con.Open();

                    SqlCommand makeadmin = new SqlCommand("UPDATE Faculty SET isAdmin = 1 WHERE Email = @email", con);

                    makeadmin.Parameters.AddWithValue("@email", id + "@marist.edu");

                    makeadmin.ExecuteScalar();
                }

                else
                {

                    con.Open();

                    SqlCommand makenewadmin = new SqlCommand("INSERT INTO Faculty (Email, IsAdmin, IsFaculty, AuthDate) VALUES (@email, 1, 1, @authdate)", con);

                    makenewadmin.Parameters.AddWithValue("@email", id + "@marist.edu");
                    makenewadmin.Parameters.AddWithValue("@authdate", DateTime.Now);

                    makenewadmin.ExecuteScalar();


                }

                con.Close();

                return View("AdminRedirect");

            }

            else {

                return (View("NotAdminRedirect"));

            }

        }

        //Function that loads the admin page and checks if the user is an admin and should
        //have access to the page
        public ActionResult Admin()
        {

            if (isAdmin() == true)
            {

                ViewBag.ID = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@"));

                RegaliaEntities constring = new RegaliaEntities();

                ViewBag.faculty = constring.Faculties.ToList();
                ViewBag.orders = constring.Orders.ToList();

               
               


                return View();

            }

            else {

                 return (View("NotAdminRedirect"));

            }

        }

        //This fucntion takes the user ID from CAS and checks the database to see if the account
        //has admin privledges
        public bool isAdmin()
        {

            con.ConnectionString = connectionstring;

            con.Open();

            SqlCommand getadminstatus = new SqlCommand("SELECT isAdmin FROM Faculty WHERE Email = @email", con);

            getadminstatus.Parameters.AddWithValue("@email", User.Identity.Name);

            var status = Convert.ToInt32(getadminstatus.ExecuteScalar());


            if (status == 1)
            {

                con.Close();
                return (true);
 
            }

            else {

                con.Close();

                return (false);
                
            }

        }

        //This funciton is what loads the primary survey page, it checks the databse to get the 
        //Users data for autofill and assigns them to ViewBag variables the HTML page
        //Uses to populate the fields
        public ActionResult Index()
        {
   //         Debug.WriteLine(User.Identity.NameClainType);
             ViewBag.ID = User.Identity.Name.Substring(0, User.Identity.Name.IndexOf("@"));

            if (EmailAlreadyExists(User.Identity.Name) == true)
            {

                ViewBag.Name = GetUserData("Name");
                ViewBag.PhoneNumber = GetUserData("PhoneNumber");
                ViewBag.Department = GetUserData("Department");
                ViewBag.HeightFeet = GetUserData("HeightFeet");
                ViewBag.HeightInches = GetUserData("HeightInches");
                ViewBag.Weight = GetUserData("Weight");
                ViewBag.CapSize = GetUserData("CapSize");
                ViewBag.Degree = GetUserData("Degree");
                ViewBag.Discipline = GetUserData("Discipline");
                ViewBag.University = GetUserData("College");
                
                
            }

            else {
                ViewBag.Name = null;
                ViewBag.PhoneNumber = null;
                ViewBag.Department = null;
                ViewBag.HeightFeet = null;
                ViewBag.HeightFeet = null;
                ViewBag.Weight = null;
                ViewBag.CapSize = null;
                ViewBag.Degree = null;
                ViewBag.University = null;
                
            }

            if (OrderAlreadyExists(User.Identity.Name) || HistoricOrderAlreadyExists(User.Identity.Name))
            {

                ViewBag.State = GetOrderData("CollegeState");
                ViewBag.City = GetOrderData("CollegeCity");

            }

            else
            {
                ViewBag.State = null;
                ViewBag.City = null;


            }

            return View();

        }

        //This fucntion is used to read the DB and return user data for use in other parts of this code
        public String GetUserData(String Input)
        {

            con.ConnectionString = connectionstring;

            con.Open();

            SqlCommand findinfo = new SqlCommand("SELECT " + Input + " FROM Faculty WHERE Email = @email", con);

            findinfo.Parameters.AddWithValue("@email", User.Identity.Name);

            String output = findinfo.ExecuteScalar().ToString();

            con.Close();

            return (output);

        }

        //This function is used to read the database and get order data for the given column name in the database
        //It reads the most recent information from both the active orders table and the historic orders table
        public String GetOrderData(String Input)
        {

            if (OrderAlreadyExists(User.Identity.Name) == true)
            {
                con.ConnectionString = connectionstring;

                con.Open();

                SqlCommand findinfo = new SqlCommand("SELECT " + Input + " FROM Orders WHERE Email = @email", con);

                findinfo.Parameters.AddWithValue("@email", User.Identity.Name);

                String output = findinfo.ExecuteScalar().ToString();

                con.Close();

                return (output);


            }

            else if (HistoricOrderAlreadyExists(User.Identity.Name) == true)
            {
                con.ConnectionString = connectionstring;

                con.Open();

                SqlCommand findinfo = new SqlCommand("SELECT TOP 1 " + Input + " FROM HistoricOrders WHERE Email = @email ORDER BY DateandTime DESC ", con);

                findinfo.Parameters.AddWithValue("@email", User.Identity.Name);

                String output = findinfo.ExecuteScalar().ToString();

                con.Close();

                return (output);




            }
            else {
                return (null);

            }




        } 

        //This function is used to generate ordernumbers, it reads the DB for the largest number then adds one it does this
        //by checking both the active orders table and the historic orders table
        public int Ordernumber()
        {
            int ordernumber;

            SqlCommand generateordernum = new SqlCommand("SELECT MAX(OrderID) FROM Orders", con);
            SqlCommand generatehistoricordernum = new SqlCommand("SELECT MAX(OrderID) FROM HistoricOrders", con);

            if ((generateordernum.ExecuteScalar() is DBNull) && (generatehistoricordernum.ExecuteScalar() is DBNull))
            {

            ordernumber = 1;

            }

            else
            {

                if (generatehistoricordernum.ExecuteScalar() is DBNull)
                {
                    ordernumber = (Convert.ToInt32(generateordernum.ExecuteScalar())) + 1;

                }

                else if (generateordernum.ExecuteScalar() is DBNull)
                {

                    ordernumber = (Convert.ToInt32(generatehistoricordernum.ExecuteScalar())) + 1;

                }

                else if ((Convert.ToInt32(generateordernum.ExecuteScalar())) < (Convert.ToInt32(generatehistoricordernum.ExecuteScalar())))
                {

                    ordernumber = (Convert.ToInt32(generatehistoricordernum.ExecuteScalar())) + 1;


                }

                else if ((Convert.ToInt32(generatehistoricordernum.ExecuteScalar())) < (Convert.ToInt32(generateordernum.ExecuteScalar())))
                {

                    ordernumber = (Convert.ToInt32(generateordernum.ExecuteScalar())) + 1;


                }




                else {
                    ordernumber = 1000;

                }
                

            }

            return ordernumber;

        }

        //This function is used to query the DB to find if an email has already been entered and returns a boolean
        public Boolean EmailAlreadyExists(String Email)
        {

            con.ConnectionString = connectionstring;

            con.Open();

            SqlCommand findemail = new SqlCommand("SELECT 1 FROM Faculty WHERE Email = @email", con);

            findemail.Parameters.AddWithValue("@email", Email);

            if (Convert.ToInt32(findemail.ExecuteScalar()) == 1)
            {

                con.Close();
                return true;

            }

            else
            {

                con.Close();
                return false;

            }

        }


        //This function is used to find if an order already exists from a users account
        public Boolean OrderAlreadyExists(String Email)
        {

            con.ConnectionString = connectionstring;

            con.Open();

            SqlCommand findemail = new SqlCommand("SELECT 1 FROM Orders WHERE Email = @email", con);

            findemail.Parameters.AddWithValue("@email", Email);

            if (Convert.ToInt32(findemail.ExecuteScalar()) == 1)
            {

                con.Close();
                return true;

            }

            else
            {

                con.Close();
                return false;

            }

        }

        //This fucntion is used to see if the user has a historic order in the historic database
        public Boolean HistoricOrderAlreadyExists(String Email)
        {

            con.ConnectionString = connectionstring;

            con.Open();

            SqlCommand findemail = new SqlCommand("SELECT 1 FROM HistoricOrders WHERE Email = @email", con);

            findemail.Parameters.AddWithValue("@email", Email);

            if (Convert.ToInt32(findemail.ExecuteScalar()) == 1)
            {

                con.Close();
                return true;

            }

            else
            {

                con.Close();
                return false;

            }

        }


        //This function is used to check the values of the checkboxes at the top of the webpage to find the different combinations of ceremony attendance
        public String Ceremony(bool fridayCheckBox, bool saturdayCheckBox)
        {

            String ceremony;

            if (fridayCheckBox == true && saturdayCheckBox != true)
            {

                ceremony = "Friday";

            }

            else if (saturdayCheckBox == true && fridayCheckBox != true)
            {

                ceremony = "Saturday";

            }

            else if (fridayCheckBox == true && saturdayCheckBox == true)
            {

                ceremony = "Friday and Saturday";

            }

            else
            {

                ceremony = "Not Attending";

            }

            return ceremony;

        }


        //This fucniton takes in all of the users data and sends an email to them formatted in HTML
        public static void SendEmail(String email, String name, String PhoneNumber, String Department, int HeightFeet, int HeightInches, int Weight, String CapSize, String Degree, String GrantingInstitution, String InstitutionState, String InstitutionCity)
        {
            //Change this to reflect the email you would like to use
            MailMessage mailMessage = new MailMessage("maristregalia@gmail.com", email);
            mailMessage.Subject = "Your order on MaristRegalia.site"; 
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<p>Dear " + name + ",</p> <p> Thank you for submitting your regalia order!  We have the following information listed for you:<br/> Phone Number: " + PhoneNumber + " <br/> Department: " + Department + " <br/> Height: " + HeightFeet + "\' " + HeightInches + "\"<br/>Weight: " + Weight + "<br />Cap Size: " + CapSize + "<br />Degree: " + Degree + "<br />Graduation Institution: " + GrantingInstitution + "<br />Graduation City: " + InstitutionCity + ", " + InstitutionState + "</p><p>If any of the previous information listed is incorrect, please revisit <a href='http://regalia.it.marist.edu/Web/Index'>https://regalia.it.marist.edu</a> to correct any errors.</p><p>Regards,</p><p>Marist Regalia Orders Team</p><p>&nbsp;</p>";

            //This is the mail server the email is sent from
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                //Here is the account information for the email
                UserName = "maristregalia@gmail.com",
                Password = "vkojywyjcjgwsziy"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

        }


        public void ExportOrders()
        {

            con.ConnectionString = connectionstring;

            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders", con))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())

                {

                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);

                        //Build the CSV file data as a Comma separated string.
                        string csv = string.Empty;

                        foreach (DataColumn column in dt.Columns)
                        {
                            
                            //Add the Header row for CSV file.
                            csv += column.ColumnName + ',';
                        }

                        //Add new line.
                        csv += "\r\n";

                        foreach (DataRow row in dt.Rows)
                        {

                            foreach (DataColumn column in dt.Columns)
                            {
            
                            //Add the Data rows.
                            csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';

                            }

                            //Add new line.
                            csv += "\r\n";

                        }

                        String Date = DateTime.Today.ToString("MM/dd/yyyy");

                        //Download the CSV file.
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=Orders_Table_"+ Date + ".csv");
                        Response.Charset = "";
                        Response.ContentType = "application/text";
                        Response.Output.Write(csv);
                        Response.Flush();
                        Response.End();

                    }

                }
         
            }

        }

        public void ExportFaculty()
        {

            con.ConnectionString = connectionstring;

            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Faculty", con))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())

                {

                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);

                        //Build the CSV file data as a Comma separated string.
                        string csv = string.Empty;

                        foreach (DataColumn column in dt.Columns)
                        {

                            //Add the Header row for CSV file.
                            csv += column.ColumnName + ',';
                        }

                        //Add new line.
                        csv += "\r\n";

                        foreach (DataRow row in dt.Rows)
                        {

                            foreach (DataColumn column in dt.Columns)
                            {

                                //Add the Data rows.
                                csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';

                            }

                            //Add new line.
                            csv += "\r\n";

                        }

                        String Date = DateTime.Today.ToString("MM/dd/yyyy");

                        //Download the CSV file.
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=Faculty_Table_" + Date + ".csv");
                        Response.Charset = "";
                        Response.ContentType = "application/text";
                        Response.Output.Write(csv);
                        Response.Flush();
                        Response.End();

                    }

                }

            }

        }

        public void ExportHistoricOrders()
        {

            con.ConnectionString = connectionstring;

            con.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM HistoricOrders", con))
            {

                using (SqlDataAdapter sda = new SqlDataAdapter())

                {

                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataTable dt = new DataTable())
                    {

                        sda.Fill(dt);

                        //Build the CSV file data as a Comma separated string.
                        string csv = string.Empty;

                        foreach (DataColumn column in dt.Columns)
                        {

                            //Add the Header row for CSV file.
                            csv += column.ColumnName + ',';
                        }

                        //Add new line.
                        csv += "\r\n";

                        foreach (DataRow row in dt.Rows)
                        {

                            foreach (DataColumn column in dt.Columns)
                            {

                                //Add the Data rows.
                                csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';

                            }

                            //Add new line.
                            csv += "\r\n";

                        }

                        String Date = DateTime.Today.ToString("MM/dd/yyyy");

                        //Download the CSV file.
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=Historic_Orders_Table_" + Date + ".csv");
                        Response.Charset = "";
                        Response.ContentType = "application/text";
                        Response.Output.Write(csv);
                        Response.Flush();
                        Response.End();

                    }

                }

            }

        }

        public ActionResult FormComplete() {

            return View();

        }

    }
}