using MySql.Data.MySqlClient;
using OneSoccer.core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSoccer.core.Entidades
{
    public class Equipo
    {
        public int id { get; set; }
        public String nombre { get; set; }
       public String estadio { get; set; }
        public String pais { get; set; }
        public String presidente { get; set; }
        public String entrenador { get; set; }
        public Liga liga { get; set; }


        public static List<Equipo> EquipoByLiga(int id)
        {
            List<Equipo> equipos = new List<Equipo>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM equipo WHERE idliga = " + id;
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Equipo equipo = new Equipo();
                        equipo.id = int.Parse(dataReader["id"].ToString());
                        equipo.nombre = dataReader["nombre"].ToString();
                        equipo.estadio =dataReader["estadio"].ToString();
                        equipo.pais = dataReader["pais"].ToString();
                        equipo.entrenador = dataReader["entrenador"].ToString();
                        equipo.presidente = dataReader["presidente"].ToString();

                        equipos.Add(equipo);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return equipos;

        }

        public static bool Guardar(int id, string nombre, string estadio, string pais, string entrenador, string presidente)
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
                        cmd.CommandText = "INSERT INTO equipo (nombre, estadio, pais, entrenador, presidente) VALUES (@nombre, @estadio, @pais, @entrenador, @presidente);";

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@estadio", estadio);
                        cmd.Parameters.AddWithValue("@pais", pais);
                        cmd.Parameters.AddWithValue("@entrenador", entrenador);
                        cmd.Parameters.AddWithValue("@presidente", presidente);


                    }
                    else
                    {
                        cmd.CommandText = "UPDATE equipo SET nombre = @nombre, estadio = @estadio, pais = @pais, entrenador = @entrenador, presidente = @presidente WHERE id = @id;";

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@estadio", estadio);
                        cmd.Parameters.AddWithValue("@pais", pais);
                        cmd.Parameters.AddWithValue("@entrenador", entrenador);

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

        public static Equipo GetById(int id)
        {
            Equipo equipo = new Equipo();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, estadio, pais, entrenador, presidente FROM equipo WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        equipo.id = int.Parse(dataReader["id"].ToString());
                        equipo.nombre = dataReader["nombre"].ToString();
                        equipo.estadio = dataReader["estadio"].ToString();
                        equipo.pais = dataReader["pais"].ToString();
                        equipo.entrenador = dataReader["entrenador"].ToString();
                        equipo.presidente = dataReader["presidente"].ToString();



                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return equipo;
        }


    }
}
