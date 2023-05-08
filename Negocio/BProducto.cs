using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Datos;
using Entidad;



namespace Negocio
{
    public class BProducto
    {
        DProducto datos = new DProducto();

        public List<Producto> Listar(string name)
        {
            var products = datos.Listar(name);
            return products;
        }

        public void Insertar(Producto producto)
        {
            try
            {
                datos.Insertar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar(Producto producto)
        {
            try
            {
                datos.Actualizar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(Producto producto)
        {
            try
            {

                datos.Eliminar(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}