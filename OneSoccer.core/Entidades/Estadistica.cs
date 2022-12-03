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
    public String partidos { get; set; }
    public String minutosJuga { get; set; }
    public String goles { get; set; }
    public String asistencias { get; set; }
    public String tarjetaAma { get; set; }
    public String tarjetasRojas { get; set; }

}
}
