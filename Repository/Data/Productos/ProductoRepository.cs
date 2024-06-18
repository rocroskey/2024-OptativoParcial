using Dapper;
using Repository.Data.DBConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Productos
{
    public class ProductoRepository
    {
        IDbConnection _connection;
        public ProductoRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();

        }
        public bool add(ProductoModel productomodel)
        {
            try
            {
                _connection.Execute("INSERT INTO producto(descripcion, cantidad_minima, cantidad_stock, precio_compra, precio_venta, categoria, marca, estado) " +
                    $"Values(@descripcion, @cantidad_minima, @cantidad_stock, @precio_compra, @precio_venta, @categoria, @marca, @estado)", productomodel);
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto", ex);
            }
        }

        public bool delete(int id)
        {
            try
            {
                _connection.Execute($"DELETE FROM producto WHERE id = {id}");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto", ex);
            }

        }

        public bool update(ProductoModel productoModel)
        {
            try
            {
                _connection.Execute("UPDATE producto SET " +
                                    "descripcion = @descripcion, " +
                                    "cantidad_minima = @cantidad_minima, " +
                                    "cantidad_stock = @cantidad_stock, " +
                                    "precio_compra = @precio_compra, " +
                                    "precio_venta = @precio_venta, " +
                                    "categoria = @categoria, " +
                                    "marca = @marca, " +
                                    "estado = @estado " +
                                    "WHERE id = @id", productoModel);
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto", ex);
            }
        }

        public ProductoModel select(int id)
        {
            try
            {
                return _connection.QuerySingleOrDefault<ProductoModel>($"SELECT * FROM producto WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar el producto", ex);
            }
        }

        public IEnumerable<ProductoModel> list()
        {
            try
            {
                return _connection.Query<ProductoModel>("SELECT * FROM producto");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos", ex);
            }
            finally
            {
                _connection.Close();
            }
        }

        public ProductoModel ObtenerPorId(int id)
        {
            try
            {
                return _connection.QuerySingleOrDefault<ProductoModel>("SELECT * FROM producto WHERE id = @Id", new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto por ID", ex);
            }
        }

        public string ObtenerDescripcionPorId(int id)
        {
            try
            {
                return _connection.QuerySingleOrDefault<string>("SELECT descripcion FROM producto WHERE id = @Id", new { Id = id });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la descripción del producto por ID", ex);
            }
        }
    }
}
