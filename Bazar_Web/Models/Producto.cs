﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazar_Web.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string ImagenURL { get; set; }

        public  double Precio { get; set; }

        public int Stock { get; set; }
    }
}