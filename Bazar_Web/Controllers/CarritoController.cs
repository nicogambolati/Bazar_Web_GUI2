using Bazar_Web.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bazar_Web.Controllers
{
    public class CarritoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carrito
        public ActionResult Index()
        {
            List<CarritoProducto> productos = GetProductosFromCookie();

            return View(productos); // productosEnCarrito
        }

        private List<CarritoProducto> GetProductosFromCookie()
        {
            List<CarritoProducto> productos = new List<CarritoProducto>();
            // Ver que pasa cuando esta logueado el usuario. Puede cambiar el indice de la cookie.
            if (this.Request.Cookies["carrito"] != null)
            {
                // Traigo la cookie y armo el array de ids de productos.
                CarritoProductoJS[] productosEnCookie = JsonConvert.DeserializeObject<CarritoProductoJS[]>(this.Request.Cookies["carrito"].Value);

                foreach (CarritoProductoJS producto in productosEnCookie)
                {
                    Producto productoDb = this.db.Productos.Find(Int32.Parse(producto.producto));
                    CarritoProducto carritoProducto = new CarritoProducto();
                    carritoProducto.ProductoId = productoDb.Id;
                    carritoProducto.Nombre = productoDb.Nombre;
                    carritoProducto.Precio = productoDb.Precio;
                    carritoProducto.Cantidad = producto.cantidad;
                    carritoProducto.ImagenURL = productoDb.ImagenURL;

                    productos.Add(carritoProducto);
                }
            }

            return productos;
        }

        public ActionResult Checkout()
        {
            List<CarritoProducto> productosCookie = GetProductosFromCookie();
            List<CarritoProducto> productosSinStock = new List<CarritoProducto>();

            foreach (CarritoProducto producto in productosCookie)
            {
                Producto productoDB = this.db.Productos.Find(producto.ProductoId);
                if(productoDB.Stock < producto.Cantidad)
                {
                    productosSinStock.Add(producto);
                }
            }

            if (productosSinStock.Count == 0)
            {
                Orden pedido = new Orden();
                pedido.UsuarioId = Request.LogonUserIdentity.User.Value;
                pedido.UsuarioNombre = User.Identity.GetUserName();
                pedido.FechaPedido = DateTime.UtcNow;
                pedido.Estado = EstadoOrden.Creada;
                pedido.Items = productosCookie.Select(x => new OrdenItem
                {
                    ProductoId = x.ProductoId,
                    Nombre = x.Nombre,
                    Precio = x.Precio,
                    Cantidad = x.Cantidad
                }).ToList();

                db.Ordenes.Add(pedido);
                db.SaveChanges();

                if (this.Response.Cookies["carrito"] != null)
                {
                    this.Response.Cookies["carrito"].Expires = DateTime.Now.AddDays(-2);
                }

                return View(pedido);
            }
            else
            {
                return View("ProductosSinStock",productosSinStock);
            }
        }

        private class CarritoProductoJS
        {
            public string producto { get; set; }
            public int cantidad { get; set; }
        }
    }
}