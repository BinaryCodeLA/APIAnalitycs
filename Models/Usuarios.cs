using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiWeb.Models
{
    public class Usuarios
    {
        public  string Uid { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string telefono { get; set; }

        public Usuarios()
        {
            Uid = "user12234";
            Nombre = "Nombre de Prueba";
            Apellido = "Apellido de prueba";
            telefono = "88999988";
        }
    }
}