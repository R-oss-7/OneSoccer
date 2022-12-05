using MySql.Data.MySqlClient;
using OneSoccer.core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSoccer.core.Entidades
{

    public class Estadistica
    {
        public int id { get; set; }
        public Jugador jugador { get; set; }
        public int partidos { get; set; }
        public int MinutosJugados { get; set; }
        public int goles { get; set; }
        public int asistencias { get; set; }
        public int tarjetaAma { get; set; }
        public int tarjetasRojas { get; set; }


        public static List<Estadistica> GetAll()
        {
            List<Estadistica> estadisticas = new List<Estadistica>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT estadistica.id, estadistica.partidos, estadistica.MinutosJugados, estadistica.Goles,estadistica.Asistencias, estadistica.TarjetasAma, estadistica.TarjetasRoj , jugador.id AS idjugador, jugador.nombre, jugador.apellido FROM estadistica INNER JOIN jugador ON estadistica.idjugador = jugador.id WHERE estadistica.id = jugador.id;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();


                    while (dataReader.Read())
                    {
                        Estadistica estadistica = new Estadistica();
                        estadistica.id = int.Parse(dataReader["id"].ToString());
                        estadistica.partidos = int.Parse(dataReader["partidos"].ToString());
                        estadistica.MinutosJugados = int.Parse(dataReader["MinutosJugados"].ToString());
                        estadistica.goles = int.Parse(dataReader["Goles"].ToString());
                        estadistica.asistencias = int.Parse(dataReader["Asistencias"].ToString());
                        estadistica.tarjetaAma = int.Parse(dataReader["TarjetasAma"].ToString());
                        estadistica.tarjetasRojas = int.Parse(dataReader["TarjetasRojas"].ToString());

                        estadisticas.Add(estadistica);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estadisticas;
        }

        public static bool Guardar(int id, int partidos, int minutosJugados, int Goles, int asistencias, int tarjetasAma, int tarjetaRojas)
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
                        cmd.CommandText = "INSERT INTO estadistica (partidos, MinutosJugados, Goles, Asistencias, TarjetaAma, TarjetaRoj) VALUES (@partidos, @MinutosJugados, @Goles, @Asistencias, @TarjetaAma, @TarjetaRoj);";

                        cmd.Parameters.AddWithValue("@partidos", partidos);
                        cmd.Parameters.AddWithValue("@MinutosJugados", minutosJugados);
                        cmd.Parameters.AddWithValue("@Goles", Goles);
                        cmd.Parameters.AddWithValue("@Asistencias", asistencias);
                        cmd.Parameters.AddWithValue("@TarjetaAma", tarjetasAma);
                        cmd.Parameters.AddWithValue("@TarjetaRoj", tarjetaRojas);

                    }
                    else
                    {
                        cmd.CommandText = " UPDATE estadistica partidos = @partidos, MinutosJugados = @MinutosJugados, Goles = @Goles, Asistencias = @Asistencias, TarjetaAma = @TarjetaAma, TarjetaRoj = @TarjetaRoj ";
                        cmd.Parameters.AddWithValue("@partidos", partidos);
                        cmd.Parameters.AddWithValue("@MinutosJugados", minutosJugados);
                        cmd.Parameters.AddWithValue("@Goles", Goles);
                        cmd.Parameters.AddWithValue("@Asistencias", asistencias);
                        cmd.Parameters.AddWithValue("@TarjetaAma", tarjetasAma);
                        cmd.Parameters.AddWithValue("@TarjetaRoj", tarjetaRojas);

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

        public static Estadistica GetById(int id)
        {
            Estadistica estadisticas = new Estadistica();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM estadistica WHERE id = " + id;

                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Estadistica estadistica = new Estadistica();
                        estadistica.id = int.Parse(dataReader["id"].ToString());
                        estadistica.partidos = int.Parse(dataReader["partidos"].ToString());
                        estadistica.MinutosJugados = int.Parse(dataReader["MinutosJugados"].ToString());
                        estadistica.goles = int.Parse(dataReader["Goles"].ToString());
                        estadistica.asistencias = int.Parse(dataReader["Asistencias"].ToString());
                        estadistica.tarjetaAma = int.Parse(dataReader["TarjetasAma"].ToString());
                        estadistica.tarjetasRojas = int.Parse(dataReader["TarjetasRojas"].ToString());
          

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estadisticas;
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
                    cmd.CommandText = "DELETE FROM estadistica WHERE id = @id;";
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


        public static List<Estadistica> EstadisticaByJugador(int id)
        {
            List<Estadistica> estadisticas = new List<Estadistica>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM estadistica WHERE idJugador = " + id ;
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Estadistica estadistica = new Estadistica();
                        estadistica.id = int.Parse(dataReader["id"].ToString());
                        estadistica.partidos = int.Parse(dataReader["partidos"].ToString());
                        estadistica.MinutosJugados = int.Parse(dataReader["MinutosJugados"].ToString());
                        estadistica.goles = int.Parse(dataReader["Goles"].ToString());
                        estadistica.asistencias = int.Parse(dataReader["Asistencias"].ToString());
                        estadistica.tarjetaAma = int.Parse(dataReader["TarjetasAma"].ToString());
                        estadistica.tarjetasRojas = int.Parse(dataReader["TarjetasRoj"].ToString());


                        estadisticas.Add(estadistica);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return estadisticas;

        }


    }








}
