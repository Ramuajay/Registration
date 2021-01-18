using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace matchdetails_to_database
{
    public partial class employee : System.Web.UI.Page
    {
        string connectionString = @"Server=DESKTOP-J6BPQB2\VIC;Database=master;Integrated Security = true";
        protected void Page_Load(object sender, EventArgs e)
        {
            binddatatogrid(connectionString, gview);

        }

        public class SQl
        {

            public void AddUsertoDB(users u)
            {

                MakeSqlConnections(u.username, u.firstname, u.lastname, u.email, u.phone);

            }
            public void AddUserToDB(string userName, string firstName, string lastname, string email, string phone)
            {
                MakeSqlConnections(userName, firstName, lastname, email, phone);

            }


            void MakeSqlConnections(string userName, string firstName, string lastname, string email, string phone)
            {

                SqlConnection connecttoDB = new SqlConnection();
                connecttoDB.ConnectionString = @"Server=DESKTOP-J6BPQB2\VIC;Database=master;Integrated Security = true";
                connecttoDB.Open();

                SqlCommand sql = new SqlCommand();

                sql.CommandText = "spCreateNewUser";
                sql.CommandType = System.Data.CommandType.StoredProcedure;
                sql.Connection = connecttoDB;
                sql.Parameters.AddWithValue("@userName", userName);
                sql.Parameters.AddWithValue("@firstName", firstName);
                sql.Parameters.AddWithValue("@lastname", lastname);
                sql.Parameters.AddWithValue("@email", email);
                sql.Parameters.AddWithValue("@phone", phone);
                sql.ExecuteNonQuery();

            }

            public void binddatatogrid(string connectionString, GridView gview)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    SqlDataAdapter sqlDa = new SqlDataAdapter("select * from employee", sqlCon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    gview.DataSource = dtbl;
                    gview.DataBind();

                    sqlCon.Close();

                }
            }
            protected void btnSubmitTeamName_Click(object sender, EventArgs e)
            {
                
            }

        }
       

    }
}
