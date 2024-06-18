using Repository.Data.Clientes;
using Repository.Data.Facturas;
using Repository.Data.Sucursales;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Servicios
{
    public class FacturaService
    {
        private FacturaRepository facturaRepository;
        private ClienteRepository clienteRepository;
        private SucursalRepository sucursalRepository;

        public FacturaService(string connectionString)
        {
            facturaRepository = new FacturaRepository(connectionString);
            clienteRepository = new ClienteRepository(connectionString);
            sucursalRepository = new SucursalRepository(connectionString);
        }
        public int agregar(FacturaModel factura)
        {
            try
            {
                int idCliente = clienteRepository.ObtenerIdClientePorDocumento(factura.documento_cliente);
                int idSucursal = sucursalRepository.ObtenerIdSucursalPorDescripcion(factura.sucursal);

                factura.id_cliente = idCliente;
                factura.id_sucursal = idSucursal;

                if (validarfactura(factura))
                {
                    int idFacturaInsertada = facturaRepository.add(factura);
                    return idFacturaInsertada;
                }
                else
                {
                    throw new Exception("Favor corroborar e ingresar correctamente los datos.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public bool eliminar(string nro_factura)
        {
            return facturaRepository.delete(nro_factura);
        }
        public bool actualizar(FacturaModel factura, string nro_factura)
        {
            if (validarfactura(factura))
            {
                return facturaRepository.update(factura, nro_factura);
            }
            else
            {
                throw new Exception("Favor corroborar e ingresar correctamente los datos.");
            }
        }
        public FacturaModel seleccionar(string nro_factura)
        {
            return facturaRepository.select(nro_factura);
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            return facturaRepository.list();
        }

        public DateTime GetValidDateTimeInput(string prompt)
        {
            DateTime result;
            bool validInput = false;

            do
            {
                Console.Write(prompt);
                validInput = DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

                if (!validInput)
                {
                    Console.WriteLine("Por favor ingrese una fecha y hora válida en el formato correcto (yyyy-MM-dd HH:mm:ss):");
                }

            } while (!validInput);

            return result;
        }

        public bool validarfactura(FacturaModel factura)
        {
            if (factura == null)
                if (!Regex.IsMatch(factura.nro_factura, @"^\d{3}-\d{3}-\d{6}$"))
                    return false;
            if (factura.total <= 0 || factura.total_iva5 <= 0 || factura.total_iva10 <= 0 || factura.total_iva <= 0)
                return false;
            if (string.IsNullOrEmpty(factura.total_letras) || factura.total_letras.Length < 6)
                return false;

            return true;

        }
    }


}
