using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NoteServer.Models;



namespace NoteServer
{
    public class UserPercistance
    {

        public UserPercistance()
        {

        }

        public bool saveUser(User user) {

            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM username WHERE username = '" + user.username.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();

            if (myreader.Read())
            {
                return true;
            }

            else
            {
                myreader.Close();
                sqlString = "INSERT INTO username (username,password) VALUES ('" + user.username.ToString() + "','" + user.password.ToString() + "')";
                cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return false;

            }

        }


        public bool checkLogin(String username , String password)
        {
            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM username WHERE username = '" + username.ToString() + "' and password = '"+password.ToString()+"'";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();

            if (myreader.Read())
            {
                return true;
            }

            else
            {
                
                return false;

            }

        }

    }
}