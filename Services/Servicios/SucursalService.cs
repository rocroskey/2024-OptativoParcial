using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data.Sucursales;

namespace Services.Servicios
{
    public class SucursalService
    {
        private SucursalRepository sucursalRepository;

        public SucursalService(string connectionString)
        {
            sucursalRepository = new SucursalRepository(connectionString);
        }
        public bool agregar(SucursalModel sucursal)
        {
            if (validarDatos(sucursal))
            {
                return sucursalRepository.add(sucursal);

            }
            else
            {
                Console.WriteLine("Favor corroborar e ingresar correctamente los datos.");

                throw new Exception("Favor corroborar e ingresar correctamente los datos.");
            }
        }

        public bool actualizar(SucursalModel sucursal)
        {
            return sucursalRepository.update(sucursal);
        }

        public bool eliminar(int id)
        {
            return sucursalRepository.delete(id);
        }

        public SucursalModel seleccionar(int id )
        {
            return sucursalRepository.select(id );
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            return sucursalRepository.list();
        }

        public bool validarDatos(SucursalModel sucursal)
        {
            if (sucursal == null)
                return false;
            if (string.IsNullOrEmpty(sucursal.direccion) || sucursal.direccion.Length < 10)
                return false;
            if (string.IsNullOrEmpty(sucursal.mail)) 
                return false;
                int atIndex = sucursal.mail.IndexOf('@');
            if (atIndex <= 0 || sucursal.mail.IndexOf('.', atIndex) <= atIndex + 1)
                return false;


            return true;

        }

    }
}

