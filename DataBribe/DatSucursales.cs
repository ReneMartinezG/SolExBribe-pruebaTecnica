using DataBribe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBribe
{   
    public class DatSucursales
    {

        public void AgregarSucursal(Sucursales s)
        {
            using(BribeEntities db = new BribeEntities())
            {
                db.Sucursales.Add(s);
                db.SaveChanges();
            }
        }
        
        public List<ProductoPorSucursal> ObtenerSucursales()
        {
            List<ProductoPorSucursal> ls = new List<ProductoPorSucursal>();

            try
            {
                using(BribeEntities db = new BribeEntities())
                {
                    ls = db.ProductoPorSucursal.Include("Sucursales").Include("Productos").ToList();
                }            
                return ls;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> TodasLasSucursalesSinDuplicados()
        {
            List<string> sucursalesUnicas = new List<string>();

            using (BribeEntities db = new BribeEntities())
            {
                sucursalesUnicas = db.Sucursales.Select(s => s.Sucursal)
                .Distinct().ToList();
            }      
           
            return sucursalesUnicas;
        }

        public Sucursales ObtenerSucursalPorNombre(string sucursal)
        {
            Sucursales s = new Sucursales();
            using (BribeEntities db = new BribeEntities())
            {
                s = db.Sucursales.Where(x=> x.Sucursal == sucursal).FirstOrDefault();
            }

            return s;
        }

        public void AgregarPRoductoPorSucursales(ProductoPorSucursal ps)
        {
            using(BribeEntities db = new BribeEntities())
            {
                db.ProductoPorSucursal.Add(ps);
                db.SaveChanges();
            }
        }

        public ProductoPorSucursal ObtenerProductoSucursalPorID(int id)
        {
            ProductoPorSucursal ps = new ProductoPorSucursal();

            using (BribeEntities db = new BribeEntities())
            {
                ps = db.ProductoPorSucursal.Where(x=> x.id == id).FirstOrDefault();
            }

            return ps;
        }

        public void EditarProductoSucursal(ProductoPorSucursal ps)
        {
            using(BribeEntities db = new BribeEntities())
            {
                db.ProductoPorSucursal.AddOrUpdate(ps);
                db.SaveChanges();
            }
        }

    }
}
