using Repository.Data.Clientes;
using Repository.Data.Facturas;
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

            ClienteService clienteService = new ClienteService(connectionString);
            FacturaService facturaService = new FacturaService(connectionString);
            SucursalService sucursalService = new SucursalService(connectionString);

            Console.WriteLine("Bienvenido");

            bool continuar = true;

            while (continuar)
            {

                Console.WriteLine("\nDigite una de las siguientes opciones:");
                Console.WriteLine("C - Para Clientes");
                Console.WriteLine("F - Para Facturas");
                Console.WriteLine("S - Para Sucursales");

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

                            Console.WriteLine("La Factura ha sido registrada  correctamente.");
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

                            factura.nro_factura = actualizarfactura;

                            Console.WriteLine("Ingrese los datos de la factura:");

                            Console.Write("Número de Factura: ");
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





                            facturaService.actualizar(factura, actualizarfactura);

                            Console.WriteLine("La Factura ha sido actualizadoa correctamente");

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
                        }

                        if (opcionf == "5")
                        {

                            Console.WriteLine("\n Listado de todas las facturas:\n ");
                            facturaService.GetAll().ToList().ForEach(factura =>
                            Console.WriteLine(
                            $" Nro Factura: {factura.nro_factura} \n " +
                            $"Fecha y Hora: {factura.fecha_hora} \n " +
                            $"Total: {factura.total} \n " +
                            $"Total IVA 5%: {factura.total_iva5} \n " +
                            $"Total IVA 10%: {factura.total_iva10} \n " +
                            $"Total IVA: {factura.total_iva} \n " +
                            $"Total (Letras): {factura.total_letras} \n " +
                            $"Sucursal: {factura.sucursal} \n "
                            )
                        );
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
