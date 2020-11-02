using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApiWeb.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace RestApiWeb.Dominio
{
    public class DUser
    {

        public string GuardarUser(string struser)
        {
            string mensaje = "";

            try
            {
                User usuario = new User();
                DataBase database = new DataBase();

                usuario.Username = struser;
                database.DBOpen();
                var result = PostData(usuario, database);
                database.DBClsoe();
                mensaje = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return mensaje;
        }

        private string PostData(User usuario, DataBase database)
        {
            string message = "";

            try
            {

                string sql = @" INSERT INTO dbanalitycs.users (Username) ";
                sql += " VALUES ( @Username ) ";
                //string Username;
                //Username = usuario.Username;
                //var trans = database.dbconnection.BeginTransaction();

                int rowsAffected = database.dbconnection.Execute(sql, new { Username = usuario.Username });


                if (rowsAffected > 0)
                {
                    message = "OK: Se ha guardado nuevos datos";
                }
                else
                {
                    message = "ERROR: Problemas al guardar";
                }
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


            return message;
        }
    }
}