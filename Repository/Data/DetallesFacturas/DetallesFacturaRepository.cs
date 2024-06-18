using Dapper;
using Repository.Data.DBConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.DetallesFacturas
{
    public class DetallesFacturaRepository
    {
        IDbConnection _connection;
        public DetallesFacturaRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();

        }

        public bool add(DetallesFacturaModel detallesFacturaModel)
        {
            try
            {
                _connection.Execute("INSERT INTO detalle_factura(id_factura, id_producto, cantidad_producto, subtotal) " +
                    $"Values(@id_factura, @id_producto, @cantidad_producto, @subtotal)", detallesFacturaModel);
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar los detalles de la factura", ex);
            }
        }

        public bool delete(int id)
        {
            try
            {
                _connection.Execute($"DELETE FROM detalle_factura WHERE id = {id}");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los detalles de la factura", ex);
            }

        }

        public bool update(DetallesFacturaModel detallesFacturaModel)
        {
            try
            {
                _connection.Execute("UPDATE detalle_factura SET " +
                                    "id_factura = @id_factura, " +
                                    "id_producto = @id_producto, " +
                                    "cantidad_producto = @cantidad_producto, " +
                                    "subtotal = @subtotal " +
                                    "WHERE id_factura = @id_factura", detallesFacturaModel);
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar los detalles de la factura", ex);
            }
        }

        public DetallesFacturaModel select(int id)
        {
            try
            {
                return _connection.QuerySingleOrDefault<DetallesFacturaModel>($"SELECT * FROM detalle_factura WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar los detalles de la factura", ex);
            }
        }

        public IEnumerable<DetallesFacturaModel> list()
        {
            try
            {
                return _connection.Query<DetallesFacturaModel>("SELECT * FROM detalle_factura");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los detalles de la factura", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public int ObtenerIdFacturaPorNumero(int id_factura) { 
            try
            {
                return _connection.QuerySingleOrDefault<int>("SELECT id FROM factura WHERE id = @id", new { id = id_factura });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID de la factura por Numero", ex);
            }
        }
        public IEnumerable<DetallesFacturaModel> ObtenerPorIdFactura(int idFactura)
        {
            try
            {
                return _connection.Query<DetallesFacturaModel>("SELECT * FROM detalle_factura WHERE id_factura = @IdFactura", new { IdFactura = idFactura });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de factura por ID de factura", ex);
            }
        }
    }
}
