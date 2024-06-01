using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBribe.Models.Entidades
{
    public class SucursalNombre
    {
        public List<string> Sucursal{ get; set; }

        public List<ProductoPorSucursal> ProductoSucursal { get; set; }
    }
}
