using Repository.Data.DBConfig;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Repository.Data.Sucursales
{
    public class SucursalRepository
    {
        IDbConnection _connection;

        public SucursalRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(SucursalModel sucursalModel)
        {
            try
            {
                _connection.Execute("INSERT INTO sucursal(descripcion, direccion, telefono, whatsapp, mail, estado) " +
                    $"Values(@descripcion, @direccion, @telefono, @whatsapp, @mail, @estado)", sucursalModel);
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la sucursal", ex);
            }
        }

        public bool delete(int id)
        {
            try
            {
                _connection.Execute($"DELETE FROM sucursal WHERE id = {id}");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la sucursal", ex);
            }
            
        }

        public bool update(SucursalModel sucursalModel)
        {
            try
            {
                _connection.Execute("UPDATE sucursal SET " +
                                    "direccion = @direccion, " +
                                    "telefono = @telefono, " +
                                    "whatsapp = @whatsapp, " +
                                    "mail = @mail, " +
                                    "estado = @estado " +
                                    "WHERE descripcion = @descripcion", sucursalModel);
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la sucursal", ex);
            }
        }

        public SucursalModel select(int id)
        {
            try
            {
                return _connection.QuerySingleOrDefault<SucursalModel>($"SELECT * FROM sucursal WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar la sucursal", ex);
            }
        }

        public IEnumerable<SucursalModel> list()
        {
            try
            {
                return _connection.Query<SucursalModel>("SELECT * FROM sucursal");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las sucursales", ex);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}