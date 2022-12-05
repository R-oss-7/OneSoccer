using MySql.Data.MySqlClient;
using OneSoccer.core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSoccer.core.Entidades
{
    public class Arbitro
    {
        public int id { get; set; }
        public String nombrecom { get; set; }
        public String nacionalidad { get; set; }
        public int edad { get; set; }
        public String posicion { get; set; }
        public Liga liga { get; set; }


        public static List<Arbitro> GetAll()
        {
            List<Arbitro> arbitros = new List<Arbitro>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM arbitro ORDER BY nombrecom";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Arbitro arbitro = new Arbitro();
                        arbitro.id = int.Parse(dataReader["id"].ToString());
                        arbitro.nombrecom = dataReader["nombrecom"].ToString();
                        arbitro.nacionalidad = dataReader["pais"].ToString();
                        arbitro.edad = int.Parse(dataReader["edad"].ToString());
                        arbitro.posicion = dataReader["posicion"].ToString();
                        arbitro.liga = new Liga();

                        arbitros.Add(arbitro);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return arbitros;
        }


        public static bool Guardar(int id, string nombrecom, string pais, int edad, string posicion, Liga liga)
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
                        cmd.CommandText = "INSERT INTO arbitro (nombre, pais, edad, posiscion, liga) VALUES (@nombre, @pais, @edad, @posicion, @liga);";

                        cmd.Parameters.AddWithValue("@nombre", nombrecom);
                        cmd.Parameters.AddWithValue("@pais", pais);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@posicion", posicion);
                        cmd.Parameters.AddWithValue("@liga", liga);

                    }
                    else
                    {
                        cmd.CommandText = "UPDATE liga SET nombre = @nombre, pais = @pais, edad = @edad, posicion = @posicion, liga = @liga WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombrecom);
                        cmd.Parameters.AddWithValue("@pais", pais);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@posicion", posicion);
                        cmd.Parameters.AddWithValue("@liga", liga);

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

        public static Arbitro GetById(int id)
        {
            Arbitro arbitro = new Arbitro();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, pais, edad, posicion, liga FROM arbitro WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        arbitro.id = int.Parse(dataReader["id"].ToString());
                        arbitro.nombrecom = dataReader["nombrecom"].ToString();
                        arbitro.nacionalidad = dataReader["pais"].ToString();
                        arbitro.edad = int.Parse(dataReader["edad"].ToString());
                        arbitro.posicion = dataReader["posicion"].ToString();
                        arbitro.liga = new Liga();

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return arbitro;
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
                    cmd.CommandText = "DELETE FROM arbitro WHERE id = @id";
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


        public static List<Arbitro> arbitroByLiga(int id)
        {
            List<Arbitro> arbitros = new List<Arbitro>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM arbitro WHERE idLiga = " + id + " ORDER BY nombreCom";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Arbitro arbitro = new Arbitro();
                        arbitro.id = int.Parse(dataReader["id"].ToString());
                        arbitro.nombrecom = dataReader["nombre"].ToString();
                        arbitro.nacionalidad = dataReader["apellido"].ToString();
                        arbitro.posicion = dataReader["posicion"].ToString();
                        arbitro.edad = int.Parse(dataReader["numero"].ToString());
                       


                        arbitros.Add(arbitro);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return arbitros;

        }


    }
}