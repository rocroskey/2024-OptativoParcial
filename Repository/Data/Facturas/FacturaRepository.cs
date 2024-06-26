﻿using Dapper;
using Repository.Data.DBConfig;
using System.Data;

namespace Repository.Data.Facturas
{


    public class FacturaRepository
    {
        IDbConnection _connection;

        public FacturaRepository(string connectionString)
        {
            _connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public int add(FacturaModel facturaModel)
        {
            try
            {
                string query = @"
                    INSERT INTO factura(id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal, id_sucursal)
                    VALUES(@id_cliente, @nro_factura, @fecha_hora, @total, @total_iva5, @total_iva10, @total_iva, @total_letras, @sucursal, @id_sucursal)
                    RETURNING id_factura"; // Utiliza RETURNING para obtener el ID generado

                int idFactura = _connection.Query<int>(query, facturaModel).Single();

                return idFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la factura", ex);
            }
        }

        public bool delete(string nro_factura)
        {
            try
            {
                _connection.Execute("DELETE FROM factura WHERE nro_factura = @NroFactura", new { NroFactura = nro_factura });
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
                _connection.Execute("UPDATE factura SET " +
                    "nro_factura = @nro_factura, " +
                    "fecha_hora = @fecha_hora, " +
                    "total = @total, " +
                    "total_iva5 = @total_iva5, " +
                    "total_iva10 = @total_iva10, " +
                    "total_iva = @total_iva, " +
                    "total_letras = @total_letras, " +
                    "sucursal = @sucursal " +
                    "WHERE nro_factura = @nro_factura",facturaModel
                    );
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
                return _connection.QueryFirstOrDefault<FacturaModel>("SELECT * FROM factura WHERE nro_factura = @NroFactura", new { NroFactura = nro_factura });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacturaModel> list()
        {
            try
            {
                return _connection.Query<FacturaModel>("SELECT * FROM factura");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}