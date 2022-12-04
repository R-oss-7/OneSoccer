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

    }
}
