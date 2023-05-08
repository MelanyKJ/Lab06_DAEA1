using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entidad;
using System.Security.Cryptography;
using Datos.Datos;

namespace Datos
{
    public class DProducto
    {

        private string connectionString = "Data Source=MACK26;Initial Catalog=lab06; Integrated Security = True;";

        public List<Producto> Listar(string name)
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlCommand command = null;
            List<Producto> products = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_GetProducto", connection);
                command.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = command.ExecuteReader();
                products = new List<Producto>();


                while (reader.Read())
                {

                    Producto Producto = new Producto();
                    Producto.IdProducto = (int)reader["IdProducto"];
                    Producto.Nombre = reader["Nombre"].ToString();
                    Producto.Precio = (decimal)reader["Precio"];
                    Producto.Estado = (bool)reader["Estado"];


                    products.Add(Producto);

                }

                connection.Close();

                //Muestro la información
                return products;


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            {
                connection = null;
                command = null;
                products = null;

            }


        }

        public void Insertar(Producto Producto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("USP_InsertProducto", connection); 
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado                
                    command.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    command.Parameters.AddWithValue("@Precio", Producto.Precio);
                    command.Parameters.AddWithValue("@Estado", Producto.Estado);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Actualizar(Producto Producto)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter param1;
                SqlParameter param2;
                SqlParameter param3;
                SqlParameter param4;

                param1 = new SqlParameter();
                param1.ParameterName = "@IdProducto";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = Producto.IdProducto;

                param2 = new SqlParameter();
                param2.ParameterName = "@nombre";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Value = Producto.IdProducto;

                param3 = new SqlParameter();
                param3.ParameterName = "@precio";
                param3.SqlDbType = SqlDbType.Decimal;
                param3.Value = Producto.Precio;


                param4 = new SqlParameter();
                param4.ParameterName = "@estado";
                param4.SqlDbType = SqlDbType.VarChar;
                param4.Value = Producto.Estado;

                parameters.Add(param1);
                parameters.Add(param2);
                parameters.Add(param3);
                parameters.Add(param4);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_UpdateProducto", CommandType.StoredProcedure, parameters.ToArray());
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
                List<SqlParameter> parameters = new List<SqlParameter>();

                SqlParameter param1;

                param1 = new SqlParameter();
                param1.ParameterName = "@IdProducto";
                param1.SqlDbType = SqlDbType.Int;
                param1.Value = producto.IdProducto;

                parameters.Add(param1);

                SqlHelper.ExecuteNonQuery(connectionString, "USP_DeleteProducto", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }

}

