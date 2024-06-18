using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Productos
{
    public class ProductoModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public double cantidad_minima { get; set; }
        public double cantidad_stock { get; set; }
        public int precio_compra {  get; set; }
        public int precio_venta {  get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string estado { get; set; }

    }
}
