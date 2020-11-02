using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApiWeb.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace RestApiWeb.Dominio
{
    public class DContacto
    {
        public string GuardaContacto(Contact _contacto)
        {
            string mensaje = "";

            try
            {
               
                DataBase database = new DataBase();

                database.DBOpen();
                var result = PostContacto(_contacto, database);
                database.DBClsoe();
                mensaje = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return mensaje;
        }

        private string PostContacto(Contact contacto, DataBase database)
        {
            string message = "";

            try
            {

                string sql = @" INSERT INTO dbanalitycs.contact (Nombre,Correo,Mensaje) ";
                sql += " VALUES ( @Nombre, @Correo, @Mensaje ) ";
      
                int rowsAffected = database.dbconnection.Execute(sql, new { 
                                                                           Nombre = contacto.Nombre,  
                                                                           Correo = contacto.Correo,
                                                                           Mensaje = contacto.Mensaje
                                                                   });
                if (rowsAffected > 0)
                {
                    message = "Mensaje Enviado";
                }
                else
                {
                    message = "Problemas al Enviar Mensaje";
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