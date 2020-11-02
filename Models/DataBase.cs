using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiWeb.Models
{
    public class DataBase
    {
        public string stCnn { get; set; }
        public MySqlConnection dbconnection { get; set; }

        public DataBase()
        {
            this.stCnn = @" Data Source=dbanliticysmysql.mysql.database.azure.com; Database=dbanalitycs; User Id=binarycodela@dbanliticysmysql; Password=Geekc0de..";

        }

        public MySqlConnection DBOpen()
        {
            try
            {
                this.dbconnection = new MySqlConnection(this.stCnn);
                dbconnection.Open();
                return this.dbconnection;

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DBClsoe()
        {
            this.dbconnection.Close();
        }
    }
}