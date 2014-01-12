using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hurtownia
{
    interface BazaImpl
    {
        //CRUD
        int Create(String query);
        DataTable Read(String query);
        int Update(String query);
        int Delete(String query);
    }

    class SQLlite : BazaImpl
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
        SQLiteCommand cmd;
        SQLiteDataReader datareader;
        DataTable dt;

        public int Create(String query)
        {
            int i = 0;
            try
            {
                conn.Open();
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                //datareader = cmd.ExecuteReader();
                conn.Close();
                //MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            return i;
        }

        public DataTable Read(string query)
        {
            try
            {
                conn.Open();
                cmd = new SQLiteCommand(query, conn);
                datareader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                dt = new DataTable();
                dt.Load(datareader);
                conn.Close();
                //MessageBox.Show("READ zakonczony sukcesem");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int Update(string query)
        {
            int i = 0;
            try
            {
                conn.Open();
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                //datareader = cmd.ExecuteReader();
                conn.Close();
                //MessageBox.Show("Update");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            return i;
        }

        public int Delete(string query)
        {
            int i = 0;
            try
            {
                conn.Open();
                cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                //datareader = cmd.ExecuteReader();
                conn.Close();
                //MessageBox.Show("Delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            return i;
        }
    }
}
