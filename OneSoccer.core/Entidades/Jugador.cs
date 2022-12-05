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
    public class Jugador
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String posicion { get; set; }
        public int numero { get; set; }
        public String nacionalidad { get; set; }
        public int edad { get; set; }
        public Equipo equipo { get; set; }

        public static List<Jugador> GetAll()
        {
            List<Jugador> jugadores = new List<Jugador>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM jugador ORDER BY nombre";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Jugador jugador = new Jugador();
                        jugador.id = int.Parse(dataReader["id"].ToString());
                        jugador.nombre = dataReader["nombre"].ToString();
                        jugador.apellido = dataReader["apellido"].ToString();
                        jugador.posicion = dataReader["posicion"].ToString();
                        jugador.numero = int.Parse(dataReader["numero"].ToString());
                        jugador.nacionalidad = dataReader["nacionalidad"].ToString();
                        jugador.edad = int.Parse(dataReader["edad"].ToString());
                        jugador.equipo = new Equipo();

                        jugadores.Add(jugador);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jugadores;
        }

        public static bool Guardar(int id, string nombre, string apellido, string posicion, int numero, string nacionalidad, int edad, Equipo equipo)
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
                        cmd.CommandText = "INSERT INTO jugador(nombre, apellido, posicion, numero, nacionalidad, edad, equipo) VALUES (@nombre, @apellido, @posicion, @numero, @nacionalidad, @edad, @equipo);";

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@equipo", equipo);

                    }
                    else
                    {
                        cmd.CommandText = " UPDATE jugador nombre = @nombre, apellido = @apellido, posicion = @posicion, numero = @numero, nacionalidad = @nacionalidad, edad = @edad, equipo = @equipo;";

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                        cmd.Parameters.AddWithValue("@edad", edad);
                        cmd.Parameters.AddWithValue("@equipo", equipo);

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

        public static Jugador GetById(int id)
        {
            Jugador jugador = new Jugador();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, apellido, posicion, numero, nacionalidad, edad, equipo FROM liga WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        jugador.id = int.Parse(dataReader["id"].ToString());
                        jugador.nombre = dataReader["nombre"].ToString();
                        jugador.apellido = dataReader["apellido"].ToString();
                        jugador.posicion = dataReader["posicion"].ToString();
                        jugador.numero = int.Parse(dataReader["numero"].ToString());
                        jugador.nacionalidad = dataReader["nacionalidad"].ToString();
                        jugador.edad = int.Parse(dataReader["edad"].ToString());
                        jugador.equipo = new Equipo();

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jugador;
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
                    cmd.CommandText = "DELETE FROM jugador WHERE id = @id;";
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
