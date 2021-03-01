using Bazar_Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Bazar_Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Pedidos
        public ActionResult PedidosPendientes()
        {
            List<Orden> ordenes = this.db.Ordenes
                                    .Where(x => x.Estado != EstadoOrden.Entregada && x.Estado != EstadoOrden.Rechazada)
                                    .OrderByDescending(x => x.FechaPedido)
                                    .ToList();
            return View(ordenes);
        }

        public ActionResult EditarPedido(int id)
        {
            Orden orden = this.db.Ordenes.First(x => x.Id == id);

            return View(orden);
        }

        [HttpPost]
        public ActionResult EditarPedido([Bind(Include = "Id,Estado")]Orden orden)
        {
            Orden _orden = this.db.Ordenes.Include("Items").First(x => x.Id == orden.Id);

            if (_orden.Estado == EstadoOrden.Creada && (orden.Estado == EstadoOrden.Procesando || orden.Estado == EstadoOrden.Entregada ))
            {
                foreach(OrdenItem item in _orden.Items)
                {
                    Producto producto = this.db.Productos.First(x => x.Id == item.ProductoId);
                    producto.Stock -= item.Cantidad;

                    // Validar que la cantidad no quede en cero.
                }
            }

            _orden.Estado = orden.Estado;

            this.db.SaveChanges();

            return RedirectToAction("PedidosPendientes");
        }
        #endregion

        public ActionResult ProductosSinStock()
        {
            List<Producto> productos = this.db.Productos.Where(x => x.Stock == 0).OrderBy(x => x.Nombre).ToList();

            return View(productos);
        }

        public ActionResult Usuarios()
        {
            var usuarios = this.db.Users.ToList();
            return View(usuarios);
        }
    }
}