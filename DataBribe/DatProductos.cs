using DataBribe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBribe
{
    public class DatProductos
    {

        public List<Productos> ObtenerProductos()
        {
            List<Productos> p = new List<Productos>();

            using (BribeEntities db = new BribeEntities())
            {
                p = db.Productos.ToList();
            }

            return p;
        }

        public void AgregarProducto(Productos p)
        {
           
            using (BribeEntities db = new BribeEntities())
            {
                db.Productos.Add(p);
                db.SaveChanges();

            }
        }

        public Productos BuscarPorID(int id)
        {
            Productos p = new Productos();

            using (BribeEntities db = new BribeEntities())
            {
                p = db.Productos.Where(x=> x.id == id).FirstOrDefault();
              
            }

            return p;
        }

        public void EditarProducto(Productos p)
        {
            using(BribeEntities db = new BribeEntities())
            {
                db.Productos.AddOrUpdate(p);
                db.SaveChanges();
            }
        }

        public Productos BuscarProductoPorCodigoBarras(string producto,string codigoBarras)
        {
            Productos p = new Productos();
            using(BribeEntities db = new BribeEntities())
            {
                p = db.Productos.Where(x=> x.producto == producto && x.codigoBarras==codigoBarras).FirstOrDefault();

            }

            return p;


        }

        public void ModificarProducto(Productos p)
        {
           
            using (BribeEntities db = new BribeEntities())
            {
                db.Productos.AddOrUpdate(p);
                db.SaveChanges();
            }
        }



    }
}
