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
        NpgsqlConnection _connection;
        public ClienteRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();

        }

        public bool add(ClienteModel clienteModel)
        {
            try
            {
                var cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO cliente(id_banco, nombre, apellido, documento, direccion, mail, celular, estado) " +
                    $"Values(" +
                    $"'{clienteModel.id_banco}', " +
                    $"'{clienteModel.nombre}', " +
                    $"'{clienteModel.apellido}', " +
                    $"'{clienteModel.documento}', " +
                    $"'{clienteModel.direccion}', " +
                    $"'{clienteModel.mail}', " +
                    $"'{clienteModel.celular}', " +
                    $"'{clienteModel.estado}') ";
                cmd.ExecuteNonQuery();
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
                var cmd = _connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM cliente WHERE documento ='{documento}'";
                cmd.ExecuteNonQuery();
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
                var cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE cliente" +
                    $" SET " +
                    $"direccion = '{clienteModel.direccion}', " +
                    $"mail = '{clienteModel.mail}', " +
                    $"celular = '{clienteModel.celular}', " +
                    $"estado = '{clienteModel.estado}' " +
                    $" WHERE documento = '{documento}' ";
                cmd.ExecuteNonQuery();
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
                var cmd = _connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM cliente WHERE documento = '{documento}'";

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        ClienteModel cliente = new ClienteModel
                        {
                            id_banco = (int)reader["id_banco"],
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            documento = reader["documento"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            mail = reader["mail"].ToString(),
                            celular = reader["celular"].ToString(),
                            estado = reader["estado"].ToString()
                        };

                        return cliente;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteModel> list()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            var cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM cliente";
            var list = cmd.ExecuteReader();

            while (list.Read())
            {
                clientes.Add(new ClienteModel
                {
                    id_banco = (int)list.GetValue(1),
                    nombre = list.GetString(2),
                    apellido = list.GetString(3),
                    documento = list.GetString(4),
                    direccion = list.GetString(5),
                    mail = list.GetString(6),
                    celular = list.GetString(7),
                    estado = list.GetString(8)
                });
            }
            return clientes;
        }
        public int ObtenerIdClientePorDocumento(string documentoCliente)
        {
            // Aquí debes implementar la lógica para obtener el ID del cliente
            // basado en el documento del cliente, puedes hacer una consulta
            // a la base de datos o utilizar algún otro método para obtener el ID.
            // Por ejemplo, puedes usar Entity Framework o hacer una consulta SQL.

            // Ejemplo de consulta SQL (solo como referencia, adapta según tu base de datos y lógica):
            var cmd = _connection.CreateCommand();
            cmd.CommandText = $"SELECT id FROM cliente WHERE documento = '{documentoCliente}'";
            int idCliente = (int)cmd.ExecuteScalar();

            return idCliente;
        }
    }

}
