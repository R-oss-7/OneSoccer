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
        String estadio { get; set; }
        public String pais { get; set; }
        public String presidente { get; set; }
        public Liga liga { get; set; }
    }
}
