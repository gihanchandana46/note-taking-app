using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoteServer.Models;
using System.Collections;
using System.Data.SqlClient;

namespace NoteServer
{
    public class NotePercistance
    {

        public ArrayList getNote()
        {
            ArrayList noteArray = new ArrayList();
            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM note";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();

            while (myreader.Read())
            {
                Note p = new Note();
                p.id = myreader.GetInt32(0);

                p.date = myreader.GetDateTime(1);
                p.title = myreader.GetString(2);
                p.body = myreader.GetString(3);
                p.username = myreader.GetString(4);

                noteArray.Add(p);

            }
            return noteArray;
        }



        public ArrayList getNotebyId(String username)
        {
           
            ArrayList noteArray = new ArrayList();
            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM note where username='"+username.ToString()+"'";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();


            while (myreader.Read())
            {
                Note p = new Note();
                p.id = myreader.GetInt32(0);
                p.date = myreader.GetDateTime(1);
                p.title = myreader.GetString(2);
                p.body = myreader.GetString(3);
                p.username = myreader.GetString(4);
                noteArray.Add(p);
            }
            return noteArray;
            
           
        }


        public bool saveNote(Note NoteToSave)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM note WHERE id = '" + NoteToSave.id.ToString() + "'";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();

            if (myreader.Read())
            {
                return true;
            }

            else
            {
                myreader.Close();
                sqlString = "INSERT INTO note (date,title,body,username) VALUES ('" + dateTime.ToString("yyyy/MM/dd") + "','" + NoteToSave.title + "','" + NoteToSave.body + "','" + NoteToSave.username + "')";
                cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return false;

            }

        }


        public bool updateNote(int id, Note NoteToSave)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM note WHERE id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();

            if (myreader.Read())
            {
                myreader.Close();
                sqlString = "Update note set titile= '"+NoteToSave.title+"', body='"+NoteToSave.body+"'where id ='"+ id + "'";
                cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }

            else
            {
               
                return false;

            }

        }


        public bool deleteNote(int id)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            SqlConnection conn = DbConnect.GetConnection();
            SqlDataReader myreader = null;
            String sqlString = "SELECT * FROM note WHERE id = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            myreader = cmd.ExecuteReader();

            if (myreader.Read())
            {
                myreader.Close();
                sqlString = "Delete from note where id= '"+id+"'";
                cmd = new SqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }

            else
            {

                return false;

            }

        }




    }


}