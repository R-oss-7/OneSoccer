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
        public String pais { get; set; }
        public int edad { get; set; }
        public String posicion { get; set; }

        public Liga liga { get; set; }
    }
}
