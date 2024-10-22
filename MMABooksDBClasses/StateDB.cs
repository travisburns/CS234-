using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class StateDB
    {

        public static List<State> GetStates()
        {
            List<State> states = new List<State>();
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT StateCode, StateName "
                                   + "FROM States "
                                   + "ORDER BY StateName";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    State s = new State();
                    s.StateCode = reader["StateCode"].ToString();
                    s.StateName = reader["StateName"].ToString();
                    states.Add(s);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return states;
        }
    }
}
