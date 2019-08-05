using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
namespace Project_HD.DAO
{
    public class DataProvider
    {
        private static OleDbDataAdapter adapter = new OleDbDataAdapter();
        private static OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|db_test.accdb;Persist Security Info=False;");

        private static OleDbConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public static DataTable ExecuteSelectQuery(string query, OleDbParameter[] parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            DataTable dtbKetQua = new DataTable();
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameter);
                adapter.SelectCommand = cmd;
                adapter.Fill(dtbKetQua);
                conn.Close();
            }
            catch (OleDbException e)
            {
                return null;
            }

            return dtbKetQua;
        }

        public static int ExecuteInsertQuery(string query, OleDbParameter[] parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            int rowsAffected;
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameter);
                adapter.InsertCommand = cmd;
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (OleDbException e)
            {
                return 0;
            }
            return rowsAffected;
        }

        public static int ExecuteInsertLastID(string query, OleDbParameter[] parameter)
        {
            string query2 = "Select @@Identity";
            int id = 0;
            OleDbCommand cmd = new OleDbCommand();
            int rowsAffected;
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameter);
                adapter.InsertCommand = cmd;
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    cmd.CommandText = query2;
                    id = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }
            catch (OleDbException e)
            {
                return 0;
            }
            return id;
        }

        public static int ExecuteUpdateQuery(string query, OleDbParameter[] parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            int rowsAffected;
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameter);
                adapter.UpdateCommand = cmd;
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (OleDbException e)
            {
                return 0;
            }
            return rowsAffected;
        }
        public static int ExecuteArrayUpdateQuery(string query, OleDbParameter[][] parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            int rowsAffected=0;
            try
            {
                cmd.Connection = OpenConnection();
                for(int i=0;i<parameter.Length;i++)
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameter[i]);
                    adapter.UpdateCommand = cmd;
                    rowsAffected += cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (OleDbException e)
            {
                return 0;
            }
            return rowsAffected;
        }

        public static int ExecuteDeleteQuery(string query, OleDbParameter[] parameter)
        {
            OleDbCommand cmd = new OleDbCommand();
            int rowsAffected;
            try
            {
                cmd.Connection = OpenConnection();
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameter);
                adapter.DeleteCommand = cmd;
                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (OleDbException e)
            {
                return 0;
            }
            return rowsAffected;
        }
    }
}
