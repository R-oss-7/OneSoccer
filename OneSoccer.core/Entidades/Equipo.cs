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
                        equipo.pais = dataReader["equipo"].ToString();
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

    }
}
