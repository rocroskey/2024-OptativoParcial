using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Facturas
{
    public class FacturaModel
    {


        public int id_factura { get; set; }
        public int id_cliente { get; set; }
        public string nro_factura { get; set; }
        public DateTime fecha_hora { get; set; }
        public double total { get; set; }
        public double total_iva5 { get; set; }
        public double total_iva10 { get; set; }
        public double total_iva { get; set; }
        public string total_letras { get; set; }
        public string sucursal { get; set; }
        public string documento_cliente { get; set; }
    }
}
