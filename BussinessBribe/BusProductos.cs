using DataBribe;
using DataBribe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBribe
{
    public class BusProductos
    {
        DatProductos datProducto = new DatProductos();
        DatSucursales datsursal = new DatSucursales();


        public List<Productos> ObtenerProductos()
        {
            return datProducto.ObtenerProductos();
        }

        public Productos BuscarPorID(int id)
        {
            Productos p = new Productos();

            p = datProducto.BuscarPorID(id);

            return p;
        }

        public void EditarProducto(Productos p)
        {
            datProducto.EditarProducto(p);
        }

        public void AgregarProductoATodasSucursales(Productos p)
        {
            datProducto.AgregarProducto(p);

            Productos producto = new Productos();
            producto = datProducto.BuscarProductoPorCodigoBarras(p.producto, p.codigoBarras);

            List<string> lsSucursales = new List<string>();
            lsSucursales = datsursal.TodasLasSucursalesSinDuplicados();

           
            foreach (string sucursal in lsSucursales)
            {
                Sucursales s = new Sucursales();
                
                s = datsursal.ObtenerSucursalPorNombre(sucursal);

                ProductoPorSucursal ps = new ProductoPorSucursal();

                ps.idProducto = producto.id;
                ps.idSucursal = s.id;
                ps.cantidad = 0;

                datsursal.AgregarPRoductoPorSucursales(ps);

                s = null;
            }


           

        }

        public ProductoPorSucursal ObtenerProductoPorSucursalPorID(int id)
        {
            ProductoPorSucursal ps = new ProductoPorSucursal();
            ps = datsursal.ObtenerProductoSucursalPorID(id);

            return ps;
        }

        public void AgregarExistenciaProductoPorsucursal(ProductoPorSucursal ps, int cantidad)
        {
            if(cantidad < 0)
            {
                throw new Exception("El numero no puede ser menor a 0");
            }

            ps.cantidad += cantidad;

            datsursal.EditarProductoSucursal(ps);

        }

        public void VenderExistenciaProductoPorsucursal(ProductoPorSucursal ps, int cantidad)
        {
            if (cantidad < 0)
            {
                throw new Exception("El numero no puede ser menor a 0");
            }

            ps.cantidad -= cantidad;

            datsursal.EditarProductoSucursal(ps);

        }

    }
}
