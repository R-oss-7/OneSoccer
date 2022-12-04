using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSoccer.core.Entidades
{
    public class Entrenador
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public String nacionalidad { get; set; }
        public Equipo equipo { get; set; }

    }
}
