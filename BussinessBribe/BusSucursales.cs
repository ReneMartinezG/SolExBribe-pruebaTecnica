using DataBribe;
using DataBribe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBribe
{
    public class BusSucursales
    {
        DatSucursales datSursales = new DatSucursales();
        DatProductos datProducto = new DatProductos();

        public void AgregarsucursalConProductos(Sucursales s)
        {
            datSursales.AgregarSucursal(s);

            Sucursales sucursal = new Sucursales();
           sucursal = datSursales.ObtenerSucursalPorNombre(s.Sucursal);

            List<Productos> p = new List<Productos>();

            p = datProducto.ObtenerProductos();

            foreach (var productoFor in p)
            {
                ProductoPorSucursal ps = new ProductoPorSucursal();
                ps.idProducto = productoFor.id;
                ps.idSucursal = sucursal.id;
                ps.cantidad = 0;

                datSursales.AgregarPRoductoPorSucursales(ps);
                
            }



        }

        public List<ProductoPorSucursal> ObtenerSucursales()
        {
            return datSursales.ObtenerSucursales();
        }

        public List<string> TodasLasSucursalesSinDuplicados()
        {
            return datSursales.TodasLasSucursalesSinDuplicados();
        }

    }


}
