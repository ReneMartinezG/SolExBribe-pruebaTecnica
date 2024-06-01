using BussinessBribe;
using DataBribe.Models;
using DataBribe.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExBribe.Controllers
{
    public class HomeController : Controller
    {
        BusSucursales BusSucursal = new BusSucursales();
        BusProductos BusProducto = new BusProductos();


        // GET: Home
        public ActionResult Index()
        {
           return View();

        }

        public ActionResult SucursalProducto()
        {
            SucursalNombre objSN = new SucursalNombre();

            try
            {
                List<string> lsSucDup = BusSucursal.TodasLasSucursalesSinDuplicados();
                List<ProductoPorSucursal> lsPS = BusSucursal.ObtenerSucursales();


                objSN.Sucursal = lsSucDup;
                objSN.ProductoSucursal = lsPS;

                return View(objSN);

            }
            catch (Exception ex)
            {
                TempData["err"] = "Ocurrio un error. " + ex.Message;
                return View(objSN);
            }
        }


        public ActionResult IrAgregarExistencia(int idProductoPorSucursal)
        {
            ProductoPorSucursal ps = new ProductoPorSucursal();

            ps = BusProducto.ObtenerProductoPorSucursalPorID(idProductoPorSucursal);

            return View("AgregarExistencia",ps);

        }

        public ActionResult AgregarExistencia(ProductoPorSucursal ps, int cantidadNueva)
        {
            BusProducto.AgregarExistenciaProductoPorsucursal(ps,cantidadNueva);

            return RedirectToAction("SucursalProducto");
        }

        public ActionResult irVenderProducto(int idProductoPorSucursal)
        {
            ProductoPorSucursal ps = new ProductoPorSucursal();

            ps = BusProducto.ObtenerProductoPorSucursalPorID(idProductoPorSucursal);

            return View("VenderExistencia", ps);
        }

        public ActionResult VenderExistencia(ProductoPorSucursal ps, int cantidadNueva)
        {
            BusProducto.VenderExistenciaProductoPorsucursal(ps, cantidadNueva);

            return RedirectToAction("SucursalProducto");
        }

        public ActionResult irAgregarProducto()
        {
            return View("AgregarProducto"); 
        }


        public ActionResult AgregarProducto(Productos p)
        {
            BusProducto.AgregarProductoATodasSucursales(p);

            return RedirectToAction("SucursalProducto");
        }

        public ActionResult irAgregarSucursal()
        {
            return View("AgregarSucursal");
        }

        public ActionResult Agregarsucursal(Sucursales s)
        {
            
            BusSucursal.AgregarsucursalConProductos(s);

            return RedirectToAction("SucursalProducto");
        }

        public ActionResult IrProductos()
        {
            List<Productos> p = new List<Productos>();

            p = BusProducto.ObtenerProductos();

            return View("Productos", p);
        }

        public ActionResult irEditarProducto(int idProducto)
        {
            Productos p = new Productos();
            p = BusProducto.BuscarPorID(idProducto);
            return View("EditarProducto",p);
        }

        public ActionResult EditarProductos(Productos p)
        {
            BusProducto.EditarProducto(p);
            return RedirectToAction("IrProductos");
        }

    }

    
}