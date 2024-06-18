using Repository.Data.Clientes;
using Repository.Data.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicios
{
    public class ProductoService
    {
        private ProductoRepository productoRepository;
        private readonly string _connectionString;

        public ProductoService(string connectionString)
        {
            productoRepository = new ProductoRepository(connectionString);
            _connectionString = connectionString;
        }
        public bool agregar(ProductoModel producto)
        {
            return validarDatos(producto) ? productoRepository.add(producto) : throw new Exception("Error en la validacion de datos. Favor verificar");
        }

        public bool actualizar(ProductoModel productoModel)
        {
            return validarDatos(productoModel) ? productoRepository.update(productoModel) : throw new Exception("Error en la validacion de datos. Favor verificar");
        }

        public bool eliminar(int id)
        {
            return id > 0 ? productoRepository.delete(id) : false;
        }

        public ProductoModel seleccionar(int id)
        {
            return productoRepository.select(id);
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            return productoRepository.list();
        }

        public double ObtenerPrecioVenta(int idProducto)
        {
            // Aquí debes implementar la lógica para obtener el precio de venta del producto
            // por ejemplo, puedes tener un método en tu repositorio de productos

            // Ejemplo simplificado:
            ProductoModel producto = productoRepository.ObtenerPorId(idProducto);
            return producto != null ? producto.precio_venta : 0.0;
        }


        private bool validarDatos(ProductoModel producto)
        {
            if (
                string.IsNullOrEmpty(producto.descripcion) ||
                producto.cantidad_minima <= 0 ||
                producto.cantidad_stock < 0 ||
                producto.precio_compra <= 0 ||
                producto.precio_venta <= 0 ||
                string.IsNullOrEmpty(producto.categoria) ||
                string.IsNullOrEmpty(producto.marca) ||
                string.IsNullOrEmpty(producto.estado))
            {
                Console.WriteLine("Los campos son obligatorios.");
                return false;
            }

            if (producto.cantidad_minima <= 1)
            {
                Console.WriteLine("La cantidad mín. debe ser superior a 1.");
                return false;
            }

            if (producto.precio_compra <= 0 || producto.precio_venta <= 0)
            {
                Console.WriteLine("Tanto el precio de compra como el precio de venta deben ser enteros.");
                return false;
            }

            return true;
        }

    }
}