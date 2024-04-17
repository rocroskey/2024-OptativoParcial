using Npgsql;
using Repository.Data.DBConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Facturas
{


    public class FacturaRepository
    {
        NpgsqlConnection _connection;
        public FacturaRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(FacturaModel facturaModel)
        {
            try
            {
                var cmd = _connection.CreateCommand();
                cmd.CommandText = "INSERT INTO factura(id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) " +
                    $"Values(" +
                    $"'{facturaModel.id_cliente}', " +
                    $"'{facturaModel.nro_factura}', " +
                    $"'{facturaModel.fecha_hora}', " +
                    $"'{facturaModel.total}', " +
                    $"'{facturaModel.total_iva5}', " +
                    $"'{facturaModel.total_iva10}', " +
                    $"'{facturaModel.total_iva}', " +
                    $"'{facturaModel.total_letras}', " +
                    $"'{facturaModel.sucursal}') ";
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(string nro_factura)
        {
            try
            {
                var cmd = _connection.CreateCommand();
                cmd.CommandText = $"DELETE FROM factura WHERE nro_factura ='{nro_factura}' ";
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(FacturaModel facturaModel, string nro_factura)
        {
            try
            {
                var cmd = _connection.CreateCommand();
                cmd.CommandText = "UPDATE factura" +
                    $" SET " +
                    $"nro_factura = '{facturaModel.nro_factura}', " +
                    $"fecha_hora = '{facturaModel.fecha_hora}', " +
                    $"total = '{facturaModel.total}', " +
                    $"total_iva5 = '{facturaModel.total_iva5}', " +
                    $"total_iva10 = '{facturaModel.total_iva10}', " +
                    $"total_iva = '{facturaModel.total_iva}', " +
                    $"total_letras = '{facturaModel.total_letras}', " +
                    $"sucursal = '{facturaModel.sucursal}' " +
                    $"WHERE nro_factura = '{nro_factura}'";
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FacturaModel select(string nro_factura)
        {
            try
            {
                var cmd = _connection.CreateCommand();
                cmd.CommandText = $"SELECT * FROM factura WHERE nro_factura = '{nro_factura}'";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var factura = new FacturaModel
                        {
                            nro_factura = reader.GetString(reader.GetOrdinal("nro_factura")),
                            fecha_hora = reader.GetDateTime(reader.GetOrdinal("fecha_hora")),
                            total = reader.GetDouble(reader.GetOrdinal("total")),
                            total_iva5 = reader.GetDouble(reader.GetOrdinal("total_iva5")),
                            total_iva10 = reader.GetDouble(reader.GetOrdinal("total_iva10")),
                            total_iva = reader.GetDouble(reader.GetOrdinal("total_iva")),
                            total_letras = reader.GetString(reader.GetOrdinal("total_letras")),
                            sucursal = reader.GetString(reader.GetOrdinal("sucursal"))
                        };
                        return factura;
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

        public List<FacturaModel> list()
        {
            try
            {
                var facturas = new List<FacturaModel>();
                var cmd = _connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM factura";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var factura = new FacturaModel
                        {
                            nro_factura = reader.GetString(reader.GetOrdinal("nro_factura")),
                            fecha_hora = reader.GetDateTime(reader.GetOrdinal("fecha_hora")),
                            total = reader.GetDouble(reader.GetOrdinal("total")),
                            total_iva5 = reader.GetDouble(reader.GetOrdinal("total_iva5")),
                            total_iva10 = reader.GetDouble(reader.GetOrdinal("total_iva10")),
                            total_iva = reader.GetDouble(reader.GetOrdinal("total_iva")),
                            total_letras = reader.GetString(reader.GetOrdinal("total_letras")),
                            sucursal = reader.GetString(reader.GetOrdinal("sucursal"))
                        };
                        facturas.Add(factura);
                    }
                }
                return facturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
