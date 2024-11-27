using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class FiltroReporteDto
    {
        public long IdClient { get; set; }
        public long IdUser { get; set; }
        public long IdBroker { get; set; }
        public int MesInicio { get; set; }
        public int MesFin { get; set; }
    }
}
