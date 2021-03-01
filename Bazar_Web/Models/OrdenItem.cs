using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazar_Web.Models
{
    public class OrdenItem
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}