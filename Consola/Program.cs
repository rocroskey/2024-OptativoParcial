using Repository.Data.Clientes;
using Repository.Data.DetallesFacturas;
using Repository.Data.Facturas;
using Repository.Data.Productos;
using Repository.Data.Sucursales;
using Services.Servicios;
using System.Globalization;


namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=rc12345;Database=optativo";

            ProductoRepository productoRepository = new ProductoRepository(connectionString);
            ClienteService clienteService = new ClienteService(connectionString);
            FacturaService facturaService = new FacturaService(connectionString);
            SucursalService sucursalService = new SucursalService(connectionString);
            ProductoService productoService = new ProductoService(connectionString);
            DetalleFacturaService detalleFacturaService = new DetalleFacturaService(connectionString);

            Console.WriteLine("Bienvenido");



            bool continuar = true;

            while (continuar)
            {

                Console.WriteLine("\nDigite una de las siguientes opciones:");
                Console.WriteLine("C - Para Clientes");
                Console.WriteLine("F - Para Facturas");
                Console.WriteLine("S - Para Sucursales");
                Console.WriteLine("P - Para Productos");
                Console.WriteLine("D - Para Detalles de Factura");

                Console.Write("Opcion: ");
                string menu = Console.ReadLine().ToUpper();

                switch (menu)
                {
                    case "F":
                        Console.WriteLine(" \nMenu de Facturas \n Seleccione una de las siguientes opciones");
                        Console.Write(" Ingrese: \n 1 - Para Ingresar \n 2 - Para Eliminar \n 3 - Para Actualizar \n 4 - Para Buscar \n 5 - Para Listar \n 0 - Para Salir \n Opcion a seleccionar:  ");
                        string opcionf = Console.ReadLine();

                        if (opcionf == "0")
                        {
                            break;
                        }
                        if (opcionf == "1")
                        {
                            var factura = new FacturaModel();
                            Console.Write("Número de Documento: ");
                            factura.documento_cliente = Console.ReadLine();

                            Console.Write("Número de Factura: (Formato XXX-XXX-XXXXXX): ");
                            factura.nro_factura = Console.ReadLine();

                            Console.Write("Fecha y Hora (YYYY-MM-DD HH:mm:ss): ");
                            factura.fecha_hora = DateTime.Parse(Console.ReadLine());

                            Console.Write("Total: ");
                            factura.total = double.Parse(Console.ReadLine());

                            Console.Write("Total IVA 5%: ");
                            factura.total_iva5 = double.Parse(Console.ReadLine());

                            Console.Write("Total IVA 10%: ");
                            factura.total_iva10 = double.Parse(Console.ReadLine());

                            Console.Write("Total IVA: ");
                            factura.total_iva = double.Parse(Console.ReadLine());

                            Console.Write("Total en letras: ");
                            factura.total_letras = Console.ReadLine();

                            Console.Write("Sucursal: ");
                            factura.sucursal = Console.ReadLine();

                            facturaService.agregar(factura);

                            // Buscar la factura por su número
                            FacturaModel facturaCreada = facturaService.seleccionar(factura.nro_factura);

                            if (facturaCreada != null)
                            {
                                int idFactura = facturaCreada.id_factura;

                                bool capturarDetalles = true;
                                while (capturarDetalles)
                                {
                                    var detallesFactura = new DetallesFacturaModel();

                                    Console.Write("ID Producto: ");
                                    detallesFactura.id_producto = int.Parse(Console.ReadLine());

                                    Console.Write("Cantidad Producto: ");
                                    detallesFactura.cantidad_producto = double.Parse(Console.ReadLine());

                                    double precioProducto = productoService.ObtenerPrecioVenta(detallesFactura.id_producto);
                                    detallesFactura.subtotal = detallesFactura.cantidad_producto * precioProducto;

                                    detallesFactura.id_factura = idFactura; // Asignar el ID de la factura

                                    detalleFacturaService.agregar(detallesFactura);

                                    Console.WriteLine("Detalle de factura agregado.");

                                    Console.Write("¿Desea agregar otro detalle de factura? (S/N): ");
                                    string respuesta = Console.ReadLine().ToUpper();
                                    if (respuesta != "S")
                                    {
                                        capturarDetalles = false;
                                    }
                                }

                                Console.WriteLine("La Factura ha sido registrada correctamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró ninguna factura con ese número.");
                            }
                        }


                        if (opcionf == "2")
                        {
                            Console.WriteLine("Ingrese el Nro. de Factura a Eliminar");
                            string nrofactura = Console.ReadLine();

                            facturaService.eliminar(nrofactura);

                            Console.WriteLine("La Factura ha sido eliminada correctamente");
                        }

                        if (opcionf == "3")
                        {
                            var factura = new FacturaModel();

                            Console.WriteLine("Ingrese el Numero de la factura a actualizar:");
                            string actualizarfactura = Console.ReadLine();

                            FacturaModel facturaExistente = facturaService.seleccionar(actualizarfactura);
                            if (facturaExistente == null)
                            {
                                Console.WriteLine($"No se encontró ninguna factura con el número {actualizarfactura}.");
                            }
                            else
                            {
                                Console.WriteLine("Factura encontrada. Ingrese los nuevos datos:");

                                Console.Write("Número de Factura: ");
                                facturaExistente.nro_factura = Console.ReadLine();

                                Console.Write("Fecha y Hora (YYYY-MM-DD HH:mm:ss): ");
                                facturaExistente.fecha_hora = DateTime.Parse(Console.ReadLine());

                                Console.Write("Total: ");
                                facturaExistente.total = double.Parse(Console.ReadLine());

                                Console.Write("Total IVA 5%: ");
                                facturaExistente.total_iva5 = double.Parse(Console.ReadLine());

                                Console.Write("Total IVA 10%: ");
                                facturaExistente.total_iva10 = double.Parse(Console.ReadLine());

                                Console.Write("Total IVA: ");
                                facturaExistente.total_iva = double.Parse(Console.ReadLine());

                                Console.Write("Total en letras: ");
                                facturaExistente.total_letras = Console.ReadLine();

                                Console.Write("Sucursal: ");
                                facturaExistente.sucursal = Console.ReadLine();

                                // Actualizar la factura en la base de datos
                                facturaService.actualizar(facturaExistente, actualizarfactura);

                                

                                Console.WriteLine("La Factura ha sido actualizada correctamente");
                            }

                        }
                        if (opcionf == "4")
                        {
                            var factura = new FacturaModel();
                            Console.WriteLine("Ingrese el número de factura a buscar:");
                            string numeroFacturaBuscar = Console.ReadLine();
                            FacturaModel facturaEncontrada = facturaService.seleccionar(numeroFacturaBuscar);
                            if (facturaEncontrada != null)
                            {
                                Console.WriteLine("\n Factura encontrada:\n");
                                Console.WriteLine($"Número de Factura: {facturaEncontrada.nro_factura}");
                                Console.WriteLine($"Fecha y Hora: {facturaEncontrada.fecha_hora}");
                                Console.WriteLine($"Total: {facturaEncontrada.total}");
                                Console.WriteLine($"Total IVA 5%: {facturaEncontrada.total_iva5}");
                                Console.WriteLine($"Total IVA 10%: {facturaEncontrada.total_iva10}");
                                Console.WriteLine($"Total IVA: {facturaEncontrada.total_iva}");
                                Console.WriteLine($"Total en letras: {facturaEncontrada.total_letras}");
                                Console.WriteLine($"Sucursal: {facturaEncontrada.sucursal}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró ninguna factura con ese número.");
                            }
                            var detallesFactura = detalleFacturaService.ObtenerDetallesPorIdFactura(facturaEncontrada.id_factura).ToList();

                            if (detallesFactura.Any())
                            {
                                Console.WriteLine("\nDetalles de la Factura:");
                                foreach (var detalle in detallesFactura)
                                {
                                    string descripcionProducto = productoRepository.ObtenerDescripcionPorId(detalle.id_producto);
                                    Console.WriteLine($"ID Producto: {detalle.id_producto}, Descripcion: {descripcionProducto}, Cantidad: {detalle.cantidad_producto}, Subtotal: {detalle.subtotal}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron detalles para esta factura.");
                            }
                        }

                        if (opcionf == "5")
                        {

                            Console.WriteLine("\n Listado de todas las facturas:\n ");
                            var facturas = facturaService.GetAll().ToList();

                            foreach (var factura in facturas)
                            {
                                Console.WriteLine($" Nro Factura: {factura.nro_factura} \n " +
                                                  $"Fecha y Hora: {factura.fecha_hora} \n " +
                                                  $"Total: {factura.total} \n " +
                                                  $"Total IVA 5%: {factura.total_iva5} \n " +
                                                  $"Total IVA 10%: {factura.total_iva10} \n " +
                                                  $"Total IVA: {factura.total_iva} \n " +
                                                  $"Total (Letras): {factura.total_letras} \n " +
                                                  $"Sucursal: {factura.sucursal} \n ");

                                // Obtener detalles de la factura
                                var detallesFactura = detalleFacturaService.ObtenerDetallesPorIdFactura(factura.id_factura).ToList();

                                if (detallesFactura.Any())
                                {
                                    Console.WriteLine("Detalles de la Factura:");
                                    foreach (var detalle in detallesFactura)
                                    {
                                        // Obtener la descripción del producto utilizando ProductoRepository directamente
                                        string descripcionProducto = productoRepository.ObtenerDescripcionPorId(detalle.id_producto);

                                        Console.WriteLine($"  ID Producto: {detalle.id_producto} - Descripción: {descripcionProducto}, " +
                                                          $"Cantidad: {detalle.cantidad_producto}, Subtotal: {detalle.subtotal}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No se encontraron detalles para esta factura.");
                                }

                                Console.WriteLine();
                            }
                        }

                        break;

                    case "C":

                        Console.WriteLine("\nMenu de Clientes \n Seleccione una de las siguientes opciones");
                        Console.Write(" Ingrese: \n 1 - Para Ingresar \n 2 - Para Eliminar \n 3 - Para Actualizar \n 4 - Para Buscar \n 5 - Para Listar \n 0 - Para Salir \n Opcion a seleccionar: ");
                        string opcionc = Console.ReadLine();

                        if (opcionc == "0")
                        {
                            break;
                        }
                        if (opcionc == "1")
                        {
                            var cliente = new ClienteModel();
                            Console.WriteLine("Ingrese los datos del cliente: ");
                            cliente.id_banco = Convert.ToInt32(ReadInput("ID Banco: "));
                            cliente.nombre = ReadInput("Nombre: ");
                            cliente.apellido = ReadInput("Apellido: ");
                            cliente.documento = ReadInput("Documento: ");
                            cliente.direccion = ReadInput("Dirección: ");
                            cliente.mail = ReadInput("Correo electrónico: ");
                            cliente.celular = ReadInput("Celular: ");
                            cliente.estado = ReadInput("Estado: ");

                            clienteService.agregar(cliente);

                            Console.WriteLine("El cliente ha sido registrado correctamente.");
                        }
                        if (opcionc == "2")
                        {
                            Console.WriteLine("Ingrese el documento del cliente a Eliminar");
                            string documento = Console.ReadLine();

                            clienteService.eliminar(documento);

                            Console.WriteLine("El Cliente ha sido eliminado correctamente");
                        }
                        if (opcionc == "3")
                        {
                            var cliente = new ClienteModel();

                            Console.WriteLine("Ingrese el documento del cliente a actualizar:");
                            string actualizardocumento = Console.ReadLine();

                            cliente.documento = actualizardocumento;

                            Console.WriteLine("Ingrese los nuevos datos:");
                            Console.WriteLine("Dirección:");
                            string nuevadireccion = Console.ReadLine();
                            Console.WriteLine("Correo electrónico:");
                            string nuevomail = Console.ReadLine();
                            Console.WriteLine("Celular:");
                            string nuevocelular = Console.ReadLine();
                            Console.WriteLine("Estado:");
                            string nuevoestado = Console.ReadLine();

                            cliente.direccion = nuevadireccion;
                            cliente.mail = nuevomail;
                            cliente.celular = nuevocelular;
                            cliente.estado = nuevoestado;

                            clienteService.actualizar(cliente, actualizardocumento);

                            Console.WriteLine("El Cliente ha sido actualizado correctamente");
                        }
                        if (opcionc == "4")
                        {
                            var cliente = new ClienteModel();
                            Console.WriteLine("Ingrese su documento:");
                            string documento = Console.ReadLine();
                            ClienteModel clienteModel = clienteService.seleccionar(documento);

                            if (clienteModel != null)
                            {
                                Console.WriteLine("\n Cliente encontrado:\n");
                                Console.WriteLine($"Nombre: {clienteModel.nombre}");
                                Console.WriteLine($"Apellido: {clienteModel.apellido}");
                                Console.WriteLine($"Documento: {clienteModel.documento}");
                                Console.WriteLine($"Direccion: {clienteModel.direccion}");
                                Console.WriteLine($"Mail: {clienteModel.mail}");
                                Console.WriteLine($"Celular: {clienteModel.celular}");
                                Console.WriteLine($"Estado: {clienteModel.estado}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró el cliente.");
                            }

                        }
                        if (opcionc == "5")
                        {
                            Console.WriteLine("\n Lista de Clientes: \n");
                            clienteService.GetAll().ToList().ForEach(cliente =>
                            Console.WriteLine(
                                $" Nombre: {cliente.nombre} \n " +
                                $"Apellido: {cliente.apellido} \n " +
                                $"Documento: {cliente.documento} \n " +
                                $"Direccion: {cliente.direccion} \n " +
                                $"Mail: {cliente.mail} \n " +
                                $"Celular: {cliente.celular} \n " +
                                $"Estado: {cliente.estado} \n "
                                )
                            );
                        }
                        break;

                    case "S":
                        Console.WriteLine("\nMenu de Sucursales \n Seleccione una de las siguientes opciones");
                        Console.Write(" Ingrese: \n 1 - Para Ingresar \n 2 - Para Eliminar \n 3 - Para Actualizar \n 4 - Para Buscar \n 5 - Para Listar \n 0 - Para Salir \n Opcion a seleccionar: ");
                        string opciones = Console.ReadLine();

                        if (opciones == "0")
                        {
                            break;
                        }
                        if (opciones == "1")
                        {
                            var sucursal = new SucursalModel();
                            Console.WriteLine("Ingrese los datos de la sucursal: ");
                            sucursal.descripcion = ReadInput("Descripción: ");
                            sucursal.direccion = ReadInput("Dirección: ");
                            sucursal.telefono = ReadInput("Teléfono: ");
                            sucursal.whatsapp = ReadInput("WhatsApp: ");
                            sucursal.mail = ReadInput("Correo electrónico: ");
                            sucursal.estado = ReadInput("Estado: ");

                            sucursalService.agregar(sucursal);

                            Console.WriteLine("La sucursal ha sido registrada correctamente.");
                        }
                        if (opciones == "2")
                        {
                            Console.WriteLine("Ingrese el ID de la sucursal a eliminar:");
                            int id = int.Parse(Console.ReadLine());

                            sucursalService.eliminar(id);

                            Console.WriteLine("La sucursal ha sido eliminada correctamente");
                        }
                        if (opciones == "3")
                        {
                            var sucursal = new SucursalModel();

                            Console.WriteLine("Ingrese el ID de la sucursal a actualizar:");
                            int id = int.Parse(Console.ReadLine());

                            sucursal.id = id;
                            SucursalModel sucursalEncontrada = sucursalService.seleccionar(id);
                            if (sucursalEncontrada != null)
                            {
                                Console.WriteLine($"Sucursal: {sucursalEncontrada.descripcion}");
                                Console.WriteLine("Ingrese los nuevos datos:");
                                Console.WriteLine("Dirección:");
                                sucursal.direccion = Console.ReadLine();
                                Console.WriteLine("Teléfono:");
                                sucursal.telefono = Console.ReadLine();
                                Console.WriteLine("WhatsApp:");
                                sucursal.whatsapp = Console.ReadLine();
                                Console.WriteLine("Correo electrónico:");
                                sucursal.mail = Console.ReadLine();
                                Console.WriteLine("Estado:");
                                sucursal.estado = Console.ReadLine();
                            }

                            sucursalService.actualizar(sucursal);

                            Console.WriteLine("La sucursal ha sido actualizada correctamente");
                        }
                        if (opciones == "4")
                        {
                            Console.WriteLine("Ingrese el ID de la sucursal a buscar:");
                            int id = int.Parse(Console.ReadLine());
                            SucursalModel sucursalEncontrada = sucursalService.seleccionar(id);
                            if (sucursalEncontrada != null)
                            {
                                Console.WriteLine("\n Sucursal encontrada:\n");
                                Console.WriteLine($"ID: {sucursalEncontrada.id}");
                                Console.WriteLine($"Descripción: {sucursalEncontrada.descripcion}");
                                Console.WriteLine($"Dirección: {sucursalEncontrada.direccion}");
                                Console.WriteLine($"Teléfono: {sucursalEncontrada.telefono}");
                                Console.WriteLine($"WhatsApp: {sucursalEncontrada.whatsapp}");
                                Console.WriteLine($"Correo electrónico: {sucursalEncontrada.mail}");
                                Console.WriteLine($"Estado: {sucursalEncontrada.estado}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró ninguna sucursal con ese ID.");
                            }
                        }
                        if (opciones == "5")
                        {
                            Console.WriteLine("\n Lista de Sucursales: \n");
                            sucursalService.GetAll().ToList().ForEach(sucursal =>
                                Console.WriteLine(
                                    $" ID: {sucursal.id} \n " +
                                    $"Descripción: {sucursal.descripcion} \n " +
                                    $"Dirección: {sucursal.direccion} \n " +
                                    $"Teléfono: {sucursal.telefono} \n " +
                                    $"WhatsApp: {sucursal.whatsapp} \n " +
                                    $"Correo electrónico: {sucursal.mail} \n " +
                                    $"Estado: {sucursal.estado} \n "
                                )
                            );
                        }
                        break;

                    case "P":
                        Console.WriteLine("\nMenu de Productos \n Seleccione una de las siguientes opciones");
                        Console.Write(" Ingrese: \n 1 - Para Ingresar \n 2 - Para Eliminar \n 3 - Para Actualizar \n 4 - Para Buscar \n 5 - Para Listar \n 0 - Para Salir \n Opcion a seleccionar: ");
                        string opcionp = Console.ReadLine();

                        if (opcionp == "0")
                        {
                            break;
                        }
                        if (opcionp == "1")
                        {
                            var producto = new ProductoModel();
                            Console.WriteLine("Ingrese los datos del Producto: ");
                            producto.descripcion = ReadInput("Descripción: ");
                            producto.cantidad_minima = double.Parse(ReadInput("Cantidad Minima: "));
                            producto.cantidad_stock = double.Parse(ReadInput("Cantidad en Stock: "));
                            producto.precio_compra = int.Parse(ReadInput("Precio de Compra: "));
                            producto.precio_venta = int.Parse(ReadInput("Precio de Venta: "));
                            producto.categoria = ReadInput("Categoria: ");
                            producto.marca = ReadInput("Marca: ");
                            producto.estado = ReadInput("Estado: ");

                            productoService.agregar(producto);

                            Console.WriteLine("El producto ha sido registrado correctamente.");
                        }
                        if (opcionp == "2")
                        {
                            Console.Write("Ingrese el ID del producto a eliminar: ");
                            int idProducto = int.Parse(Console.ReadLine());

                            productoService.eliminar(idProducto);

                            Console.WriteLine("El producto ha sido eliminado correctamente.");
                        }

                        if (opcionp == "3")
                        {
                            var producto = new ProductoModel();

                            Console.Write("Ingrese el ID del producto a actualizar: ");
                            int id_producto = int.Parse(Console.ReadLine());

                            producto.id = id_producto;

                            Console.Write("Descripción: ");
                            producto.descripcion = Console.ReadLine();

                            Console.Write("Cantidad mínima: ");
                            producto.cantidad_minima = double.Parse(Console.ReadLine());

                            Console.Write("Cantidad en stock: ");
                            producto.cantidad_stock = double.Parse(Console.ReadLine());

                            Console.Write("Precio de compra: ");
                            producto.precio_compra = int.Parse(Console.ReadLine());

                            Console.Write("Precio de venta: ");
                            producto.precio_venta = int.Parse(Console.ReadLine());

                            Console.Write("Categoría: ");
                            producto.categoria = Console.ReadLine();

                            Console.Write("Marca: ");
                            producto.marca = Console.ReadLine();

                            Console.Write("Estado: ");
                            producto.estado = Console.ReadLine();

                            productoService.actualizar(producto);

                            Console.WriteLine("El producto ha sido actualizado correctamente.");
                        }

                        if (opcionp == "4")
                        {
                            Console.Write("Ingrese el ID del producto a buscar: ");
                            int idProducto = int.Parse(Console.ReadLine());

                            ProductoModel productoEncontrado = productoService.seleccionar(idProducto);

                            if (productoEncontrado != null)
                            {
                                Console.WriteLine("\nProducto encontrado:\n");
                                Console.WriteLine($"ID: {productoEncontrado.id}");
                                Console.WriteLine($"Descripción: {productoEncontrado.descripcion}");
                                Console.WriteLine($"Cantidad mínima: {productoEncontrado.cantidad_minima}");
                                Console.WriteLine($"Cantidad en stock: {productoEncontrado.cantidad_stock}");
                                Console.WriteLine($"Precio de compra: {productoEncontrado.precio_compra}");
                                Console.WriteLine($"Precio de venta: {productoEncontrado.precio_venta}");
                                Console.WriteLine($"Categoría: {productoEncontrado.categoria}");
                                Console.WriteLine($"Marca: {productoEncontrado.marca}");
                                Console.WriteLine($"Estado: {productoEncontrado.estado}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró ningún producto con ese ID.");
                            }
                        }

                        if (opcionp == "5")
                        {
                            Console.WriteLine("\nListado de todos los productos:\n");
                            productoService.GetAll().ToList().ForEach(producto =>
                                Console.WriteLine(
                                    $"Descripción: {producto.descripcion} \n" +
                                    $"Cantidad mínima: {producto.cantidad_minima} \n" +
                                    $"Cantidad en stock: {producto.cantidad_stock} \n" +
                                    $"Precio de compra: {producto.precio_compra} \n" +
                                    $"Precio de venta: {producto.precio_venta} \n" +
                                    $"Categoría: {producto.categoria} \n" +
                                    $"Marca: {producto.marca} \n" +
                                    $"Estado: {producto.estado} \n"
                                )
                            );
                        }
                        break;

                        case "D":
                        Console.WriteLine("\nMenu de Detalles de Factura \n Seleccione una de las siguientes opciones");
                        Console.Write(" Ingrese: \n 1 - Para Ingresar \n 2 - Para Eliminar \n 3 - Para Actualizar \n 4 - Para Buscar \n 5 - Para Listar \n 0 - Para Salir \n Opcion a seleccionar: ");
                        string opciond = Console.ReadLine();

                        if (opciond == "0")
                        {
                            break;
                        }
                        if (opciond == "1")
                        {
                            var detallesFactura = new DetallesFacturaModel();
                            Console.WriteLine("Ingrese los datos: ");
                            detallesFactura.id_factura= int.Parse(ReadInput("ID de la factura: "));
                            detallesFactura.id_producto = int.Parse(ReadInput("ID del Producto: "));
                            detallesFactura.cantidad_producto = int.Parse(ReadInput("Cantidad de Producto "));
                            detallesFactura.subtotal = double.Parse(ReadInput("Subtotal: "));


                            detalleFacturaService.agregar(detallesFactura);

                            Console.WriteLine("Los Datos han sido registrados correctamente.");
                        }
                        if (opciond == "2")
                        {
                            Console.Write("Ingrese el ID a eliminar: ");
                            int id = int.Parse(Console.ReadLine());

                            detalleFacturaService.eliminar(id);

                            Console.WriteLine("Los datos han sido eliminados correctamente.");
                        }

                        if (opciond == "3")
                        {
                            var detallesFactura = new DetallesFacturaModel();

                            Console.Write("Ingrese el ID a actualizar: ");
                            int id = int.Parse(Console.ReadLine());

                            detallesFactura.id = id;

                            Console.Write("ID de la Factura: ");
                            detallesFactura.id_factura   = int.Parse(Console.ReadLine());

                            Console.Write("ID del Producto: ");
                            detallesFactura.id_producto = int.Parse(Console.ReadLine());

                            Console.Write("Cantidad de Producto: ");
                            detallesFactura.cantidad_producto = double.Parse(Console.ReadLine());

                            Console.Write("Subtotal: ");
                            detallesFactura.subtotal = int.Parse(Console.ReadLine());

                            Console.WriteLine("Los datos han sido actualizados correctamente.");
                        }

                        if (opciond == "4")
                        {
                            Console.Write("Ingrese el ID del detalle a buscar: ");
                            int id = int.Parse(Console.ReadLine());

                            DetallesFacturaModel detalle_encontrado = detalleFacturaService.seleccionar(id);

                            if (detalle_encontrado != null)
                            {
                                Console.WriteLine("\nDetalle encontrado:\n");
                                Console.WriteLine($"ID del Detalle: {detalle_encontrado.id}");
                                Console.WriteLine($"ID de la Factura: {detalle_encontrado.id_factura}");
                                Console.WriteLine($"ID del Prodcuto: {detalle_encontrado.id_producto}");
                                Console.WriteLine($"Cantidad de Producto: {detalle_encontrado.cantidad_producto}");
                                Console.WriteLine($"Subtotal: {detalle_encontrado.subtotal}");
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron datos con ese ID.");
                            }
                        }

                        if (opciond == "5")
                        {
                            Console.WriteLine("\nListado de todos los Detalles de Facturacion:\n");
                            detalleFacturaService.GetAll().ToList().ForEach(detalleFactura =>
                                Console.WriteLine(
                                    $"ID de la Factura: {detalleFactura.id_factura} \n" +
                                    $"ID del Producto: {detalleFactura.id_producto} \n" +
                                    $"Cantidad de Producto: {detalleFactura.cantidad_producto} \n" +
                                    $"Subtotal: {detalleFactura.subtotal} \n"
                                )
                            );
                        }
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }


                static string ReadInput(string prompt)
                {
                    Console.Write(prompt + " ");
                    return Console.ReadLine();
                }


                double ReadDoubleInput(string prompt) => double.Parse(ReadInput(prompt));

                static DateTime ReadDateTimeInput(string prompt, string format)
                {
                    DateTime result;
                    bool isValidInput = false;

                    do
                    {
                        Console.Write(prompt);
                        string input = Console.ReadLine();

                        isValidInput = DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

                        if (!isValidInput)
                        {
                            Console.WriteLine($"Entrada no válida. Por favor, ingrese la fecha y hora en el formato {format}.");
                        }
                    } while (!isValidInput);

                    return result;
                }
                break;


            }

        }

    }

}


