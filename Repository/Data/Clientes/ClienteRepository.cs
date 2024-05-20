using Dapper;
using Npgsql;
using Repository.Data.DBConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Clientes
{
    public class ClienteRepository
    {
        IDbConnection _connection;
        public ClienteRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();

        }

        public bool add(ClienteModel clienteModel)
        {
            try
            {
                _connection.Execute("INSERT INTO cliente(id_banco, nombre, apellido, documento, direccion, mail, celular, estado) " +
                    "VALUES(@id_banco, @nombre, @apellido, @documento, @direccion, @mail, @celular, @estado)", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(string documento)
        {
            try
            {
                _connection.Execute("DELETE FROM cliente WHERE documento = @Documento", new { Documento = documento });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(ClienteModel clienteModel, string documento)
        {
            try
            {
                _connection.Execute("UPDATE cliente SET " +
                    "direccion = @direccion, " +
                    "mail = @mail, " +
                    "celular = @celular, " +
                    "estado = @estado " +
                    "WHERE documento = @Documento", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel select(string documento)
        {
            try
            {
                return _connection.QuerySingleOrDefault<ClienteModel>("SELECT * FROM cliente WHERE documento = @Documento", new { Documento = documento });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClienteModel> list()
        {
            try
            {
                return _connection.Query<ClienteModel>("SELECT * FROM cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ObtenerIdClientePorDocumento(string documentoCliente)
        {
            try
            {
                return _connection.QuerySingleOrDefault<int>("SELECT id FROM cliente WHERE documento = @Documento", new { Documento = documentoCliente });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}