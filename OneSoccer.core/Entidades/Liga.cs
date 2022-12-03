using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSoccer.core.Entidades
{
    public class Liga
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String pais { get; set; }
        public String duracion { get; set; }
        public Equipo equipo { get; set; }
        public Arbitro arbitro { get; set; }
    }
}
