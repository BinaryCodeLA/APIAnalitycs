﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiWeb.Models
{
    public class Contact
    {
        public int? idc { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Mensaje { get; set; }
    }
}