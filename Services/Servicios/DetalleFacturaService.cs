
using Repository.Data.DetallesFacturas;
using Repository.Data.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicios
{
    public class DetalleFacturaService
    {
        private DetallesFacturaRepository detalleRepository;
        private FacturaRepository facturaRepository;
        private readonly string _connectionString;

        public DetalleFacturaService(string connectionString)
        {
            detalleRepository = new DetallesFacturaRepository(connectionString);
            facturaRepository = new FacturaRepository(connectionString);
            _connectionString = connectionString;
        }
        public bool agregar(DetallesFacturaModel detallesFactura)
        {
            return detalleRepository.add(detallesFactura);
        }

        public bool actualizar(DetallesFacturaModel detallesFacturaModel)
        {
            return detalleRepository.update(detallesFacturaModel);
        }

        public bool ActualizarDetalles(IEnumerable<DetallesFacturaModel> nuevosDetalles)
        {
            try
            {
                foreach (var detalle in nuevosDetalles)
                {
                    detalleRepository.update(detalle);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los detalles de la factura", ex);
            }
        }

        public bool eliminar(int id)
        {
            return detalleRepository.delete(id);
        }

        public DetallesFacturaModel seleccionar(int id)
        {
            return detalleRepository.select(id);
        }

        public IEnumerable<DetallesFacturaModel> GetAll()
        {
            return detalleRepository.list();
        }

        public IEnumerable<DetallesFacturaModel> ObtenerDetallesPorIdFactura(int idFactura)
        {
            return detalleRepository.ObtenerPorIdFactura(idFactura);
        }
    }

    }

