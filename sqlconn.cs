using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace wpfapp
{
    class sqlconn
    {

        private string conn; // field

        private SqlConnection connobject;

        public sqlconn(string sqlcon)
        {
            conn = sqlcon; // Set the initial value for model
        }

        public void sqlconnect() // connect to sql function
        {
            SqlConnection cnn;
            string connetionString = String.Format(@"{0}", conn);

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            connobject = cnn;
        }

        public void insertcommand(string query, string land, string verdensdel1, string verdensdel2, int rang, int fødselsrate) // function to insert values to sql
        {
            SqlCommand insertCommand = new SqlCommand(query, connobject);

            insertCommand.Parameters.Add(new SqlParameter("0", land));
            insertCommand.Parameters.Add(new SqlParameter("1", verdensdel1));
            insertCommand.Parameters.Add(new SqlParameter("2", verdensdel2));
            insertCommand.Parameters.Add(new SqlParameter("3", rang));
            insertCommand.Parameters.Add(new SqlParameter("3", fødselsrate));

            insertCommand.ExecuteNonQuery();
        }

        public void insertlogin(string query, string navn, string kodeord, string rolle) // function to insert username into the database
        {
            SqlCommand command = new SqlCommand(query, connobject);

            command.Parameters.Add(new SqlParameter("0", navn));
            command.Parameters.Add(new SqlParameter("1", kodeord));
            command.Parameters.Add(new SqlParameter("2", rolle));

            command.ExecuteNonQuery();
        }

        public void editcommand(string query) // function to edit the sql server
        {
            SqlCommand command = new SqlCommand(query, connobject);

            command.ExecuteNonQuery();
        }

        public void deletecommand(string query)
        {
            SqlCommand command = new SqlCommand(query, connobject);

            command.ExecuteNonQuery();

        }

        public List<string> picktitles() // select ID column from sql database and return the values.
        {
            SqlCommand command = new SqlCommand("SELECT ID FROM fødselsrate_2017", connobject);

            List<string> mylist = new List<string>();

            command.Parameters.Add(new SqlParameter("0", 1));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        mylist.Add(reader[i].ToString());
                    }
                }

            }
            return mylist;
        }

        public string authenticate(string brugernavn, string password) // function that authenticate login - select the specified role and login information to authenticate
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE brugernavn='" + brugernavn + "' AND kodeord='" + password + "'", conn);

            DataTable dt = new DataTable();

            string returnValue = "";

            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {

                string query = "SELECT role from login WHERE brugernavn = @username and kodeord=@password";

                using (SqlCommand sqlcmd = new SqlCommand(query, connobject))
                {
                    sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = brugernavn;
                    sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    returnValue = (string)sqlcmd.ExecuteScalar();
                }

                return returnValue.Trim();
            }
            else
                return "invalid";
        }

        public List<Dictionary<string, string>> selecteverything() // function to select everything from sql database and pass them to a list. 
        {

            Dictionary<string, string> column;

            SqlCommand command = new SqlCommand("SELECT * FROM fødselsrate_2017", connobject);

            List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

            command.Parameters.Add(new SqlParameter("0", 1));

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns
                column = new Dictionary<string, string>();

                column["ID"] = reader["ID"].ToString();
                column["land"] = reader["land"].ToString();
                column["verdensdel1"] = reader["verdensdel1"].ToString();
                column["verdensdel2"] = reader["verdensdel2"].ToString();
                column["rang"] = reader["rang"].ToString();
                column["fødselsrate"] = reader["fødselsrate"].ToString();

                rows.Add(column); //Place the dictionary into the list
            }

            return rows;
        }


    }
}
