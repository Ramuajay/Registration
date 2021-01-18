using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;



namespace RegistrationApp
{
    public class SQl
    {

        public  void AddUsertoDB(Users u)
        {


           MakeSqlConnections(u.Username,u.Firstname,u.Lastname,u.Email,u.Phone)


        }
        public void AddUserToDB(string userName, string firstName, string lastname, string email, string phone)
        {



            MakeSqlConnections(userName,  firstName,  lastname,  email,  phone);



        }


        void MakeSqlConnections(string userName, string firstName, string lastname, string email, string phone)
        {

            SqlConnection connecttoDB = new SqlConnection();
            connecttoDB.ConnectionString = @"Server=(LocalDb)\MSSQLLocalDB;Database=RegistrationDB;Integrated Security = true";
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

        


      
    }
}