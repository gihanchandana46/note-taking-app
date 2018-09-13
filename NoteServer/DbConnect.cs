using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace NoteServer
{
    public class DbConnect
    {
        public static SqlConnection GetConnection()
        {
            
            //   myconnectionString ="Data Source=localhost;" +"Initial Catalog=notetaking;" + "User ID=Gihan;" + "Password=";

            string myconnectionString;

            myconnectionString ="Data Source=localhost;" +"Initial Catalog=notetaking;" + "Integrated Security=True;";
            SqlConnection conn = new SqlConnection(myconnectionString);

            conn.Open();
            return conn;


        }

    }
}