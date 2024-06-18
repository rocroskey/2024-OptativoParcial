using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.DetallesFacturas
{
    public class DetallesFacturaModel
    {
        public int id {  get; set; }
        public int id_factura { get; set; }
        public int id_producto { get; set; }
        public double cantidad_producto { get; set; }
        public double subtotal { get; set; }

    }
}
