using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazar_Web.Models
{
    public class Orden
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaPedido { get; set; }
        public EstadoOrden Estado { get; set; }
        public List<OrdenItem> Items { get; set; }
    }

    public enum EstadoOrden
    {
        Creada,
        Procesando,
        Entregada,
        Rechazada
    }
}