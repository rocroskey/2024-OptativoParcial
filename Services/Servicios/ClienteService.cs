
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data.Clientes;


namespace Services.Servicios
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;

        public ClienteService(string connectionString)
        {
            clienteRepository = new ClienteRepository(connectionString);
        }

        public bool agregar(ClienteModel cliente)
        {
            if (validarDatos(cliente))
            {
                return clienteRepository.add(cliente);

            }
            else
            {
                Console.WriteLine("Favor corroborar e ingresar correctamente los datos.");

                throw new Exception("Favor corroborar e ingresar correctamente los datos.");
            }
        }

        public bool actualizar(ClienteModel cliente, string documento)
        {
            return clienteRepository.update(cliente, documento);
        }

        public bool eliminar(string documento)
        {
            return clienteRepository.delete(documento);
        }

        public ClienteModel seleccionar(string documento)
        {
            return clienteRepository.select(documento);
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            return clienteRepository.list();
        }

        public bool validarDatos(ClienteModel cliente)
        {
            if (cliente == null)
                return false;
            if (string.IsNullOrEmpty(cliente.nombre) || cliente.nombre.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.apellido) || cliente.apellido.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.documento) || cliente.documento.Length < 3)
                return false;
            if (string.IsNullOrEmpty(cliente.celular) || cliente.celular.Length != 10)
                return false;

            return true;

        }

    }
}
