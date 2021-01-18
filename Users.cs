using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApp
{
    public class Users
    {

        public int UserID { get; }
        public string Username { get; set; }
        public string Firstname{ get; set; }

        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        
        public void CreateNewUser(Users u)
        {

            ///Vishal n Vamshi write code here
        }
        public int ModifyUser(Users u)
        {

            return 1;

        }

        public void DeleteUser(Users u)
        {



        }

        public void InactivateUser(Users u)
        {



        }
    }
}
