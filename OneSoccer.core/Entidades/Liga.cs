using MySql.Data.MySqlClient;
using OneSoccer.core.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OneSoccer.core.Entidades

{
    public class Liga
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String pais { get; set; }
     
        public static List<Liga> GetAll()
        {
            List<Liga> ligas = new List<Liga>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM liga ORDER BY nombre";
                    MySqlCommand command  = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Liga liga = new Liga();
                        liga.id = int.Parse(dataReader["id"].ToString());
                        liga.nombre = dataReader["nombre"].ToString();
                        liga.pais = dataReader["pais"].ToString();
                    

                        ligas.Add(liga);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ligas;
        }


        public static bool Guardar(int id, string nombre, string pais)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();

                    if (id == 0)
                    {
                        cmd.CommandText = "INSERT INTO liga (nombre, pais) VALUES (@nombre, @pais);";

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@pais", pais);
                 
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE liga SET nombre = @nombre, pais = @pais WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@pais", pais);
                       
                    }

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static Liga GetById(int id)
        {
            Liga liga = new Liga();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, pais FROM liga WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        liga.id = int.Parse(dataReader["id"].ToString());
                        liga.nombre = dataReader["nombre"].ToString();
                        liga.pais = dataReader["pais"].ToString();
                       
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return liga;
        }

        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM liga WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }



    }
}
